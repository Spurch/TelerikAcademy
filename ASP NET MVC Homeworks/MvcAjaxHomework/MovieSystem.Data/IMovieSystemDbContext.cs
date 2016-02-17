namespace MovieSystem.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using MovieSystem.Models;

    public interface IMovieSystemDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<Actor> Actors { get; set; }

        IDbSet<Movie> Movies { get; set; }

        IDbSet<Studio> Studios { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
