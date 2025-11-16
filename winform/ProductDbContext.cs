using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanPhamWinform
{
    internal class ProductDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = LAPTOP-72EA6F25\\SQLEXPRESS12; Database = CustomerDB; Trusted_Connection = True; TrustServerCertificate = True");
        }

        public DbSet<Product> Products { get; set; }
    }
}
