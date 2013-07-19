using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookXMLParser
{
    public class AddressBook : Contact
    {
        private List<Contact> _contactList = new List<Contact>();

        public void addContact(Contact contact)
        {
            _contactList.Add(contact);
        }
        public void removeContact(Contact contact)
        {
            _contactList.Remove(contact);
        }
        public void removeAllContacts()
        {
            _contactList.Clear();
        }
        public List<Contact> getContacts
        {
            get { return _contactList; }
        }
        public int getContactsSize()
        {
            return _contactList.Count;
        }
    }
}
