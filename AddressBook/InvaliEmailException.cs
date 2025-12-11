using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBook
{
    public  class InvaliEmailException : Exception
    {
        public InvaliEmailException(string msg) : base(msg)
        {

        }

    }
   
}
