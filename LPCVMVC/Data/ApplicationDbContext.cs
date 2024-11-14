using LatvijasPasts.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace LPCVMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Cv> CVs { get; set; }
        public DbSet<Address> Addreses { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LatvijasPasts.Core.Models.PersonalData> PersonalData { get; set; } = default!;
    }
}
