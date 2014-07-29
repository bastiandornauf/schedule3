using ComponentFactory.Krypton.Toolkit;
namespace HPSchedule
{
    partial class HPSchedule
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Calendar.DrawTool drawTool1 = new Calendar.DrawTool();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HPSchedule));
            this.dayView = new Calendar.DayView();
            this.einstellungenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allgemeinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.patientenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anlegenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechnungswesenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthCalendar1 = new ComponentFactory.Krypton.Toolkit.KryptonMonthCalendar();
            this.calendarContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.geheZuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.birthdayListbox = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.birthdayListContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmBirthdayListPatientEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.dayviewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.neuerMerkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuerTerminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminKopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminMehrfachKopierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmDeleteNextAppointments = new System.Windows.Forms.ToolStripMenuItem();
            this.patientBearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mmProgram = new System.Windows.Forms.ToolStripMenuItem();
            this.mmProgramInfo = new System.Windows.Forms.ToolStripMenuItem();
            this.mmProgramLogOff = new System.Windows.Forms.ToolStripMenuItem();
            this.mmPatient = new System.Windows.Forms.ToolStripMenuItem();
            this.mmPatientNew = new System.Windows.Forms.ToolStripMenuItem();
            this.mmPatientEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.patientNachNummerSuchenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmStatistics = new System.Windows.Forms.ToolStripMenuItem();
            this.mmAccounting = new System.Windows.Forms.ToolStripMenuItem();
            this.mmRechnungswesenEditItemsAndGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.mmRechnungswesenGenerateSingleInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mmRechnungswesenGenerateInvoices = new System.Windows.Forms.ToolStripMenuItem();
            this.mmRechnungswesenCancelInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.mmSetInvoicesPaid = new System.Windows.Forms.ToolStripMenuItem();
            this.zeigeAbzurechnendeTermineAnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tESTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mmOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.praxisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.datenbankToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.anzeigeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rechnungswesenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabelDayView = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelLoadTime = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusLabelAppointmentCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.bAffirmtAppointments = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.kryptonManager1 = new ComponentFactory.Krypton.Toolkit.KryptonManager(this.components);
            this.bNextWeek = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.bPrevWeek = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.einstellungenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.patientenToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statistikToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.calendarContextMenu.SuspendLayout();
            this.birthdayListContextMenu.SuspendLayout();
            this.dayviewContextMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // dayView
            // 
            drawTool1.DayView = this.dayView;
            this.dayView.ActiveTool = drawTool1;
            this.dayView.AllowInplaceEditing = false;
            this.dayView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dayView.DaysToShow = 7;
            this.dayView.DrawMarks = true;
            this.dayView.DrawMiddayMarks = true;
            this.dayView.EndMiddayMark = 60;
            this.dayView.FirstHourMark = 32;
            this.dayView.FirstWeekday = System.DayOfWeek.Monday;
            this.dayView.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayView.HalfHourHeight = 15;
            this.dayView.LastHourMark = 86;
            this.dayView.Location = new System.Drawing.Point(0, 44);
            this.dayView.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.dayView.Name = "dayView";
            this.dayView.SelectionEnd = new System.DateTime(((long)(0)));
            this.dayView.SelectionStart = new System.DateTime(((long)(0)));
            this.dayView.Size = new System.Drawing.Size(585, 447);
            this.dayView.StartDate = new System.DateTime(((long)(0)));
            this.dayView.StartMiddayMark = 50;
            this.dayView.StartWeekday = false;
            this.dayView.TabIndex = 2;
            this.dayView.Text = "dayView1";
            // 
            // einstellungenToolStripMenuItem
            // 
            this.einstellungenToolStripMenuItem.Name = "einstellungenToolStripMenuItem";
            this.einstellungenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // allgemeinToolStripMenuItem
            // 
            this.allgemeinToolStripMenuItem.Name = "allgemeinToolStripMenuItem";
            this.allgemeinToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // datenbankToolStripMenuItem
            // 
            this.datenbankToolStripMenuItem.Name = "datenbankToolStripMenuItem";
            this.datenbankToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // patientenToolStripMenuItem
            // 
            this.patientenToolStripMenuItem.Name = "patientenToolStripMenuItem";
            this.patientenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // anlegenToolStripMenuItem
            // 
            this.anlegenToolStripMenuItem.Name = "anlegenToolStripMenuItem";
            this.anlegenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // rechnungswesenToolStripMenuItem
            // 
            this.rechnungswesenToolStripMenuItem.Name = "rechnungswesenToolStripMenuItem";
            this.rechnungswesenToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // statistikToolStripMenuItem
            // 
            this.statistikToolStripMenuItem.Name = "statistikToolStripMenuItem";
            this.statistikToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthCalendar1.ContextMenuStrip = this.calendarContextMenu;
            this.monthCalendar1.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.monthCalendar1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.monthCalendar1.Location = new System.Drawing.Point(592, 109);
            this.monthCalendar1.Margin = new System.Windows.Forms.Padding(5);
            this.monthCalendar1.MaxSelectionCount = 1;
            this.monthCalendar1.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.SelectionEnd = new System.DateTime(2009, 3, 24, 0, 0, 0, 0);
            this.monthCalendar1.SelectionStart = new System.DateTime(2009, 3, 24, 0, 0, 0, 0);
            this.monthCalendar1.Size = new System.Drawing.Size(230, 184);
            this.monthCalendar1.TabIndex = 3;
            this.monthCalendar1.TodayDate = new System.DateTime(((long)(0)));
            this.monthCalendar1.TodayFormat = "D";
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged_1);
            // 
            // calendarContextMenu
            // 
            this.calendarContextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.calendarContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.calendarContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.geheZuToolStripMenuItem});
            this.calendarContextMenu.Name = "calendarContextMenu";
            this.calendarContextMenu.Size = new System.Drawing.Size(133, 42);
            // 
            // geheZuToolStripMenuItem
            // 
            this.geheZuToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.calendarMonth;
            this.geheZuToolStripMenuItem.Name = "geheZuToolStripMenuItem";
            this.geheZuToolStripMenuItem.Size = new System.Drawing.Size(132, 38);
            this.geheZuToolStripMenuItem.Text = "Gehe zu";
            this.geheZuToolStripMenuItem.Click += new System.EventHandler(this.geheZuToolStripMenuItem_Click);
            // 
            // birthdayListbox
            // 
            this.birthdayListbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.birthdayListbox.ContextMenuStrip = this.birthdayListContextMenu;
            this.birthdayListbox.FormattingEnabled = true;
            this.birthdayListbox.HorizontalScrollbar = true;
            this.birthdayListbox.Location = new System.Drawing.Point(592, 362);
            this.birthdayListbox.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.birthdayListbox.Name = "birthdayListbox";
            this.birthdayListbox.Size = new System.Drawing.Size(229, 84);
            this.birthdayListbox.TabIndex = 5;
            // 
            // birthdayListContextMenu
            // 
            this.birthdayListContextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.birthdayListContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.birthdayListContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmBirthdayListPatientEdit});
            this.birthdayListContextMenu.Name = "birthdayListContextMenu";
            this.birthdayListContextMenu.Size = new System.Drawing.Size(187, 42);
            // 
            // cmBirthdayListPatientEdit
            // 
            this.cmBirthdayListPatientEdit.Image = global::HPSchedule.Properties.Resources.ContactsFemale;
            this.cmBirthdayListPatientEdit.Name = "cmBirthdayListPatientEdit";
            this.cmBirthdayListPatientEdit.Size = new System.Drawing.Size(186, 38);
            this.cmBirthdayListPatientEdit.Text = "Patient bearbeiten";
            this.cmBirthdayListPatientEdit.Click += new System.EventHandler(this.cmBirthdayListPatientEdit_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(592, 338);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 4;
            this.label1.Values.Text = "Geburtstage";
            // 
            // dayviewContextMenu
            // 
            this.dayviewContextMenu.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dayviewContextMenu.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dayviewContextMenu.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.dayviewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuerMerkerToolStripMenuItem,
            this.neuerTerminToolStripMenuItem,
            this.terminBearbeitenToolStripMenuItem,
            this.terminKopierenToolStripMenuItem,
            this.terminMehrfachKopierenToolStripMenuItem,
            this.terminLöschenToolStripMenuItem,
            this.mmDeleteNextAppointments,
            this.patientBearbeitenToolStripMenuItem});
            this.dayviewContextMenu.Name = "dayviewContextMenu";
            this.dayviewContextMenu.Size = new System.Drawing.Size(232, 308);
            // 
            // neuerMerkerToolStripMenuItem
            // 
            this.neuerMerkerToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Notes;
            this.neuerMerkerToolStripMenuItem.Name = "neuerMerkerToolStripMenuItem";
            this.neuerMerkerToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.neuerMerkerToolStripMenuItem.Text = "Neuer Merker";
            this.neuerMerkerToolStripMenuItem.Click += new System.EventHandler(this.neuerMerkerToolStripMenuItem_Click);
            // 
            // neuerTerminToolStripMenuItem
            // 
            this.neuerTerminToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.NewDoc;
            this.neuerTerminToolStripMenuItem.Name = "neuerTerminToolStripMenuItem";
            this.neuerTerminToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.neuerTerminToolStripMenuItem.Text = "Neuer Termin";
            this.neuerTerminToolStripMenuItem.Click += new System.EventHandler(this.neuerTerminToolStripMenuItem_Click);
            // 
            // terminBearbeitenToolStripMenuItem
            // 
            this.terminBearbeitenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Write;
            this.terminBearbeitenToolStripMenuItem.Name = "terminBearbeitenToolStripMenuItem";
            this.terminBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.terminBearbeitenToolStripMenuItem.Text = "Termin bearbeiten";
            this.terminBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.terminBearbeitenToolStripMenuItem_Click);
            // 
            // terminKopierenToolStripMenuItem
            // 
            this.terminKopierenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Copy;
            this.terminKopierenToolStripMenuItem.Name = "terminKopierenToolStripMenuItem";
            this.terminKopierenToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.terminKopierenToolStripMenuItem.Text = "Termin kopieren";
            this.terminKopierenToolStripMenuItem.Click += new System.EventHandler(this.terminKopierenToolStripMenuItem_Click);
            // 
            // terminMehrfachKopierenToolStripMenuItem
            // 
            this.terminMehrfachKopierenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Clipboard;
            this.terminMehrfachKopierenToolStripMenuItem.Name = "terminMehrfachKopierenToolStripMenuItem";
            this.terminMehrfachKopierenToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.terminMehrfachKopierenToolStripMenuItem.Text = "Termin mehrfach kopieren";
            this.terminMehrfachKopierenToolStripMenuItem.Click += new System.EventHandler(this.terminMehrfachKopierenToolStripMenuItem_Click);
            // 
            // terminLöschenToolStripMenuItem
            // 
            this.terminLöschenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.Delete;
            this.terminLöschenToolStripMenuItem.Name = "terminLöschenToolStripMenuItem";
            this.terminLöschenToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.terminLöschenToolStripMenuItem.Text = "Termin löschen";
            this.terminLöschenToolStripMenuItem.Click += new System.EventHandler(this.terminLöschenToolStripMenuItem_Click);
            // 
            // mmDeleteNextAppointments
            // 
            this.mmDeleteNextAppointments.Image = global::HPSchedule.Properties.Resources.DeleteMulti;
            this.mmDeleteNextAppointments.Name = "mmDeleteNextAppointments";
            this.mmDeleteNextAppointments.Size = new System.Drawing.Size(231, 38);
            this.mmDeleteNextAppointments.Text = "Weitere Termine löschen";
            this.mmDeleteNextAppointments.Click += new System.EventHandler(this.mmDeleteNextAppointments_Click);
            // 
            // patientBearbeitenToolStripMenuItem
            // 
            this.patientBearbeitenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.ContactsFemale;
            this.patientBearbeitenToolStripMenuItem.Name = "patientBearbeitenToolStripMenuItem";
            this.patientBearbeitenToolStripMenuItem.Size = new System.Drawing.Size(231, 38);
            this.patientBearbeitenToolStripMenuItem.Text = "Patient bearbeiten";
            this.patientBearbeitenToolStripMenuItem.Click += new System.EventHandler(this.patientBearbeitenToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmProgram,
            this.mmPatient,
            this.mmStatistics,
            this.mmAccounting,
            this.mmOptions});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(832, 40);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mmProgram
            // 
            this.mmProgram.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmProgramInfo,
            this.mmProgramLogOff});
            this.mmProgram.Image = global::HPSchedule.Properties.Resources.doctor;
            this.mmProgram.Name = "mmProgram";
            this.mmProgram.Size = new System.Drawing.Size(108, 36);
            this.mmProgram.Text = "Programm";
            // 
            // mmProgramInfo
            // 
            this.mmProgramInfo.Image = global::HPSchedule.Properties.Resources.Help;
            this.mmProgramInfo.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.mmProgramInfo.Name = "mmProgramInfo";
            this.mmProgramInfo.Size = new System.Drawing.Size(196, 38);
            this.mmProgramInfo.Text = "Info";
            this.mmProgramInfo.Click += new System.EventHandler(this.mmProgramInfo_Click);
            // 
            // mmProgramLogOff
            // 
            this.mmProgramLogOff.Image = global::HPSchedule.Properties.Resources.LogOff;
            this.mmProgramLogOff.Name = "mmProgramLogOff";
            this.mmProgramLogOff.Size = new System.Drawing.Size(196, 38);
            this.mmProgramLogOff.Text = "Programm beenden";
            this.mmProgramLogOff.Click += new System.EventHandler(this.mmLogOff_Click);
            // 
            // mmPatient
            // 
            this.mmPatient.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmPatientNew,
            this.mmPatientEdit,
            this.patientNachNummerSuchenToolStripMenuItem});
            this.mmPatient.Image = global::HPSchedule.Properties.Resources.Users;
            this.mmPatient.Name = "mmPatient";
            this.mmPatient.Size = new System.Drawing.Size(119, 36);
            this.mmPatient.Text = "Stammdaten";
            // 
            // mmPatientNew
            // 
            this.mmPatientNew.Image = global::HPSchedule.Properties.Resources.UserAdd;
            this.mmPatientNew.Name = "mmPatientNew";
            this.mmPatientNew.Size = new System.Drawing.Size(248, 38);
            this.mmPatientNew.Text = "Neuen Patient anlegen";
            this.mmPatientNew.Click += new System.EventHandler(this.mmPatientNew_Click);
            // 
            // mmPatientEdit
            // 
            this.mmPatientEdit.Image = global::HPSchedule.Properties.Resources.ContactsFemale;
            this.mmPatientEdit.Name = "mmPatientEdit";
            this.mmPatientEdit.Size = new System.Drawing.Size(248, 38);
            this.mmPatientEdit.Text = "Patient bearbeiten";
            this.mmPatientEdit.Click += new System.EventHandler(this.mmPatientEdit_Click);
            // 
            // patientNachNummerSuchenToolStripMenuItem
            // 
            this.patientNachNummerSuchenToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.search2;
            this.patientNachNummerSuchenToolStripMenuItem.Name = "patientNachNummerSuchenToolStripMenuItem";
            this.patientNachNummerSuchenToolStripMenuItem.Size = new System.Drawing.Size(248, 38);
            this.patientNachNummerSuchenToolStripMenuItem.Text = "Patient nach Nummer suchen";
            this.patientNachNummerSuchenToolStripMenuItem.Click += new System.EventHandler(this.patientNachNummerSuchenToolStripMenuItem_Click);
            // 
            // mmStatistics
            // 
            this.mmStatistics.Enabled = false;
            this.mmStatistics.Image = global::HPSchedule.Properties.Resources.Table;
            this.mmStatistics.Name = "mmStatistics";
            this.mmStatistics.Size = new System.Drawing.Size(92, 36);
            this.mmStatistics.Text = "Statistik";
            // 
            // mmAccounting
            // 
            this.mmAccounting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mmRechnungswesenEditItemsAndGroups,
            this.mmRechnungswesenGenerateSingleInvoice,
            this.mmRechnungswesenGenerateInvoices,
            this.mmRechnungswesenCancelInvoice,
            this.mmSetInvoicesPaid,
            this.zeigeAbzurechnendeTermineAnToolStripMenuItem,
            this.tESTToolStripMenuItem});
            this.mmAccounting.Image = global::HPSchedule.Properties.Resources.ComposeEmail;
            this.mmAccounting.Name = "mmAccounting";
            this.mmAccounting.Size = new System.Drawing.Size(143, 36);
            this.mmAccounting.Text = "Rechnungswesen";
            // 
            // mmRechnungswesenEditItemsAndGroups
            // 
            this.mmRechnungswesenEditItemsAndGroups.Image = global::HPSchedule.Properties.Resources.Write;
            this.mmRechnungswesenEditItemsAndGroups.Name = "mmRechnungswesenEditItemsAndGroups";
            this.mmRechnungswesenEditItemsAndGroups.Size = new System.Drawing.Size(292, 38);
            this.mmRechnungswesenEditItemsAndGroups.Text = "Artikel und Gruppen verwalten";
            this.mmRechnungswesenEditItemsAndGroups.Click += new System.EventHandler(this.mmRechnungswesenEditItemsAndGroups_Click);
            // 
            // mmRechnungswesenGenerateSingleInvoice
            // 
            this.mmRechnungswesenGenerateSingleInvoice.Enabled = false;
            this.mmRechnungswesenGenerateSingleInvoice.Image = global::HPSchedule.Properties.Resources.PrinterLetter;
            this.mmRechnungswesenGenerateSingleInvoice.Name = "mmRechnungswesenGenerateSingleInvoice";
            this.mmRechnungswesenGenerateSingleInvoice.Size = new System.Drawing.Size(292, 38);
            this.mmRechnungswesenGenerateSingleInvoice.Text = "einzelne Rechnung erstellen";
            // 
            // mmRechnungswesenGenerateInvoices
            // 
            this.mmRechnungswesenGenerateInvoices.Enabled = false;
            this.mmRechnungswesenGenerateInvoices.Image = global::HPSchedule.Properties.Resources.PrinterLetter;
            this.mmRechnungswesenGenerateInvoices.Name = "mmRechnungswesenGenerateInvoices";
            this.mmRechnungswesenGenerateInvoices.Size = new System.Drawing.Size(292, 38);
            this.mmRechnungswesenGenerateInvoices.Text = "automatisch Rechnungen erstellen";
            // 
            // mmRechnungswesenCancelInvoice
            // 
            this.mmRechnungswesenCancelInvoice.Enabled = false;
            this.mmRechnungswesenCancelInvoice.Image = global::HPSchedule.Properties.Resources.Bad;
            this.mmRechnungswesenCancelInvoice.Name = "mmRechnungswesenCancelInvoice";
            this.mmRechnungswesenCancelInvoice.Size = new System.Drawing.Size(292, 38);
            this.mmRechnungswesenCancelInvoice.Text = "Rechnung stornieren";
            // 
            // mmSetInvoicesPaid
            // 
            this.mmSetInvoicesPaid.Enabled = false;
            this.mmSetInvoicesPaid.Image = global::HPSchedule.Properties.Resources.Good;
            this.mmSetInvoicesPaid.Name = "mmSetInvoicesPaid";
            this.mmSetInvoicesPaid.Size = new System.Drawing.Size(292, 38);
            this.mmSetInvoicesPaid.Text = "Zahlungseingänge registrieren";
            // 
            // zeigeAbzurechnendeTermineAnToolStripMenuItem
            // 
            this.zeigeAbzurechnendeTermineAnToolStripMenuItem.Name = "zeigeAbzurechnendeTermineAnToolStripMenuItem";
            this.zeigeAbzurechnendeTermineAnToolStripMenuItem.Size = new System.Drawing.Size(292, 38);
            this.zeigeAbzurechnendeTermineAnToolStripMenuItem.Text = "Zeige abzurechnende Termine an";
            this.zeigeAbzurechnendeTermineAnToolStripMenuItem.Click += new System.EventHandler(this.zeigeAbzurechnendeTermineAnToolStripMenuItem_Click);
            // 
            // tESTToolStripMenuItem
            // 
            this.tESTToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.letter_5_32;
            this.tESTToolStripMenuItem.Name = "tESTToolStripMenuItem";
            this.tESTToolStripMenuItem.Size = new System.Drawing.Size(292, 38);
            this.tESTToolStripMenuItem.Text = "Automatischer Rechnungsdruck (WIP)";
            this.tESTToolStripMenuItem.Click += new System.EventHandler(this.tESTToolStripMenuItem_Click);
            // 
            // mmOptions
            // 
            this.mmOptions.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.praxisToolStripMenuItem,
            this.datenbankToolStripMenuItem1,
            this.anzeigeToolStripMenuItem});
            this.mmOptions.Image = global::HPSchedule.Properties.Resources.config4;
            this.mmOptions.Name = "mmOptions";
            this.mmOptions.Size = new System.Drawing.Size(122, 36);
            this.mmOptions.Text = "Einstellungen";
            // 
            // praxisToolStripMenuItem
            // 
            this.praxisToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.home;
            this.praxisToolStripMenuItem.Name = "praxisToolStripMenuItem";
            this.praxisToolStripMenuItem.Size = new System.Drawing.Size(147, 38);
            this.praxisToolStripMenuItem.Text = "Praxis";
            this.praxisToolStripMenuItem.Click += new System.EventHandler(this.praxisToolStripMenuItem_Click);
            // 
            // datenbankToolStripMenuItem1
            // 
            this.datenbankToolStripMenuItem1.Image = global::HPSchedule.Properties.Resources.InternetConnections;
            this.datenbankToolStripMenuItem1.Name = "datenbankToolStripMenuItem1";
            this.datenbankToolStripMenuItem1.Size = new System.Drawing.Size(147, 38);
            this.datenbankToolStripMenuItem1.Text = "Datenbank";
            this.datenbankToolStripMenuItem1.Click += new System.EventHandler(this.datenbankToolStripMenuItem1_Click);
            // 
            // anzeigeToolStripMenuItem
            // 
            this.anzeigeToolStripMenuItem.Image = global::HPSchedule.Properties.Resources.desktop;
            this.anzeigeToolStripMenuItem.Name = "anzeigeToolStripMenuItem";
            this.anzeigeToolStripMenuItem.Size = new System.Drawing.Size(147, 38);
            this.anzeigeToolStripMenuItem.Text = "Anzeige";
            this.anzeigeToolStripMenuItem.Click += new System.EventHandler(this.anzeigeToolStripMenuItem_Click);
            // 
            // rechnungswesenToolStripMenuItem1
            // 
            this.rechnungswesenToolStripMenuItem1.Name = "rechnungswesenToolStripMenuItem1";
            this.rechnungswesenToolStripMenuItem1.Size = new System.Drawing.Size(103, 36);
            this.rechnungswesenToolStripMenuItem1.Text = "Rechnungswesen";
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabelDayView,
            this.statusLabelLoadTime,
            this.statusLabelAppointmentCount});
            this.statusStrip.Location = new System.Drawing.Point(0, 493);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(832, 24);
            this.statusStrip.TabIndex = 8;
            this.statusStrip.Text = "statusStrip1";
            // 
            // statusLabelDayView
            // 
            this.statusLabelDayView.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelDayView.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusLabelDayView.Name = "statusLabelDayView";
            this.statusLabelDayView.Size = new System.Drawing.Size(630, 19);
            this.statusLabelDayView.Spring = true;
            this.statusLabelDayView.Text = "[dayview-entry]";
            this.statusLabelDayView.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // statusLabelLoadTime
            // 
            this.statusLabelLoadTime.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelLoadTime.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusLabelLoadTime.Name = "statusLabelLoadTime";
            this.statusLabelLoadTime.Size = new System.Drawing.Size(66, 19);
            this.statusLabelLoadTime.Text = "[loadtime]";
            // 
            // statusLabelAppointmentCount
            // 
            this.statusLabelAppointmentCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.statusLabelAppointmentCount.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.statusLabelAppointmentCount.Name = "statusLabelAppointmentCount";
            this.statusLabelAppointmentCount.Size = new System.Drawing.Size(121, 19);
            this.statusLabelAppointmentCount.Text = "[appointmentCount]";
            this.statusLabelAppointmentCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // bAffirmtAppointments
            // 
            this.bAffirmtAppointments.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bAffirmtAppointments.Location = new System.Drawing.Point(592, 453);
            this.bAffirmtAppointments.Name = "bAffirmtAppointments";
            this.bAffirmtAppointments.Size = new System.Drawing.Size(230, 32);
            this.bAffirmtAppointments.StateCommon.Back.ImageAlign = ComponentFactory.Krypton.Toolkit.PaletteRectangleAlign.Control;
            this.bAffirmtAppointments.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.TopLeft;
            this.bAffirmtAppointments.TabIndex = 11;
            this.bAffirmtAppointments.Values.Text = "Termine bestätigen";
            this.bAffirmtAppointments.Click += new System.EventHandler(this.bAffirmtAppointments_Click);
            // 
            // bNextWeek
            // 
            this.bNextWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bNextWeek.BackgroundImage = global::HPSchedule.Properties.Resources.arrowRight16;
            this.bNextWeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bNextWeek.Location = new System.Drawing.Point(717, 44);
            this.bNextWeek.Name = "bNextWeek";
            this.bNextWeek.Size = new System.Drawing.Size(105, 57);
            this.bNextWeek.StateCommon.Back.Image = global::HPSchedule.Properties.Resources.arrowRight16;
            this.bNextWeek.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.bNextWeek.StateCommon.Content.LongText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.bNextWeek.StateCommon.Content.LongText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.bNextWeek.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.bNextWeek.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.bNextWeek.TabIndex = 10;
            this.bNextWeek.Values.ExtraText = "weiter";
            this.bNextWeek.Values.Text = "Woche";
            this.bNextWeek.Click += new System.EventHandler(this.bNextWeek_Click);
            // 
            // bPrevWeek
            // 
            this.bPrevWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bPrevWeek.BackgroundImage = global::HPSchedule.Properties.Resources.arrowLeft16;
            this.bPrevWeek.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.bPrevWeek.Location = new System.Drawing.Point(592, 44);
            this.bPrevWeek.Name = "bPrevWeek";
            this.bPrevWeek.Size = new System.Drawing.Size(105, 57);
            this.bPrevWeek.StateCommon.Back.Image = global::HPSchedule.Properties.Resources.arrowLeft16;
            this.bPrevWeek.StateCommon.Back.ImageStyle = ComponentFactory.Krypton.Toolkit.PaletteImageStyle.CenterMiddle;
            this.bPrevWeek.StateCommon.Content.ShortText.TextH = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Center;
            this.bPrevWeek.StateCommon.Content.ShortText.TextV = ComponentFactory.Krypton.Toolkit.PaletteRelativeAlign.Near;
            this.bPrevWeek.TabIndex = 9;
            this.bPrevWeek.UseMnemonic = false;
            this.bPrevWeek.Values.ExtraText = "zurück";
            this.bPrevWeek.Values.Text = "Woche";
            this.bPrevWeek.Click += new System.EventHandler(this.bPrevWeek_Click);
            // 
            // einstellungenToolStripMenuItem1
            // 
            this.einstellungenToolStripMenuItem1.Image = global::HPSchedule.Properties.Resources.config4;
            this.einstellungenToolStripMenuItem1.Name = "einstellungenToolStripMenuItem1";
            this.einstellungenToolStripMenuItem1.Size = new System.Drawing.Size(114, 36);
            this.einstellungenToolStripMenuItem1.Text = "Einstellungen";
            // 
            // patientenToolStripMenuItem1
            // 
            this.patientenToolStripMenuItem1.Image = global::HPSchedule.Properties.Resources.Users;
            this.patientenToolStripMenuItem1.Name = "patientenToolStripMenuItem1";
            this.patientenToolStripMenuItem1.Size = new System.Drawing.Size(97, 36);
            this.patientenToolStripMenuItem1.Text = "Patienten";
            // 
            // statistikToolStripMenuItem1
            // 
            this.statistikToolStripMenuItem1.Image = global::HPSchedule.Properties.Resources.Table;
            this.statistikToolStripMenuItem1.Name = "statistikToolStripMenuItem1";
            this.statistikToolStripMenuItem1.Size = new System.Drawing.Size(89, 36);
            this.statistikToolStripMenuItem1.Text = "Statistik";
            // 
            // HPSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 517);
            this.Controls.Add(this.birthdayListbox);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dayView);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.bAffirmtAppointments);
            this.Controls.Add(this.bNextWeek);
            this.Controls.Add(this.bPrevWeek);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 4, 2, 4);
            this.MinimumSize = new System.Drawing.Size(640, 480);
            this.Name = "HPSchedule";
            this.Text = "Schedule 3";
            this.Load += new System.EventHandler(this.HPSchedule_Load);
            this.calendarContextMenu.ResumeLayout(false);
            this.birthdayListContextMenu.ResumeLayout(false);
            this.dayviewContextMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private KryptonMonthCalendar monthCalendar1;
        private Calendar.DayView dayView;
        private KryptonListBox birthdayListbox;
        private KryptonLabel label1;
        private System.Windows.Forms.ContextMenuStrip dayviewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem neuerMerkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuerTerminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminKopierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminLöschenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminMehrfachKopierenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem allgemeinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenbankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anlegenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rechnungswesenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statistikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem patientBearbeitenToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem einstellungenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem patientenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rechnungswesenToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem statistikToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mmOptions;
        private System.Windows.Forms.ToolStripMenuItem mmPatient;
        private System.Windows.Forms.ToolStripMenuItem mmAccounting;
        private System.Windows.Forms.ToolStripMenuItem mmStatistics;
        private System.Windows.Forms.ToolStripMenuItem praxisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem datenbankToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem anzeigeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmPatientNew;
        private System.Windows.Forms.ToolStripMenuItem mmPatientEdit;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelDayView;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelLoadTime;
        private System.Windows.Forms.ToolStripStatusLabel statusLabelAppointmentCount;
        private System.Windows.Forms.ContextMenuStrip birthdayListContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmBirthdayListPatientEdit;
        private System.Windows.Forms.ToolStripMenuItem mmDeleteNextAppointments;
        private System.Windows.Forms.ToolStripMenuItem patientNachNummerSuchenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmRechnungswesenEditItemsAndGroups;
        private System.Windows.Forms.ToolStripMenuItem mmRechnungswesenGenerateSingleInvoice;
        private System.Windows.Forms.ToolStripMenuItem mmRechnungswesenGenerateInvoices;
        private System.Windows.Forms.ToolStripMenuItem mmRechnungswesenCancelInvoice;
        private System.Windows.Forms.ToolStripMenuItem mmSetInvoicesPaid;
        private System.Windows.Forms.ToolStripMenuItem mmProgram;
        private System.Windows.Forms.ToolStripMenuItem mmProgramLogOff;
        private KryptonButton bPrevWeek;
        private KryptonButton bNextWeek;
        private System.Windows.Forms.ToolStripMenuItem terminBearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mmProgramInfo;
        private KryptonButton bAffirmtAppointments;
        private ComponentFactory.Krypton.Toolkit.KryptonManager kryptonManager1;
        private System.Windows.Forms.ToolStripMenuItem zeigeAbzurechnendeTermineAnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tESTToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip calendarContextMenu;
        private System.Windows.Forms.ToolStripMenuItem geheZuToolStripMenuItem;
    }
}

