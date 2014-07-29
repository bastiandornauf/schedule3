#define TIME// Ladezeit-Analyse für Kalenderseiten durchführen
//#define TIME2// Ladezeit-Analyse für Betsätigungsseite durchführen

#if TIME2
      #warning TIME2 is defined
#endif


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace HPSchedule
{
    public partial class HPSchedule : ComponentFactory.Krypton.Toolkit.KryptonForm
    {
        modus dayviewMode = modus.nil;
        Calendar.DVAppointment appointmentClipboard;
        bool connectedToDatabase = true;
        bool ctrlPressed = false;
        bool shiftPressed = false;
        Properties.Settings settings;
        List<PatientNameAndId> geburtstagskinder;

        private List<Appointment> dayviewAppointments;

        public HPSchedule()
        {
            InitializeComponent();
            settings = new Properties.Settings();

            
            // my Components
            InitializeCalendar();
            InitializeBirthdayBox();
            InitializeControls();
            InitializeBackgroundWorker();

#if TIME
#else
            statusLabelLoadTime.Text = "";
#endif
        }


        private void StartWaiting()
        {
            //Cursor.Current = Cursors.WaitCursor;
            //this.Cursor = Cursors.WaitCursor;
            this.UseWaitCursor = true;
        }
        private void EndWaiting()
        {
            //Cursor.Current = Cursors.Default;
            this.UseWaitCursor = false;
        }

        private void InitializeControls()
        {
            monthCalendar1.TodayDate = DateTime.Now;
            monthCalendar1.DateChanged += new DateRangeEventHandler(monthCalendar1_DateChanged);

            birthdayListbox.MouseDown += new MouseEventHandler(birthdayListbox_MouseDown);
            
            dayView.MouseWheel += new MouseEventHandler(dayView_MouseWheel);

            dayView.KeyDown += new KeyEventHandler(dayView_KeyDown);
            dayView.KeyUp += new KeyEventHandler(dayView_KeyUp);
            
            this.FormClosing += new FormClosingEventHandler(HPSchedule_FormClosing);
            monthCalendar1.SelectionStart = DateTime.Now;
        }

        void dayView_KeyUp(object sender, KeyEventArgs e)
        {
            ctrlPressed = false;
            shiftPressed = false;
        }

        void dayView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
                ctrlPressed = true;
            if (e.Shift)
                shiftPressed = true;
        }

        void dayView_MouseWheel(object sender, MouseEventArgs e)
        {
            
            if ( ctrlPressed )
            {
                int value = shiftPressed ? 28 : 7;
                value *= e.Delta > 0 ? -1 : 1;
                
                monthCalendar1.SelectionStart = monthCalendar1.SelectionStart.AddDays(value);
                UpdateAppointmentList();
            }                 
        }

        void HPSchedule_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveChangesInAppointmentList();
        }

        void birthdayListbox_MouseDown(object sender, MouseEventArgs e)
        {
            if (birthdayListbox.SelectedIndex >= 0)
            { 
                cmBirthdayListPatientEdit.Enabled = true;
            }
            else
            {
                cmBirthdayListPatientEdit.Enabled = false;
            }
        }

        private void InitializeBirthdayBox()
        {
            if (!connectedToDatabase)
                return;

            birthdayListbox.Items.Clear();

            geburtstagskinder = new List<PatientNameAndId>();

            DoDatabaseMagic.GetBirthdayPeople(ref geburtstagskinder);
            foreach (PatientNameAndId s in geburtstagskinder)
                    birthdayListbox.Items.Add(s.CompleteName);
        }

        private void InitializeCalendar()
        {
            dayviewAppointments = new List<Appointment>();

            dayView.DaysToShow = settings.showDaysInDayview;
            dayView.HalfHourHeight = settings.KalendarZeilenhöhe;


            //dayView.WorkingHourStart = 7;
            
            dayView.FirstWeekday = DayOfWeek.Monday;
            dayView.StartWeekday = true;
            dayView.StartDate = DateTime.Now;

            dayView.ResetScrollbar();

            dayView.userCursor = Cursors.Default;
            dayView.AllowInplaceEditing = true;

            dayView.ResolveAppointments += new Calendar.ResolveAppointmentsEventHandler(dayView_ResolveAppointments);
            dayView.NewAppointment += new Calendar.NewAppointmentEventHandler(dayView_NewAppointment);
            
            dayView.MouseMove += new MouseEventHandler(dayView_MouseMove);
            dayView.MouseDown += new MouseEventHandler(dayView_MouseDown);
            dayView.MouseDoubleClick += new MouseEventHandler(dayView_MouseDoubleClick);
            
            UpdateAppointmentList();          
        }

        private void UpdateDayView() {
            // Wie erzwinge ich neuzeichnen??
            //InitializeCalendar();

            //dayView.HalfHourHeight = settings.KalendarZeilenhöhe;
            dayView.DaysToShow = settings.showDaysInDayview;
            //dayView.Reset();
            UpdateAppointmentList();
        }

        private void HandleErrorWithDatabase(Exception e)
        {
            connectedToDatabase = false;
            MessageBox.Show("Es kann keine Verbindung zur lokalen Datenbank aufgebaut werden.\r\n" +
                            "Stellen Sie sicher, daß die Verbindungsdaten korrekt eingestellt\r\n" +
                            "wurden und der Datenbank-Service läuft.\r\n\r\n" +
                            e.Message,
                            "Schwerer Fehler",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
            
            LockMenu(true);
        }

        private void LockMenu(bool engageLock)
        {
            mmProgram.Enabled = ! engageLock;
            mmPatient.Enabled = ! engageLock;
            //mmStatistics.Enabled = ! engageLock;
            mmStatistics.Enabled = false; // TODO Statistics-Menü ist dauerhaft gesperrt
            mmAccounting.Enabled = ! engageLock;

            bNextWeek.Enabled = !engageLock;
            bPrevWeek.Enabled = !engageLock;

            bAffirmtAppointments.Enabled = !engageLock;
        }
                
        void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (!connectedToDatabase)
            {
                monthCalendar1.SelectionStart = monthCalendar1.TodayDate;
                return;
            }
            
            dayView.StartDate = monthCalendar1.SelectionStart;        

            UpdateAppointmentList();
            dayView.Update();
                
        }

        void dayView_MouseDown(object sender, MouseEventArgs e)
        {
            if (!connectedToDatabase)
                return;


            // wenn normaler Modus// wenn rechter Button
            // zeige Kontext-Menü an
            if (dayviewMode == modus.nil &&  e.Button == MouseButtons.Right)
            {
                // auswahl setzen wie bei mausclick links
                if (e.Button == MouseButtons.Right)
                {
                    MouseEventArgs fakeClick = new MouseEventArgs(MouseButtons.Left, 1, e.X, e.Y, e.Delta);
                    dayView.ForceClick(fakeClick);
                } 
                
                if (dayView.GetAppointmentAt(e.X, e.Y) != null)
                {
                    
                    // über einem Termin
                    if (dayView.GetAppointmentAt(e.X, e.Y).isTreatment)
                    {
                        terminKopierenToolStripMenuItem.Text = "Termin kopieren";
                        terminMehrfachKopierenToolStripMenuItem.Text = "Termin mehrfach kopieren";
                        terminLöschenToolStripMenuItem.Text = "Termin löschen";

                        patientBearbeitenToolStripMenuItem.Visible = true;
                        terminBearbeitenToolStripMenuItem.Visible = true;
                        mmDeleteNextAppointments.Visible = true;
                    }
                    else
                    {
                        //bzw. Merker
                        terminKopierenToolStripMenuItem.Text = "Merker kopieren";
                        terminMehrfachKopierenToolStripMenuItem.Text = "Merker mehrfach kopieren";
                        terminLöschenToolStripMenuItem.Text = "Merker löschen";
                        terminBearbeitenToolStripMenuItem.Visible = false;
                        patientBearbeitenToolStripMenuItem.Visible = false;
                        mmDeleteNextAppointments.Visible = false;
                    }
                    // zeige entsprechende Menü-Items
                    neuerMerkerToolStripMenuItem.Visible = false;
                    neuerTerminToolStripMenuItem.Visible = false;
                    terminKopierenToolStripMenuItem.Visible = true;
                    terminLöschenToolStripMenuItem.Visible = true;
                    terminMehrfachKopierenToolStripMenuItem.Visible = true;

                    dayviewContextMenu.Show(dayView, e.X, e.Y);                
                } else if( dayView.Selection == Calendar.SelectionType.DateRange )
                {
                    // nicht über einem Eintrag
                    // aber mit einer Auswahl
                    if (dayView.SelectionStart != DateTime.MinValue)
                    {
                        neuerMerkerToolStripMenuItem.Visible = true;
                        neuerTerminToolStripMenuItem.Visible = true;
                        terminKopierenToolStripMenuItem.Visible = false;
                        terminLöschenToolStripMenuItem.Visible = false;
                        terminMehrfachKopierenToolStripMenuItem.Visible = false;
                        terminBearbeitenToolStripMenuItem.Visible = false;
                        patientBearbeitenToolStripMenuItem.Visible = false;
                        mmDeleteNextAppointments.Visible = false;

                        dayviewContextMenu.Show(dayView, e.X, e.Y);
                    }
                }

                
            }
            // wenn Kopie-Modus
            if ((dayviewMode == modus.copy || dayviewMode == modus.multicopy )&& e.Button == MouseButtons.Right)
            {
                // Abbruch
                appointmentClipboard = null;
                dayviewMode = modus.nil;
                dayView.userCursor = Cursors.Default;
                dayView.Cursor = Cursors.Default; // Handzuweisung, da das Control nicht rechtzeitig den Cursorstate ändert
            }
            if ((dayviewMode == modus.copy || dayviewMode == modus.multicopy) && e.Button == MouseButtons.Left)
            {
                // Termin hier einfügen
                // Länge des Termins wird über Ticks berechnet
                TimeSpan length = TimeSpan.FromTicks(appointmentClipboard.EndDate.Ticks - appointmentClipboard.StartDate.Ticks);
                Appointment ap = new Appointment( appointmentClipboard );

                ap.StartDate = dayView.SelectionStart;                
                ap.EndDate = ap.StartDate.Add(length);

                DoDatabaseMagic.NewAppointment(ap);

                UpdateAppointmentList();
                dayView.Invalidate();

                if (dayviewMode == modus.copy)
                {
                    appointmentClipboard = null;
                    dayviewMode = modus.nil;
                    dayView.userCursor = Cursors.Default;
                    dayView.Cursor = Cursors.Default; // Handzuweisung, da das Control nicht rechtzeitig den Cursorstate ändert
                }
            }

        }

        void dayView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            // Neuen Merker setzen
            if (e.Button == MouseButtons.Left)
            {
                NeuerMerker();
            }
        }

        void dayView_MouseMove(object sender, MouseEventArgs e)
        {
            DateTime d = dayView.GetTimeAt(e.X, e.Y);
            statusLabelDayView.Text = d.ToString();

            if (dayviewMode == modus.nil)
            {
                Calendar.DVAppointment a = dayView.GetAppointmentAt(e.X, e.Y);
                if (a != null)
                {
                    statusLabelDayView.Text += ": " + a.Title.Replace('\n', '|').Replace('\r', ' ');
                }
            }
            else if (dayviewMode == modus.copy || dayviewMode == modus.multicopy)
            {
                statusLabelDayView.Text += ": " + "Kopiere " + (appointmentClipboard.isTreatment?"Termin":"Merker");
            }
        }     

        void dayView_NewAppointment(object sender, Calendar.NewAppointmentEventArgs args)
        {
            /* the dayView component calls this method if a new merker is entered
             */

            if (!connectedToDatabase)
                return;
         
            Appointment a = new Appointment();

            a.StartDate = args.StartDate;
            a.EndDate = args.EndDate;
            a.Title = args.Title;
            a.IsTreatment = false;

            DoDatabaseMagic.NewAppointment(a);

            UpdateAppointmentList();
            dayView.Invalidate();

        }

        void dayView_ResolveAppointments(object sender, Calendar.ResolveAppointmentsEventArgs args)
        {
            foreach (Appointment a in dayviewAppointments)
            {
                // BListe simulieren                
                if (!a.Occured)
                {
                    if (a.StartDate < DateTime.Now)
                        a.TextColor = Color.Gray;
                    else
                        a.TextColor = Color.Black;
                }

                if (a.IsModified)
                  SaveChangesInAppointmentList();
                
                args.Appointments.Add(a);
            }
        }

        void UpdateAppointmentList()
        {
            bool errorEncountered = false;
#if TIME
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

            sw.Start();//TODO Zeitmessung entfernen
#endif            
            if (dayviewAppointments.Exists(matchModified))
                SaveChangesInAppointmentList();
            try
            {
                DoDatabaseMagic.GetAppointments(ref dayviewAppointments, dayView.StartDate, dayView.StartDate.AddDays(dayView.DaysToShow));
                connectedToDatabase = true;
                LockMenu(false);
            }
            catch (Exception e)
            {
                HandleErrorWithDatabase(e);                
                errorEncountered = true;
            }
            finally
            {
#if TIME
                sw.Stop();
#endif
            }
            if (!errorEncountered)
            {
#if TIME
                statusLabelLoadTime.Text = "loading data in " + sw.ElapsedMilliseconds.ToString() + " ms";
#endif
                int count = 0;
                foreach (Appointment a in dayviewAppointments)
                    if (a.IsTreatment)
                        count++;

                statusLabelAppointmentCount.Text = string.Format("{0} Behandlung / {1} Merker", count, dayviewAppointments.Count - count);
            }
            else
            {
                statusLabelLoadTime.Text = "Datenbank-Fehler!";
                statusLabelAppointmentCount.Text = "";
            }
        }

        
        void SaveChangesInAppointmentList()
        {
            if( connectedToDatabase )
                foreach (Appointment ap in dayviewAppointments)
                    if (ap.IsModified)
                        DoDatabaseMagic.UpdateAppointment(ap);
        }        

        bool matchModified(Appointment a)
        {
            return a.IsModified;
        }

        void NeuerMerker()
        {
            if (!connectedToDatabase)
                return;

            Appointment a = new Appointment();

            a.StartDate = dayView.SelectionStart;
            a.EndDate = dayView.SelectionEnd;
            a.Title = "Merker";
            a.IsTreatment = false;

            DoDatabaseMagic.NewAppointment(a);

            UpdateAppointmentList();
            dayView.Invalidate();
        }

        void NeuerTermin()
        {
            if (!connectedToDatabase)
                return;

            Appointment a = new Appointment();
            a.StartDate = dayView.SelectionStart;
            a.EndDate = dayView.SelectionEnd;
            a.IsTreatment = true;

            Dialoge.TreatmentEditor dlg = new global::HPSchedule.Dialoge.TreatmentEditor(a);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Datenobjekte.Treatment t = dlg.Result;
                if (t != null)
                {
                    DoDatabaseMagic.NewTreatment(a, t);
                    UpdateAppointmentList();
                    dayView.Invalidate();
                }
            }
        }


        private void neuerMerkerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeuerMerker();
        }

        private void terminLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Menü verstecken
            dayviewContextMenu.Hide();
            
            Calendar.DVAppointment deleteMe = dayView.SelectedAppointment;
            if (deleteMe == null)
                return;
            // gute Warn-Nachricht zusammenbauen ...
            string typus;
            if( deleteMe.isTreatment )
                typus = "Termin";
            else
                typus = "Merker";

            string msg = String.Format("Der {0} '{1}' wird unwiderruflich gelöscht.{2}Sind Sie sich sicher?",
                typus,
                deleteMe.Title.Trim(),
                Environment.NewLine);

            // Sicherheitsabfrage
            if (MessageBox.Show(msg, "Vorsicht", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Benutzer ist sicher, also löschen...
                DeleteAppointment(deleteMe.Id);
            }
        }

        private void DeleteAppointment(long appointmentId)
        {
            if (!connectedToDatabase)
                return;
            
            DoDatabaseMagic.DeleteAppointment(appointmentId);

            UpdateAppointmentList();
            dayView.Invalidate();
        }

        private void terminKopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.DVAppointment copyMe = dayView.SelectedAppointment;
            
            appointmentClipboard = copyMe;
            dayviewMode = modus.copy;
            dayView.userCursor = Cursors.UpArrow;
        }

        private void terminMehrfachKopierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Calendar.DVAppointment copyMe = dayView.SelectedAppointment;

            appointmentClipboard = copyMe;
            dayviewMode = modus.multicopy;
            dayView.userCursor = Cursors.UpArrow;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }

        private void HPSchedule_Load(object sender, EventArgs e)
        {
            //Application.Idle += new EventHandler(Application_Idle);
        }

        void Application_Idle(object sender, EventArgs e)
        {
        }


        private void patientBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!connectedToDatabase)
                return;
            
            long pid = DoDatabaseMagic.GetPatientIdFromAppointment(dayView.SelectedAppointment.Id);
            if (pid > 0)
            {
                // wenn eindeutig / Auswahl getroffen
                Patient p = DoDatabaseMagic.LadePatient(pid);
                // Editor aufrufen
                PatientEditor formEditor = new PatientEditor(p);
                if (formEditor.ShowDialog() == DialogResult.OK)
                {
                    // wenn ok, dann in DB speichern
                    DoDatabaseMagic.UpdatePatient(p);
                    UpdateAppointmentList();
                    InitializeBirthdayBox();
                }
            }

        }

        private void mmPatientNew_Click(object sender, EventArgs e)
        {
            if (!connectedToDatabase)
                return;

            // neuenPatient anlegen
            Patient p = new Patient();
            // Editor aufrufen
            using (PatientEditor editor = new PatientEditor(p))
            {
                
                if (editor.ShowDialog() == DialogResult.OK)
                {
                    DoDatabaseMagic.CreateNewPatient(p);
                    InitializeBirthdayBox();
                }
                // wenn ok, dann in DB speichern
            }
        }

        private void mmPatientEdit_Click(object sender, EventArgs e)
        {
            if (!connectedToDatabase)
                return;

            // Patient suchen
            SuchePatientForm form = new SuchePatientForm();
            if (form.ShowDialog() == DialogResult.OK)
            {
                // wenn nicht eindeutig
                if (form.Result != -1)
                {
                    // wenn eindeutig / Auswahl getroffen
                    Patient p = DoDatabaseMagic.LadePatient(form.Result);
                    // Editor aufrufen
                    PatientEditor formEditor = new PatientEditor(p);
                    if (formEditor.ShowDialog() == DialogResult.OK)
                    {
                        // wenn ok, dann in DB speichern
                        DoDatabaseMagic.UpdatePatient(p);
                        UpdateAppointmentList();
                        InitializeBirthdayBox();
                    }
                }
            }
        }

        private void cmBirthdayListPatientEdit_Click(object sender, EventArgs e)
        {
            if (!connectedToDatabase)
                return;

            if (birthdayListbox.SelectedIndex >= 0)
            {
                  // wenn eindeutig / Auswahl getroffen
                    Patient p = DoDatabaseMagic.LadePatient( geburtstagskinder[birthdayListbox.SelectedIndex].Id);
                    // Editor aufrufen
                    PatientEditor formEditor = new PatientEditor(p);
                    if (formEditor.ShowDialog() == DialogResult.OK)
                    {
                        // wenn ok, dann in DB speichern
                        DoDatabaseMagic.UpdatePatient(p);
                        UpdateAppointmentList();
                        InitializeBirthdayBox();
                    }
            }
        }

        private void mmDeleteNextAppointments_Click(object sender, EventArgs e)
        {
            // Menü verstecken
            dayviewContextMenu.Hide();

            Calendar.DVAppointment deleteMe = dayView.SelectedAppointment;


            string msg = String.Format("Alle weiteren Termine  von '{0}' werden unwiederuflich gelöscht.{1}Sind Sie sich sicher?",
                deleteMe.Title,
                Environment.NewLine);

            // Sicherheitsabfrage
            if (MessageBox.Show(msg, "Vorsicht", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                // Benutzer ist sicher, also löschen...
                int deleted = DeleteNextAppointments(deleteMe.Id, deleteMe.StartDate);
                msg = String.Format("Es wurden {0} Termine gelöscht.", deleted);
                MessageBox.Show(msg, "Weitere Termine löschen");
            }
        }

        private int DeleteNextAppointments(long p, DateTime d)
        {
            if (!connectedToDatabase)
                return 0;

            
            int count = DoDatabaseMagic.DeleteNextAppointments(p, d);

            UpdateAppointmentList();
            dayView.Invalidate();

            return count;
        }

        private void patientNachNummerSuchenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!connectedToDatabase)
                return;

            AskNumericForm dialog = new AskNumericForm();
            dialog.Label = "Geben Sie die Patientennummer ein.";
            dialog.Title = "Suche Patient";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Patient p = DoDatabaseMagic.LadePatient(dialog.Result);
                // Editor aufrufen
                if (p != null)
                {
                    PatientEditor formEditor = new PatientEditor(p);
                    if (formEditor.ShowDialog() == DialogResult.OK)
                    {
                        // wenn ok, dann in DB speichern
                        DoDatabaseMagic.UpdatePatient(p);
                        UpdateAppointmentList();
                        InitializeBirthdayBox();
                    }
                }
                else
                {
                    string msg = String.Format("Ein Patient mit der Nummer {0} ist nicht bekannt.", dialog.Result);
                    MessageBox.Show(msg, "Suche Patient");
                }
            }
        }

        private void mmRechnungswesenEditItemsAndGroups_Click(object sender, EventArgs e)
        {
            InvoiceGroupAndItemEditor editor = new InvoiceGroupAndItemEditor();
            editor.ShowDialog();
        }

        private void mmLogOff_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bPrevWeek_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = monthCalendar1.SelectionStart.AddDays(-7);
        }

        private void bNextWeek_Click(object sender, EventArgs e)
        {
            monthCalendar1.SelectionStart = monthCalendar1.SelectionStart.AddDays(7);
        }

        private void neuerTerminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NeuerTermin();
        }

        private void praxisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallOptions(global::HPSchedule.Dialoge.OptionEntry.Praxis);
        }

        private void datenbankToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CallOptions(global::HPSchedule.Dialoge.OptionEntry.Datenbank);
        }

        private void CallOptions(Dialoge.OptionEntry choice)
        {
            Dialoge.OptionenEditor editor = new Dialoge.OptionenEditor(choice);

            editor.ShowDialog();
            settings.Reload();
            UpdateDayView();
            UpdateAppointmentList();
        }

        private void anzeigeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CallOptions(global::HPSchedule.Dialoge.OptionEntry.Anzeige);
        }

        private void terminBearbeitenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!connectedToDatabase)
                return;
            // Bestehenden Termin berarbeiten!!
            Calendar.DVAppointment ap = dayView.SelectedAppointment;
            Appointment appointment = new Appointment(ap);
            Datenobjekte.Treatment alteredTreatment;

            alteredTreatment = DoDatabaseMagic.GetTreatment(ap.Id);

            Dialoge.TreatmentEditor dlg = new global::HPSchedule.Dialoge.TreatmentEditor(appointment, alteredTreatment);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Datenobjekte.Treatment t = dlg.Result;
                if (t != null)
                {
                    DoDatabaseMagic.AlterTreatment(appointment, t);
                    UpdateAppointmentList();
                    dayView.Invalidate();
                }
            }
        }

        private void mmProgramInfo_Click(object sender, EventArgs e)
        {
            // Zeige AboutDlg an
            Dialoge.AboutForm dlg = new global::HPSchedule.Dialoge.AboutForm();
            dlg.Show();
        }

        private void zeigeAbzurechnendeTermineAnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuchePatientForm form = new SuchePatientForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                // wenn nicht eindeutig
                if (form.Patient != -1)
                {
                    StartWaiting();
                    Dialoge.ShowAppointmentsToInvoice dlg = new global::HPSchedule.Dialoge.ShowAppointmentsToInvoice(form.Patient);
                    dlg.Show();
                    EndWaiting();
                }
            }
        }


        List<Datenobjekte.AffirmationAwaitingAppointment> appointmentList;
        private void bAffirmtAppointments_Click(object sender, EventArgs e)
        {
            StartWaiting();
            // starte Worker der die Termine von der Datenbank einsammelt
            // Dialog wird per Callback aufgerufen
            
            // Doppelclick abfangen...
            if( ! workerAffirmAppointments.IsBusy )
                workerAffirmAppointments.RunWorkerAsync();

        }

        BackgroundWorker workerAffirmAppointments;

        #region BackgroundWorker

        private void InitializeBackgroundWorker()
        {
            // Backgroundworker zu anzeige der zu bestätigenden Termine
            workerAffirmAppointments = new BackgroundWorker();
            workerAffirmAppointments.WorkerSupportsCancellation = false;
            workerAffirmAppointments.WorkerReportsProgress = false;

            workerAffirmAppointments.DoWork += new DoWorkEventHandler(workerAffirmAppointments_DoWork);
            workerAffirmAppointments.RunWorkerCompleted += new RunWorkerCompletedEventHandler(workerAffirmAppointments_RunWorkerCompleted);
        }

