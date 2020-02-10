namespace EventHub.DAL.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EventHub.DAL.OurDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EventHub.DAL.OurDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var users = new List<User>
             {
                new User {UserName="saifejaz", Email="ssaifejaz228@gmail.com", Password="Passw0rd@123",Role="A",},
                new User { UserName = "shubhamgarg", Email = "shubhamgarg@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "palakgarg", Email = "palakgarg@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "rossgeller", Email = "ross.geller@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "rachelgreen", Email = "rachel.green@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "joeytribbiani", Email = "joey.triabbiani@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "phoebebuffey", Email = "phoebe.buffey@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "chandlerbing", Email = "chandler.bing@gmail.com", Password = "Passw0rd@123", Role = "U", },
                new User { UserName = "monikageller", Email = "monika.geller@gmail.com", Password = "Passw0rd@123", Role = "U", }

            };
            users.ForEach(s => context.Users.AddOrUpdate(p => p.UserName, s));
            context.SaveChanges();

            var events = new List<Event>
            {
                new Event{Title="Gandhi Jayanti",Date=DateTime.Parse("2020-02-20"),Location="Delhi"
                ,StartTime="12:00",Type="Public",Duration=4,Description="Gandhi Birthday",OtherDetails="Happy bday",UserID=2},

                new Event{Title="Holi",Date=DateTime.Parse("2020-03-10"),Location="Noida"
                ,StartTime="10:00",Type="Private",Duration=3,Description="Holi hai",OtherDetails="Happy holi",UserID=3},

                new Event{Title="Book Lover's Community",Date=DateTime.Parse("2020-03-15"),Location="Ghaziabad"
                ,StartTime="15:00",Type="Public",Duration=2,Description="Interesting",OtherDetails="good",UserID=4},

                new Event{Title="Sensuality in Literature",Date=DateTime.Parse("2020-02-22"),Location="Gr.Noida"
                ,StartTime="8:00",Type="Public",Duration=5,Description="nice",OtherDetails="knowledgeable",UserID=5},

                new Event{Title="Tale-A-Thon",Date=DateTime.Parse("2020-02-25"),Location="Delhi"
                ,StartTime="11:00",Type="Public",Duration=3,Description="amazing",OtherDetails="really",UserID=6},

            };
            events.ForEach(s => context.Events.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var invitations = new List<Invitation>
                {
                    new Invitation{ EventID=1,Email="palak@gmail.com"},
                    new Invitation{ EventID=1,Email="ross.geller@gmail.com"},
                    new Invitation{ EventID=1,Email="rachel.green@gmail.com"},
                    new Invitation{ EventID=1,Email="joey.triabbiani@gmail.com"},
                    new Invitation{ EventID=1,Email="phoebe.buffey@gmail.com"}

                };
            invitations.ForEach(s => context.Invitations.AddOrUpdate(s));
            context.SaveChanges();
        }
    }
}
