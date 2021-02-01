using Microsoft.EntityFrameworkCore;
using CustomerService.Model.Entity;

namespace CustomerService.Model{
    public class CustomerDatabaseContext: DbContext{
        public CustomerDatabaseContext(DbContextOptions<CustomerDatabaseContext> options):base(options)
        {
            
        }
        public DbSet<Customer> Customers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(Entity=>{
                Entity.HasKey(e=>e.CustomerID);
                Entity.ToTable("Customer");
            });
        }
    }
}