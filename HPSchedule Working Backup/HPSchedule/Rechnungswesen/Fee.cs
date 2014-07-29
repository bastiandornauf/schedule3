using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class Fee
    {
        public double Amount { get; set; }
        public long InsuranceId { get; set; }

        public override string ToString()
        {
            return String.Format("{0:c}", Amount);
        }
    }
}
