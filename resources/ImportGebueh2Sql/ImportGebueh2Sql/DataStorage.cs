using System;
using System.Collections.Generic;
using System.Text;

namespace ImportGebueh2Sql
{
    #region DataStorageClasses

    public class Eintrag
    {
        public int id;
        public Nummer n;
        public string description;
        public List<double> preise;

        public Eintrag()
        {
            preise = new List<double>();
            n = new Nummer();
        }
    }
    public class Gruppe
    {
        public int id;
        public string ident;
        public string label;
        public List<Nummer> artikel;

        public Gruppe()
        {
            artikel = new List<Nummer>();
        }

        public String getArtikel(String separator) {
            StringBuilder r = new StringBuilder();
            foreach (Nummer n in artikel)
                r.Append((r.Length == 0 ? "" : separator) + n.ToString());
            return r.ToString();
        }

    }
    public class Nummer
    {
        public int punkt = 0;
        public int unterpunkt = 0;
        public int variante = 0;

        public Nummer()
        {
        }
        public Nummer(string s)
        {
            string[] result = s.Trim().Split('.');
            if (result.GetLength(0) > 0)
                try
                {
                    punkt = Int32.Parse(result[0]);
                }
                catch
                {
                    punkt = 0;
                }
            if (result.GetLength(0) > 1)
                try
                {
                    unterpunkt = Int32.Parse(result[1]);
                }
                catch
                {
                    unterpunkt = 0;
                }
            if (result.GetLength(0) > 2)
                try
                {
                    variante = Int32.Parse(result[2]);
                }
                catch
                {
                    variante = 0;
                }




        }

        public override string ToString()
        {
            return String.Format("{0}.{1}.{2}", punkt, unterpunkt, variante);
        }

        internal int CompareTo(Nummer n)
        {
            if (punkt > n.punkt) return 1;
            if (punkt < n.punkt) return -1;

            if (unterpunkt > n.unterpunkt) return 1;
            if (unterpunkt < n.unterpunkt) return -1;

            if (variante > n.variante) return 1;
            if (variante < n.variante) return -1;

            return 0;
        }
    }
    public class Abrechnungsart
    {
        public string label;
        public int id;
    }

    public class Address
    {
        public int id;
        public string street;
        public string additionlInfo;
        public string postcode;
        public string place;
        public string country;
    }
    public class Contacts
    {
        public int id;
        public string label;
        public string contactInfo;

        public Contacts(string i, string l)
        {
            label = l;
            contactInfo = i;
        }
    }

    public class Patient
    {
        public int id;
        public Address address;
        public List<Contacts> contacts;
        public List<Termin> termine;
        public DateTime dateofBirth;
        public string comments;
        public bool male;
        public string title;
        public string firstname;
        public string lastname;
        public string occupation;
        public int methodOfPayment;
        public int insuranceId;
        public string diagnosis;
        public string publicComments;
        public string insurance;

        public Patient()
        {
            address = new Address();
            contacts = new List<Contacts>();
            termine = new List<Termin>();
        }
        public void GetInsuranceId(SqlHelper mySql)
        {
            insuranceId = mySql.GetNumeric("insurance", "id", "label=" + SqlHelper.QuoteMarks(insurance));
        }
    }

    public class Termin
    {
        public int id;
        public int patientId;
        public DateTime startDate;
        public DateTime endDate;
        public string behandlung;
        public string diagnose;
        public int status;
        public int merkerFlag;
        public bool Merker
        {
            get { return (merkerFlag == 1) ? true : false; }
        }

        public void SetDates(int timeindex)
        {
            int ti = timeindex;
            int year, month, day, hour, minute;
            //wandelt von Timeindex nach Datum&Uhrzeit um
            year = ti / 35712;
            ti -= year * 35712;
            year += 1900;

            month = ti / 2976;
            ti -= month * 2976;
            month++;

            day = ti / 96;
            ti -= day * 96;
            day++;

            hour = ti / 4;
            ti -= hour * 4;

            minute = ti * 15;

            startDate = new DateTime(year, month, day, hour, minute, 0);

            endDate = new DateTime(year, month, day, hour, minute, 0);
            endDate = endDate.AddMinutes(15);
        }
    }

    #endregion
}
