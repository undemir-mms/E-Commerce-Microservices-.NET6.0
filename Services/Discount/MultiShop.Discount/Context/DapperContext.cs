using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MultiShop.Discount.Entities;
using System.Data;

namespace MultiShop.Discount.Context
{
    public class DapperContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectiongString;

        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectiongString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;initial catalog=MultiShopDiscountDb;integrated security=true");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectiongString);
    }
}
