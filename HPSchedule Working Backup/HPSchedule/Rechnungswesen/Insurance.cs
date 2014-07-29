using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class Insurance
    {
        public long Id { get; set; }
        public string Label { get; set; }

        public override string ToString()
        {
            return String.Format("{0} ({1})", Label, Id);
        }
    }
}
