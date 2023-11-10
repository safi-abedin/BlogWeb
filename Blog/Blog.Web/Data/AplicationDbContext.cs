using Blog.Web.Areas.Admin.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Web.Data
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<Tag> Tags { get; set; }
    }
}
