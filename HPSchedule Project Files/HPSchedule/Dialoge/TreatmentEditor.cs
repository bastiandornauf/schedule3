using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using HPSchedule.Datenobjekte;

namespace HPSchedule.Dialoge
{
    public partial class TreatmentEditor : Form
    {
        PatientNameAndId patient;
        List<Treatment> treatments;
        Treatment selectedTreatment = null;
        Treatment result = null;

        public Treatment Result
        {
            get { return result; }
        }

        Appointment selectedAppointment;
        Accounting accounting;

        internal TreatmentEditor(Appointment appointment) : this(appointment, null) { }

        internal TreatmentEditor(Appointment appointment, Treatment treatment)
        {
            InitializeComponent();

            accounting = new Accounting();
            accounting.LoadFromDatabase();
            selectedAppointment = appointment;

            treatments = new List<Treatment>();

            patient = null;

            InitializeControls();

            if (treatment != null)
                patient = DoDatabaseMagic.GetPatient(treatment.PatientId);

            LoadDataToForm();

            // Wenn Treatment übergeben wurde (also bearbeitet werden soll)
            // sorge dafür dass es in der Liste ist und
            // wähle es aus!
            if (treatment != null)
            {
                int index = cbTreatmentLastFive.SelectedIndex;
                int indexOfTreatment = TreatmentIsKnown(treatment);
                if (indexOfTreatment >= 0)
                {
                    index = indexOfTreatment;
                }
                else
                {
                    treatments.Add(treatment);
                    UpdateControls();
                    index = treatments.Count - 1;
                }
                cbTreatmentLastFive.SelectedIndex = index;
            }
        }
        private int TreatmentIsKnown( Treatment treatment ) {
            int iter = 0;
            foreach( Treatment t in treatments ) {
                if (t.Id == treatment.Id)
                    return iter;
                else
                    iter++;
            }
            return -1;
        }
        private void LoadDataToForm()
        {
            //throw new Exception("The method or operation is not implemented.");
            //DoDatabaseMagic.LoadHealerToList(ref healer);
            //DoDatabaseMagic.LoadRoomToList(ref rooms);
            if (patient != null)
                DoDatabaseMagic.LoadLastTreatments(ref treatments, patient.Id);
            else
                treatments.Clear();

            foreach (Treatment t in treatments)
                t.DatabaseAction = dbAction.none;

            UpdateControls();
        }

        private void InitializeControls()
        {
            tbPatient.KeyDown += new KeyEventHandler(tbPatient_KeyDown);
        }

        void tbPatient_KeyDown(object sender, KeyEventArgs e)
        {
            SuchePatientForm dlg = new SuchePatientForm();
            dlg.StartValue = e.KeyCode.ToString();
            e.Handled = true;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                patient = DoDatabaseMagic.GetPatient(dlg.Result);

                LoadDataToForm();
            }            
        }

        private void UpdateControls()
        {
            cbTreatmentLastFive.Items.Clear();
            foreach (Treatment t in treatments)
            {
                string s = String.Format("[{0}:{1}]", t.Id, t.StartDate.ToShortDateString());
                cbTreatmentLastFive.Items.Add(s + " " + t.Diagnosis);                
            }
            if (cbTreatmentLastFive.Items.Count > 0)
                cbTreatmentLastFive.SelectedIndex = 0;

            if (patient != null)
            {
                tbPatient.Text = patient.ShortName;
            }
            else
            {
                tbPatient.Text = "bitte auswählen...";
            }


            label2.Text = selectedAppointment.StartDate.ToShortDateString() + ", " +selectedAppointment.StartDate.ToShortTimeString() + " - " + selectedAppointment.EndDate.ToShortTimeString();
        }

