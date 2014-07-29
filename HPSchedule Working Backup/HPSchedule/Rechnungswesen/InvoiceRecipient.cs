using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class InvoiceRecipient
    {
        public long PatientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Insurance Insurance { get; set; }

        public int MethodOfPayment { get; set; }
        public string MethodOfPaymentLabel { get; set; }
       

        private List<InvoiceAppointment> _appointments = new List<InvoiceAppointment>();
        public List<InvoiceAppointment> Appointments { get { return _appointments; } }

        private List<InvoiceTreatmentDetails> _treatments = new List<InvoiceTreatmentDetails>();
        public List<InvoiceTreatmentDetails> Treatments { get { return _treatments; } }

        public double Sum { get; set; }


        public override string ToString()
        {
            return String.Format("{0}, {1} ({2})",
                LastName,
                FirstName,
                Appointments.Count);

        }
    }
}
