using EduApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduApi.Data
{
    public class EduDbContext: DbContext
    {
        public EduDbContext(DbContextOptions<EduDbContext> options)
            : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
