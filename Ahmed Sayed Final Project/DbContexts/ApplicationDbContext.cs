using Ahmed_Sayed_Final_Project.Models;
using Microsoft.EntityFrameworkCore;

namespace Ahmed_Sayed_Final_Project.DbContexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Course> courses { get; set; }
        public DbSet<Ahmed_Sayed_Final_Project.Models.Professor> Professor { get; set; } = default!;
        //public DbSet<Professor> professors { get; set; }
    }

}
