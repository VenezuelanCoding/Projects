using Domain;
using Logic.Implementations;
using DataInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicInterfaces;
using System.Collections.Generic;
using UnitTest;
using Data.InDatabase;

namespace Test.Sort
{
    [TestClass]
    public class SortByNameTest
    {    
        
        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }
        [TestMethod]
        public void sortCorrectly()
        {


            IMovieRepository movierepo = new MovieDBRepository();
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();

            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);



            Genre gen1 = new Genre() { Name = "aaaa", Description = "a description"};
            Genre gen2 = new Genre() { Name = "bbbb", Description = "a description" };
            Genre gen3 = new Genre() { Name = "zzzzzzzz", Description = "a description" };
            gen1 = genrerepo.AddGenreToGenreRepository(gen1);
            gen2 = genrerepo.AddGenreToGenreRepository(gen2);
            gen3 = genrerepo.AddGenreToGenreRepository(gen3);

            Movie mov0 = new Movie() { Name = "yyyyy", PrimaryGenre = gen3,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie() { Name = "bbbbb", PrimaryGenre = gen1,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov2 = new Movie() { Name = "ccc", PrimaryGenre = gen2,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov3 = new Movie() { Name = "aa", PrimaryGenre = gen2,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov0 = movierepo.AddMovieToMovieRepository(mov0);
            mov1 = movierepo.AddMovieToMovieRepository(mov1);
            mov2 = movierepo.AddMovieToMovieRepository(mov2);
            mov3 = movierepo.AddMovieToMovieRepository(mov3);

            SortContext sortContext = new SortContext();
            sortContext.SetStrategy("By Name", genreLogic, accountLogic);
            IList<Movie> movies = sortContext.Sort(movieLogic.GetAllMovies());

            Assert.AreEqual(movies[0].Id, mov1.Id);
            Assert.AreEqual(movies[1].Id, mov3.Id);
            Assert.AreEqual(movies[2].Id, mov2.Id);
            Assert.AreEqual(movies[3].Id, mov0.Id);

        }
        [TestMethod]
        [ExpectedException(typeof(SortLogicException), "Sorting type " + "By Date" +" not available")]
        public void IncorrectSortType()
        {
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();

            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);

            SortContext sortContext = new SortContext();
            sortContext.SetStrategy("By Date", genreLogic, accountLogic);


        }

        [TestMethod]
        public void GetToString() {
            ISorting sorter = new SortByName();
            Assert.AreEqual("By Name", sorter.ToString());

        }
    }
}
