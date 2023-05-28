using DataAccess.Model;
using Labb2Webbutveckling.Shared.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataAccess
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) { }
        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Lappitoppen;Database=Labb2;Integrated Security=True;");
        }
    }
}
