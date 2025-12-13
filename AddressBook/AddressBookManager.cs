using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public  class AddressBookManager
    {
        Dictionary<string,AddressBook> addressbooks=new Dictionary<string, AddressBook> ();

        


        public void addAddressBook(string name)
        {
            if (addressbooks.ContainsKey(name))
            {
                Console.WriteLine("Address Book already exists!");
                return;
            }
            addressbooks[name] = new AddressBook();
            Console.WriteLine("Address Book created successfully");
        }

        public AddressBook getAddressBook(string name)
        {
            if (addressbooks.ContainsKey(name))
            {
                return addressbooks[name];

            }
            Console.WriteLine("Address Book not found!");
            return null;
        }

        public void displayAddressBook()
        {
            if (addressbooks.Count==0)
            {
                Console.WriteLine("addressbooks is empty");
                return;
            }
            foreach(var i in addressbooks.Keys)
            {
                Console.WriteLine(i);
            }
        }

        public void searchContactByCity(string city)
        {
            bool found = false;
            foreach(var i in addressbooks.Values)
            {
                foreach(var j in i.getContacts())
                {
                    if (j.City.Equals(city))
                    {
                        Console.WriteLine(j);
                        found = true;
                    }
                }
            }
            if (!found)
            {
                Console.WriteLine("contact not found");
            }
        }

        public void displayContactsByState()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());

            var groupbystatecontacts = allcontacts.GroupBy(p => p.State);

            Dictionary<string, List<Contact>> statedict = groupbystatecontacts.ToDictionary(n => n.Key, n => n.ToList());

            foreach( var i in statedict)
            {
                Console.WriteLine(i.Key);
                foreach(var j in i.Value)
                {
                    Console.WriteLine(j);   
                    

                }
            }
        }

    }
}
