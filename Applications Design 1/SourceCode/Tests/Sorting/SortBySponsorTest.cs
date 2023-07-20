using Domain;
using Logic.Implementations;
using DataInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LogicInterfaces;
using System.Collections.Generic;
using Data.InDatabase;
using UnitTest;
using System;

namespace Test.Sort
{
    [TestClass]
    public class SortBySponsorTest
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

            Genre gen1 = new Genre() { Name = "aaaa", Description = "a description" };
            Genre gen2 = new Genre() { Name = "bbbb", Description = "a description" };
            Genre gen3 = new Genre() { Name = "zzzzzzzz", Description = "a description" };
            gen1 = genrerepo.AddGenreToGenreRepository(gen1);
            gen2 = genrerepo.AddGenreToGenreRepository(gen2);
            gen3 = genrerepo.AddGenreToGenreRepository(gen3);



            Movie mov0 = new Movie()
            {
                Name = "yyy",
                PrimaryGenre = gen3,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = true,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            Movie mov1 = new Movie()
            {
                Name = "bbb",
                PrimaryGenre = gen1,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            Movie mov2 = new Movie()
            {
                Name = "ccc",
                PrimaryGenre = gen2,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov3 = new Movie()
            {
                Name = "aaa",
                PrimaryGenre = gen2,
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
            sortContext.SetStrategy("By Sponsor", genreLogic, accountLogic);
            IList<Movie> movies = sortContext.Sort(movieLogic.GetAllMovies());



            Assert.AreEqual(movies[0].Id, mov0.Id);
            Assert.AreEqual(movies[1].Id, mov1.Id);
            Assert.AreEqual(movies[2].Id, mov3.Id);
            Assert.AreEqual(movies[3].Id, mov2.Id);

        }
        [TestMethod]
        public void GetToString()
        {
            IMovieRepository movierepo = new MovieDBRepository();
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();

            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);

            SortContext sortContext = new SortContext();
            sortContext.SetStrategy("By Sponsor", genreLogic, accountLogic);

            Assert.AreEqual("By Sponsor", sortContext.ToString());

            sortContext.SetStrategy("By Name", genreLogic, accountLogic);

            Assert.AreEqual("By Name", sortContext.ToString());

            sortContext.SetStrategy("By Score", genreLogic, accountLogic);
            Assert.AreEqual("By Score", sortContext.ToString());


        }
    }
}
