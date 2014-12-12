namespace community_house.Migrations
{
    using community_house.Models;
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
                new House{Address = "1 Shire Oak Road", Area = 55.5, City = "Pleven", Price = 50000, UserId = "da681c1a-d246-44c8-ba2f-9a6a351ce83f"},

                new House{Address = "21 Cliffside Heaven", Area = 155.5, City = "Varna", Price = 100000, UserId = "da681c1a-d246-44c8-ba2f-9a6a351ce83f"},

                new House{Address = "19 Something", Area = 12.5, City = "Kaspichan", Price = 1000, UserId = "da681c1a-d246-44c8-ba2f-9a6a351ce83f"},
            };

            Houses.ForEach(s => context.Houses.Add(s));
            context.SaveChanges();

            List<Picture> Pictures = new List<Picture>
            {
                new Picture{FileName = "test.png", HouseID = 1},
                new Picture{FileName = "test.png", HouseID = 2},
                new Picture{FileName = "test.png", HouseID = 3}
            };

            Pictures.ForEach(s => context.Pictures.Add(s));
            context.SaveChanges();


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
