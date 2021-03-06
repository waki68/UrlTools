﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shortener.Models;

namespace Shortener.DA.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20201203103829_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Shortener.Domain.ShortCode", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .UseIdentityColumn();

                    b.Property<Guid>("Code")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("RedirectCount")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("ReqDate")
                        .HasColumnType("datetime");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("rowversion");

                    b.Property<int>("UrlId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("UrlId");

                    b.ToTable("ShortCode", "Url");
                });

            modelBuilder.Entity("Shortener.Domain.Url", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("ReqUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("TotalRedirectCount")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Url", "Url");
                });

            modelBuilder.Entity("Shortener.Domain.ShortCode", b =>
                {
                    b.HasOne("Shortener.Domain.Url", "Url")
                        .WithMany("ShortCodes")
                        .HasForeignKey("UrlId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Url");
                });

            modelBuilder.Entity("Shortener.Domain.Url", b =>
                {
                    b.Navigation("ShortCodes");
                });
#pragma warning restore 612, 618
        }
    }
}
