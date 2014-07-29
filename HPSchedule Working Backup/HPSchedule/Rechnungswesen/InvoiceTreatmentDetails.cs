using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class InvoiceTreatmentDetails
    {
        public long Id { get; set; }

        public double Amount { get; set; }

        private List<InvoiceAppointment> _appointments = new List<InvoiceAppointment>();
        public List<InvoiceAppointment> Appointments { get { return _appointments; } }

        private List<Item> _items = new List<Item>();
        public List<Item> Items { get { return _items; } }
    }
}
