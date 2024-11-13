using LatvijasPasts.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LatvijasPasts.Data
{
    public class LPDbContext(DbContextOptions<LPDbContext> options) : DbContext(options)
    {
        public DbSet<Cv> CVs { get; set; }
        public DbSet<Address> Addreses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
    }
}
