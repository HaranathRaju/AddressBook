using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public  class InvalidPhoneNumberException : Exception
    {
        public InvalidPhoneNumberException(string msg) : base(msg) 
        {

        }
    }
}
