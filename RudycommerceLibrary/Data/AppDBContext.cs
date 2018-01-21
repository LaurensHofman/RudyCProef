using RudycommerceLibrary.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RudycommerceLibrary
{
    public class AppDBContext : DbContext
    {
        #region Database Sets

        public DbSet<Language> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LocalizedProduct> LocalizedProducts { get; set; }

        #endregion

        private static AppDBContext _instance;

        public static AppDBContext Instance(string connectionString = null)
        {
            if (_instance == null)
            {
                if (!string.IsNullOrWhiteSpace(connectionString))
                {
                    _instance = new AppDBContext(connectionString);
                }
            }
            return _instance;
        }

        public AppDBContext() : base(@"Data Source=DESKTOP-QJLP9GV\LAURENSSQL;Initial Catalog=RudyCommCProef;Persist Security Info=True;User ID=C-proef;Password=cproef")
        {

        }

        public AppDBContext(string connectionString) : base(connectionString) { }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Product>()
        //        .HasMany<Language>(p => p.Languages)
        //        .WithMany(l => l.Products)
        //        .Map(m =>
        //        {
        //            m.MapLeftKey("product_id");
        //            m.MapRightKey("language_id");
        //            m.ToTable("localized_product");
        //        });
        //}
    }
}
