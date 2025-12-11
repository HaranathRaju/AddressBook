using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class AddressBook
    {
        List<Contact> contacts = new List<Contact>();

        public void addContact(Contact c)
        {
            contacts.Add(c);

        }
    }
}