        private void TreatmentEditor_Load(object sender, EventArgs e)
        {

        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if (patient != null)
            {
                if (cbTreatmentLastFive.SelectedIndex >= 0 && selectedTreatment != null)
                {
                    DialogResult = DialogResult.OK;
                    result = selectedTreatment;
                    result.PatientId = patient.Id;
                    Close();
                }
                else
                {
                    MessageBox.Show("Sie haben noch keine Behandlung ausgewählt.", "Fehler");
                }
            }
            else
            {
                MessageBox.Show("Sie haben noch keinen Patienten ausgewählt.", "Fehler");
            }
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void bNewTreatment_Click(object sender, EventArgs e)
        {
            Treatment newTreatment = new Treatment();
            newTreatment.StartDate = selectedAppointment.StartDate;
            newTreatment.EndDate = selectedAppointment.EndDate;
            
            TreatedWithEditor editor = new TreatedWithEditor(newTreatment, accounting);
            if( editor.ShowDialog() == DialogResult.OK ) {
                newTreatment.DatabaseAction = dbAction.created;
                treatments.Add(newTreatment);
                UpdateControls();
                cbTreatmentLastFive.SelectedIndex = treatments.Count - 1;
            }
        }

        private void bSearchPatient_Click(object sender, EventArgs e)
        {
            SuchePatientForm dlg = new SuchePatientForm();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                patient = DoDatabaseMagic.GetPatient(dlg.Result);
                //patient.Id = dlg.Result;
                LoadDataToForm();
            }
        }

        private void cbTreatmentLastFive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTreatmentLastFive.SelectedIndex >= 0)
            {
                selectedTreatment = treatments[cbTreatmentLastFive.SelectedIndex];
                if (selectedTreatment.Id == 0)
                    bEdit.Enabled = true;
                else
                    bEdit.Enabled = false;

            }
            else
            {
                selectedTreatment = null;
                bEdit.Enabled = false;
            }

            // Anzeige aktualisieren!
            UpdateTreatmentInfo();
        }

        private void UpdateTreatmentInfo()
        {
            lbTreatmentInfo.Items.Clear();
            
            if (selectedTreatment != null)
            {
                string s = String.Format("[{0}:{1}]", selectedTreatment.Id, selectedTreatment.StartDate.ToShortDateString());
                
                lbTreatmentInfo.Items.Add(s);
                lbTreatmentInfo.Items.Add("");
                lbTreatmentInfo.Items.Add(selectedTreatment.Diagnosis);
                lbTreatmentInfo.Items.Add("");

                foreach (TreatedWith tw in selectedTreatment.items)
                {
                    if (tw.IsGroup)
                    {
                        Group g = accounting.GetGroup(tw.GroupId);
                        lbTreatmentInfo.Items.Add(g.Label);
                    }
                    else
                    {
                        InvoiceItem item = accounting.GetItem(tw.ItemId);      
                        s = String.Format("{0}: {1}", 
                            item.Number.ToString(),
                            item.Description );
                        lbTreatmentInfo.Items.Add(s);
                    }
                }
            }
        }

        private void bCopyTreatment_Click(object sender, EventArgs e)
        {
            if (cbTreatmentLastFive.SelectedIndex < 0)
                return;

            Treatment oldTreatment = treatments[cbTreatmentLastFive.SelectedIndex];                                    
            
            Treatment newTreatment = new Treatment();            
            newTreatment.StartDate = selectedAppointment.StartDate;
            newTreatment.EndDate = selectedAppointment.EndDate;
            newTreatment.Diagnosis = oldTreatment.Diagnosis;
            newTreatment.HealerId = oldTreatment.HealerId;
            foreach (TreatedWith tw in oldTreatment.items)
            {
                TreatedWith newTw = new TreatedWith();
                if (tw.IsItem)
                    newTw.ItemId = tw.ItemId;
                else
                    newTw.GroupId = tw.GroupId;
                newTw.Id = tw.Id;

                newTreatment.items.Add(tw);
            }

            // HIER NEN EDITOR FÜR DIE BEHANDLUNG STARTEN ...
            TreatedWithEditor editor = new TreatedWithEditor(newTreatment, accounting);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                newTreatment.DatabaseAction = dbAction.created;
                treatments.Add(newTreatment);
                UpdateControls();
                cbTreatmentLastFive.SelectedIndex = treatments.Count - 1;
            }

        }

        private void bEdit_Click(object sender, EventArgs e)
        {
            if (selectedAppointment == null)
                return;
            if (selectedAppointment.Id != 0)
                MessageBox.Show("Eine bestehende Behandlung kann nicht bearbeitet werden.\r\n" +
                                "Fügen Sie statt dessen eine neue Behandlung hinzu.",
                                "Information",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Information);

            int index = cbTreatmentLastFive.SelectedIndex;
            TreatedWithEditor editor = new TreatedWithEditor(selectedTreatment, accounting);
            if (editor.ShowDialog() == DialogResult.OK)
            {
                UpdateControls();
                cbTreatmentLastFive.SelectedIndex = index;
            }
        }
    }
}