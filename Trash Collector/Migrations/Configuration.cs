namespace Trash_Collector.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Trash_Collector.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Trash_Collector.Models.ApplicationDbContext context)
        {
            context.ZipCodes.AddOrUpdate(rst => rst.ZipCodeId,
               new Models.ZipCode() { ZipCodeId = 1, ZipCodeArea = 53719 },
               new Models.ZipCode() { ZipCodeId = 2, ZipCodeArea = 53711 },
               new Models.ZipCode() { ZipCodeId = 3, ZipCodeArea = 53513 },
               new Models.ZipCode() { ZipCodeId = 4, ZipCodeArea = 53710 },
               new Models.ZipCode() { ZipCodeId = 5, ZipCodeArea = 53715 });


            context.PickUpDays.AddOrUpdate(nxt => nxt.PickUpId,
            new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Sunday" },
            new Models.PickUpDay() { PickUpId = 2, PickUpWeekday = "Monday" },
            new Models.PickUpDay() { PickUpId = 3, PickUpWeekday = "Tuesday" },
            new Models.PickUpDay() { PickUpId = 4, PickUpWeekday = "Wednesday" },
            new Models.PickUpDay() { PickUpId = 5, PickUpWeekday = "Thursday" },
            new Models.PickUpDay() { PickUpId = 6, PickUpWeekday = "Friday" },
            new Models.PickUpDay() { PickUpId = 7, PickUpWeekday = "Saturday" });

            //context.PickUpDays.AddOrUpdate(nxt => nxt.PickUpId,
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Sunday" },
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Monday" },
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Tuesday" },
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Wednesday" },
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Thursday" },
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Friday" },
            //new Models.PickUpDay() { PickUpId = 1, PickUpWeekday = "Saturday" });





            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
