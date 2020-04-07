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
        public string Category { get; set; }
        public string Name { get; set; }
        public List<string> Additions { get; set; }
    }
}
