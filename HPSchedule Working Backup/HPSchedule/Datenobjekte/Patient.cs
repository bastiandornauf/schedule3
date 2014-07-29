using System;
using System.Collections.Generic;
using System.Text;

namespace HPSchedule
{
    public class Patient : ICloneable
    {
        public Object Clone()
        {
            Patient p = new Patient();

            p.id = id;
            p.name = (PatientNameAndId) name.Clone();
            p.male = male;
            p.birth = birth;
            p.death = death;
            p.occupation = occupation;
            foreach (Address a in addressList)
                p.addressList.Add((Address)a.Clone());
            foreach (Contact c in contactList)
                p.contactList.Add((Contact)c.Clone());
            p.comments = comments;
            p.publicComments = publicComments;
            p.insurance = insurance;
            p.insuranceId = insuranceId;
            p.methodOfPayment = methodOfPayment;
            p.methodOfPaymentId = methodOfPaymentId;
            p.healer = healer;
            p.healerId = healerId;


            return p;
        }
        
        
        private long id;
        public long Id
        {
            get { return id; }
            set { id = value; }
        }

        private PatientNameAndId name;
        public PatientNameAndId Name
        {
            get { return name;            
            }
            set { name = value; }
        }
	        
        private bool male;
        public bool Male
        {
            get { return male;}
            set { male = value; }
        }

        DateTime birth;
        public DateTime DateOfBirth
        {
            get { return birth;}
            set { birth = value; }
        }

        DateTime death;
        bool isDead;
        public DateTime DateOfDeath
        {
            get { return death;}
            set { death = value; }
        }

        public bool IsDead
        {
            get { return isDead; }
            set { isDead = value; }
        }

        string occupation;
        public string Occupation
        {
            get { return occupation;}
            set { occupation = value; }
        }

        List<Address> addressList;
        public List<Address> Addresses
        {
            get { return addressList;}
        }

        public Address InvoiceAdress
        {
            get
            {
                foreach (Address a in addressList)
                    if (a.UseForInvoice)
                        return a;
                return new Address();
            }
                    
        }

        List<Contact> contactList;
        public List<Contact> Contacts
        {
            get { return contactList;}
        }

        string comments;
        public string Comments
        {
            get { return comments;}
            set { comments = value; }
        }

        string publicComments;
        public string PublicComments
        {
            get { return publicComments;}
            set { publicComments = value; }
        }
        
        long insuranceId;
        public long InsuranceId
        {
            get { return insuranceId;}
            set { insuranceId = value; }
        }
        string insurance;
        public string Insurance
        {
            get { return insurance;}
            set { insurance = value; }
        }

        int methodOfPaymentId;
        public int MethodOfPaymentId
        {
            get { return methodOfPaymentId;}
            set { methodOfPaymentId = value; }
        }
        string methodOfPayment;
        public string MethodOfPayment
        {
            get { return methodOfPayment;}
            set { methodOfPayment = value; }
        }

        long healerId;
        public long HealerId
        {
            get { return healerId;}
            set { healerId = value; }
        }
        string healer;
        public string Healer
        {
            get { return healer;}
            set { healer = value; }
        }

        public Patient()
        {
            addressList = new List<Address>();
            contactList = new List<Contact>();
            
            name = new PatientNameAndId();

            birth = DateTime.MinValue;
            death = DateTime.MinValue;
        }
    }

    public class Address : ICloneable
    {
        long id;
        public long Id
        {
            get { return id;}
            set { id = value; }
        }

        string street;
        public string Street
        {
            get { return street; }
            set { street = value; }
        }

        string additionalInfo;
        public string AdditionalInfo
        {
            get { return additionalInfo; }
            set { additionalInfo = value; }
        }

        string postcode;
        public string PostCode
        {
            get { return postcode; }
            set { postcode= value; }
        }

        string place;
        public string Place
        {
            get { return place; }
            set { place= value; }
        }

        string country;
        public string Country
        {
            get { return country; }
            set { country= value; }
        }

        bool useForInvoice;
        public bool UseForInvoice
        {
            get { return useForInvoice; }
            set { useForInvoice= value; }
        }

        public bool toBeDeleted = false;

        public string ToString(bool showDefault)
        {
            return String.Format("{0}{1}, {2}, {3}{4} / {5}",
                showDefault ? (useForInvoice ? "[X]" : "[ ]") : (""),
                postcode,
                place,
                street,
                additionalInfo != "" ? ", " + additionalInfo : "",
                country);
        }
        public override string ToString()
        {
            return ToString(false);
        }
        public string ToStringMultiline()
        {
            return String.Format("{0}{1}{2} {3}{4}",
                street + Environment.NewLine,
                additionalInfo != "" ?  additionalInfo+Environment.NewLine : "",
                postcode,
                place + Environment.NewLine,
                country.ToUpper()
                );

        }

        public string ToStringMultilineForList()
        {
            string s = "";

            if (useForInvoice)
                s = "+" + Environment.NewLine;
            else
                s = "-" + Environment.NewLine;

            s += street ;

            if (additionalInfo != "")
                s += Environment.NewLine + additionalInfo;

            s += Environment.NewLine + postcode + " " + place;

            if (country != "")
                s += Environment.NewLine + country.ToUpper();

            return s;
        }

        public Object Clone()
        {
            Address a = new Address();

            a.id = id;
            a.street = street;
            a.additionalInfo = additionalInfo;
            a.postcode = postcode;
            a.place = place;
            a.country = country;
            a.useForInvoice = useForInvoice;
            a.toBeDeleted = toBeDeleted;

            return a;
        }
    }

    public class Contact : ICloneable
    {
        public Object Clone()
        {
            Contact c = new Contact(label, contactInfo, id);
            c.toBeDeleted = toBeDeleted;
            return c;
        }

        public Contact(string pLabel, string pInfo, long pId)
        {
            id = pId;
            label = pLabel;
            contactInfo = pInfo;
            toBeDeleted = false;
        }

        public Contact() : this("", "", 0) { }
        public bool toBeDeleted;
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
        
        private string contactInfo;
        public string ContactInfo
        {
            get { return contactInfo; }
            set { contactInfo  = value; }
        }

        public override string ToString()
        {
            return label + ": " + contactInfo;
        }
	
    }

}
