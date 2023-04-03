using SM.Core.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.SQL
{
    public class DataContext:DbContext
    {
        public DataContext() :base("DefaultConnection"){ }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Likes> Likes { get; set; }
    }
}
