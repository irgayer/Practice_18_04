using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_04
{
    public class User : Entity
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public void Print()
        {
            Console.WriteLine($"Login    : {Login}");
            Console.WriteLine($"Password : {Password}");
        }
    }
}


