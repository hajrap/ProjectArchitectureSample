using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewWebPortal.ApplicationCore.Entities
{
    public class Product
    {
        private string name;
        private string price;

        public string Name { get => name; set => name = value; }
        public string Price { get => price; set => price = value; }
    }
}
