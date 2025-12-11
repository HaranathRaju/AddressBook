using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AddressBook
{
    public class Contact
    {
  
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        string emailpattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        string phonenumberpattern= @"^\d{10}$";



        public Contact() { }

        public Contact(string firstName, string lastName, string address, string city,
                       string state, string zip, string phoneNumber, string email)
        {

            if (!Regex.IsMatch(phoneNumber,phonenumberpattern))
            {
                throw new InvalidPhoneNumberException("phone number is invalid");

            }
            if (!Regex.IsMatch(email,emailpattern))
            {
                throw new InvaliEmailException("email is invalid");

            }

            FirstName = firstName;
            LastName = lastName;
            Address = address;
            City = city;
            State = state;
            Zip = zip;
            PhoneNumber = phoneNumber;
            Email = email;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} Address: {Address} {City} {State} {Zip} PhoneNumber: {PhoneNumber} Email: {Email}";
        }
    }
}
