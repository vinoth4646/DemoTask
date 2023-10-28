using AmazonWebApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace AmazonWebApplication.Data
{
    public class AppDBContext : DbContext
    {
        //ctor shortcut to create constructor
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            
        }
        // table name created
        public DbSet<Brand> Brand { get; set; }

    }
}
