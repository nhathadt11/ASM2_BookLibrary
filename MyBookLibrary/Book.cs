using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Publisher { get; set; }
        public float Price { get; set; }
        public override string ToString()
        {
            return string.Format("{0,-5}{1,-20}{2,-20}{3,-10}", ID, Title, Publisher, Price);
        }
    }
    
}
