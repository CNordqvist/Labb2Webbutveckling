using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Webbutveckling.Shared.DTOs
{
    internal class OrderDTO
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
