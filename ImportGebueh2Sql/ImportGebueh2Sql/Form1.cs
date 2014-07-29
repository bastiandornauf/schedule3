using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


using System.IO;

namespace ImportGebueh2Sql
{
    public partial class Form1 : Form
    {
        #region Dialog-related code
        private bool[] fileSelected;
        private bool doneOnce;
        private string[] fileName;
        List<TreatmentFingerprint> bListe;
        

        List<Abrechnungsart> abrechnungsarten;
        List<Eintrag> einträge;
        List<Gruppe> gruppen;

        List<Patient> patienten;
        List<Termin> terminliste;

        LogFile log;

        const int COMPONENT_COUNT = 3;
        const string NOT_SELECTED = "not selected";
        
        public Form1()
        {
            bListe = new List<TreatmentFingerprint>();
            InitializeComponent();

            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);

            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            
            labelFilename.Text = NOT_SELECTED;
            labelResult.Text = "<not done a thing>";

            doneOnce = false;
            fileSelected = new bool[COMPONENT_COUNT];
            fileName = new string[COMPONENT_COUNT];

            for( int iter = 0; iter<COMPONENT_COUNT; iter++)
            {
                fileSelected[iter] = false;
                fileName[iter] = NOT_SELECTED;
            }

            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);

            progressBar.Value = 0;
            progressBar.Minimum = 0;
            progressBar.Maximum = 100;
            progressBar.Step = 1;

            openFileDialog1.Filter = "Textdatei|*.txt";

            abrechnungsarten = new List<Abrechnungsart>();
            einträge = new List<Eintrag>();
            gruppen = new List<Gruppe>();
            patienten = new List<Patient>();
            terminliste = new List<Termin>();

