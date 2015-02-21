using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Models
{
    public class Gateway : DbContext
    {
        public Gateway() : base("Blog")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<MyBlog> Blog { set; get; }
        public DbSet<Comment> Comment { set; get; }
       

    }
}