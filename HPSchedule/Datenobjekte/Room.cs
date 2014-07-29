using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule.Datenobjekte
{
    class Room
    {
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

        public override string ToString()
        {
            return Label;
        }
        private dbAction databaseAction;

        public dbAction DatabaseAction
        {
            get { return databaseAction; }
            set { databaseAction = value; }
        }

    }
}
