using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookXMLParser
{
    public class Contact
    {
        private string _contactID;
        private string _givenName;
        private string _surName;
        private string _homePhone;
        private string _mobilePhone;
        private string _streetAddress;
        private string _postalCode;
        private string _country;
        private string _state;
        private string _city;
        private string _notes;

        public string ContactID
        {
            get { return _contactID; }
            set { _contactID = value; }
        }
        public string GivenName
        {
            get { return _givenName; }
            set { _givenName = value; }
        }
        public string SurName
        {
            get { return _surName; }
            set { _surName = value; }
        }
        public string HomePhone
        {
            get { return _homePhone; }
            set { _homePhone = value; }
        }
        public string MobilePhone
        {
            get { return _mobilePhone; }
            set { _mobilePhone = value; }
        }
        public string StreetAddress
        {
            get { return _streetAddress; }
            set { _streetAddress = value; }
        }
        public string PostalCode
        {
            get { return _postalCode; }
            set { _postalCode = value; }
        }
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }
        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        public string Notes
        {
            get { return _notes; }
            set { _notes = value; }
        }

        public Contact() {
            _contactID = "";
            _givenName = "";
            _surName = "";
            _homePhone = "";
            _mobilePhone = "";
            _streetAddress = "";
            _postalCode = "";
            _country = "";
            _state = "";
            _city = "";
            _notes = "";
        }

        public bool Equals( Contact contact ) {
            return (_contactID == contact.ContactID) &&
                   (_givenName == contact.GivenName) &&
                   (_surName == contact.SurName) &&
                   (_homePhone == contact.HomePhone) &&
                   (_mobilePhone == contact.MobilePhone) &&
                   (_streetAddress == contact.StreetAddress) &&
                   (_postalCode == contact.PostalCode) &&
                   (_country == contact.Country) &&
                   (_state == contact.State) &&
                   (_city == contact.City) &&
                   (_notes == contact.Notes);
        }

        public override string ToString()
        {
            return this.GivenName + " " + this.SurName;
        }
    }
}
