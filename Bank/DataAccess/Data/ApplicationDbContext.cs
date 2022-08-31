using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }



        public DbSet<CustomerData> Customers { get; set; }
        public DbSet<LGA> LGAs { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<State>()
                .HasRequired<CustomerData>(s => s.Name)
                .WithMany(g => g.StateID)
                .HasForeignKey<int>(s => s.StateID);
        }
    }

   
}
