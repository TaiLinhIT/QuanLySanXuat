using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuat.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Line { get; set; }
        public int Plan { get; set; }
        public int Target { get; set; }
        public int Result { get; set; }
        public int Achieve { get; set; }
        public double Progress { get; set; }
    }
}
