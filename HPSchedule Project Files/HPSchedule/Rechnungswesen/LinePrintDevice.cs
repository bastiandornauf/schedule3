using System;
using System.Collections.Generic;
using System.Text;
using LinePrinting;
using System.Windows.Forms;
using System.Drawing;

namespace HPSchedule.Rechnungswesen
{
    public class LinePrintDevice : InvoicePrintDevice
    {
        LinePrinter printCtrl = new LinePrinter();
       
        public LinePrintDevice() {
        }

        public override void Print()
        {
            if (printCtrl.Open(this.Data.invoiceNr.ToString()))
            {
                // TODO this is ugly. Printer gets asked for every invoice!
                if( printCtrl.ChoosePrinter()) {
                    PrintHeader();
                    PrintAppointments();
                    PrintFooter();
                }
                printCtrl.Close();
              
            }
        }


        private void PrintHeader()
        {
            printCtrl.PrintLine("");
            printCtrl.PrintLine("");
            printCtrl.PrintLine("");
            printCtrl.PrintLine("");
            printCtrl.PrintLine("");

            printCtrl.PrintLine("+------------------------------------------------------------+");
            printCtrl.PrintLine(Data.Patient.Name.CompleteName);

            Address a = Data.Patient.InvoiceAdress;
            printCtrl.PrintLine(a.Street);
            printCtrl.PrintLine(a.AdditionalInfo);
            printCtrl.PrintLine(a.PostCode + " " + a.Place);
            printCtrl.PrintLine(a.Country);
            
            printCtrl.PrintLine("");
            printCtrl.PrintLine("Datum: " + Data.invoiceDate.ToShortDateString() + String.Format("     ReNr.: {0}", Data.invoiceNr));
            printCtrl.PrintLine("");

        }

        private void PrintAppointments()
        {
            foreach(InvoiceTreatmentDetails t in Data.Recipient.Treatments)
            {
                printCtrl.PrintLine("Jede hier aufgefühte Leistung ...");
                
                foreach (Item i in t.Items)
                    printCtrl.PrintLine(String.Format("  - {0} {1} {2:c}", i.Tariff, i.Description, i.Fees.GetAmount(Data.Recipient.Insurance.Id)));

                printCtrl.PrintLine("");
                printCtrl.PrintLine("... fand an folgenden Terminen statt ...");
                
                StringBuilder line = new StringBuilder();
                foreach( InvoiceAppointment ap in t.Appointments ) {
                    if( line.Length > 0 )
                        line.Append(", ");
                    line.Append( ap.Start.ToShortDateString());
                }
                printCtrl.PrintLine("    " + line);

                printCtrl.PrintLine("");
                printCtrl.PrintLine(String.Format("{0} Behandlungen à {1:c} ergibt eine Zwischensumme von {2:c}.",
                    t.Appointments.Count,
                    t.Amount,
                    t.Appointments.Count * t.Amount ));

                printCtrl.PrintLine("");
            }
        }

        private void PrintFooter()
        {
            printCtrl.PrintLine("");
            printCtrl.PrintLine(String.Format("Gesamtsumme: {0:c}", Data.Recipient.Sum));
            printCtrl.FormFeed();

        }

        public override void Init(global::HPSchedule.Datenobjekte.Invoice data)
        {
            base.Init(data);

            
        }
    }
}
