using Data;
using DataInterfaces;
using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Logic.Implementations
{
    public class MovieLogic : IMovieLogic
    {

        private IMovieRepository _repository;
        public MovieLogic(IMovieRepository repo)
        {
            _repository = repo;
        }
        public void AddGenreToSubgenres(Genre aSecondGenre, Movie movie)
        {
             movie.AddGenreToSubgenres(aSecondGenre);
        }

        public Movie AddNewMovie(Movie movie, Account currentAccount)
        {
            if (currentAccount.isAdmin)
            {
                return _repository.AddMovieToMovieRepository(movie);
            }
            else {
                throw new PermissionDeniedException("Account is not Admin");
            }
           
        }

        public void DeleteMovie(Movie movie, Account currentAccount)
        {
            if (currentAccount.isAdmin)
            {
                _repository.DeleteMovie(movie.Id);
            }
            else {
                throw new PermissionDeniedException("Account is not Admin");
            }
        }

        public IList<Movie> GetAllMovies()
        {
            return _repository.GetAllMovies();
        }


        public void AddMovieToRelatedMovies(Movie mov, Movie movOriginal, Account currentAccount)
        {
            if (currentAccount.isAdmin)
            {
                movOriginal.AddMovieToRelatedMovies(mov);
                mov.AddMovieToRelatedMovies(movOriginal);
            }
            else
            {
                throw new PermissionDeniedException("Account is not Admin");
            }
        }

        public IList<Movie> GetAllPGMovies()
        {
            return _repository.GetAllMovies().Where(x => x.IsPG).ToList();
        }

        public IList<Movie> GetMoviesByGenre(Genre genre)
        {

            return _repository.GetAllMovies().Where(x => x.PrimaryGenre.Id == genre.Id || x.SubGenres.Exists(y => y.Id == genre.Id)).ToList();
        }


        public Movie GetMovieById(int id)
        {
            Movie res = _repository.SearchMovieById(id);
            if (res == null)
            {
                throw new MovieRepoException("The id does not match with any movie in the data");
            }
            else
            {
                return res;
            }
        }

        public void AddActingRoleToMovie(ActingRole aRole, Account currentAccount, Movie aMovie)
        {
            if (currentAccount.isAdmin)
            {
                _repository.AddActingRoleToMovie(aRole, aMovie.Id);
            }
            else { 
                throw new PermissionDeniedException("Account is not Admin");
            }

            
        }

        public void DetachActingRole(ActingRole aRole, Account currentAccount, Movie aMovie)
        {
            if (currentAccount.isAdmin)
            {
                _repository.DetachActingRole(aRole, aMovie.Id);
            }
            else
            {
                throw new PermissionDeniedException("Account is not Admin");
            }
        }

        public void AddDirectorToMovie(Member aDirector, Account currentAccount, Movie aMovie)
        {
            if (currentAccount.isAdmin)
            {
                _repository.AddDirectorToMovie(aDirector, aMovie);
            }
            else
            {
                throw new PermissionDeniedException("Account is not Admin");
            }
        }

        public void DetachDirector(Member aDirector, Account currentAccount, Movie aMovie)
        {
            if (currentAccount.isAdmin)
            {
                _repository.DetachDirector(aDirector, aMovie);
            }
            else
            {
                throw new PermissionDeniedException("Account is not Admin");
            }
        }
    }
}
