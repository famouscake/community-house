namespace community_house.Migrations
{
    using community_house.Models;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<community_house.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(community_house.Models.ApplicationDbContext context)
        {
            List<House> Houses = new List<House>
            {
                new House{Address = "1 Shire Oak Road", Area = 55.5, City = "Pleven", Price = 50000, UserId = context.Users.FirstOrDefault(s=>s.Email=="moonyy@abv.bg").Id},

                new House{Address = "21 Cliffside Heaven", Area = 155.5, City = "Varna", Price = 100000, UserId = context.Users.FirstOrDefault(s=>s.Email=="moonyy@abv.bg").Id},

                new House{Address = "19 Something", Area = 12.5, City = "Kaspichan", Price = 1000, UserId = context.Users.FirstOrDefault(s=>s.Email=="moonyy@abv.bg").Id},
            };

            Houses.ForEach(s => context.Houses.Add(s));
            context.SaveChanges();

            List<Picture> Pictures = new List<Picture>
            {
                new Picture{FileName = "test1.jpg", HouseID = 1},
                new Picture{FileName = "test2.jpg", HouseID = 2},
                new Picture{FileName = "test3.jpg", HouseID = 3}
            };

            Pictures.ForEach(s => context.Pictures.Add(s));
            context.SaveChanges();

            List<Models.Favourite> Favourites = new List<Models.Favourite>
            {
                new Favourite{HouseID = 1, UserId = context.Users.FirstOrDefault(s=>s.Email=="moonyy@abv.bg").Id},
                new Favourite{HouseID = 2, UserId = context.Users.FirstOrDefault(s=>s.Email=="moonyy@abv.bg").Id}
            };


            //context.Pictures.AddOrUpdate(new Models.Picture { });
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
