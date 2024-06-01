﻿// <auto-generated />
using System;
using BarberFusion.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BarberFusion.Infrastructure.Migrations
{
    [DbContext(typeof(BarberFusionContext))]
    [Migration("20240601154300_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BarberFusion.Domain.Entities.Appointment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("AppointmentDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ServiceId");

                    b.HasIndex("ShopId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Invoice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("TotalAmount")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("ShopId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.InvoiceDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("InvoiceId")
                        .HasColumnType("uuid");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uuid");

                    b.Property<decimal>("UnitPrice")
                        .HasColumnType("numeric");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("ServiceId");

                    b.ToTable("InvoiceDetail");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Service", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Shop", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Shops");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("ShopId")
                        .HasColumnType("uuid");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ShopId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.UserRole", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Appointment", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Customer", "Customer")
                        .WithMany("Appointments")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberFusion.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberFusion.Domain.Entities.Shop", "Shop")
                        .WithMany("Appointments")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Service");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Customer", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Shop", "Shop")
                        .WithMany("Customers")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Invoice", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Customer", "Customer")
                        .WithMany("Invoices")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberFusion.Domain.Entities.Shop", "Shop")
                        .WithMany("Invoices")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.InvoiceDetail", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Invoice", "Invoice")
                        .WithMany("InvoiceDetails")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberFusion.Domain.Entities.Service", "Service")
                        .WithMany()
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Invoice");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Role", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Shop", "Shop")
                        .WithMany("Roles")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Service", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Shop", "Shop")
                        .WithMany("Services")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.User", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Shop", "Shop")
                        .WithMany("Users")
                        .HasForeignKey("ShopId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Shop");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.UserRole", b =>
                {
                    b.HasOne("BarberFusion.Domain.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BarberFusion.Domain.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Customer", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Invoices");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Invoice", b =>
                {
                    b.Navigation("InvoiceDetails");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.Shop", b =>
                {
                    b.Navigation("Appointments");

                    b.Navigation("Customers");

                    b.Navigation("Invoices");

                    b.Navigation("Roles");

                    b.Navigation("Services");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("BarberFusion.Domain.Entities.User", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}