using System;
using System.Collections.Generic;
using System.Text;

namespace SipIt.types
{
    public class Order
    {
        public Order()
        {
            Items = new List<Drink>();
        }
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<Drink> Items { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime Date { get; set; }

    }
}
