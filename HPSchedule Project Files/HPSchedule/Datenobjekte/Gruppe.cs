using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class Group : IUniqueDatabasedObject
    {
        public Group()
        {
            items = new List<long>();
            db = dbAction.none;
        }
        public override string ToString()
        {
            return label;
        }
        private string label;

        public string Label
        {
            get { return label; }
            set { label = value; }
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private List<long> items;
        public List<long> InvoiceItems
        {
            get { return items; }
        }

        private dbAction db;

        public dbAction DatabaseAction
        {
            get { return db; }
            set { db = value; }
        }


        public string GetItemsAsString()
        {
            string s = "";
            foreach (long l in items)
            {
                if (s != "")
                    s += ", ";
                s += l.ToString();
            }
            return s;
        }
        public string GetItemsAsMultilineString()
        {
            string s = "";
            foreach (long l in items)
            {
                if (s != "")
                    s += Environment.NewLine;
                s += l.ToString();
            }
            return s;
        }

        public void SaveToDatabase()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void LoadFromDatabase(long id)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
