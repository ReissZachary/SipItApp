using System;
using System.Collections.Generic;
using System.Text;

namespace SipIt.types
{
    public class Drink
    {
        public Drink()
        {
            Additions = new List<string>();
        }

        public int Id { get; set; }
        public string Base { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public List<string> Additions { get; set; }
        public decimal Price { get; set; }
    }
}
