using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Menu.Entities;
using System.Linq;

namespace Menu.DataAccess
{
    public class MenuDbContext : DbContext
    {
        DbContextOptions options;
        public MenuDbContext(DbContextOptions _options) : base(_options)
        {
            options= _options;
        }

        public  DbSet<Adress> Adress { get; set; }
        public  DbSet<Adress_C> Adress_C { get; set; }
        public  DbSet<AdressType> AdressType { get; set; }
        public  DbSet<Bill> Bill { get; set; }
        public  DbSet<Category> Category { get; set; }
        public  DbSet<City> City { get; set; }
        public  DbSet<Company> Company { get; set; }
        public  DbSet<Country> Country { get; set; }
        public  DbSet<Customer> Customer { get; set; }
        public  DbSet<Desk> Desk { get; set; }
        public  DbSet<Menu.Entities.Menu> Menu { get; set; }
        public  DbSet<MenuPackageProduct_C> MenuPackageProduct_C { get; set; }
        public  DbSet<Order> Order { get; set; }
        public  DbSet<OrderPackageProduct_C> OrderPackageProduct_C { get; set; }
        public  DbSet<Package> Package { get; set; }
        public  DbSet<PackageProduct_C> PackageProduct_C { get; set; }
        public  DbSet<PaymentMethod> PaymentMethod { get; set; }
        public  DbSet<Person> Person { get; set; }
        public  DbSet<Product> Product { get; set; }
        public  DbSet<Role> Role { get; set; }
        public  DbSet<State> State { get; set; }
        public  DbSet<SubCategory> SubCategory { get; set; }
      
        public  DbSet<User> User { get; set; }
        public  DbSet<UserCompany_C> UserCompany_C { get; set; }



        //WillCascadeOnDelete == true Tüm baðlý tablolardaki 1-n olan datalarý da siler.
        //Orn. Kullanýcý silinirse kullanýcý detaylarý silinir.Adress vb tablolardan Id sine göre silinir.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adress>()
               .HasOne(s => s.State)
               .WithMany(s => s.Adress)
               .HasForeignKey(s => s.IdState);

            modelBuilder.Entity<Adress_C>()
                .HasOne(s => s.Adress)
                .WithMany(s => s.Adress_C)
                .HasForeignKey(s => s.IdAdress);

            modelBuilder.Entity<Adress_C>()
                .HasOne(s => s.AdressType)
                .WithMany(s => s.Adress_C)
                .HasForeignKey(s => s.IdAdress);

            modelBuilder.Entity<Adress_C>()
                .HasOne(s => s.Company)
                .WithMany(s => s.Adress_C)
                .HasForeignKey(s => s.IdCompany);

            modelBuilder.Entity<Adress_C>()
                  .HasOne(s => s.Person)
                  .WithMany(s => s.Adress_C)
                  .HasForeignKey(s => s.IdPerson);

            modelBuilder.Entity<Bill>()
                .HasOne(s=>s.User)
                .WithMany(s=>s.Bill)
                .HasForeignKey(s=>s.IdUser);

            modelBuilder.Entity<Bill>()
                .HasOne(s => s.PaymentMethod)
                .WithMany(s => s.Bill)
                .HasForeignKey(s => s.IdPaymentMethod);

            modelBuilder.Entity<Bill>()
                 .HasOne(s => s.User)
                 .WithMany(s => s.Bill)
                 .HasForeignKey(s => s.IdUser);

            modelBuilder.Entity<Bill>()
                .HasOne(s => s.Desk)
                .WithMany(s => s.Bill)
                .HasForeignKey(s => s.IdDesk);

            modelBuilder.Entity<Category>()
                .HasOne(s => s.Company)
                .WithMany(s => s.Category)
                .HasForeignKey(s => s.IdCompany);

        }
    }
}
