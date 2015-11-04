namespace DAL.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DAL.SchoolContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SchoolContext context)
        {

            context.Schools.AddOrUpdate(
                s => s.Id,
                new School { Id = 1, Name = "Chis n Sid", Address = "Hurst Road, Sidcup", TimeStamp = DateTime.Now },
                new School { Id = 2, Name = "Beaverwood", Address = "Chislehurst Road, Chislehurst", TimeStamp = DateTime.Now },
                new School { Id = 3, Name = "Coopers", Address = "Royal Parade", TimeStamp = DateTime.Now }
            );


            context.Students.AddOrUpdate(
                s => s.Id,
                new Student { Id = 1, Name = "Andrew Peters", School = context.Schools.Find(1) },
                new Student { Id = 2, Name = "Brice Lambson", School = context.Schools.Find(1) },
                new Student { Id = 3, Name = "Rowan Miller", School = context.Schools.Find(2) },
                new Student { Id = 4, Name = "Alex Williams", School = null }
            );


        }
    }
}