            logpath = Path.Combine(Environment.CurrentDirectory, "logfile.txt");
            log = new LogFile(logpath);
        }
        string logpath;
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            labelResult.Text = "Export beendet.";
            log.Msg("Export fertig.");
            cancelButton.Visible = false;
            cancelButton.Enabled = false;
            bDoIt.Enabled = true;
            doneOnce = true;
        
            // open log file
            System.Diagnostics.Process.Start("notepad", logpath);

        }

        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            labelResult.Text = e.UserState as string;
            progressBar.Value = e.ProgressPercentage;   
        }

        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            ExportGebuehToDatabase(sender as BackgroundWorker);
            ExportTermineToDatabase(sender as BackgroundWorker);
            ExportStammdatenToDatabase(sender as BackgroundWorker);            
        }
        

        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fileSelected = false;
            bool allFiles = true;
            foreach (bool b in fileSelected)
            {
                allFiles &= b;
            }
            if (allFiles)
                labelResult.Text = "All Files selected, ready to go!";
            else
                labelResult.Text = "Not all Files selected";

            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < COMPONENT_COUNT)
            {
                labelFilename.Text = Path.GetFileName(fileName[comboBox1.SelectedIndex]);
            }
            else
                labelFilename.Text = "";

            progressBar.Value = 0;
        }

        private void bFileSelect_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < COMPONENT_COUNT) {
                    
                    fileName[comboBox1.SelectedIndex] = openFileDialog1.FileName;
                    fileSelected[comboBox1.SelectedIndex] = true;

                    labelFilename.Text = Path.GetFileName(fileName[comboBox1.SelectedIndex]);
                }
                else
                    labelFilename.Text = "";
            }
            else
            {
                if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < COMPONENT_COUNT)
                    labelFilename.Text = Path.GetFileName(fileName[comboBox1.SelectedIndex]);
                else
                    labelFilename.Text = "";
            }
            bool allFiles = true;
            foreach (bool b in fileSelected)
            {
                allFiles &= b;
            }
            if (allFiles)
                labelResult.Text = "All Files selected, ready to go!";
            else
                labelResult.Text = "Not all Files selected";


        }

        private void bDoIt_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex >= 0 && comboBox1.SelectedIndex < COMPONENT_COUNT)
            {
                bool success = true;
                bool allFiles = true;
                foreach (bool b in fileSelected)
                    allFiles &= b;

                int index = comboBox1.SelectedIndex;
                if (doneOnce)
                {
                    labelResult.Text = "Es darf nur ein Import durchgeführt werden.";
                }
                else
                    if (allFiles)
                    {
                        log.Msg("Beginne GebüH-Import.");
                        success = ImportGebueh();
                        log.Msg("Beginne Termine-Import.");
                        success = ImportTermine();
                        log.Msg("Beginne Stammdaten-Import.");
                        success = ImportStammdaten();
                        log.Msg("Import fertig.");
                        // -------------------------------------
                        progressBar.Maximum = 100;
                        cancelButton.Visible = true;
                        cancelButton.Enabled = true;
                        bDoIt.Enabled = false;
                        log.Msg("Beginn Export.");
                        backgroundWorker1.RunWorkerAsync();
                        labelResult.Text = "Exporting ...";
                    }
                if (success)
                {
                    //labelResult.Text = "done!";
                    doneOnce = true;
                }
            }
        }
        
        void Form1_Load(object sender, EventArgs e)
        {

        }

        #endregion

        #region Import
        public bool ImportGebueh()
        {
            StreamReader sr = new StreamReader(fileName[0], Encoding.GetEncoding(1252));
            //Encoding.UTF8);
            string line;
            int mode = 0;
            // Datencontainer 
            short aarten;
            string[] splittedLine;

            progressBar.Maximum = 7;
            labelResult.Text = "Importing GebüH ...";

            this.Refresh();
            line = sr.ReadLine();

                if (line != "*START_GEBUEH*")
                {
                    MessageBox.Show("Falsches Dateiformat!");
                    labelResult.Text = "Es ist ein Fehler aufgetreten.";
                    return false;
                }
                else
                {
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {        
                            if (line.StartsWith("*START"))
                            {
                                mode++;
                                progressBar.PerformStep();
                            }
                            else if (line.StartsWith("*END"))
                            { }
                            else
                            {
                                if (mode == 1)
                                {
                                    mode++;
                                }
                                if (mode == 2)
                                { // ABRECHNUNGSARTEN
                                    if (Int16.TryParse(line, out aarten))
                                    {
                                        progressBar.PerformStep();
                                        mode++;
                                    }
                                }
                                
                                else if (mode == 3)
                                {
                                    Abrechnungsart aart = new Abrechnungsart();
                                    aart.label = line.Trim();
                                    abrechnungsarten.Add(aart);
                                }
                                else if (mode == 4) // EINTRAEGE_ANZAHL
                                {
                                    mode++;
                                    progressBar.PerformStep();
                                }
                                else if (mode == 5) // EINTRAGE
                                {
                                    if (line.StartsWith("*"))
                                        if (line == "*START_GRUPPEN*")
                                            mode++;
                                        else { }
                                    else
                                    {
                                        Eintrag neuerEintrag = new Eintrag();
                                        #region parse_einträge
                                        // parse line
                                        splittedLine = line.Split('#');
                                        //CNummer
                                        string[] cNummer;
                                        cNummer = splittedLine[0].Split('.');
                                        try { neuerEintrag.n.punkt = Int32.Parse(cNummer[0]); }
                                        catch { neuerEintrag.n.punkt = 0; }
                                        try { neuerEintrag.n.unterpunkt = Int32.Parse(cNummer[1]); }
                                        catch { neuerEintrag.n.unterpunkt = 0; }
                                        try { neuerEintrag.n.variante = Int32.Parse(cNummer[2]); }
                                        catch { neuerEintrag.n.variante = 0; }
                                        //Beschreibung
                                        neuerEintrag.description = splittedLine[1];
                                        //Beträge
                                        string[] beträge;
                                        beträge = splittedLine[2].Split('/');
                                        if (beträge.GetLength(0) >= 0)
                                        {
                                            double value; string t;
                                            foreach (string s in beträge)
                                            {
                                                char[] zeichen = { ' ', 'E', 'U', 'R' };
                                                t = s.Substring(0, s.Length - 4);
                                                try
                                                {
                                                    value = Double.Parse(t);
                                                }
                                                catch
                                                {
                                                    value = 0.0;
                                                }
                                                neuerEintrag.preise.Add(value);
                                            }
                                        }
                                        #endregion
                                        einträge.Add(neuerEintrag);
                                    }
                                }
                                else if (mode == 6) // GRUPPEN_ANZAHL
                                {
                                    mode++;
                                    progressBar.PerformStep();
                                }
                                else if (mode == 7) // GRUPPEN
                                {
                                    Gruppe neueGruppe = new Gruppe();
                                    // parse line
                                    #region parse_gruppen
                                    splittedLine = line.Split('#');
                                    neueGruppe.ident = splittedLine[0].Trim();
                                    neueGruppe.label = splittedLine[1].Trim();
                                    string[] artikel = splittedLine[2].Split(';');
                                    foreach (string n in artikel)
                                    {
                                        neueGruppe.artikel.Add(new Nummer(n));
                                    }

                                    //MessageBox.Show(neueGruppe.label);
                                    #endregion
                                    gruppen.Add(neueGruppe);
                                }
                            }

                        }
                    } while (line != null);
                    return true;
                }
        }

        public bool ImportStammdaten()
        {
            StreamReader sr = new StreamReader(fileName[2], Encoding.GetEncoding(1252));
            // Datencontainer 
            string line;
            List<string> infile = new List<string>();
            labelResult.Text = "Importing Stammdaten ...";
            this.Refresh();
            // hol die Datei ein
            
            line = sr.ReadLine();
            if (line != "*START_PATIENTENLISTE*")
                {
                    MessageBox.Show("Falsches Dateiformat!");
                    labelResult.Text = "Es ist ein Fehler aufgetreten.";
                    return false;
                }
                else
                {
                    infile.Add(line);
                    do
                    {
                        line = sr.ReadLine();
                        if (line != null)
                        {
                            infile.Add(line);
                        }
                    } while (line != null);
                    progressBar.Maximum = infile.Count;

                    bool pblattLoaded = false;
                    bool termineLoaded = false;
                    List<string> pb_lines = new List<string>();
                    List<string> t_lines = new List<string>();
                    int mode = 0;
                    foreach (string s in infile)
                    {
                        progressBar.PerformStep();
                        //MessageBox.Show(s + Environment.NewLine + String.Format("Mode: {0}", mode)); 
                        switch (mode)
                        {

                            case 0:// suche nach Anfang
                                if (s == "*START_PATIENTENBLATT*")
                                {
                                    mode = 1;
                                }
                                break;
                            case 1:// scanne PBlatt
                                if (s == "*END_PATIENTENBLATT*")
                                {
                                    pblattLoaded = true;
                                    mode = 0;
                                }
                                else if (s == "*START_TERMINE*")
                                {
                                    mode = 2;
                                }
                                else
                                {
                                    pb_lines.Add(s);
                                }
                                break;
                            case 2:// scanne Termine
                                if (s == "*END_TERMINE*")
                                {
                                    termineLoaded = true;
                                    mode = 1;
                                }
                                else
                                    t_lines.Add(s);
                                break;
                        }
                        if (termineLoaded && pblattLoaded)
                        {
                            patienten.Add(ImportPatientenblatt(pb_lines, t_lines));
                            pb_lines.Clear();
                            t_lines.Clear();
                            termineLoaded = false;
                            pblattLoaded = false;
                        }
                    }
                    //MessageBox.Show( patienten.Count.ToString());
                    return true;
                }
        }
    
        private Patient ImportPatientenblatt(List<string> pLines,List<string> tLines)
        {
            Patient patient = new Patient();
            string[] splitter;


            // ID
            patient.id = Int32.Parse(pLines[0]);
            // NAME
            splitter = pLines[1].Split('/');
            if (splitter.GetLength(0) != 3)
            {
                throw new Exception("Name eines Patienten hat nicht 3 Elemente!");
            }
            else
            {
                patient.title = splitter[0];
                patient.firstname = splitter[1];
                patient.lastname = splitter[2];
            }
            // Geschlecht
            patient.male = (pLines[2] == "M" ? true : false);
            // Adresse
            patient.address.street = pLines[3];
            patient.address.additionlInfo = pLines[20];
            patient.address.postcode = pLines[4];
            patient.address.place = pLines[5];
            patient.address.country = "";
            // Kontakte
            if (pLines[6] != "")
                patient.contacts.Add(new Contacts(pLines[6], (pLines[7] == "") ? "Telefon 1" : pLines[7]));
            if (pLines[8] != "")
                patient.contacts.Add(new Contacts(pLines[8], (pLines[9] == "") ? "Telefon 2" : pLines[9]));
            if (pLines[10] != "")
                patient.contacts.Add(new Contacts(pLines[10], (pLines[11] == "") ? "Fax" : pLines[11]));
            if (pLines[18] != "")
                patient.contacts.Add(new Contacts(pLines[18], "eMail"));
            //Geburtstag
            patient.dateofBirth = DateTime.Parse(pLines[12]);
            // Job
            patient.occupation = pLines[13];
            //Zahlungsweise
            patient.methodOfPayment = Int32.Parse(pLines[14]);
            // Notizen
            patient.comments = ReplaceSpecialChars(pLines[15]);
            // Diagnose
            patient.diagnosis = pLines[16];
            // Abrechnungsart
            patient.insurance = pLines[17];// beim Export wird die ID dazu ermittelt            
            // Bemerkungen
            patient.publicComments = ReplaceSpecialChars(pLines[21]);

            foreach (string termin in tLines)
            {
                Termin t = ImportTermine( termin );
                t.merkerFlag = 0; // hier alles Behandlungen, keine Merker!!
                patient.termine.Add( t );
            }

            return patient;
        }

        private string ReplaceSpecialChars(string p)
        {
            return p.Replace("\\n", "\n").
                     Replace("\\r", "\r").
                     Replace("\"", "\\\"").
                     Replace("\'", "\\'");
        }

        private Termin ImportTermine(string termin)
        {
            Termin neuerTermin = new Termin();
            string[] splittedTermin = termin.Split('#');

            neuerTermin.patientId = Int32.Parse(splittedTermin[0]);
            neuerTermin.SetDates( Int32.Parse( splittedTermin[1]) );
            neuerTermin.behandlung = splittedTermin[2];
            neuerTermin.diagnose = splittedTermin[3];
            neuerTermin.status = Int32.Parse( splittedTermin[4] );
            neuerTermin.merkerFlag = Int32.Parse( splittedTermin[5] );

            return neuerTermin;
        }            

        private bool  ImportTermine()
        {
            labelResult.Text = "Importing Termine ...";
            this.Refresh();

            StreamReader sr = new StreamReader(fileName[1], Encoding.GetEncoding(1252));
            // Datencontainer 
            List<string> infile = new List<string>();            
            string line = sr.ReadLine();
            if (line != "*START_BLISTE*")
                {
                    MessageBox.Show("Falsches Dateiformat!");
                    labelResult.Text = "Es ist ein Fehler aufgetreten.";
                    return false;
                }
                else
                {
                    do
                    {
                        line = sr.ReadLine();
                        if ( line != null )
                            if (!line.StartsWith("*"))
                                infile.Add(line);
                    } while (line != null);
                    progressBar.Maximum = infile.Count;
                    // Einlesen von infile in Datenstruktur
                    foreach (string s in infile)
                    {
                        Termin t = ImportTermine( s );
                        terminliste.Add(t);
                        progressBar.PerformStep();
                    }
                    return true;
                }
        }

        #endregion

        
        #region ExportToSQL
        /*
        private void CreateADefaultHealer()
        {
            SqlHelper db = new SqlHelper(log);

            db.Insert("healer", "name", "'Default'");
            defaultHealer = db.GetId("healer");
        }
        private void ExportGebuehToDatabase(BackgroundWorker worker)
        {
            string userState = "Exporting GebüH ...";
            
            int totalElements = abrechnungsarten.Count + einträge.Count + gruppen.Count;
            int steps = 0;

            SqlHelper mySql = new SqlHelper(log);
            // ---------------- Abrechnungsarten -------------------
            foreach (Abrechnungsart aart in abrechnungsarten)
            {
                // füge hinzu
                if (mySql.Insert("insurance", "label", SqlHelper.QuoteMarks(aart.label)) > 0)
                {
                    // vergebene id ermitteln
                    aart.id = mySql.GetId("insurance");
                    steps++;
                    worker.ReportProgress((int)(100 * steps / totalElements), userState);
                }
                
                //this.Refresh();
            }
            // ---------------- Artikel ---------------------------
            foreach (Eintrag eintrag in einträge)
            {
                // wenn min. 1 Zeile erzeugt wurde
                if (mySql.Insert("invoiceitem", "description, tariffMain, tariffSub",
                    SqlHelper.QuoteMarks(eintrag.description) + ", " + eintrag.n.punkt + ", " + eintrag.n.unterpunkt) > 0)
                {
                    // trage die erzeugt ID nach
                    eintrag.id = mySql.GetId("invoiceitem");

                    int insuranceIndex = 1;
                    foreach (double preis in eintrag.preise)
                    {
                        mySql.Insert("fee", "invoiceitemid, insuranceid, fee", String.Format("{0}, {1}, {2}",
                            eintrag.id,
                            insuranceIndex,
                            preis.ToString().Replace(',','.')
                        ));
                        insuranceIndex++;
                    }

                    
                }
                steps++;
                worker.ReportProgress((int)(100 * steps / totalElements));
            }
            // ---------------- Gruppen ---------------------------
            foreach( Gruppe gruppe in gruppen ) 
            {
                if (mySql.Insert("invoicegroup", "label", SqlHelper.QuoteMarks(gruppe.label)) > 0)
                {
                    gruppe.id = mySql.GetId("invoicegroup");
                    //MessageBox.Show(gruppe.label);
                    foreach (Nummer n in gruppe.artikel)
                    {

                        if (n != null)
                        {
                            if (n.CompareTo(new Nummer("0.0")) != 0)
                            {
                            
                                //int artikelId = mySql.GetId("invoiceitem");
                                int artikelId = -1;
                                foreach (Eintrag e in einträge)
                                {
                                    if (e.n.CompareTo(n) == 0)
                                    {
                                        artikelId = e.id;
                                        break;
                                    }
                                }
                                if (artikelId >= 0)
                                    mySql.Insert("groupitems", "invoiceItemId, invoiceGroupId",
                                        String.Format("{0}, {1}", artikelId, gruppe.id));
                                else
                                    throw new Exception("Artikel in Gruppe, aber nicht in Artikel-Liste");
                            }
                        }
                    }

                }
                steps++;
                worker.ReportProgress((int)(100 * steps / totalElements));
            }
        }
        private void ExportTermineToDatabase(BackgroundWorker worker)
        {

            string userState = "Exporting Terminliste ...";
            int steps = 0;
            SqlHelper mySql = new SqlHelper(log);
            foreach (Termin t in terminliste)
            {
                ExportTerminToDatabase(t, false, mySql);
                steps++;
                worker.ReportProgress((int)(100 * steps / terminliste.Count), userState);
            }
        }

        long IsKnownBehandlung(long patientId, string diagnose, string behandlung)
        {
            TreatmentFingerprint a = new TreatmentFingerprint();
            a.PatientId = patientId;
            a.Diagnose = diagnose;
            a.Behandlung = behandlung;

            foreach (TreatmentFingerprint b in bListe)
            {

                if (b.Equals(a))
                    return b.Id;

            }
            return -1;
        }

        private void ExportTerminToDatabase(Termin t, bool occured, SqlHelper mySql)
        {
            int treatmentId = 0;
            string label = "Appointment";
            // wenn kein Merker, dann
            if (!t.Merker)
            {
                // TODO: Habe das Gefühl, Programm erzeugt sehr viele Treatments ?
                #region erzeuge Treatment, wenn kein Merker
                // erzeuge Eintrag in treatment
                // schau nach ob GENAU dieses treatment schon existiert
                long foundBehandlung = IsKnownBehandlung(t.patientId, t.diagnose, t.behandlung );
                if(foundBehandlung == -1)
                {
                    # region neue Behandlung anlegen
                    mySql.Insert("treatment", "patientId, diagnosis, healerId",
                        String.Format("{0},'{1}',{2}",
                        t.patientId,
                        t.diagnose,
                        defaultHealer.ToString() 
                        )) ;
                    
                    //Ermittel treatmentId                        
                    treatmentId = mySql.GetId("treatment");

                    TreatmentFingerprint a = new TreatmentFingerprint();
                    a.PatientId = t.patientId;
                    a.Diagnose = t.diagnose;
                    a.Behandlung = t.behandlung;
                    a.Id = treatmentId;

                    bListe.Add(a);

                    
                    string[] behandlungen = t.behandlung.Split(';');
                    if (behandlungen.GetLength(0) >= 0) 
                    {
                        #region  Trage die Behandlung in treatedwith ein
                        foreach (string s in behandlungen)
                        {
                            if (s == "")
                            {
                                log.Error("Kein Eintrag für Behandlung bei Patient " + t.patientId.ToString());
                            } else if (s.Contains("."))
                            {
                                //ist eine CNummer
                                Nummer n = new Nummer(s);
                                ExportTreated(n, treatmentId, mySql);
                            } else {
                                // ist eine Gruppe
                                #region gruppe zerlegen und eintrag
                                bool notFound = true;
                                for (int iter = 0; iter < gruppen.Count; iter++)
                                {

                                    if (gruppen[iter].ident == s.Trim())
                                    {
                                        //foreach (Nummer n in gruppen[iter].artikel)
                                        //{
                                        //    ExportTreated(n, treatmentId, mySql);
                                        //}
                                        //notFound = false;
                                        ExportTreated(gruppen[iter].id, treatmentId, mySql);
                                        notFound = false;
                                        break;
                                    }
                                }
                                if (notFound)
                                {
                                    log.Error("Unbekannte Gruppe '" + s + "' bei Patient " + t.patientId.ToString());
                                }
                                #endregion

                            }// end  if (s == "") else ...
                        }
                        #endregion
                    }// endif Behandlung.Length>0
                    #endregion
                }
                else
                    treatmentId = (int)foundBehandlung;

                // und label für Appointment vergeben
                label = t.patientId.ToString(); // BESSER NAMEN HOLEN!!!    TODO                            
            #endregion
            }
            
            else
            {
                // setze Merkersachen für Appointment
                label = t.diagnose;
            }
            
        // erzeuge Eintrag in appointment
            mySql.Insert("appointment", "startDate, endDate, occured, label, treatmentId, invoiceId",
                String.Format("'{0}', '{1}', {2}, '{3}', {4}, {5}",
                    SqlHelper.formatDatetime(t.startDate),
                    SqlHelper.formatDatetime(t.endDate),
                    occured ? "true" : "false",
                    label,
                    treatmentId,
                    "null"
                    ));
            t.id = mySql.GetId("appointment");
        }

        private void ExportTerminToDatabase(Termin t, bool occured)
        {
            SqlHelper mySql = new SqlHelper(log);
            ExportTerminToDatabase(t, occured, mySql);
        }

        private void ExportTreated(Nummer n, int treatmentId)
        {
            SqlHelper mySql = new SqlHelper(log);
            ExportTreated(n, treatmentId, mySql);
        }
        private void ExportTreated(Nummer n, int treatmentId, SqlHelper mySql)
        {
            // ID des Eintrages mit Nummer n ermitteln
            int eintragId = -999;
            foreach (Eintrag e in einträge)
            {
                if (e.n.CompareTo(n) == 0)
                {
                    eintragId = e.id;
                    break;
                }
            }
            if (eintragId != -999)
            {
                // Relation in Datenbank ablegen
                mySql.Insert("treatedWith", "treatmentId, invoiceItemId, invoiceGroupId",
                    String.Format("{0}, {1}, null", treatmentId, eintragId));
            }
            else
            {
                log.Error("Unbekannte Behandlung " + n.ToString() + " in Treatment " + treatmentId.ToString());
            }
        }
        private void ExportTreated(long groupId, int treatmentId, SqlHelper mySql)
        {
            // Relation in Datenbank ablegen
            mySql.Insert("treatedWith", "treatmentId, invoiceItemId, invoiceGroupId",
                String.Format("{0}, null, {1}", treatmentId, groupId));
        }  

        private void ExportStammdatenToDatabase(BackgroundWorker worker)
        {
            string userState;
            SqlHelper mySql = new SqlHelper(log);
            int counter = 0;
            int max = patienten.Count;
            int t_max = 0;
            int t_step = 0;
            int percent;

            foreach (Patient p in patienten)
            {
                counter++;
                if (p != null)
                {
                    //labelResult.Text = String.Format("Exportiere Stammdaten (Patient {0}/{1}) ...", counter, max);
                    //this.Refresh();

                    // Schreibe in patient
                    p.GetInsuranceId(mySql);
                    mySql.Insert("patient",
                        "dateOfBirth, comments, male, title, firstname, lastname, occupation, insuranceId, methodOfPayment, publiccomments",
                        String.Format("{0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}",
                        SqlHelper.formatDatetimeQuoted(p.dateofBirth),
                        SqlHelper.QuoteMarks(p.comments),
                        p.male ? "true" : "false",
                        SqlHelper.QuoteMarks(p.title),
                        SqlHelper.QuoteMarks(p.firstname),
                        SqlHelper.QuoteMarks(p.lastname),
                        SqlHelper.QuoteMarks(p.occupation),
                        p.insuranceId,
                        p.methodOfPayment+1,
                        SqlHelper.QuoteMarks(p.publicComments)));
                    // todo: evtl besser alte IDs für Patientennummern nehmen?
                    p.id = mySql.GetId("patient");
                    // schreibe in address
                    mySql.Insert("address", "patientId, street, additionalInfo, postcode, place, useforinvoice",
                        String.Format("{0}, {1}, {2}, {3}, {4}, {5}",
                        p.id,
                        SqlHelper.QuoteMarks(p.address.street),
                        SqlHelper.QuoteMarks(p.address.additionlInfo),
                        SqlHelper.QuoteMarks(p.address.postcode),
                        SqlHelper.QuoteMarks(p.address.place),
                        "true"));
                    // schreibe in contacts
                    foreach (Contacts cn in p.contacts)
                    {
                        mySql.Insert("contacts", "patientId, label, contactInfo",
                            String.Format("{0}, {1}, {2}",
                            p.id,
                            SqlHelper.QuoteMarks(cn.label),
                            SqlHelper.QuoteMarks(cn.contactInfo)));
                    }

                    // schreibe in termine
                    //progressBar.Maximum = p.termine.Count;
                    //progressBar.Value = 0;
                    t_max = p.termine.Count;
                    t_step = 0;
                    foreach (Termin t in p.termine)
                    {
                        ExportTerminToDatabase(t, true, mySql);
                        t_step++;
                        //progressBar.PerformStep();
                        //this.Refresh();
                        userState = String.Format("Exportiere Patient {0}/{1}", counter, max);
                        if (t_max != 0)
                            percent = (int)(100 * t_step / t_max);
                        else
                            percent = 100;
                        worker.ReportProgress(percent, userState);

                    }
                    //progressBar.Refresh();
                    //if (counter > 50)//TODO
                    //{
                    //    &&log.Error("Debug-Limit von 50 Datensätzen erreciht.");
                    //    MessageBox.Show("Aus Debug-Gründen wird bei 50 importierten Patienten abgebrochen.");
                    //    return;

                    //}
                }
            }
        }

        */
        #endregion


        #region ExportToCSV


        private void ExportGebuehToDatabase(BackgroundWorker worker)
        {
           
            int totalElements =  einträge.Count + gruppen.Count;
            int steps = 0;

            CsvExport artikelExport = new CsvExport();
            // ---------------- Artikel ---------------------------
            foreach (Eintrag eintrag in einträge)
            {
                artikelExport.AddRow();

                artikelExport["Nummer"] = eintrag.n.ToString();
                artikelExport["Beschreibung"] = eintrag.description;

                int insuranceIndex = 1;
                foreach (Abrechnungsart aart in abrechnungsarten)
                {
                    artikelExport[aart.label] = string.Format("{0:c}", eintrag.preise[insuranceIndex]);
                }

                steps++;
                worker.ReportProgress((int)(100 * steps / totalElements));
            }

            CsvExport gruppenExport = new CsvExport();
            // ---------------- Gruppen ---------------------------
            foreach( Gruppe gruppe in gruppen ) 
            {
                gruppenExport.AddRow();

                gruppenExport["Name"] = gruppe.label;
                gruppenExport["Artikel"] = gruppe.getArtikel("/");

                steps++;
                worker.ReportProgress((int)(100 * steps / totalElements));
            }

            artikelExport.ExportToFile(getFilename("artikel"));
            gruppenExport.ExportToFile(getFilename("gruppen"));

        }

        private String getFilename(String name) {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), name + ".csv");
        }

        private void ExportTermineToDatabase(BackgroundWorker worker)
        {
            CsvExport termineExport = new CsvExport();

            string userState = "Exporting Terminliste ...";
            int steps = 0;
            foreach (Termin t in terminliste)
            {
                termineExport.AddRow();

                termineExport["Patient"] = t.patientId;
                termineExport["StartDate"] = t.startDate.ToLocalTime();
                termineExport["Behandlung"] = t.behandlung;              
                termineExport["Diagnose"] = t.diagnose;
                termineExport["IstMerker"] = t.merkerFlag;
                
                steps++;
                worker.ReportProgress((int)(100 * steps / terminliste.Count), userState);
            }

            termineExport.ExportToFile(getFilename("termine"));
        }

        /*
        long IsKnownBehandlung(long patientId, string diagnose, string behandlung)
        {
            TreatmentFingerprint a = new TreatmentFingerprint();
            a.PatientId = patientId;
            a.Diagnose = diagnose;
            a.Behandlung = behandlung;

            foreach (TreatmentFingerprint b in bListe)
            {

                if (b.Equals(a))
                    return b.Id;

            }
            return -1;
        }

        private void ExportTerminToDatabase(Termin t, bool occured, SqlHelper mySql)
        {
            int treatmentId = 0;
            string label = "Appointment";
            // wenn kein Merker, dann
            if (!t.Merker)
            {
                // TODO: Habe das Gefühl, Programm erzeugt sehr viele Treatments ?
                #region erzeuge Treatment, wenn kein Merker
                // erzeuge Eintrag in treatment
                // schau nach ob GENAU dieses treatment schon existiert
                long foundBehandlung = IsKnownBehandlung(t.patientId, t.diagnose, t.behandlung );
                if(foundBehandlung == -1)
                {
                    # region neue Behandlung anlegen
                    mySql.Insert("treatment", "patientId, diagnosis, healerId",
                        String.Format("{0},'{1}',{2}",
                        t.patientId,
                        t.diagnose,
                        defaultHealer.ToString() 
                        )) ;
                    
                    //Ermittel treatmentId                        
                    treatmentId = mySql.GetId("treatment");

                    TreatmentFingerprint a = new TreatmentFingerprint();
                    a.PatientId = t.patientId;
                    a.Diagnose = t.diagnose;
                    a.Behandlung = t.behandlung;
                    a.Id = treatmentId;

                    bListe.Add(a);

                    
                    string[] behandlungen = t.behandlung.Split(';');
                    if (behandlungen.GetLength(0) >= 0) 
                    {
                        #region  Trage die Behandlung in treatedwith ein
                        foreach (string s in behandlungen)
                        {
                            if (s == "")
                            {
                                log.Error("Kein Eintrag für Behandlung bei Patient " + t.patientId.ToString());
                            } else if (s.Contains("."))
                            {
                                //ist eine CNummer
                                Nummer n = new Nummer(s);
                                ExportTreated(n, treatmentId, mySql);
                            } else {
                                // ist eine Gruppe
                                #region gruppe zerlegen und eintrag
                                bool notFound = true;
                                for (int iter = 0; iter < gruppen.Count; iter++)
                                {

                                    if (gruppen[iter].ident == s.Trim())
                                    {
                                        //foreach (Nummer n in gruppen[iter].artikel)
                                        //{
                                        //    ExportTreated(n, treatmentId, mySql);
                                        //}
                                        //notFound = false;
                                        ExportTreated(gruppen[iter].id, treatmentId, mySql);
                                        notFound = false;
                                        break;
                                    }
                                }
                                if (notFound)
                                {
                                    log.Error("Unbekannte Gruppe '" + s + "' bei Patient " + t.patientId.ToString());
                                }
                                #endregion

                            }// end  if (s == "") else ...
                        }
                        #endregion
                    }// endif Behandlung.Length>0
                    #endregion
                }
                else
                    treatmentId = (int)foundBehandlung;

                // und label für Appointment vergeben
                label = t.patientId.ToString(); // BESSER NAMEN HOLEN!!!    TODO                            
            #endregion
            }
            
            else
            {
                // setze Merkersachen für Appointment
                label = t.diagnose;
            }
            
        // erzeuge Eintrag in appointment
            mySql.Insert("appointment", "startDate, endDate, occured, label, treatmentId, invoiceId",
                String.Format("'{0}', '{1}', {2}, '{3}', {4}, {5}",
                    SqlHelper.formatDatetime(t.startDate),
                    SqlHelper.formatDatetime(t.endDate),
                    occured ? "true" : "false",
                    label,
                    treatmentId,
                    "null"
                    ));
            t.id = mySql.GetId("appointment");
        }

        private void ExportTerminToDatabase(Termin t, bool occured)
        {
            SqlHelper mySql = new SqlHelper(log);
            ExportTerminToDatabase(t, occured, mySql);
        }

        private void ExportTreated(Nummer n, int treatmentId)
        {
            SqlHelper mySql = new SqlHelper(log);
            ExportTreated(n, treatmentId, mySql);
        }
        private void ExportTreated(Nummer n, int treatmentId, SqlHelper mySql)
        {
            // ID des Eintrages mit Nummer n ermitteln
            int eintragId = -999;
            foreach (Eintrag e in einträge)
            {
                if (e.n.CompareTo(n) == 0)
                {
                    eintragId = e.id;
                    break;
                }
            }
            if (eintragId != -999)
            {
                // Relation in Datenbank ablegen
                mySql.Insert("treatedWith", "treatmentId, invoiceItemId, invoiceGroupId",
                    String.Format("{0}, {1}, null", treatmentId, eintragId));
            }
            else
            {
                log.Error("Unbekannte Behandlung " + n.ToString() + " in Treatment " + treatmentId.ToString());
            }
        }
        private void ExportTreated(long groupId, int treatmentId, SqlHelper mySql)
        {
            // Relation in Datenbank ablegen
            mySql.Insert("treatedWith", "treatmentId, invoiceItemId, invoiceGroupId",
                String.Format("{0}, null, {1}", treatmentId, groupId));
        }  
        */
        private void ExportStammdatenToDatabase(BackgroundWorker worker)
        {
            int counter = 0;
            int max = patienten.Count;

            CsvExport patientenExport = new CsvExport();
            CsvExport behandlungenExport = new CsvExport();

            foreach (Patient p in patienten)
            {
                counter++;

                patientenExport.AddRow();

                patientenExport["ID"] = p.id;
                patientenExport["Name"] = p.lastname;
                patientenExport["Vorname"] = p.firstname;
                patientenExport["Anrede"] = p.title;
                
                patientenExport["Geburtstag"] = p.dateofBirth.ToShortDateString();
                patientenExport["Versicherung"] = p.insurance;
                patientenExport["Bezahlt"] = p.methodOfPayment;
                patientenExport["Interne Anmerkungen"] = p.comments;
                patientenExport["Anmerkungen"] = p.publicComments;
                patientenExport["Geschlecht"] = (p.male?"männlich":"weiblich");

                patientenExport["Anschrift"] = p.address.street;
                patientenExport["Anschrift 2"] = p.address.additionlInfo;
                patientenExport["PLZ"] = p.address.postcode;
                patientenExport["Ort"] = p.address.place;
                patientenExport["Land"] = p.address.country;

                // schreibe in contacts
                StringBuilder c = new StringBuilder();
                foreach (Contacts cn in p.contacts)
                {                    
                    c.Append(cn.label);
                    c.Append("--");
                    c.Append(cn.contactInfo);
                    c.Append("#");
                }
                patientenExport["Telefon"] = c.ToString();

                foreach (Termin t in p.termine) {
                    behandlungenExport.AddRow();

                    behandlungenExport["PatientID"] = p.id;
                    behandlungenExport["StartDate"] = t.startDate.ToLocalTime();
                    behandlungenExport["Behandlung"] = t.behandlung;
                    behandlungenExport["Diagnose"] = t.diagnose;
                    behandlungenExport["IstMerker"] = t.merkerFlag;
                }

                worker.ReportProgress((int) (100*counter/patienten.Count));

            }
            patientenExport.ExportToFile(getFilename("stammdaten"));
            behandlungenExport.ExportToFile(getFilename("behandlungen"));
        }


#endregion
    }

    
}



