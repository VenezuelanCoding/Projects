using Domain;
using System.Collections.Generic;
using System;


namespace DataInterfaces
{
    public interface IMovieRepository
    {
        Movie AddMovieToMovieRepository(Movie aMovie);

        IList<Movie> GetAllMovies();

        Movie SearchMovieByName(string name);

        void DeleteMovie(int id);

        Movie SearchMovieById(int id);

        void AddActingRoleToMovie(ActingRole ActingRole, int idMovie);
        
        void AddDirectorToMovie(Member aDirector, Movie aMovie);

        void DetachActingRole(ActingRole actingRole, int idMovie);

        void DetachDirector(Member aDirector, Movie aMovie);

    }

}
