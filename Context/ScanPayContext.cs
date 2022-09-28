 using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Scanpay.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Scanpay.Contex
{
    public class ScanPayContext : DbContext
    {
        public ScanPayContext(DbContextOptions<ScanPayContext> option) : base(option)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* var staffCode = $"SP{Guid.NewGuid().ToString().Substring(0, 9).Replace("-", "").ToUpper()}";

            var user = new User
            {
                FirstName = "Muftau",
                LastName = "Dada",
                Address = "Lagos",
                Email = "dadamuftau@gmail.com",
                PhoneNumber = "08051678489",
                Password = staffCode,


            };
            

            modelBuilder.Entity<Staff>().HasData(new Staff
            {
                FirstName = "Muftau",
                LastName = "Dada",
                Address = "Lagos",
                Email = "dadamuftau@gmail.com",
                PhoneNumber = "08051678489",
                StaffCode = staffCode,
                UserId = user.Id,
                User = user

            });

            
                var userRole = new UserRole
                {
                    Role = new Role
                    {
                        Name = "SuperAdmin",
                        Description = "Over-sight function"
                    },
                    RoleId = 1,
                    User = user,
                    UserId = user.Id
                };
                user.UserRoles.Add(userRole);*/
            
            
            
            
        }
        public DbSet<Brand> Brands { get; set; }

        public DbSet<ItemBrand> ItemBrands { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ItemCategory> ItemCategories { get; set; }

        public DbSet<Order> Orders { get; set; }
        
        public DbSet<ItemOrder> ItemOrders { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Role> Roles { get; set; }

        public DbSet<Staff> Staffs { get; set; }

        public DbSet<Stock> Stocks { get; set; }

        public DbSet<ItemStock> ItemStocks { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }

        public override DatabaseFacade Database => base.Database;

        public override ChangeTracker ChangeTracker => base.ChangeTracker;

        public override IModel Model => base.Model;

        public override DbContextId ContextId => base.ContextId;




    }
}
