using System;
using System.Collections.Generic;
using System.Text;
using HPSchedule.Rechnungswesen;

namespace HPSchedule.Datenobjekte
{
    public class Invoice
    {
        // Todo: Rechnungsobjekt erstellen

        public Invoice()
        {
            PrintingMode = PrintingMode.LinePrinter; //TODO: set default to fancy, implement fancy
        }

        public DateTime invoiceDate = DateTime.Now;
        public long invoiceNr = 123456;//TODO: setze invoiceNr
        
        public InvoiceRecipient Recipient { get; set; }
        public Patient Patient { get; set; }
        
        public Address InvoiceAddress { get { return Patient.InvoiceAdress; } }
        
        public PrintingMode PrintingMode { get; set; }

       

        public void Generate(InvoiceRecipient recipient)
        {
            invoiceDate = DateTime.Now;
            
            Recipient = recipient;
            Patient = DoDatabaseMagic.LadePatient(recipient.PatientId);           
        }

        public void Print()
        {
            InvoicePrintDevice device;
            if (PrintingMode == PrintingMode.LinePrinter)
                device = new LinePrintDevice();
            else
                //device zuweisen
                throw new Exception("Fancy-PrintingMode not yet implemented.");
            device.Init(this);
            device.Print();
        }

        public void Save()
        {
            System.Xml.Serialization.XmlSerializer mySerializer = new System.Xml.Serialization.XmlSerializer(typeof(Invoice));
            // To write to a file, create a StreamWriter object.
            System.IO.StreamWriter myWriter = new System.IO.StreamWriter(this.Filename);
            mySerializer.Serialize(myWriter, this);
            myWriter.Close();
        }

        public string Filename { 
            get {
                return System.IO.Path.Combine( (new Properties.Settings()).pathToInvoiceFiles, invoiceDate.ToLexOrder() + String.Format(" {0:0000000}",Patient.Id)+ ".xml");
            }}

        private void WriteToDatabase()
        {
            // perform nitpickking 
        }
    }

    public enum PrintingMode
    {
        LinePrinter,
        Fancy
    }
}
