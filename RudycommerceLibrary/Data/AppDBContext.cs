﻿using RudycommerceLibrary.Entities;
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
        public DbSet<Language> Languages { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<SpecificProductProperty> SpecificProductProperties { get; set; }
        public DbSet<Article> Articles { get; set; }

        public DbSet<LocalizedProduct> LocalizedProducts { get; set; }
        public DbSet<LocalizedProductCategory> LocalizedProductCategories { get; set; }
        public DbSet<LocalizedSpecificProductProperty> LocalizedSpecificProductProperties { get; set; }
        public DbSet<Category_SpecificProductProperties> Category_SpecificProductProperties { get; set; }
        public DbSet<Product_SpecificProductProperties> Product_SpecificProductProperties { get; set; }
        public DbSet<Localized_Product_SpecificProductProperties> Localized_Product_SpecificProductProperties { get; set; }
         
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

        public AppDBContext() : base(@"Data Source=DESKTOP-PKK44LS\MSSQL;Initial Catalog=RudyCommCProef;Persist Security Info=True;User ID=cproef;Password=cproef")
        {

        }

        private AppDBContext(string connectionString) : base(connectionString) { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Category (1) to (many) Products
            modelBuilder.Entity<Product>()
                .HasRequired<ProductCategory>(p => p.ProductCategory)
                .WithMany(pc => pc.Products)
                .HasForeignKey<int>(p => p.CategoryID);
            #endregion
            #region Category has 0/1 Parent
            modelBuilder.Entity<ProductCategory>()
                .HasOptional<ProductCategory>(p1 => p1.Parent)
                .WithMany(p2 => p2.Children)
                .HasForeignKey<int?>(m => m.ParentID);
            #endregion
            #region Products (many) to (many) Languages
            modelBuilder.Entity<LocalizedProduct>()
                .HasKey(lp => new { lp.ProductID, lp.LanguageID });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.LocalizedProducts)
                .WithRequired()
                .HasForeignKey(lp => lp.ProductID);

            modelBuilder.Entity<Language>()
                .HasMany(sl => sl.LocalizedProducts)
                .WithRequired()
                .HasForeignKey(lp => lp.LanguageID);
            #endregion
            #region Categories (many) to (many) Languages
            modelBuilder.Entity<LocalizedProductCategory>()
                .HasKey(lpc => new { lpc.CategoryID, lpc.LanguageID });

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.LocalizedProductCategories)
                .WithRequired()
                .HasForeignKey(lpc => lpc.CategoryID);

            modelBuilder.Entity<Language>()
                .HasMany(sl => sl.LocalizedProducts)
                .WithRequired()
                .HasForeignKey(lpc => lpc.LanguageID);
            #endregion
            #region Product properties (many) to (many) Languages
            modelBuilder.Entity<LocalizedSpecificProductProperty>()
                .HasKey(lpp => new { lpp.SpecificProductPropertyID, lpp.LanguageID });

            modelBuilder.Entity<SpecificProductProperty>()
                .HasMany(pp => pp.LocalizedSpecificProductProperties)
                .WithRequired()
                .HasForeignKey(lpp => lpp.SpecificProductPropertyID);

            modelBuilder.Entity<Language>()
                .HasMany(sl => sl.LocalizedSpecificProductProperties)
                .WithRequired()
                .HasForeignKey(lpp => lpp.LanguageID);
            #endregion
            #region Product properties (many) to (many) categories
            modelBuilder.Entity<Category_SpecificProductProperties>()
                .HasKey(cpp => new { cpp.SpecificProductPropertyID, cpp.CategoryID });

            modelBuilder.Entity<SpecificProductProperty>()
                .HasMany(pp => pp.LocalizedSpecificProductProperties)
                .WithRequired()
                .HasForeignKey(cpp => cpp.SpecificProductPropertyID);

            modelBuilder.Entity<ProductCategory>()
                .HasMany(pc => pc.Category_SpecificProductProperties)
                .WithRequired()
                .HasForeignKey(cpp => cpp.CategoryID);
            #endregion
            #region Products (many) to (many) SpecificProductProperties
            modelBuilder.Entity<Product_SpecificProductProperties>()
                .HasKey(ppp => new { ppp.ProductID, ppp.SpecificProductPropertyID });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Product_SpecificProductProperties)
                .WithRequired()
                .HasForeignKey(ppp => ppp.ProductID);

            modelBuilder.Entity<SpecificProductProperty>()
                .HasMany(pp => pp.Product_SpecificProductProperties)
                .WithRequired()
                .HasForeignKey(ppp => ppp.SpecificProductPropertyID);
            #endregion
            #region Product specific productproperties (many) to (many) Languages
            modelBuilder.Entity<Localized_Product_SpecificProductProperties>()
                .HasKey(lppp => new { lppp.ProductID, lppp.SpecificProductPropertyID, lppp.LanguageID });

            modelBuilder.Entity<Product>()
                .HasMany(p => p.Localized_Product_SpecificProductProperties)
                .WithRequired()
                .HasForeignKey(lppp => lppp.ProductID);

            modelBuilder.Entity<SpecificProductProperty>()
                .HasMany(pp => pp.Localized_Product_SpecificProductProperties)
                .WithRequired()
                .HasForeignKey(lppp => lppp.SpecificProductPropertyID);

            modelBuilder.Entity<Language>()
                .HasMany(sl => sl.Localized_Product_SpecificProductProperties)
                .WithRequired()
                .HasForeignKey(lppp => lppp.LanguageID);
            #endregion
            #region Product (1) to (many) Articles
            modelBuilder.Entity<Article>()
                .HasRequired<Product>(a => a.Product)
                .WithMany(p => p.Articles)
                .HasForeignKey<int>(a => a.ProductID);
            #endregion
            #region Languages (1) to (many) DesktopUsers
            modelBuilder.Entity<DesktopUser>()
                .HasRequired<Language>(du => du.Language)
                .WithMany(l => l.DesktopUsers)
                .HasForeignKey<int>(du => du.PreferredLanguageID);
            #endregion
        }
    }
}
