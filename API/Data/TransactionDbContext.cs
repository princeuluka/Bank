using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<CustomerData> Customers { get; set; }
        public DbSet<LGA> LGAs { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<CustomerAccount> Accounts { get; set; }
        public DbSet<Transactions> Transactions { get; set; }

    }
}
