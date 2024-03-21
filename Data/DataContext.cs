using Microsoft.EntityFrameworkCore;
using MiddlewarePOC.Models;

namespace MiddlewarePOC.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public DbSet<Person> Persons { get; set; }
    }
}