#if TIME2
        System.Diagnostics.Stopwatch swApp = new System.Diagnostics.Stopwatch();
#endif
        void workerAffirmAppointments_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
#if TIME2
            swApp.Stop();
            MessageBox.Show(String.Format("Zu bestätigende Termine wurden in {0}ms ermittelt.",
                swApp.ElapsedMilliseconds.ToString()));
#endif
            EndWaiting();
            if (appointmentList.Count > 0)
                using (Dialoge.AffirmApointmentsForm dialog = new Dialoge.AffirmApointmentsForm(appointmentList))
                {

                    dialog.ShowDialog();

                    UpdateDayView();

                    // Todo: vielleicht nicht-modal?? gut oder schlecht??
                    // dann UpdateDayView per CallBack-Funktion?
                }
            else
                MessageBox.Show("Es liegen keine zu bestätigenden Termine vor.");

            appointmentList.Clear();
        }

        void workerAffirmAppointments_DoWork(object sender, DoWorkEventArgs e)
        {
#if TIME2
            swApp.Reset();
            swApp.Start();
#endif

            BackgroundWorker worker = sender as BackgroundWorker;
            appointmentList = DoDatabaseMagic.GetAppointmentsWaitingForAffirmation();
        }

        #endregion

        private void tESTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Dialoge.TestRechnungsdruck dlg = new global::HPSchedule.Dialoge.TestRechnungsdruck();
            Dialoge.InvoicePrintingDlg dlg = new global::HPSchedule.Dialoge.InvoicePrintingDlg();
            dlg.ShowDialog();
        }

        private void geheZuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dialoge.AskDateTime dlg = new Dialoge.AskDateTime();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                monthCalendar1.SelectionStart = dlg.Value;
                UpdateAppointmentList();
            }
        }

        private void monthCalendar1_DateChanged_1(object sender, DateRangeEventArgs e)
        {
            UpdateAppointmentList();
        }

    }

    enum modus { nil, copy, multicopy };
}