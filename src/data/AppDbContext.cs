using Catedra1_Gabriel_Cruz.src.Models;
using Microsoft.EntityFrameworkCore;
namespace Catedra1_Gabriel_Cruz.src.data
{
    public class AppDbContext(DbContextOptions dbContextOptions) :  DbContext(dbContextOptions)
    {
        public DbSet<User> Users { get; set; }
    }
}