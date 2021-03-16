using DocApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace DocApi.DbContexts
{
    public class DocApiContext : DbContext
    {
        public DbSet<Document> Documents { get; set; }
        public DbSet<User> Users { get; set; }


        public DocApiContext(DbContextOptions<DocApiContext> options) 
            : base(options)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Document>().HasData(
                new Document()
                {
                    Id = 1,
                    Name = "Vorderrad",
                    Größe = 10000,
                    Typ = "CAD",
                    ZeitpunktDesHochladens = new DateTime
                    (2021, 01, 04, 11, 20, 40),
                    UserId = 1
                },
                new Document()
                {
                    Id = 2,
                    Name = "Vorderrad",
                    Größe = 10000,
                    Typ = "CAD",
                    ZeitpunktDesHochladens = new DateTime (2021, 01, 04, 11, 20, 40),
                    UserId = 1
                },
                new Document()
                {
                    Id = 3,
                    Name = "Hinterrad",
                    Größe = 12000,
                    Typ = "CAD",
                    ZeitpunktDesHochladens = new DateTime
                    (2020, 04, 04, 10, 20, 40),
                    UserId = 1
                });
           
            modelBuilder.Entity<User>().HasData(
                new User()
                {
                    Id = 1,
                    Anrede = "Herr",
                    Vorname = "Harald",
                    Nachname = "Schmid",
                    Email = "harald.schmid@test.de",
                    Password = null,
                    RoleName = "User"
                },
                new User()
                {
                    Id = 2,
                    Anrede = "Herr",
                    Vorname = "Heinz",
                    Nachname = "Huber",
                    Email = "heinz.huber@test.de",
                    Password = null,
                    RoleName = "Admin"
                },
                new User()
                {
                    Id = 3,
                    Anrede = "Frau",
                    Vorname = "Heidi",
                    Nachname = "Breitner",
                    Email = "heidi.breitner@test.de",
                    Password = null,
                    RoleName = "Admin"
                },
                new User()
                {
                    Id = 4,
                    Anrede = "Herr",
                    Vorname = "Martin",
                    Nachname = "Klein",
                    Email = "martin.klein@test.de",
                    Password = null,
                    RoleName = "User"
                });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Role>().HasData(
                new Role()
                {
                    RoleName = "User",
                    Beschreibung = "Mitarbeiter",
                },
                new Role()
                {
                    RoleName = "Admin",
                    Beschreibung = "Administrator der Seite",
                },
                new Role()
                {
                    RoleName = "Partner",
                    Beschreibung = "Externe Benutzer"
                });
        }
    }
}
