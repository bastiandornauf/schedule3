using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    public class Insurance : IUniqueDatabasedObject
    {

        public Insurance()
        {
            db = dbAction.none;
        }

        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private string label;

        public string Label
        {
            get { return label; }
            set { label = value; }
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
