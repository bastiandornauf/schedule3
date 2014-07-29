using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class Accounting : IDatabasedCollection
    {
        private List<InvoiceItem> items;
        public List<InvoiceItem> Items
        {
            get { return items; }
        }

        private List<Insurance> insurances;
        public List<Insurance> Insurances
        {
            get { return insurances; }
        }

        private List<Group> groups;
        public List<Group> Groups
        {
            get { return groups; }
        }

        public Accounting()
        {
            items = new List<InvoiceItem>();
            insurances = new List<Insurance>();
            groups = new List<Group>();

            db = dbAction.none;
        }

        private dbAction db;
        public dbAction DatabaseAction
        {
            get { return db; }
            set { db = value; }
        }

        public void LoadFromDatabase()
        {
            DoDatabaseMagic.LoadAccountingFromDB( this);
            this.db = dbAction.none;
        }

        public void SaveToDatabase()
        {
            if (this.db != dbAction.none)
            {
                DoDatabaseMagic.SaveAccountingToDB(this);
                this.db = dbAction.none;
            }
        }

        internal string SumGroupFeeAsString(Group g, int insuranceIndex)
        {
            if (insuranceIndex < 0 || insuranceIndex > insurances.Count)
            {
                return "?";
            }

            return String.Format("{0:c}", SumGroupFee(g, insuranceIndex));

        }
        internal double SumGroupFee(Group g, int insuranceIndex)
        {
            double sum = 0;
            if (insuranceIndex < 0 || insuranceIndex > insurances.Count)
            {
                throw new ArgumentException("Index zeigt nicht auf bekannte Insurance");
            }

            foreach (long itemId in g.InvoiceItems)
            {
                InvoiceItem i = GetItem(itemId);
                if (i != null)
                {
                    if( insuranceIndex < i.Fees.Count )
                        sum += i.Fees[insuranceIndex].Amount;
                }
                //else
                    //throw new ApplicationException("Gruppe enthält unbekanntes InvoiceItem");

            }

            return sum;
        }

        internal Insurance GetInsurance(long p)
        {
            foreach (Insurance i in insurances)
            {
                if (p == i.Id)
                    return i;
            }
            return null;
        }
        
        internal InvoiceItem GetItem(long itemId)
        {
            foreach (InvoiceItem i in items)
            {
                if (i.Id == itemId)
                    return i;
            }
            return null;
        }

        internal Group GetGroup(long groupId)
        {
            foreach (Group g in groups)
            {
                if (g.Id == groupId)
                    return g;
            }
            return null;
        }

    }
}
