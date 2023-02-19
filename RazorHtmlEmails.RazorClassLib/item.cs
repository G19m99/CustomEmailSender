using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorHtmlEmails.RazorClassLib
{
    public class item
    {
        public string name { get; set; }
        public int amount { get; set; }
        public decimal price { get; set; }
        public item(string name, int amount, decimal price)
        {
            this.name = name;
            this.amount = amount;
            this.price = price;
        }
    }
}
