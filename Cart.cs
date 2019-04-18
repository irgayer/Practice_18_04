using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice_18_04
{
    public class Cart : Entity
    {
        public User User { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    } 
}
