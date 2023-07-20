using Data.Exceptions;
using Data.InMemory;
using Domain;
using Domain.exceptions.Movies;
using Logic.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Logic.Test
{
    [TestClass]
    public class MovieLogicTest
    {
        [TestMethod]
        public void NewMovie()
        {
            Movie mov = new Movie();
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.CreateMovie(mov);
            Assert.AreEqual(res, mov);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoMovieDuplicate))]
        public void MovieAlreadyExists()
        {
            Movie mov = new Movie { Name = "Scarface"};
            Movie mov2 = new Movie { Name = "Scarface" };
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            logic.CreateMovie(mov);
            logic.CreateMovie(mov2);

        }

        [TestMethod]
        public void MovieExists()
        {
            Movie mov = new Movie();
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.CreateMovie(mov);
            Assert.AreEqual(res, logic.GetMovie(mov.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoMovieNotFound))]
        public void MovieDoesNotExists()
        {
            Movie mov = new Movie();
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.CreateMovie(mov);
            logic.GetMovie("Halloween");
        }

        [TestMethod]
        public void GetAllMoviesIsEmpty()
        {

            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Assert.AreEqual(0, logic.GetAllMovies().Count);

        }

        [TestMethod]
        public void GetAllMoviesIsNotEmpty()
        {

            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Movie mov = new Movie();
            logic.CreateMovie(mov);
            Assert.AreNotEqual(0, logic.GetAllMovies().Count);

        }

        [TestMethod]
        public void DeleteExistingMovie()
        {
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Movie mov = new Movie { Name = "Saw III"};
            logic.CreateMovie(mov);
            logic.DeleteMovie(mov);
            Assert.AreEqual(0, logic.GetAllMovies().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoMovieNotFound))]
        public void DeleteNonExistingMovie()
        {
            Movie mov = new Movie { Name = "Your name"};
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.CreateMovie(mov);
            logic.GetMovie("Halloween");
        }

        [TestMethod]
        public void AddRelatedValidMovieToRelatedMovie()
        {
            Movie mov = new Movie { Name = "Your name" };
            Movie mov2 = new Movie { Name = "A silent voice" };
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            logic.CreateMovie(mov);
            logic.CreateMovie(mov2);
            logic.AddMovieToRelatedMovies(mov2, mov);
            Assert.IsTrue(mov.RelatedMovies.Contains(mov2));
            Assert.IsTrue(mov2.RelatedMovies.Contains(mov));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieAddedToSameMovie))]
        public void MovieAddsItselfToRelatedMovies()
        {
            Movie mov = new Movie { Name = "A silent voice" };
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            logic.CreateMovie(mov);
            logic.AddMovieToRelatedMovies(mov, mov);
        }

        [TestMethod]
        public void DeleteMovieThatIsRelatedToOthers()
        {
            Movie mov = new Movie { Name = "Your name" };
            Movie mov2 = new Movie { Name = "A silent voice" };
            Movie mov3 = new Movie { Name = "Quintessial Quintuplets" };
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            logic.CreateMovie(mov);
            logic.CreateMovie(mov2);
            logic.CreateMovie(mov3);
            logic.AddMovieToRelatedMovies(mov2, mov);
            logic.AddMovieToRelatedMovies(mov3, mov);
            logic.DeleteMovie(mov);
            Assert.IsFalse(mov3.RelatedMovies.Contains(mov));
            Assert.IsFalse(mov2.RelatedMovies.Contains(mov));
        }

        [TestMethod]
        public void AddValidSubgenre()
        {
            Genre gen = new Genre { Name = "Romance" };
            Movie mov = new Movie { Name = "Quintessial Quintuplets", PrimaryGenre = gen};
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Genre subgen = new Genre { Name = "Comedy" };
            logic.CreateMovie(mov);
            logic.AddGenreToSubgenres(subgen, mov);
            Assert.IsTrue(mov.SubGenres.Contains(subgen));
        }

        [TestMethod]
        [ExpectedException(typeof(GenreIsSameAsPrimary))]
        public void AddPrimaryToSubgenre()
        {
            Genre gen = new Genre { Name = "Romance" };
            Movie mov = new Movie { Name = "Quintessial Quintuplets", PrimaryGenre = gen };
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Genre subgen = new Genre { Name = "Comedy" };
            logic.CreateMovie(mov);
            logic.AddGenreToSubgenres(gen, mov);
        }

        [TestMethod]
        [ExpectedException(typeof(RepeatedSecundaryGenreInMovie))]
        public void AddRepeatedToSubgenre()
        {
            Genre gen = new Genre { Name = "Romance" };
            Movie mov = new Movie { Name = "Quintessial Quintuplets", PrimaryGenre = gen };
            MovieMemoryRepository repo = new MovieMemoryRepository();
            MovieLogic logic = new MovieLogic(repo);
            Genre subgen = new Genre { Name = "Comedy" };
            logic.CreateMovie(mov);
            logic.AddGenreToSubgenres(subgen, mov);
            logic.AddGenreToSubgenres(subgen, mov);
        }
    }
}
