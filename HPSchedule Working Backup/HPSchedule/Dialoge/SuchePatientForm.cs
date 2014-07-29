using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule
{
    public partial class SuchePatientForm : Form
    {
        long patientId;
        private string startValue = "";
        List<PatientNameAndId> liste;
        List<PatientNameAndId> resultList;

        public string StartValue
        {
            set { startValue = value;  }
        }

        public SuchePatientForm()
        {
            InitializeComponent();
            this.Shown += new EventHandler(SuchePatientForm_Shown);



            patientId = -1;
            label1.Text = "0 Patienten passen auf die Anfrage" ;

            liste = new List<PatientNameAndId>();
            resultList = new List<PatientNameAndId>();

            listBox1.DoubleClick += new EventHandler(listBox1_DoubleClick);

            textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;//AutoCompleteMode.SuggestAppend;
            textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;

            DoDatabaseMagic.FillPatientNameAndIdList( ref liste );
            foreach (PatientNameAndId item in liste)
            {
                textBox1.AutoCompleteCustomSource.Add(item.LexicalName);
                textBox1.AutoCompleteCustomSource.Add(item.ShortName);
            }

        }

        void SuchePatientForm_Shown(object sender, EventArgs e)
        {
            if (startValue != "")
                textBox1.Text = startValue;
            textBox1.SelectionStart = textBox1.Text.Length;

            textBox1_TextChanged(this, new EventArgs());
        }

        public long Result
        {
            get { return patientId; }
        }

        /// <summary>
        /// Ausgewählter Patient
        /// </summary>
        public long Patient { get { return patientId; } }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {                        
            resultList.Clear();

            // suche nach Patienten, ändere Leer-Eingaben in Datenbank-Wildcard "alle"
            DoDatabaseMagic.FindMatchingPatients( textBox1.Text==String.Empty?"%":textBox1.Text , ref resultList );
            listBox1.Items.Clear();
            foreach (PatientNameAndId item in resultList)
            {
                listBox1.Items.Add(item.LexicalName);
            }
            label1.Text = String.Format("{0} Patienten passen auf die Anfrage", listBox1.Items.Count);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
                if (listBox1.SelectedIndex < resultList.Count)
                    patientId = resultList[listBox1.SelectedIndex].Id;
                else
                    patientId = -1;
            else
                patientId = -1;
        }

        void listBox1_DoubleClick(object sender, EventArgs e)
        {
            if (patientId != -1)
            {
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            // todo: sind noch mehrere Leute ausgewählt kann man nicht nur mit enter auswählen!
            if (resultList.Count == 1)
                patientId = resultList[0].Id;

            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void SuchePatientForm_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //}
        }

    }


}