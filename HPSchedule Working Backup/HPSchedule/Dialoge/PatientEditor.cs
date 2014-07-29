using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule
{
    public partial class PatientEditor : Form
    {
        Patient p, pBackup;
        AdditionalPatientInfo additionalInfo;
        Datenobjekte.Accounting acc;
        int insuranceIndex;

        public PatientEditor(Patient patient)
        {
            InitializeComponent();
            
            p = patient;
            if (patient != null)
                pBackup = patient.Clone() as Patient;
            else
                pBackup = null;
            additionalInfo = new AdditionalPatientInfo(patient.Id);

            acc = new Datenobjekte.Accounting();
            DoDatabaseMagic.LoadAccountingFromDB(acc);

            FillDataInForm(); // For InitControls, sonst killt TextChanged den Datenbestand
            InitializeControls();

        }
        private void PatientEditor_Load(object sender, EventArgs e)
        {

        }

        private void FillDataInForm()
        {
            // Fülle Controls mit Daten aus Patient p
            nameLabel.Text = p.Name.CompleteName;

            if (p.Id > 0)
                labelPatientId.Text = "Id: "+p.Id.ToString();
            else
                labelPatientId.Text = "Id: ?";

            tbLastname.Text = p.Name.Lastname;
            cbTitle.Text = p.Name.Title;
            tbFirstname.Text = p.Name.Firstname;

            radioButton1.Checked = p.Male;

            if (p.DateOfBirth == DateTime.MinValue)
            {
                p.DateOfBirth = pickerBirthDate.MinDate;
            }
            pickerBirthDate.Value = p.DateOfBirth;

            SetDeathControls(p.IsDead);
            if (p.IsDead) {
                if (p.DateOfDeath == DateTime.MinValue)
                {
                    p.DateOfDeath = pickerDeathDate.MinDate;
                }
                pickerDeathDate.Value = p.DateOfDeath;
            }

            tbComments.Text = p.Comments;
            tbPublicComments.Text = p.PublicComments;

            cbInsurance.Items.Clear();
            int count = 0;
            foreach (Datenobjekte.Insurance i in acc.Insurances)
            {
                cbInsurance.Items.Add(i.Label);
                if (i.Id == p.InsuranceId)
                    insuranceIndex = count;
                count++;
            }


            cbMethodOfPayment.Items.Add("auf Rechnung"); // Hier besser auch auf Accounting/Datenbank gehen
            cbMethodOfPayment.Items.Add("Barzahlung");
            //cbMethodOfPayment.Items.Add("auf Rechnung");


            FillAdditionalInfoToForm();

            UpdateAddressListbox();
            UpdateContactListbox();

        }

        private void FillAdditionalInfoToForm()
        {
            
            tbHealer.Text = additionalInfo.BehandlerName;

            if(acc.Insurances.Count > 0 )
                cbInsurance.SelectedIndex = insuranceIndex;            
            
            if (p.MethodOfPaymentId == 0)
                cbMethodOfPayment.SelectedIndex = 0;
            else if (p.MethodOfPaymentId == 1)
                cbMethodOfPayment.SelectedIndex = 1;
            else
                cbMethodOfPayment.Text = p.MethodOfPaymentId.ToString() + " (unbekannt)";

            tbFirstTreatment.Text = additionalInfo.FirstTreatment;
            tbLatestTreatment.Text = additionalInfo.LatestTreatment;
            tbTreatmentCount.Text = additionalInfo.OpenTreatmentCount + " / " + additionalInfo.TotalTreatmentCount;

        }

        private void SetDeathControls(bool isDead)
        {
            if (isDead)
                mmSwitchDeath.Text = "Tod widerrufen";
            else
                mmSwitchDeath.Text = "Tod eintragen";

            pickerDeathDate.Enabled = isDead;
            pickerDeathDate.Visible = isDead;
            labelDeath.Visible = isDead;
        }

        private void InitializeControls()
        {
            pickerBirthDate.Format = DateTimePickerFormat.Short;
            

            listBoxAddress.MouseDown += new MouseEventHandler(listBoxAddress_MouseDown);
            listBoxContacts.MouseDown += new MouseEventHandler(listBoxContacts_MouseDown);

            listBoxAddress.DrawMode = DrawMode.OwnerDrawVariable;
            listBoxAddress.DrawItem += new DrawItemEventHandler(listBoxAddress_DrawItem);
            listBoxAddress.MeasureItem +=new MeasureItemEventHandler(listBoxAddress_MeasureItem);

            tbFirstname.TextChanged += new EventHandler(Name_TextChanged);
            tbLastname.TextChanged += new EventHandler(Name_TextChanged);
            cbTitle.TextChanged += new EventHandler(Name_TextChanged);

        }

        #region Zeichne listBoxAddress selbst, damit mehrzeilig
        void  listBoxAddress_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            string s = (sender as ListBox).Items[e.Index].ToString();
            
            SizeF sf = e.Graphics.MeasureString(decodeItemEntry(s), Font, Width);
            //int htex = (e.Index==0) ? 15 : 10;
            int htex = ((int)e.Graphics.MeasureString("Abg", Font, Width).Height)/2;

            e.ItemHeight = (int)sf.Height + htex;			         
            e.ItemWidth = Width;
        }

        string decodeItemEntry(string s)
        {
            if (s.StartsWith("+")) // WENN DEFAULT-ADRESSE
                return "[Rechnungsadresse]" + Environment.NewLine + "   " + s.Substring(3).Replace("\r\n", "\r\n   ");
            else
                return "[weitere Adresse]" + Environment.NewLine + "   " + s.Substring(3).Replace("\r\n", "\r\n   ");
            //return s.Substring(3);


        }

        void listBoxAddress_DrawItem(object sender, DrawItemEventArgs e) {       
            /*chk if list box has any items*/
            if(e.Index > -1)
            {
                string s = (sender as ListBox).Items[e.Index].ToString();
                Font customFont = Font;
                //if (s.StartsWith("+")) // WENN DEFAULT-ADRESSE
                //{
                    //customFont = new Font(Font, FontStyle.Italic);
                //}

                s = decodeItemEntry(s);

                /*Normal items*/
                if((e.State & DrawItemState.Focus)==0)
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Window),
                        e.Bounds);
                    e.Graphics.DrawString(s,customFont,
                        new SolidBrush(SystemColors.WindowText),
                        e.Bounds);              
                    e.Graphics.DrawRectangle(
                        new Pen(SystemColors.Highlight),e.Bounds);              
                }
                else /*Selected item, needs highlighting*/
                {
                    e.Graphics.FillRectangle(
                        new SolidBrush(SystemColors.Highlight),
                        e.Bounds);
                    e.Graphics.DrawString(s,customFont,
                        new SolidBrush(SystemColors.HighlightText),
                        e.Bounds);
                }
            }
    }
        #endregion 

        void Name_TextChanged(object sender, EventArgs e)
        {
            p.Name.Firstname = tbFirstname.Text;
            p.Name.Lastname = tbLastname.Text;
            p.Name.Title = cbTitle.Text;


            nameLabel.Text = p.Name.CompleteName;
        }



        #region AddresseUndKontakte

        void listBoxContacts_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBoxContacts.SelectedIndex != -1)
                {
                    // Eintrag ausgewählt
                    cmiContextDelete.Enabled = true;
                    cmiContextEdit.Enabled = true;
                }
                else
                {
                    cmiContextDelete.Enabled = false;
                    cmiContextEdit.Enabled = false;
                }
            }
        }

        void listBoxAddress_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listBoxAddress.SelectedIndex != -1)
                {
                    // Eintrag ausgewählt
                    cmiAddressDelete.Enabled = true;
                    cmiAddressEdit.Enabled = true;
                    cmiAddressSetDefault.Enabled = true;
                }
                else
                {
                    cmiAddressDelete.Enabled = false;
                    cmiAddressEdit.Enabled = false;
                    cmiAddressSetDefault.Enabled = false;
                }
            }
        }
        
        
        private void cmiAddressNew_Click(object sender, EventArgs e)
        {
            Address newAddress = new Address();
            AddressEditor editor = new AddressEditor(newAddress);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                p.Addresses.Add(newAddress);
                UpdateAddressListbox();
            }
        }

        private void cmiAddressEdit_Click(object sender, EventArgs e)
        {
            if (listBoxAddress.SelectedIndex >= 0 && listBoxAddress.SelectedIndex < p.Addresses.Count)
            {
                if (!p.Addresses[listBoxAddress.SelectedIndex].toBeDeleted)
                {
                    AddressEditor editor = new AddressEditor(p.Addresses[listBoxAddress.SelectedIndex]);
                    editor.ShowDialog();
                    UpdateAddressListbox();
                }
            }
        }

        private void cmiAddressDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher?", "Vorsicht!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                p.Addresses[listBoxAddress.SelectedIndex].toBeDeleted = true;

            UpdateAddressListbox(); 
        }

        private void cmiAddressSetDefault_Click(object sender, EventArgs e)
        {
            if (listBoxAddress.SelectedIndex >= 0 && listBoxAddress.SelectedIndex < p.Addresses.Count)
            {
                for (int iter = 0; iter < p.Addresses.Count; iter++)
                {
                    if (iter == listBoxAddress.SelectedIndex && ! p.Addresses[iter].toBeDeleted)
                        p.Addresses[iter].UseForInvoice = true;
                    else
                        p.Addresses[iter].UseForInvoice = false;
                }
            }
            UpdateAddressListbox();
        }

        private void UpdateAddressListbox()
        {
            if (p.Addresses.Count == 1)
            {
                p.Addresses[0].UseForInvoice = true;                
            }
                        
            listBoxAddress.Items.Clear();
            foreach (Address a in p.Addresses)
            {
                if (a.toBeDeleted)
                    listBoxAddress.Items.Add("- wird gelöscht -");
                else
                    listBoxAddress.Items.Add(a.ToStringMultilineForList() );
                //listBoxAddress.Items.Add(a.ToString(true));
            }
        }
        
        private void cmiContextNew_Click(object sender, EventArgs e)
        {
            Contact c = new Contact();
            ContactEditor ceditor = new ContactEditor(c);
            if (ceditor.ShowDialog() == DialogResult.OK)
            {
                p.Contacts.Add(c);
                UpdateContactListbox();
            }
        }

        private void UpdateContactListbox()
        {
            listBoxContacts.Items.Clear();
            foreach (Contact c in p.Contacts)
                if (c.toBeDeleted)
                    listBoxContacts.Items.Add("- wird gelöscht -");
                else    
                    listBoxContacts.Items.Add(c.ToString());
        }

        private void cmiContextEdit_Click(object sender, EventArgs e)
        {
            if (listBoxContacts.SelectedIndex >= 0 && listBoxContacts.SelectedIndex < p.Contacts.Count)
            {
                if (!p.Contacts[listBoxContacts.SelectedIndex].toBeDeleted)
                {
                    ContactEditor ceditor = new ContactEditor(p.Contacts[listBoxContacts.SelectedIndex]);
                    ceditor.ShowDialog();
                    UpdateContactListbox();
                }
            }
        }

        private void cmiContextDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Sind Sie sicher?", "Vorsicht!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                p.Contacts[listBoxContacts.SelectedIndex].toBeDeleted = true;

            UpdateContactListbox();
        }

        #endregion

        private void bOK_Click(object sender, EventArgs e)
        {
            if (p.Name.LexicalName.Trim() == ",")
            {
                MessageBox.Show("Sie müssen einen Namen eingeben.", "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            SaveDataFromForm();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void SaveDataFromForm()
        {
            // Patient p bekommt die bearbeiteten Daten ...
            // p.Name und p.Addresses/Contacts wird direkt bearbeitet
            p.Male = radioButton1.Checked;
            p.DateOfBirth = pickerBirthDate.Value;
            if (pickerDeathDate.Enabled)
            {
                p.IsDead = true;
                p.DateOfDeath = pickerDeathDate.Value;
            }
            else
            {
                p.IsDead = false;
                p.DateOfDeath = DateTime.MinValue;
            }
            p.Comments = tbComments.Text;
            p.PublicComments = tbPublicComments.Text;

            //INSURANCE
            if( cbInsurance.SelectedIndex >= 0 )
                p.InsuranceId = acc.Insurances[cbInsurance.SelectedIndex].Id;
            
            //MethodOfPayment
            if (cbMethodOfPayment.SelectedIndex >= 0)
                p.MethodOfPaymentId = cbMethodOfPayment.SelectedIndex; // ???
        }


        private void bCancel_Click(object sender, EventArgs e)
        {
            p = pBackup;
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void mmSwitchDeath_Click(object sender, EventArgs e)
        {
            p.IsDead = !p.IsDead;
            SetDeathControls(p.IsDead);

            if (p.IsDead && (p.DateOfDeath == null || p.DateOfDeath == DateTime.MinValue))
            {
                p.DateOfDeath = pickerDeathDate.MinDate;
            }
        }

  





    }

    class AdditionalPatientInfo
    {
        public AdditionalPatientInfo(long pid)
        {
            patientId = pid;
            if (patientId > 0)
            {
                naMode = false;
                FillFieldsFromDatabase();
            }
            else
                naMode = true;
        }
        
        long patientId;
        bool naMode;
        string naMsg = "n/a";
        string toFirstTreatment;
        string toLatestTreatment;

        private void FillFieldsFromDatabase()
        {
            object[] results = DoDatabaseMagic.GetListOfAdditionalPatientInfos(patientId);
            if (results.GetLength(0) > 4)
            {
                //firstTreatment
                firstTreatment = (DateTime)(results[0]!=null?results[0]:DateTime.MinValue);
                //latestTreatment
                latestTreatment = (DateTime)(results[1] != null ? results[1] : DateTime.MinValue);
                //openTreatmentCount
                openTreatmentCount = (int)results[2];
                //totalTreatmentCount
                totalTreatmentCount = (int)results[3];
                //behandler
                behandlerName = (string)results[4];
            }
            DateTime now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            TimeSpan timeSpanToTreatment = now.Subtract( firstTreatment );
            toFirstTreatment = FormatTimeSince(timeSpanToTreatment);
            
            timeSpanToTreatment = now.Subtract( latestTreatment );
            toLatestTreatment = FormatTimeSince(timeSpanToTreatment);
        }

        private string FormatTimeSince(TimeSpan time)
        {
            bool inFuture = false;

            if (time.Ticks < 0)
            {
                inFuture = true;
                time = new TimeSpan(time.Ticks * -1);
            }
            else
                time = time.Add(new TimeSpan(1, 0, 0, 0)); // einen Tag dazu, dann stimmts


            if (time.Days == 0)
                return "(heute)";
            else if (time.Days == 1)
                return inFuture ? "(morgen)" : "(gestern)";

            int jahre = time.Days / 360;
            int monate = (time.Days-jahre*360) / 30;
            int tage = time.Days % 30;

            if (! inFuture )

                if (jahre > 0)
                    return String.Format("(vor {0} {1}, {2} {3})", 
                        jahre, jahre > 1 ? "Jahren" : "Jahr", 
                        monate, monate > 1 ? "Monaten" : "Monat");
                else

                    if (monate >0)
                        return String.Format("(vor {0} {1} und {2} {3})", 
                            monate, monate > 1 ? "Monaten" : "Monat",
                            tage, tage > 1 ? "Tagen" : "Tag");

                    else
                        return String.Format("(vor {0} {1})", tage, tage > 1 ? "Tagen" : "Tag");
            else
                return String.Format("(in {0} Tagen)", tage);
        }
       
        private DateTime firstTreatment;

        public string FirstTreatment
        {
            get
            {
                return naMode ? naMsg :
              firstTreatment == DateTime.MinValue ? "noch keine Behandlungen" :
                       firstTreatment.ToShortDateString() + " "
                       + toFirstTreatment; 
            
            
            }
        }

        private DateTime latestTreatment;

        public string LatestTreatment
        {
            get
            {
                return naMode ? naMsg :
              latestTreatment == DateTime.MinValue ? "noch keine Behandlungen" :
                       latestTreatment.ToShortDateString() + " " +
                       toLatestTreatment;
            }
        }

        private int openTreatmentCount;
        
        public string OpenTreatmentCount
        {
            get { return naMode ? naMsg : openTreatmentCount.ToString(); }
        }

        private int totalTreatmentCount;
        
        public string TotalTreatmentCount
        {
            get { return naMode ? naMsg : totalTreatmentCount.ToString(); }
        }

        private string behandlerName;
        public string BehandlerName
        {
            get { return naMode ? naMsg : behandlerName; }
        }


    }
}