﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using apiDocuments;

#nullable disable

namespace apiDocuments.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("apiDocuments.Models.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CustomName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("DocumentFile")
                        .HasColumnType("longtext");

                    b.Property<string>("Extension")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("MimeType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OriginalName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
