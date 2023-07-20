
using DataInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Data.InDatabase
{
    public class MovieDBRepository : IMovieRepository
    {


        public Movie AddMovieToMovieRepository(Movie aMovie)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movBD = SearchMovieById(aMovie.Id);
                if (movBD != null)
                {
                    throw new MovieRepoException("Movie already exists");
                }
                else
                {

                    dbContext.Genres.Attach(aMovie.PrimaryGenre);


                    for (int i = 0; i < aMovie.SubGenres.Count; i++) {
                        dbContext.Genres.Attach(aMovie.SubGenres[i]);

                    }

                    for (int i = 0; i < aMovie.RelatedMovies.Count; i++) {
                        int RelatedMovId = aMovie.RelatedMovies[i].Id;
                        aMovie.RelatedMovies[i] = dbContext.Movies.Include("PrimaryGenre").FirstOrDefault(x => x.Id == RelatedMovId);
                        dbContext.Movies.Attach(aMovie.RelatedMovies[i]);
                    }

                    aMovie = dbContext.Movies.Add(aMovie);
                    dbContext.SaveChanges();
                    aMovie = dbContext.Movies.Include("RelatedMovies").FirstOrDefault(x => x.Id == aMovie.Id);
                    for (int i = 0; i < aMovie.RelatedMovies.Count; i++)
                    {
                        int RelatedMovId = aMovie.RelatedMovies[i].Id;
                        Movie RelatedMovie = dbContext.Movies.Include("RelatedMovies").FirstOrDefault(x => x.Id == RelatedMovId);
                        RelatedMovie.RelatedMovies.Add(aMovie);

                    }
                    dbContext.SaveChanges();



                }

                return aMovie;
            }
        }
    

        public void DeleteMovie(int id)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie mov = SearchMovieById(id);
                if (mov != null)
                {

                    DeleteRelatedMovies(mov.Id);
                    DetachSubgenres(mov.Id);
                    DetachAllActingRoles(mov.Id);
                    DetachAllDirctors(mov.Id);
                    DeleteReferencesInProfiles(mov.Id);

                    FinishDeleteMovie(mov.Id);
         
                }
                else
                {
                    throw new MovieRepoException("Movie not found");
                }
            }
        }

        public IList<Movie> GetAllMovies()
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Movies.Include("PrimaryGenre").
                    Include("SubGenres").
                    Include("WatchedBy").
                    Include("SuperLikedBy").
                    Include("LikedBy").
                    Include("DislikedBy").
                    Include("RelatedMovies").
                    Include("Directors").
                    Include("ActingRoles.Member").ToList();
            }
        }

        public Movie SearchMovieById(int id)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Movies.Include("PrimaryGenre").
                    Include("SubGenres").
                    Include("WatchedBy").
                    Include("SuperLikedBy").
                    Include("LikedBy").
                    Include("DislikedBy").
                    Include("RelatedMovies").
                    Include("Directors").
                    Include("ActingRoles.Member").FirstOrDefault(x => x.Id == id);

            }
        }

        public Movie SearchMovieByName(string name)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Movies.Include("PrimaryGenre").
                    Include("SubGenres").
                    Include("WatchedBy").
                    Include("SuperLikedBy").
                    Include("LikedBy").
                    Include("DislikedBy").
                    Include("RelatedMovies").
                    Include("Directors").
                    Include("ActingRoles").FirstOrDefault(x => x.Name == name);
            }
        }

        public void AddActingRoleToMovie(ActingRole Role, int idMovie)
        {
            using (AppDBContext dbContext = new AppDBContext()) {
                Movie movieDB = dbContext.Movies.Include("ActingRoles.Member").FirstOrDefault(x => x.Id == idMovie);
                if (movieDB != null)
                {
                    if (movieDB.ActingRoles.FirstOrDefault(x => x.Name == Role.Name) != null)
                    {
                        throw new MovieRepoException("Acting Role with that name already present in this Movie");
                    }
                    else {
                        Member memberDb = dbContext.Members.FirstOrDefault(x => x.Name == Role.Member.Name);
                        Role.Member = memberDb;
                        movieDB.ActingRoles.Add(Role);
                        dbContext.SaveChanges();


                    }
                }
                else {
                    throw new MovieRepoException("Movie does not exist");

                }

            }

        }
        public void AddDirectorToMovie(Member aDirector, Movie aMovie)
        {

            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie mov = dbContext.Movies.Include("Directors").FirstOrDefault(x => x.Id == aMovie.Id);
                if (mov != null)
                {
                    Member director = dbContext.Members.FirstOrDefault(x => x.Id == aDirector.Id);
                    if (director != null)
                    {
                        mov.AddDirectors(director);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new MemberRepoException("Director not found");
                    }
                }
                else
                {
                    throw new MovieRepoException("Movie not found");
                }
            }
        }

        public void DetachActingRole(ActingRole actingRole, int idMovie)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                ActingRole role = dbContext.ActingRoles.FirstOrDefault(x=>x.Id == actingRole.Id);
                dbContext.Entry(role).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();

            }
        }


        public void DetachDirector(Member aDirector, Movie aMovie)
        {
            using (AppDBContext dbContext = new AppDBContext()) {
                Member member = dbContext.Members.FirstOrDefault(x => x.Id == aDirector.Id);
                Movie movieDB = dbContext.Movies.Include("Directors").FirstOrDefault(x => x.Id == aMovie.Id);
                movieDB.Directors.Remove(member);
                dbContext.SaveChanges();

            }
        }

        private void DetachSubgenres(int movId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDB = dbContext.Movies.Include("Subgenres").FirstOrDefault(x => x.Id == movId);
                movieDB.SubGenres.Clear();
                dbContext.SaveChanges();

            }
        }
        private void FinishDeleteMovie(int id) {

            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie mov = dbContext.Movies.FirstOrDefault(x => x.Id == id);
                dbContext.Entry(mov).State = System.Data.Entity.EntityState.Deleted;
                dbContext.SaveChanges();

            }
    
        }
        private void DeleteRelatedMovies(int id) {

            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie mov = dbContext.Movies.Include("RelatedMovies").FirstOrDefault(x => x.Id == id);
                foreach (Movie relatedMovie in mov.RelatedMovies)
                {
                    dbContext.Movies.Include("RelatedMovies").Include("Directors").FirstOrDefault(x => x.Id == relatedMovie.Id);
                    relatedMovie.RelatedMovies.Remove(mov);
                }
                mov.RelatedMovies.Clear();

                dbContext.SaveChanges();
            }
        }

        private void DetachAllActingRoles(int id) {

            using (AppDBContext dbContext = new AppDBContext()) {


                List<ActingRole> actingRoles = dbContext.ActingRoles.Where(x => x.ActingMovie.Id == id).ToList();

                foreach (ActingRole role in actingRoles)
                {
                    DetachActingRole(role, id);
                }
                dbContext.SaveChanges();
            }
        }

        private void DetachAllDirctors(int id) {

            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie mov = dbContext.Movies.Include("Directors").FirstOrDefault(x => x.Id == id);

                foreach (Member director in mov.Directors)
                {
                    Member member = dbContext.Members.FirstOrDefault(x => x.Id == director.Id);
                    DetachDirector(member, mov);
                }
                dbContext.SaveChanges();
            }
        }

        private void DeleteReferencesInProfiles(int id) {
            using (AppDBContext dbContext = new AppDBContext()) {

                Movie mov = dbContext.Movies.FirstOrDefault(x => x.Id == id);

                List<Profile> AllProfiles = dbContext.Profiles.Include("WatchedMovies").Include("SuperLikedMovies").Include("DisLikedMovies").Include("DisLikedMovies").ToList();

                foreach (Profile prof in AllProfiles)
                {
                    prof.LikedMovies.Remove(mov);
                    prof.SuperLikedMovies.Remove(mov);
                    prof.DisLikedMovies.Remove(mov);
                    prof.WatchedMovies.Remove(mov);
                }
                dbContext.SaveChanges();
            }

        }
    }
}
