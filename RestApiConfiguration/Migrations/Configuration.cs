using RestApiConfiguration.Data;

namespace RestApiConfiguration.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<RestApiConfiguration.Data.ConfigDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(RestApiConfiguration.Data.ConfigDbContext context)
        {
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
            var cfg1 = new ConfigurationEntity()
            {
                EmailAdress = "extragalactic88@gmail.com",
                ConfigName = "FirstConfig",
                Registration = true,
                HostingName = "somee.com",
                TypeOfHosting = "paid",
                FtpUserName = "extragalactic"
            };

            var cfg2 = new ConfigurationEntity()
            {
                EmailAdress = "euwc@gmail.com",
                ConfigName = "SecondConfig",
                Registration = false,
                HostingName = "godaddy.com",
                TypeOfHosting = "paid",
                FtpUserName = "euwc"
            };

            context.Configurations.Add(cfg1);
            context.Configurations.Add(cfg2);
        }
    }
}
