﻿// <auto-generated />
using Magic.Words.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Magic.Words.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231214211055_addingSubscriptions")]
    partial class addingSubscriptions
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Magic.Words.Core.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"));

                    b.Property<string>("SubscriptionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("SubscriptionPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SubscriptionId");

                    b.ToTable("Subscriptions");

                    b.HasData(
                        new
                        {
                            SubscriptionId = 1,
                            SubscriptionName = "Standart",
                            SubscriptionPrice = 0m
                        },
                        new
                        {
                            SubscriptionId = 2,
                            SubscriptionName = "Premium",
                            SubscriptionPrice = 9.99m
                        },
                        new
                        {
                            SubscriptionId = 3,
                            SubscriptionName = "Royal",
                            SubscriptionPrice = 99.99m
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
