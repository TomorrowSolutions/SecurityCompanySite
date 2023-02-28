using Microsoft.EntityFrameworkCore;
using test.Models;

namespace KursovoiRSOD.Models
{
    public class SecurityCompanyDbContext:DbContext
    {
        public SecurityCompanyDbContext(DbContextOptions<SecurityCompanyDbContext> options):base(options) { 
            
        }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<GuardedObject> GuardedObjects { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }

    }
}
