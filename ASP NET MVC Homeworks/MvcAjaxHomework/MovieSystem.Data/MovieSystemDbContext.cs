namespace MovieSystem.Data
{
    using System;
    using System.Data.Entity;
    using MovieSystem.Models;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using System.Data.Entity.Infrastructure;

    public class MovieSystemDbContext : DbContext, IMovieSystemDbContext
    {
        public MovieSystemDbContext()
            :base("defaultConnection")
        {

        }

        public IDbSet<Actor> Actors { get; set; }

        public IDbSet<Movie> Movies { get; set; }

        public IDbSet<Studio> Studios { get; set; }


        public static MovieSystemDbContext Create()
        {
            return new MovieSystemDbContext();
        }
    }
}
