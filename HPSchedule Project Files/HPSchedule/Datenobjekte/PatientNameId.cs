using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule
{
    /// <summary>
    /// Enthält Patientname und Id
    /// </summary>
    public class PatientNameAndId : ICloneable, IComparable
    {
        string firstname;
        string lastname;
        string title;
        long id;


        public int CompareTo( Object p ) {
            PatientNameAndId pa = p as PatientNameAndId;
            if (pa == null)
                throw new ArgumentException("PatientNameAndId kann nur mit sich selbst verglichen werden.");
             if (lastname.CompareTo( pa.lastname) != 0 )
                 return lastname.CompareTo(lastname);
             else if (firstname.CompareTo( pa.firstname) != 0 )
                 return firstname.CompareTo(pa.firstname);
            return 0;
        }

        public Object Clone()
        {
            return new PatientNameAndId(firstname, lastname, title, id);
        }
        
        public string CompleteName
        {
            get { return title + " " + firstname + " " + lastname; }
        }

        public string ShortName
        {
            get { return firstname + " " + lastname; }
        }

        public string LexicalName
        {
            get { return lastname + ", " + firstname; }
        }

        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string Lastname
        {
            get { return lastname; }
            set { lastname = value; }
        }

        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        public PatientNameAndId(string first, string last, string t, long ident)
        {
            firstname = first;
            lastname = last;
            title = t;
            id = ident;
        }

        public PatientNameAndId(string first, string last) : this(first, last, "", 0) { }

        public PatientNameAndId() : this("", "", "", 0) { }

        public override string ToString()
        {
            return ShortName;
        }

    }
}
