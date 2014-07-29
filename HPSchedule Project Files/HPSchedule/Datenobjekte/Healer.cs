using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HPSchedule.Datenobjekte
{
    class Healer
    {
        private long id;

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return Name;
        }
        
        private Color color;
        public Color Color
        {
            get { return color; }
            set { color = value; }
        }
        public void SetColor( int r, int g, int b ) {
            color = Color.FromArgb(r, g, b);
        }
        private dbAction databaseAction;

        public dbAction DatabaseAction
        {
            get { return databaseAction; }
            set { databaseAction = value; }
        }

    }
}
