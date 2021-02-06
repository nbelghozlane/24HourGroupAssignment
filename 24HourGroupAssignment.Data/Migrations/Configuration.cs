namespace _24HourGroupAssignment.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<_24HourGroupAssignment.Data.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
<<<<<<< HEAD
            ContextKey = "_24HourGroupAssignment.Data.ApplicationDbContext";
=======
>>>>>>> 001f48e617f223252f53de89891965b5441c17bb
        }

        protected override void Seed(_24HourGroupAssignment.Data.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
