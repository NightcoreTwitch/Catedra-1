using System.Data.Common;
using Microsoft.EntityFrameworkCore;
namespace Catedra1_Gabriel_Cruz.src.Models
{
    public class AppDbContext(DbContextOptions dbContextOptions) :  DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; }
    }
}