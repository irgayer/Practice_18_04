﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_04
{
    public class Product : Entity
    {
        public string Name { get; set; }
        public double Cost { get; set; }

        public void Print()
        {
            Console.WriteLine($"{Name} : {Cost}");
        }
    }
}
