using AddressBook;
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
            AddressBook addressbook = null;
            AddressBookManager addressbookmanager=new AddressBookManager();


            while (true)
            {
                Console.WriteLine("1.Add Multiple addressbook");
                Console.WriteLine("2..Add contact");
                Console.WriteLine("3..Edit contact");
                Console.WriteLine("4..Delete contact");
                Console.WriteLine("5..Display contacts");
                Console.WriteLine("6.Display Addressbook");
                Console.WriteLine("7.search contacts by city");
                Console.WriteLine("8.display contacts by state");
                Console.WriteLine("9.display contacts by city");
                Console.WriteLine("10.display count by state");
                Console.WriteLine("11.display count by city");
                Console.WriteLine("12.Sort contacts by name");
                Console.WriteLine("13.sort contacts by state");
                Console.WriteLine("14.sort contacts by city");
                Console.WriteLine("15.sort contacts by zip");

                Console.WriteLine("enter choice: ");
                int choice = Convert.ToInt32(Console.ReadLine());
                try
                {

                    switch (choice)
                    {
                        case 1:
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
                        case 2:
                            {
                                if (addressbook == null)
                                {
                                    Console.WriteLine("first select addressbook");
                                    break;
                                }
                                else
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

                            }

                        case 3:
                            {
                                if (addressbook == null)
                                {
                                    Console.WriteLine("select the addressbook");
                                    break;
                                    
                                }

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
                        case 4:
                            {
                                if (addressbook == null)
                                {
                                    Console.WriteLine("no contact found");
                                    break;
                                }
                                Console.WriteLine("enter first name: ");
                                string firstname = Console.ReadLine();
                                Console.WriteLine("enter last name: ");
                                string lastname = Console.ReadLine();
                                addressbook.deleteContact(firstname, lastname);
                                break;

                            }
                        case 5:
                            {
                                if (addressbook==null)
                                {
                                    Console.WriteLine("select the addressbook");
                                    break;
                                }
                                addressbook.displayContacts();
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
                                Console.WriteLine("displaying contacts by state");
                                addressbookmanager.displayContactsByState();
                                break;

                            }
                        case 9:
                            {
                                Console.WriteLine("displaying contacts by city");
                                addressbookmanager.displayContactsByCity();
                                break;

                            }
                        case 10:
                            {
                                addressbookmanager.countByState();
                                break;
                            }
                        case 11:
                            {
                                addressbookmanager.countByCity();
                                break;
                            }
                        case 12:
                            {
                                Console.WriteLine("contacts sorted by Name ");
                                addressbookmanager.sortByName();
                                break;
                            }
                        case 13:
                            {
                                Console.WriteLine("contacts sorted by State");
                                addressbookmanager.sortByState();
                                break;
                            }
                        case 14:
                            {
                                Console.WriteLine("contacts sorted by City");
                                addressbookmanager.sortByCity();
                                break;
                            }
                        case 15:
                            {
                                Console.WriteLine("contacts sorted by Zip");
                                addressbookmanager.sortByZip();
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


