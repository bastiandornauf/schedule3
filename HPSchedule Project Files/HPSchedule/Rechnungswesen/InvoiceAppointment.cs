using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class InvoiceAppointment
    {
        public long Id { get; set; }
        
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Label { get; set; }
        public long TreatmentId { get; set; }

        public override string ToString()
        {
            return String.Format("{0}, Treatment {1}", Start.ToShortDateString(), TreatmentId);
        }
    }
}
