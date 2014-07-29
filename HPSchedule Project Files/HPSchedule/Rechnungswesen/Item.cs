using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Rechnungswesen
{
    public class Item : IComparable
    {
        public long Id { get; set; }
        public string Description { get; set; }
        public int TariffMain { get; set; }
        public int TariffSub { get; set; }
        public long InvoiceId { get; set; } // wofür das gut war weiß ich nicht mehr

        private FeeList fees = new FeeList();
        public FeeList Fees { get { return fees; } }


        public string Tariff
        {
            get
            {
                if (TariffMain == 0)
                    return String.Empty;
                else
                    return String.Format("{0}.{1}", TariffMain, TariffSub);
            }
        }
        public override string ToString()
        {
            if (Tariff == String.Empty)
                return Description;
            else
                return Tariff + " " + Description;
        }



        #region IComparable Member

        public int CompareTo(object obj)
        {
            Item o = (Item)obj;

            if (TariffMain != o.TariffMain)
                return TariffMain.CompareTo(o.TariffMain);
            else if (TariffSub != o.TariffSub)
                return TariffSub.CompareTo(o.TariffSub);
            else
                return Description.CompareTo(o.Description);
        }

        #endregion
    }
}
