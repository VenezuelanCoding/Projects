using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.InDatabase
{
    public class AppDBContext : DbContext
    {

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<ActingRole> ActingRoles { get; set; }
        public DbSet<Score> Scores { get; set; }
        public AppDBContext() : base("AppDB")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {       
            modelBuilder.Entity<Movie>()
            .HasMany<Genre>(m => m.SubGenres)
            .WithMany(g => g.Movies)
            .Map(mg =>
            {
                mg.MapLeftKey("MovieRefId");
                mg.MapRightKey("GenreRefId");
                mg.ToTable("HasSubgenres");
            });

            modelBuilder.Entity<Movie>()
            .HasMany<Movie>(m1 => m1.RelatedMovies)
            .WithMany()
            .Map(m1m2 =>
            {
                m1m2.MapLeftKey("MovieRefId");
                m1m2.MapRightKey("RelatedRefId");
                m1m2.ToTable("RelatedMovies");
            });

            modelBuilder.Entity<Movie>()
            .HasMany<Member>(m => m.Directors)
            .WithMany(m2 => m2.DirectMovies)
            .Map(m1m2 =>
            {
                m1m2.MapLeftKey("MovieRefId");
                m1m2.MapRightKey("MemberRefId");
                m1m2.ToTable("Directs");
            });

            modelBuilder.Entity<Movie>()
            .HasMany<Profile>(m => m.WatchedBy)
            .WithMany(p => p.WatchedMovies)
            .Map(mp =>
            {
                mp.MapLeftKey("MovieRefId");
                mp.MapRightKey("ProfileRefId");
                mp.ToTable("WatchedBy");
            });

            modelBuilder.Entity<Movie>()
           .HasMany<Profile>(m => m.SuperlikedBy)
           .WithMany(p => p.SuperLikedMovies)
           .Map(mp =>
           {
               mp.MapLeftKey("MovieRefId");
               mp.MapRightKey("ProfileRefId");
               mp.ToTable("SuperLikedBy");
           });

           modelBuilder.Entity<Movie>()
          .HasMany<Profile>(m => m.LikedBy)
          .WithMany(p => p.LikedMovies)
          .Map(mp =>
          {
              mp.MapLeftKey("MovieRefId");
              mp.MapRightKey("ProfileRefId");
              mp.ToTable("LikedBy");
          });

            modelBuilder.Entity<Movie>()
          .HasMany<Profile>(m => m.DislikedBy)
          .WithMany(p => p.DisLikedMovies)
          .Map(mp =>
          {
              mp.MapLeftKey("MovieRefId");
              mp.MapRightKey("ProfileRefId");
              mp.ToTable("DislikedBy");
          });
        }

    }
}
