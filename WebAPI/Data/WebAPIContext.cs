using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<WebAPI.Models.Agreement> Agreement { get; set; }

        public DbSet<WebAPI.Models.Person> Person { get; set; }

        public DbSet<WebAPI.Models.Status> Status { get; set; }

        public DbSet<WebAPI.Models.Type> Type { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agreement>().HasData(
                new Agreement[]
                {
                new Agreement
                {
                    Id = 1,
                    PersonId = 2,
                    StatusId = 1,
                    TypeId = 2,
                    Number = 1,
                    DataOpen = new DateTime(2020, 07, 12),
                    DataClose = new DateTime(2020, 10, 12)
                },
                new Agreement
                {
                    Id = 2,
                    PersonId = 1,
                    StatusId = 2,
                    TypeId = 1,
                    Number = 2,
                    DataOpen = new DateTime(2020, 10, 12),
                    DataClose = new DateTime(2020, 10, 12)
                },
                new Agreement
                {
                    Id = 3,
                    PersonId = 5,
                    StatusId = 1,
                    TypeId = 3,
                    Number = 3,
                    DataOpen = new DateTime(2020, 07,12 ),
                    DataClose = new DateTime( 2020, 10,12)
                },
                new Agreement
                {
                    Id = 4,
                    PersonId = 3,
                    StatusId = 1,
                    TypeId = 2,
                    Number = 4,
                    DataOpen = new DateTime(2020, 07, 14),
                    DataClose = new DateTime(2020, 10, 12)
                }
                });

            modelBuilder.Entity<Person>().HasData(
                new Person[]
                {
                    new Person { Id = 1, Inn = 122365456212, Type = false, Shifer = "sdada", Data = new DateTime(2020, 10, 12) },
                    new Person { Id = 2, Inn = 122515456212, Type = false, Shifer = "shfgha", Data = new DateTime(2020, 07, 12) },
                    new Person { Id = 3, Inn = 1225154562, Type = true, Shifer = "ssdfgha", Data = new DateTime(2020, 07, 14) },
                    new Person { Id = 4, Inn = 1227545621, Type = true, Shifer = "sjhk", Data = new DateTime(2020, 10, 12) },
                    new Person { Id = 5, Inn = 122516556212, Type = false, Shifer = "rtya", Data = new DateTime(2020, 10, 12) },
                    new Person { Id = 6, Inn = 1287545621, Type = true, Shifer = "ssyio", Data = new DateTime(2020, 10, 14) },
                });

            modelBuilder.Entity<Status>().HasData(
                new Status[]
                {
                    new Status { Id = 1, StatusAggrement = "действует" },
                    new Status { Id = 2, StatusAggrement = "блокирован" },
                });

            modelBuilder.Entity< Models.Type >().HasData(
                new Models.Type[]
                {
                   new Models.Type { Id = 1, TypeAggrement = "дилерский" },
                   new Models.Type { Id = 2, TypeAggrement = "брокерский" },
                   new Models.Type { Id = 3, TypeAggrement = "управления" },
                });

        }
    }


}
