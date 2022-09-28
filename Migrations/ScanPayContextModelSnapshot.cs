﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Scanpay.Contex;

namespace Scanpay.Migrations
{
    [DbContext(typeof(ScanPayContext))]
    partial class ScanPayContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.11");

            modelBuilder.Entity("Scanpay.Entity.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("BrandName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
                });

            modelBuilder.Entity("Scanpay.Entity.Cart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("Scanpay.Entity.CartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CartId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("ItemQuantity")
                        .HasColumnType("int");

                    b.Property<double>("ItemWeigth")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CartId");

                    b.HasIndex("ItemId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("Scanpay.Entity.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CategoryName")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Scanpay.Entity.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Scanpay.Entity.Item", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpiryDate")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("ItemImage")
                        .HasColumnType("text");

                    b.Property<int>("ItemStatus")
                        .HasColumnType("int");

                    b.Property<double>("ItemWeight")
                        .HasColumnType("double");

                    b.Property<string>("ItemtName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ManufacturingDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("QrCode")
                        .HasColumnType("text");

                    b.Property<string>("QrCodeImage")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemBrand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemBrands");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemCategories");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("UnitWeight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("ItemOrders");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemStock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("StockId")
                        .HasColumnType("int");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("StockId");

                    b.ToTable("ItemStocks");
                });

            modelBuilder.Entity("Scanpay.Entity.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("OrderReference")
                        .HasColumnType("text");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<double>("TotalWeight")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Scanpay.Entity.Payment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<string>("PaymentReference")
                        .HasColumnType("text");

                    b.Property<int>("PaymentStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CustomerID");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("Scanpay.Entity.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Scanpay.Entity.Staff", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("StaffCode")
                        .HasColumnType("text");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("Scanpay.Entity.Stock", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("StockName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Stocks");
                });

            modelBuilder.Entity("Scanpay.Entity.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("HashSalt")
                        .HasColumnType("text");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Scanpay.Entity.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateModified")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("Datecreated")
                        .HasColumnType("datetime");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Scanpay.Entity.Cart", b =>
                {
                    b.HasOne("Scanpay.Entity.Customer", "Customer")
                        .WithMany("Carts")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Scanpay.Entity.CartItem", b =>
                {
                    b.HasOne("Scanpay.Entity.Cart", "Cart")
                        .WithMany("CartItems")
                        .HasForeignKey("CartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.Item", "Item")
                        .WithMany("CartItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Scanpay.Entity.Customer", b =>
                {
                    b.HasOne("Scanpay.Entity.User", "User")
                        .WithOne("Customer")
                        .HasForeignKey("Scanpay.Entity.Customer", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemBrand", b =>
                {
                    b.HasOne("Scanpay.Entity.Brand", "Brand")
                        .WithMany("ItemBrands")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.Item", "Item")
                        .WithMany("ItemBrands")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brand");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemCategory", b =>
                {
                    b.HasOne("Scanpay.Entity.Category", "Category")
                        .WithMany("ItemCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.Item", "Item")
                        .WithMany("ItemCategories")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Item");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemOrder", b =>
                {
                    b.HasOne("Scanpay.Entity.Item", "Item")
                        .WithMany("ItemOrders")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.Order", "Order")
                        .WithMany("ItemOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Scanpay.Entity.ItemStock", b =>
                {
                    b.HasOne("Scanpay.Entity.Item", "Item")
                        .WithMany("ItemStocks")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.Stock", "Stock")
                        .WithMany("ItemStocks")
                        .HasForeignKey("StockId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Item");

                    b.Navigation("Stock");
                });

            modelBuilder.Entity("Scanpay.Entity.Order", b =>
                {
                    b.HasOne("Scanpay.Entity.Customer", "Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Scanpay.Entity.Payment", b =>
                {
                    b.HasOne("Scanpay.Entity.Customer", "Customer")
                        .WithMany("Payments")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.Order", "Order")
                        .WithOne("Payment")
                        .HasForeignKey("Scanpay.Entity.Payment", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Scanpay.Entity.Staff", b =>
                {
                    b.HasOne("Scanpay.Entity.User", "User")
                        .WithOne("Staff")
                        .HasForeignKey("Scanpay.Entity.Staff", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Scanpay.Entity.UserRole", b =>
                {
                    b.HasOne("Scanpay.Entity.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanpay.Entity.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Scanpay.Entity.Brand", b =>
                {
                    b.Navigation("ItemBrands");
                });

            modelBuilder.Entity("Scanpay.Entity.Cart", b =>
                {
                    b.Navigation("CartItems");
                });

            modelBuilder.Entity("Scanpay.Entity.Category", b =>
                {
                    b.Navigation("ItemCategories");
                });

            modelBuilder.Entity("Scanpay.Entity.Customer", b =>
                {
                    b.Navigation("Carts");

                    b.Navigation("Orders");

                    b.Navigation("Payments");
                });

            modelBuilder.Entity("Scanpay.Entity.Item", b =>
                {
                    b.Navigation("CartItems");

                    b.Navigation("ItemBrands");

                    b.Navigation("ItemCategories");

                    b.Navigation("ItemOrders");

                    b.Navigation("ItemStocks");
                });

            modelBuilder.Entity("Scanpay.Entity.Order", b =>
                {
                    b.Navigation("ItemOrders");

                    b.Navigation("Payment");
                });

            modelBuilder.Entity("Scanpay.Entity.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Scanpay.Entity.Stock", b =>
                {
                    b.Navigation("ItemStocks");
                });

            modelBuilder.Entity("Scanpay.Entity.User", b =>
                {
                    b.Navigation("Customer");

                    b.Navigation("Staff");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
