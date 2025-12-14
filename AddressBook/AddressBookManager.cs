using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace AddressBook
{
    public  class AddressBookManager
    {
        Dictionary<string,AddressBook> addressbooks=new Dictionary<string, AddressBook> ();

        private string dataFile = "AddressBooks.json";

        public void SaveToFile()
        {
            string json = JsonSerializer.Serialize(addressbooks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(dataFile, json);
        }

        public void LoadFromFile()
        {
            if (File.Exists(dataFile))
            {
                string json = File.ReadAllText(dataFile);
                addressbooks = JsonSerializer.Deserialize<Dictionary<string, AddressBook>>(json);
            }
        }

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
        public void displayContactsByCity()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());

            var groupbycitycontacts = allcontacts.GroupBy(n => n.City);

            Dictionary<string, List<Contact>> citydict = groupbycitycontacts.ToDictionary(n => n.Key ,n => n.ToList());

            foreach(var i in citydict)
            {
                Console.WriteLine(i);
                foreach( var j in i.Value)
                {
                    Console.WriteLine(j);
                }
            }
        }

        public void countByState()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());

            var groupbystatecontacts = allcontacts.GroupBy(n => n.State);

            Dictionary<string, int> statedict = groupbystatecontacts.ToDictionary(n => n.Key, n => n.Count());

            foreach(var i in statedict)
            {
                Console.WriteLine("Contacts from "+i.Key +" : "+i.Value);
            }
        }
        public void countByCity()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());

            var groupbycitycontacts = allcontacts.GroupBy(n => n.City);

            Dictionary<string, int> citydict = groupbycitycontacts.ToDictionary(n => n.Key, n => n.Count());

            foreach (var i in citydict)
            {
                Console.WriteLine("Contacts from "+i.Key + " : " + i.Value);
            }
        }

        public void sortByName()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());

            var sortbyname = allcontacts.OrderBy(n => n.FirstName).ToList();

            foreach (var i in sortbyname)
            {
                Console.WriteLine(i);
            }
        }

        public void sortByState()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());
            var sortedbystate = allcontacts.OrderBy(n => n.State).ToList();

            foreach (var i in sortedbystate)
            {
                Console.WriteLine(i);
            }
        }

        public void sortByCity()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());
            var sortbycity = allcontacts.OrderBy(n => n.City).ToList();

            foreach (var i in sortbycity)
            {
                Console.WriteLine(i);
            }
        }

        public void sortByZip()
        {
            var allcontacts = addressbooks.Values.SelectMany(n => n.getContacts());

            var sortbyzip = allcontacts.OrderBy(n => n.Zip);

            foreach( var i in sortbyzip)
            {
                Console.WriteLine(i);
            }
        }
        

    }
}
