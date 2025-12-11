using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine(" Welcome To AddressBook ");
            AddressBook addressbook = new AddressBook();
            while (true)
            {
                Console.WriteLine("1.Add contact");

                Console.WriteLine("enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            Console.WriteLine("enter first name: ");
                            string firstname=Console.ReadLine();
                            Console.WriteLine("enter last name: ");
                            string lastname=Console.ReadLine();   
                            Console.WriteLine("enter address: ");
                            string address=Console.ReadLine();
                            Console.WriteLine("enter city: ");
                            string city=Console.ReadLine(); 
                            Console.WriteLine("enter state: ");
                            string state=Console.ReadLine();
                            Console.WriteLine("enter zip: ");
                            string zip=Console.ReadLine();
                            Console.WriteLine("enter phone number: ");
                            string phonenumber=Console.ReadLine();  
                            Console.WriteLine("enter email: ");
                            string email=Console.ReadLine();
                            Contact c = new Contact(firstname, lastname, address, city, state, zip, phonenumber, email);
                            addressbook.addContact(c);
                            break;

                        }
                }
            }

        }
    }
}