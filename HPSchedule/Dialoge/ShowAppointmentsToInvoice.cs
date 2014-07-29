using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPSchedule.Dialoge
{
    public partial class ShowAppointmentsToInvoice : Form
    {
        public ShowAppointmentsToInvoice(long patientId)
        {
            InitializeComponent();
            this.patientId = patientId;
            p = DoDatabaseMagic.LadePatient(patientId);

            this.Text += " "+p.Name.ToString();
            // Icon setzen
            this.Icon = Helferlein.AllThoseTinyHelper.GetIconFromRessources("letter", 32);

        }
        DataTable dt = new DataTable();
        private long patientId = 0;
        Patient p;

        private void ShowAppointmentsToInvoice_Load(object sender, EventArgs e)
        {
            dt = DoDatabaseMagic.GetDataTableOfAppointmentsToInvoice(patientId);
            dataGridView.DataSource = dt;

            GenerateInvoiceText();
        }

        private void GenerateInvoiceText()
        {
            Datenobjekte.Accounting accounting = new global::HPSchedule.Datenobjekte.Accounting();
            accounting.LoadFromDatabase();
            double total = 0.0;

            StringBuilder invoice = new StringBuilder();

            // Anschrift
            invoice.AppendLine(p.Name.CompleteName);
            foreach (Address a in p.Addresses)
            {
                if (a.UseForInvoice)
                    invoice.AppendFormat("{0}" + Environment.NewLine + "{1} {2}" + Environment.NewLine,
                        a.Street,
                        a.PostCode,
                        a.Place);
            }
            invoice.AppendLine(String.Empty);

            // Für jedes Treatment...
            List<Datenobjekte.Treatment> treatments = DoDatabaseMagic.GetTreatmentsOfAppointmentsToInvoice(p.Id);
            foreach (Datenobjekte.Treatment t in treatments)
            {
                invoice.AppendLine(String.Empty);

                
                //Diagnose
                invoice.AppendLine("Diagnose: "+t.Diagnosis);
                // Termine
                StringBuilder dateList = new StringBuilder();
                List<Appointment> appointments = DoDatabaseMagic.GetAppointmentsForTreatment(t.Id);
                foreach (Appointment a in appointments)
                {
                    if (dateList.Length != 0)
                        dateList.Append(", ");

                    dateList.Append(a.StartDate.ToShortDateString());
                }
                invoice.AppendLine("  An jedem der aufgeführten Tage: " + dateList.ToString());
                
                //Auflistung
                double fee = 0.0;
                StringBuilder itemList = new StringBuilder();
                foreach (Datenobjekte.TreatedWith item in t.items)
                {
                    if (itemList.Length != 0)
                        itemList.Append(", ");

                    itemList.Append(item.ToString());


                    if (item.IsGroup)
                    {
                        foreach (long idOfItemInGroup in accounting.GetGroup(item.GroupId).InvoiceItems)
                        {
                            fee += accounting.GetItem(idOfItemInGroup).GetFee(p.InsuranceId).Amount;
                        }
                    }
                    else
                        fee += accounting.GetItem(item.ItemId).GetFee(p.InsuranceId).Amount;
                }
                invoice.AppendLine("  wurde folgende Behandlung durchgeführt:"+Environment.NewLine+"  " + itemList.ToString());

                invoice.AppendLine(String.Format("  -> {0} Termine zu {1:c} = {2:c}",
                                                    appointments.Count,
                                                    fee,
                                                    fee*appointments.Count));

                total += fee * appointments.Count;

            }


            invoice.AppendLine("");
            invoice.AppendLine(String.Format("GESAMTSUMME: {0:c}", total));
            
            
            // Text anzeigen und keine Auswahl
            kryptonRichTextBox1.Text = invoice.ToString();
            kryptonRichTextBox1.SelectionLength = 0;
        }
    }
}
