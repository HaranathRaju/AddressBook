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
            Console.WriteLine("contact added successfully");
        }

        public void editContact(string firstname, string lastname, string address, string city, string state, string zip, string phonenumber, string email)
        {

            foreach (Contact i in contacts)
            {
                if (i.FirstName == firstname && i.LastName == lastname)
                {
                    i.Address = address;
                    i.City = city;
                    i.State = state;
                    i.Zip = zip;
                    i.PhoneNumber = phonenumber;
                    i.Email = email;
                    Console.WriteLine("contact edited succesfully");
                    return;

                }

            }
            Console.WriteLine("contact not found");
        
        }

        public void deleteContact(string firstname,string lastname)
        {
            for (int i = 0; i < contacts.Count;i++)
            {
                if (contacts[i].FirstName.Equals(firstname) && contacts[i].LastName.Equals(lastname))
                {
                    contacts.RemoveAt(i);
                    Console.WriteLine("contact deleted successfully");
                    return;
                }
            }
            Console.WriteLine("contact not found");

        }

    }
}
