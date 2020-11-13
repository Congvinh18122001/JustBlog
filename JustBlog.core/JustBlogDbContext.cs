using JustBlog.core.Objects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustBlog.core
{
   public class JustBlogDbContext : DbContext
    {
        public JustBlogDbContext() : base("name=connstring")
        {

        }
        public virtual DbSet<Category>Categories { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
