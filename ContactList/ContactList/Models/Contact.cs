using System;
using System.Collections.Generic;
using System.Text;

namespace ContactList.Models
{
    public class Contact
    {
        public Contact(string name, string number)
        {
            Name = name;
            Number = number;
        }
        public string Name { get; }
        public string Number { get; }
    }
}

