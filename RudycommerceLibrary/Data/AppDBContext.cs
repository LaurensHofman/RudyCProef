using RudycommerceLibrary.Entities;
using RudycommerceLibrary.Entities.ProductsAndCategories;
using RudycommerceLibrary.Entities.ProductsAndCategories.Localized;
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
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductProperty> ProductProperties { get; set; }


        public DbSet<LocalizedProduct> LocalizedProducts { get; set; }
        public DbSet<LocalizedProductCategory> LocalizedProductCategories { get; set; }
        public DbSet<LocalizedProductProperty> LocalizedProductProperties { get; set; }
        public DbSet<Category_ProductProperties> Category_ProductProperties { get; set; }
        public DbSet<Product_ProductProperties> product_ProductProperties { get; set; }
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
            // Category (1) to (many) Products
            modelBuilder.Entity<Product>()
                .HasRequired<ProductCategory>(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey<int>(p => p.CategoryID);

            // Category has 0/1 Parent
            modelBuilder.Entity<ProductCategory>()
                .HasOptional<ProductCategory>(p1 => p1.Parent)
                .WithMany(p2 => p2.Children)
                .HasForeignKey<int?>(m => m.ParentID);

            // Products (many) to (many) Languages
            modelBuilder.Entity<LocalizedProduct>()
                .HasKey(lp => new { lp.ProductID, lp.LanguageID });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.LocalizedProducts)
                .WithRequired()
                .HasForeignKey(lp => lp.ProductID);

            modelBuilder.Entity<SiteLanguage>()
                .HasMany(sl => sl.LocalizedProducts)
                .WithRequired()
                .HasForeignKey(lp => lp.LanguageID);

            // Categories (many) to (many) Languages
            modelBuilder.Entity<LocalizedProductCategory>()
                .HasKey(lpc => new { lpc.CategoryID, lpc.LanguageID });

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.LocalizedProductCategories)
                .WithRequired()
                .HasForeignKey(lpc => lpc.CategoryID);

            modelBuilder.Entity<SiteLanguage>()
                .HasMany(sl => sl.LocalizedProducts)
                .WithRequired()
                .HasForeignKey(lpc => lpc.LanguageID);

            // Product properties (many) to (many) Languages
            modelBuilder.Entity<LocalizedProductProperty>()
                .HasKey(lpp => new { lpp.ProductPropertyID, lpp.LanguageID });

            modelBuilder.Entity<ProductProperty>()
                .HasMany(pp => pp.LocalizedProductProperties)
                .WithRequired()
                .HasForeignKey(lpp => lpp.ProductPropertyID);

            modelBuilder.Entity<SiteLanguage>()
                .HasMany(sl => sl.LocalizedProductProperties)
                .WithRequired()
                .HasForeignKey(lpp => lpp.LanguageID);

            // Product properties (many) to (many) categories
            modelBuilder.Entity<Category_ProductProperties>()
                .HasKey(cpp => new { cpp.ProductPropertyID, cpp.CategoryID });

            modelBuilder.Entity<ProductProperty>()
                .HasMany(pp => pp.LocalizedProductProperties)
                .WithRequired()
                .HasForeignKey(cpp => cpp.ProductPropertyID);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Category_ProductProperties)
                .WithRequired()
                .HasForeignKey(cpp => cpp.CategoryID);

            // Products (many) to (many) ProductProperties
            modelBuilder.Entity<Product_ProductProperties>()
                .HasKey(ppp => new { ppp.ProductID, ppp.ProductPropertyID });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Product_ProductProperties)
                .WithRequired()
                .HasForeignKey(ppp => ppp.ProductID);

            modelBuilder.Entity<ProductProperty>()
                .HasMany(pp => pp.Product_ProductProperties)
                .WithRequired()
                .HasForeignKey(ppp => ppp.ProductPropertyID);
        }
    }
}
