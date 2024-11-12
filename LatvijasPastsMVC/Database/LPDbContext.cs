using LatvijasPastsMVC.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace LatvijasPastsMVC.Database
{
    public class LPDbContext(DbContextOptions<LPDbContext> options) : DbContext(options)
    {
        public DbSet<CV> CVs { get; set; }
    }
}
