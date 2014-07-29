using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using HPSchedule.Rechnungswesen;

namespace HPSchedule.Rechnungswesen
{
    public class InvoiceSelector : IComparable
    {
        public InvoiceSelector(InvoiceRecipient r)
        {
            Recipient = r;   
            
        }
        
        public bool GenerateInvoice { get; set; }
        public string LastName { get { return Recipient.LastName; } }
        public string FirstName { get { return Recipient.FirstName; } }
        public int NumberOfAppointments { get { return Recipient.Appointments.Count; } }
        public int SinceLastAppointment { get { return CalcDaysSinceLastAppointment(); } }

        private int CalcDaysSinceLastAppointment()
        {
            DateTime lastDate = DateTime.MinValue;

            foreach (InvoiceAppointment a in Recipient.Appointments)
                if (a.Start > lastDate)
                    lastDate = a.Start;

            TimeSpan diff = DateTime.Now - lastDate;

            return (int)diff.TotalDays;
        }

        public double Total { get { return Recipient.Sum; } }

        
        [Browsable(false)]
        public InvoiceRecipient Recipient { get; set; }


        public void CheckState(int count, double total, int daysSince)
        {
            GenerateInvoice =
                (NumberOfAppointments >= count || Total >= total || SinceLastAppointment >= daysSince);
        }

        #region IComparable Member

        public int CompareTo(object obj)
        {
            InvoiceSelector other = (InvoiceSelector)obj;
            if (other == null)
                return 0;

            if (this.LastName.CompareTo(other.LastName) != 0)
                return this.LastName.CompareTo(other.LastName);
            else
                return this.FirstName.CompareTo(other.FirstName);
        }

        #endregion
    }
}
