using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class Group
    {
        public long Id { get; set; }
        public string Label { get; set; }
        
        private List<Rechnungswesen.Item> items = new List<Item>();
        public List<Rechnungswesen.Item> Items
        {
            get { return items; }
        }

        public double Sum( long insuranceId ) {
            double sum = 0.0;

            foreach( Item i in items )
                sum += i.Fees.GetAmount( insuranceId );

            return sum;
        }

        public override string ToString()
        {
            return String.Format("{0} ({1} items)", Label, Items.Count);
        }
    }
}
