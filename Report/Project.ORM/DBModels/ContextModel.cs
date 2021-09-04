using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Project.ORM.DBModels
{
    public partial class ContextModel : DbContext
    {
        public ContextModel()
            : base("name=DefaultConnectionString")
        {
        }

        public virtual DbSet<AdminInfo> AdminInfoes { get; set; }
        public virtual DbSet<MemberInfo> MemberInfoes { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminInfo>()
                .Property(e => e.AdminAccount)
                .IsUnicode(false);

            modelBuilder.Entity<MemberInfo>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.Account)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Photo)
                .IsUnicode(false);
        }
    }
}
