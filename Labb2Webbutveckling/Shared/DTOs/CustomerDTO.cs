using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb2Webbutveckling.Shared.DTOs
{
    internal class CustomerDTO
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; }
    }
}
