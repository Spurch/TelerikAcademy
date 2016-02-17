namespace MovieSystem.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieSystemDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieSystemDbContext context)
        {
            var leadActor = new Actor()
            {
                Age = 24,
                FirstName = "John",
                LastName = "Doe",
            
            };
            context.Actors.Add(leadActor);

            var leadActress = new Actor()
            {
                Age = 21,
                FirstName = "Jane",
                LastName = "Oswald",

            };
            context.Actors.Add(leadActress);

            var movie01 = new Movie()
            {
                Director = "DirectorZ",
                Name = "SomeMovie",
                Title = "SomeTitle",
                Year = "2001",
                LeadingMale = leadActor,
                LeadingFemale = leadActress
            };
            context.Movies.Add(movie01);


            var studio01 = new Studio()
            {
                Address = "CA, Hollywood, USA",
                Name = "StudioX",
            };

            studio01.Movies.Add(movie01);

            var studio02 = new Studio()
            {
                Address = "Paris, Alfel Tower, Fance",
                Name = "StudioY"
            };

            context.Studios.Add(studio01);
            context.Studios.Add(studio02);
            context.SaveChanges();
        }
    }
}
