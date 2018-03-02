using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.Products;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments;
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

        public DbSet<DesktopUser> DesktopUsers { get; set; }
        public DbSet<SiteLanguage> Languages { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<LocalizedProduct> LocalizedProducts { get; set; }

        #region GamingEquipment
        public DbSet<GamingController> Controllers { get; set; }
        public DbSet<Headset> Headsets { get; set; }
        public DbSet<GamingKeyboard> Keyboards { get; set; }
        public DbSet<MouseMat> MouseMats { get; set; }
        public DbSet<GamingMouse> Mice { get; set; }
        #endregion GamingEquipment

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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>()
            //    .HasMany(p => p.Languages)
            //    .WithMany(l => l.Products)
            //    .Map(m =>
            //    {
            //        m.MapLeftKey("product_id");
            //        m.MapRightKey("language_id");
            //        m.ToTable("localized_product");
            //    });

            modelBuilder.Entity<LocalizedProduct>()
               .HasKey(lp => new { lp.ProductID, lp.LanguageID });

            modelBuilder.Entity<Product>()
                        .HasMany(p => p.LocalizedProducts)
                        .WithRequired()
                        .HasForeignKey(lp => lp.ProductID);

            modelBuilder.Entity<SiteLanguage>()
                        .HasMany(l => l.LocalizedProducts)
                        .WithRequired()
                        .HasForeignKey(lp => lp.LanguageID);
        }
    }
}
