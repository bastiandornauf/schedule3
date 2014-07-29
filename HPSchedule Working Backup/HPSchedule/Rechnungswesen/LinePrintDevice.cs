using System;
using System.Collections.Generic;
using System.Text;

using System.Windows.Forms;
using System.Drawing;

namespace HPSchedule.Rechnungswesen
{
    public class LinePrintDevice : InvoicePrintDevice
    {
        RichTextBoxPrintCtrl.RichTextBoxPrintCtrl printCtrl = new RichTextBoxPrintCtrl.RichTextBoxPrintCtrl();

        public LinePrintDevice() {
            printCtrl.Font = new Font(new FontFamily("Courier New"), 11f, FontStyle.Regular);
        }

        public override void Print()
        {
            PrintHeader();
            PrintAppointments();
            PrintFooter();
            printCtrl.OnPrint(this, new EventArgs());
        }


        private void PrintHeader()
        {
            printCtrl.AppendLine("+------------------------------------------------------------+");
            printCtrl.AppendLine(Data.Patient.Name.CompleteName);
            printCtrl.AppendLine(Data.Patient.InvoiceAdress.ToStringMultiline());
            printCtrl.AppendNewLine();
            printCtrl.AppendLine("Datum: " + Data.invoiceDate.ToShortDateString() + String.Format("     ReNr.: {0}", Data.invoiceNr));
            printCtrl.AppendNewLine();

        }

        private void PrintAppointments()
        {
            foreach(InvoiceTreatmentDetails t in Data.Recipient.Treatments)
            {
                printCtrl.AppendLine("Jede hier aufgefühte Leistung ...");
                
                foreach (Item i in t.Items)
                    printCtrl.AppendLine( String.Format("  - {0} {1} {2:c}", i.Tariff, i.Description, i.Fees.GetAmount( Data.Recipient.Insurance.Id )));

                printCtrl.AppendNewLine();
                printCtrl.AppendLine("... fand an folgenden Terminen statt ...");
                
                StringBuilder line = new StringBuilder();
                foreach( InvoiceAppointment ap in t.Appointments ) {
                    if( line.Length > 0 )
                        line.Append(", ");
                    line.Append( ap.Start.ToShortDateString());
                }
                printCtrl.AppendLine( "    " + line );

                printCtrl.AppendNewLine();
                printCtrl.AppendLine(String.Format("{0} Behandlungen à {1:c} ergibt eine Zwischensumme von {2:c}.",
                    t.Appointments.Count,
                    t.Amount,
                    t.Appointments.Count * t.Amount ));
                    
                printCtrl.AppendNewLine();
            }
        }

        private void PrintFooter()
        {
            printCtrl.AppendNewLine();
            printCtrl.AppendLine(String.Format("Gesamtsumme: {0:c}", Data.Recipient.Sum));
            printCtrl.AppendNewLine();
            printCtrl.AppendNewLine();

        }

        public override void Init(global::HPSchedule.Datenobjekte.Invoice data)
        {
            base.Init(data);

            
        }
    }
}
