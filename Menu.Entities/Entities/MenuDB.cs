using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;

using System.Linq;

namespace Menu.Entities
{
    public partial class MenuDB : DbContext
    {
        public MenuDB()
            : base("name=MenuDB")
        {
        }

        public virtual DbSet<Adress> Adress { get; set; }
        public virtual DbSet<Adress_C> Adress_C { get; set; }
        public virtual DbSet<AdressType> AdressType { get; set; }
        public virtual DbSet<Bill> Bill { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Company> Company { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Desk> Desk { get; set; }
        public virtual DbSet<Menu> Menu { get; set; }
        public virtual DbSet<MenuPackageProduct_C> MenuPackageProduct_C { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<OrderPackageProduct_C> OrderPackageProduct_C { get; set; }
        public virtual DbSet<Package> Package { get; set; }
        public virtual DbSet<PackageProduct_C> PackageProduct_C { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<SubCategory> SubCategory { get; set; }
      
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCompany_C> UserCompany_C { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>()
                .HasMany(e => e.Adress_C)
                .WithRequired(e => e.Adress)
                .HasForeignKey(e => e.IdAdress)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AdressType>()
                .HasMany(e => e.Adress_C)
                .WithRequired(e => e.AdressType)
                .HasForeignKey(e => e.IdAdressType)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bill>()
                .Property(e => e.TotalPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Bill>()
                .HasMany(e => e.Order)
                .WithRequired(e => e.Bill)
                .HasForeignKey(e => e.IdBill)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Package)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.SubCategory)
                .WithRequired(e => e.Category)
                .HasForeignKey(e => e.IdCategory)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<City>()
                .HasMany(e => e.State)
                .WithRequired(e => e.City)
                .HasForeignKey(e => e.IdCity)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Adress_C)
                .WithOptional(e => e.Company)
                .HasForeignKey(e => e.IdCompany);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Desk)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.Menu)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Company>()
                .HasMany(e => e.UserCompany_C)
                .WithRequired(e => e.Company)
                .HasForeignKey(e => e.IdCompany)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Country>()
                .HasMany(e => e.City)
                .WithRequired(e => e.Country)
                .HasForeignKey(e => e.IdCountry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.IpAdress)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Desk>()
                .HasMany(e => e.Bill)
                .WithRequired(e => e.Desk)
                .HasForeignKey(e => e.IdDesk)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Menu>()
                .HasMany(e => e.MenuPackageProduct_C)
                .WithRequired(e => e.Menu)
                .HasForeignKey(e => e.IdMenu)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MenuPackageProduct_C>()
                .HasMany(e => e.OrderPackageProduct_C)
                .WithRequired(e => e.MenuPackageProduct_C)
                .HasForeignKey(e => e.IdMenuPackageProduct_C)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderPackageProduct_C)
                .WithRequired(e => e.Order)
                .HasForeignKey(e => e.IdOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Package>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.MenuPackageProduct_C)
                .WithOptional(e => e.Package)
                .HasForeignKey(e => e.IdPackage);

            modelBuilder.Entity<Package>()
                .HasMany(e => e.PackageProduct_C)
                .WithRequired(e => e.Package)
                .HasForeignKey(e => e.IdPackage)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PaymentMethod>()
                .HasMany(e => e.Bill)
                .WithRequired(e => e.PaymentMethod1)
                .HasForeignKey(e => e.PaymentMethod)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Adress_C)
                .WithOptional(e => e.Person)
                .HasForeignKey(e => e.IdPerson);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Customer)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.User)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.IdPerson)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.Price)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.MenuPackageProduct_C)
                .WithOptional(e => e.Product)
                .HasForeignKey(e => e.IdProduct);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PackageProduct_C)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.IdProduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserCompany_C)
                .WithRequired(e => e.Role)
                .HasForeignKey(e => e.IdRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<State>()
                .HasMany(e => e.Adress)
                .WithRequired(e => e.State)
                .HasForeignKey(e => e.IdState)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Package)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.IdSubCategory);

            modelBuilder.Entity<SubCategory>()
                .HasMany(e => e.Product)
                .WithOptional(e => e.SubCategory)
                .HasForeignKey(e => e.IdSubCategory);

            modelBuilder.Entity<User>()
                .Property(e => e.Phone)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Bill)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserCompany_C)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.IdUser)
                .WillCascadeOnDelete(false);
        }
    }
}
