using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyEcommerceAdmin.Models
{
    public partial class MyEcommerceDbContext : DbContext
    {
        public MyEcommerceDbContext()
            : base("name=MyEcommerceDbContext")
        {
        }

        public virtual DbSet<admin_Employee> admin_Employee { get; set; }
        public virtual DbSet<admin_Login> admin_Login { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<RecentlyView> RecentlyViews { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
    }
}