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
            AddressBookManager addressbookmanager=new AddressBookManager();


            while (true)
            {
                Console.WriteLine("1.Add contact");
                Console.WriteLine("2.Edit contact");
                Console.WriteLine("3.Delete contact");
                Console.WriteLine("4.Display contacts");
                Console.WriteLine("5.Add Multiple addressbook");
                Console.WriteLine("6.Display Addressbook");
                Console.WriteLine("7.search contacts by city");
                Console.WriteLine("8.display contacts by state");
                Console.WriteLine("9.display contacts by city");

                Console.WriteLine("enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {

                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("enter first name: ");
                                string firstname = Console.ReadLine();
                                Console.WriteLine("enter last name: ");
                                string lastname = Console.ReadLine();
                                Console.WriteLine("enter address: ");
                                string address = Console.ReadLine();
                                Console.WriteLine("enter city: ");
                                string city = Console.ReadLine();
                                Console.WriteLine("enter state: ");
                                string state = Console.ReadLine();
                                Console.WriteLine("enter zip: ");
                                string zip = Console.ReadLine();
                                Console.WriteLine("enter phone number: ");
                                string phonenumber = Console.ReadLine();
                                Console.WriteLine("enter email: ");
                                string email = Console.ReadLine();
                                Contact c = new Contact(firstname, lastname, address, city, state, zip, phonenumber, email);
                                addressbook.addContact(c);
                                break;

                            }
                        case 2:
                            {
                                Console.WriteLine("enter first name: ");
                                string firstname = Console.ReadLine();
                                Console.WriteLine("enter last name: ");
                                string lastname = Console.ReadLine();
                                Console.WriteLine("enter address: ");
                                string address = Console.ReadLine();
                                Console.WriteLine("enter city: ");
                                string city = Console.ReadLine();
                                Console.WriteLine("enter state: ");
                                string state = Console.ReadLine();
                                Console.WriteLine("enter zip: ");
                                string zip = Console.ReadLine();
                                Console.WriteLine("enter phone number: ");
                                string phonenumber = Console.ReadLine();
                                Console.WriteLine("enter email: ");
                                string email = Console.ReadLine();
                                addressbook.editContact(firstname, lastname, address, city, state, zip, phonenumber, email);
                                break;

                            }
                        case 3:
                            {
                                Console.WriteLine("enter first name: ");
                                string firstname = Console.ReadLine();
                                Console.WriteLine("enter last name: ");
                                string lastname = Console.ReadLine();
                                addressbook.deleteContact(firstname, lastname);
                                break;

                            }
                        case 4:
                            {
                                addressbook.displayContacts();
                                break;
                            }
                        case 5: 
                            {
                                Console.Write("Enter AddressBook name: ");
                                string name = Console.ReadLine();

                                if (addressbookmanager.getAddressBook(name) == null)
                                {
                                    addressbookmanager.addAddressBook(name);
                                }

                                addressbook = addressbookmanager.getAddressBook(name);
                                Console.WriteLine($"AddressBook {name} selected");
                                break;
                            }

                        case 6: 
                            {
                                addressbookmanager.displayAddressBook();

                                Console.Write("Enter AddressBook name to select: ");
                                string name = Console.ReadLine();

                                if (!string.IsNullOrEmpty(name))
                                {
                                    addressbook = addressbookmanager.getAddressBook(name);
                                    if (addressbook != null)
                                        Console.WriteLine($"AddressBook '{name}' selected");
                                }

                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("enter city name: ");
                                string city=Console.ReadLine();
                                addressbookmanager.searchContactByCity(city);
                                break;
                            }
                        case 8:
                            {
                                addressbookmanager.displayContactsByState();
                                break;

                            }
                    }

                }
                catch (InvalidPhoneNumberException e) 
                {
                    Console.WriteLine(e.Message);
                }
                catch(InvaliEmailException e)
                {
                    Console.WriteLine(e.Message);   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}