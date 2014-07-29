using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class InvoiceItem : IUniqueDatabasedObject
    {

        public InvoiceItem()
        {
            db = dbAction.none;
            fees = new List<Fee>();
            nr = new TariffNumber();
        }

        public override string ToString()
        {
            return desc;
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private TariffNumber nr;

        public TariffNumber Number
        {
            get { return nr; }
            set { nr = value; }
        }


        private string desc;

        public string Description
        {
            get { return desc; }
            set { desc = value; }
        }

        private List<Fee> fees;

        public List<Fee> Fees
        {
            get { return fees; }
        }
        
        private dbAction db;

        public dbAction DatabaseAction
        {
            get { return db; }
            set { db = value; }
        }


        internal Fee GetFee(long insuranceId)
        {
            foreach (Fee f in fees)
                if (insuranceId == f.Insurance)
                    return f;
            return null;
        }

        #region IDatabased Member


        public void SaveToDatabase()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void LoadFromDatabase(long id)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }

    public class TariffNumber : IComparable 
    {
        public TariffNumber(int vMain, int vSub)
        {
            main = vMain;
            sub = vSub;
        }

        public TariffNumber() : this(0, 0) { }

        private int main;

        public int Main
        {
            get { return main; }
            set { main = value; }
        }

        private int sub;

        public int Sub
        {
            get { return sub; }
            set { sub = value; }
        }

        public override string ToString()
        {
            if (main == 0)
                return "";
            else if (sub == 0)
                return main.ToString();
            else
                return String.Format("{0}.{1}", main, sub);
        }

        #region IComparable Member

        public int CompareTo(object obj)
        {
            TariffNumber n = obj as TariffNumber;
            if (n == null)
                throw new ArgumentException("Falscher Typ");

            if (main == n.main)
                return sub.CompareTo(n.sub);
            else
                return main.CompareTo(n.main);
        }

        #endregion

        internal static bool CheckFormat(string p)
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("^[0-9]+[.]?[0-9]*$");
            return regex.IsMatch(p);
        }

        public void Parse( string value ) 
        {
            string s = value.Trim();

            string[] substrings = s.Split('.');

            if( substrings.Length <1 || substrings.Length >2 ) {
                throw new ArgumentException("Der string value enthält keine Number");
            }

            try{
                main = Int32.Parse( substrings[0].Trim() );
                
                if (substrings.Length == 2 && substrings[1].Trim() != "")
                    sub = Int32.Parse(substrings[1].Trim());
                else
                    sub = 0;

            } catch
            {
                throw new ArgumentException("Der string value enthält keine Number");
            }

        }

        public string ToStringVerbose()
        {
            return String.Format("{0}.{1}", main, sub);
        }
    }
}
