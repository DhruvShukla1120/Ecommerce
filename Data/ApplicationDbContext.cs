using DevOpsGroupProjects.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DevOpsGroupProjects.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Product> products { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}