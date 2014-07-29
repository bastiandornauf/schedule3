using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace HPSchedule.Dialoge
{
    public partial class AffirmApointmentsForm : KryptonForm
    {
        public AffirmApointmentsForm(List<Datenobjekte.AffirmationAwaitingAppointment> listOfAppointments)
        {
            if (listOfAppointments == null)
                throw new Exception("AffirmApointmentsForm:CTOR listOfAppointments  darf nicht null sein.");

            InitializeComponent();
            this.listOfAppointments = listOfAppointments;

            dataGridView.DataSource = this.listOfAppointments;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

         
            MakeColumnReadOnly("Treatment");
            MakeColumnReadOnly("Diagnosis");


            // Icon setzen
            this.Icon = Helferlein.AllThoseTinyHelper.GetIconFromRessources("letter", 32);

        }

        /// <summary>
        /// Setzt das ReadOnly-Attribut einer Spalte des kryptonDataGridView1.
        /// Bei unbekannten Feldern wird der Vorgang ignoriert, führt aber nicht
        /// zu einer Exception.
        /// </summary>
        /// <param name="fieldName">Header der Spalte</param>
        private void MakeColumnReadOnly(string fieldName)
        {
            DataGridViewColumn col = null;
            col = dataGridView.Columns[fieldName];
            if (col != null)
                col.ReadOnly = true;
#if DEBUG
            else
                MessageBox.Show(String.Format("DEBUG: MakeColumnReadOnly auf unbekannte Spalte {0} aufgerufen", fieldName ));
#endif 
        }

        private List<Datenobjekte.AffirmationAwaitingAppointment> listOfAppointments;

        private void AffirmApointmentsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            dataGridView.EndEdit();
            if( SaveChangesOnExit )
                WriteChangesToDatabase();
        }


        private void AffirmApointmentsForm_Load(object sender, EventArgs e)
        {
            dataGridView.AutoResizeColumns();
        }

        private bool SaveChangesOnExit = true;
        
        private void WriteChangesToDatabase()
        {
            
            
            int i = 0;
            foreach (Datenobjekte.AffirmationAwaitingAppointment ap in listOfAppointments)
            {
                if (ap.Occured)
                {
                    ap.SetOccuredInDB();
                    i++;
                }
            }
            
            MessageBox.Show(
                String.Format("Von den {0} Terminen wurden {1} bestätigt.",
                    listOfAppointments.Count,
                    i));
        }

        private void AffirmApointmentsForm_Load_1(object sender, EventArgs e)
        {
            TranslateHeaderAndSetFormatting();
        }

        private void TranslateHeaderAndSetFormatting()
        {

            foreach (DataGridViewColumn col in dataGridView.Columns)
            {
                switch (col.HeaderText)
                {
                    case "Occured":
                        col.HeaderText = "Bestätigen?";
                        break;
                    case "Start":
                        col.HeaderText = "Beginn";
                        break;
                    case "End":
                        col.HeaderText = "Ende";
                        col.DefaultCellStyle.Format = "HH:mm";
                        break;
                    case "FirstName":
                        col.HeaderText = "Vorname";
                        break;
                    case "LastName":
                        col.HeaderText = "Nachname";
                        break;
                    case "Diagnosis":
                        col.HeaderText = "Diagnose";
                        break;
                    case "Treatment":
                        col.HeaderText = "Behandlung";
                        break;
                    default: break;

                }
            }
        }

        private void alleMarkierenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkOccuredFields(true);
        }

        private void MarkOccuredFields(bool value)
        {
            // Auswahl aufheben
            DataGridViewCell oldCell = dataGridView.CurrentCell;
            dataGridView.CurrentCell = null;

            foreach (Datenobjekte.AffirmationAwaitingAppointment ap in listOfAppointments)
            {
                ap.Occured = value;
            }
            dataGridView.Refresh();

            dataGridView.CurrentCell = oldCell;
        }

        private void alleMarkierungenLöschenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkOccuredFields(false);
        }

        private void ohneBestätigungAbbrechenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChangesOnExit = false;
            this.Close();
        }

        private void bestätigungDurchführenUndBeendenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveChangesOnExit = true;
            this.Close();
        }

    }
}
