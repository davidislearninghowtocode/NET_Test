using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPhamWinform
{
    internal class Product
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public string Statement {  get; set; }
        public decimal Total {  get; set; }
        public DateTime OrderDate { get; set; }
    }
}
