using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.Products;
using RudycommerceLibrary.Entities.Products.GamingEquipments.ElectronicEquipments;
using RudycommerceLibrary.Entities.Products.GamingEquipments.NonElectronicEquipments;
using RudycommerceLibrary.Entities.Products.LocalizedProducts;
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

        #region GamingEquipment
        public DbSet<GamingController> Controllers { get; set; }
        public DbSet<Headset> Headsets { get; set; }
        public DbSet<GamingKeyboard> Keyboards { get; set; }
        public DbSet<MouseMat> MouseMats { get; set; }
        public DbSet<GamingMouse> Mice { get; set; }
        #endregion GamingEquipment

        #region Localized GamingEquipment
        public DbSet<LocalizedHeadset> LocalizedHeadsets { get; set; }
        public DbSet<LocalizedGamingController> LocalizedGamingControllers { get; set; }
        public DbSet<LocalizedGamingKeyboard> LocalizedGamingKeyboards { get; set; }
        //public DbSet<LocalizedGamingMouse> LocalizedGamingMice { get; set; }
        //public DbSet<LocalizedMouseMat> LocalizedMouseMats { get; set; }
        #endregion


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
            #region Localized Products
            #region Headset
            modelBuilder.Entity<LocalizedHeadset>()
                .HasKey(lh => new { lh.ProductID, lh.LanguageID });

            modelBuilder.Entity<Headset>()
                .HasMany(h => h.LocalizedHeadsets)
                .WithRequired()
                .HasForeignKey(lh => lh.ProductID);

            modelBuilder.Entity<SiteLanguage>()
                .HasMany(sl => sl.LocalizedHeadsets)
                .WithRequired()
                .HasForeignKey(lh => lh.LanguageID);
            #endregion
            #region Controller
            modelBuilder.Entity<LocalizedGamingController>()
                .HasKey(lgc => new { lgc.ProductID, lgc.LanguageID });

            modelBuilder.Entity<GamingController>()
                .HasMany(gc => gc.LocalizedGamingControllers)
                .WithRequired()
                .HasForeignKey(lgc => lgc.ProductID);

            modelBuilder.Entity<SiteLanguage>()
                .HasMany(sl => sl.LocalizedGamingControllers)
                .WithRequired()
                .HasForeignKey(lgc => lgc.LanguageID);
            #endregion
            #region Keyboard
            modelBuilder.Entity<LocalizedGamingKeyboard>()
                .HasKey(lgk => new { lgk.ProductID, lgk.LanguageID });

            modelBuilder.Entity<GamingKeyboard>()
                .HasMany(gk => gk.LocalizedGamingKeyboards)
                .WithRequired()
                .HasForeignKey(lgk => lgk.ProductID);

            modelBuilder.Entity<SiteLanguage>()
                .HasMany(sl => sl.LocalizedGamingKeyboards)
                .WithRequired()
                .HasForeignKey(lgk => lgk.LanguageID);
            #endregion
            #endregion
        }
    }
}
