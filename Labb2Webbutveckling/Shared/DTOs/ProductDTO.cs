using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Webbutveckling.Shared.DTOs
{
    internal class ProductDTO
    {
        public int ProductID { get; set; }
        public string ProductNumber { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal Price { get; set; }
        public string ProductCategory { get; set; }
        public bool Status { get; set; }
    }
}
