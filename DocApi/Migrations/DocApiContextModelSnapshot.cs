﻿// <auto-generated />
using System;
using DocApi.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DocApi.Migrations
{
    [DbContext(typeof(DocApiContext))]
    partial class DocApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DocApi.Entities.Document", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Größe")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Typ")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ZeitpunktDesHochladens")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Größe = 10000,
                            Name = "Vorderrad",
                            Typ = "CAD",
                            UserId = 1,
                            ZeitpunktDesHochladens = new DateTime(2021, 1, 4, 11, 20, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 2,
                            Größe = 10000,
                            Name = "Vorderrad",
                            Typ = "CAD",
                            UserId = 1,
                            ZeitpunktDesHochladens = new DateTime(2021, 1, 4, 11, 20, 40, 0, DateTimeKind.Unspecified)
                        },
                        new
                        {
                            Id = 3,
                            Größe = 12000,
                            Name = "Hinterrad",
                            Typ = "CAD",
                            UserId = 1,
                            ZeitpunktDesHochladens = new DateTime(2020, 4, 4, 10, 20, 40, 0, DateTimeKind.Unspecified)
                        });
                });

            modelBuilder.Entity("DocApi.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Beschreibung")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            Beschreibung = "Mitarbeiter",
                            RoleName = "User"
                        },
                        new
                        {
                            RoleId = 2,
                            Beschreibung = "Administrator der Seite",
                            RoleName = "Admin"
                        },
                        new
                        {
                            RoleId = 3,
                            Beschreibung = "Externe Benutzer",
                            RoleName = "Partner"
                        });
                });

            modelBuilder.Entity("DocApi.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Anrede")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nachname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Vorname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Anrede = "Herr",
                            Email = "harald.schmid@test.de",
                            Nachname = "Schmid",
                            RoleId = 1,
                            Vorname = "Harald"
                        },
                        new
                        {
                            Id = 2,
                            Anrede = "Herr",
                            Email = "heinz.huber@test.de",
                            Nachname = "Huber",
                            RoleId = 2,
                            Vorname = "Heinz"
                        },
                        new
                        {
                            Id = 3,
                            Anrede = "Frau",
                            Email = "heidi.breitner@test.de",
                            Nachname = "Breitner",
                            RoleId = 2,
                            Vorname = "Heidi"
                        },
                        new
                        {
                            Id = 4,
                            Anrede = "Herr",
                            Email = "martin.klein@test.de",
                            Nachname = "Klein",
                            RoleId = 1,
                            Vorname = "Martin"
                        });
                });

            modelBuilder.Entity("DocApi.Entities.Document", b =>
                {
                    b.HasOne("DocApi.Entities.User", null)
                        .WithMany("Documents")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocApi.Entities.User", b =>
                {
                    b.HasOne("DocApi.Entities.Role", null)
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DocApi.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("DocApi.Entities.User", b =>
                {
                    b.Navigation("Documents");
                });
#pragma warning restore 612, 618
        }
    }
}
