
using DataInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.InDatabase
{
    public class GenreDBRepository : IGenreRepository
    
    {
        public Genre AddGenreToGenreRepository(Genre aGenre)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Genre gen = SearchGenre(aGenre.Name);
                if (gen != null)
                {
                    throw new GenreRepoException("Genre already exists");
                }
                else
                {
                    dbContext.Genres.Add(aGenre);
                    dbContext.SaveChanges();
                }

                return aGenre;
            }
        }

        public void DeleteGenre(string name)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Genre gen = SearchGenre(name);
                List<Movie> primary;
                List<Movie> secondary;
                if (gen != null)
                {
                    primary = dbContext.Movies.Where(x => x.PrimaryGenre.Id == gen.Id).ToList();
                    secondary = dbContext.Movies.Where(x => x.SubGenres.Any(g => g.Id == gen.Id)).ToList();

                }
                else {
                    throw new GenreRepoException("Genre not found");

                }


                if (primary.Count == 0 && secondary.Count == 0)
                {
                    dbContext.Entry(gen).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.Genres.Remove(gen);
                    dbContext.SaveChanges();
                }
                else {
                    throw new GenreRepoException("There is at least one movie with this Genre or SubGenre");
                }
            }
        }

        public IList<Genre> GetAllGenres()
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Genres.ToList();
            }
        }

        public Genre SearchGenre(string name)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Genres.FirstOrDefault(x => x.Name == name);
            }
        }
    }
}
