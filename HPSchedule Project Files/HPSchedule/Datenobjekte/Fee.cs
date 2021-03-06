using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class Fee : IUniqueDatabasedObject
    {
        public Fee()
        {
            db = dbAction.none;
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { if (id != value) db = dbAction.modified;  id = value; }
        }

        private long insurance;

        public long Insurance
        {
            get { return insurance; }
            set { if (insurance != value) db = dbAction.modified; insurance = value; }
        }

        private double amount;

        public double Amount
        {
            get { return amount; }
            set { if (amount != value) db = dbAction.modified;  amount = value; }
        }

        private dbAction db;

        public dbAction DatabaseAction
        {
            get { return db; }
            set { db = value; }
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
}
