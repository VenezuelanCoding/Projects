using Domain;
using System.Collections.Generic;
using System.IO;

namespace LogicInterfaces
{
    public interface IMovieLogic
    {
        Movie AddNewMovie(Movie movie, Account currentAccount);

        IList<Movie> GetAllMovies();

        void AddGenreToSubgenres(Genre aSecondGenre, Movie aMovie);

        void AddMovieToRelatedMovies(Movie related, Movie Original, Account currentAccount);

        void DeleteMovie(Movie movie, Account currentAccount);

        IList<Movie> GetAllPGMovies();

        IList<Movie> GetMoviesByGenre(Genre genre);

        Movie GetMovieById(int id);

        void AddActingRoleToMovie(ActingRole aRole, Account currentAccount, Movie aMovie);

        void DetachActingRole(ActingRole aRole, Account currentAccount, Movie aMovie);

        void AddDirectorToMovie(Member aDirector, Account currentAccount, Movie aMovie);
        
        void DetachDirector(Member aDirector, Account currentAccount, Movie aMovie);
    }
}
