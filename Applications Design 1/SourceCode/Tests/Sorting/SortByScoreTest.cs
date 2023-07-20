using DataInterfaces;
using Domain;
using LogicInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Logic.Implementations;
using System.Collections.Generic;
using Data.InDatabase;
using UnitTest;

namespace Test.Sort
{
    [TestClass]
    public class SortByScoreTest
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
            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountRepository accountrepot = new AccountDBRepository();
            IAccountLogic accountLogic = new AccountLogic(accountrepot);

            Genre gen1 = new Genre() { Name = "gen1", Description = "A description"};
            Genre gen2 = new Genre() { Name = "gen2", Description = "A description" };
            Genre gen3 = new Genre() { Name = "gen3", Description = "A description" };

            Genre gen4 = new Genre() { Name = "gen4", Description = "A description" };


            gen1 = genrerepo.AddGenreToGenreRepository(gen1);
            gen2 = genrerepo.AddGenreToGenreRepository(gen2);
            gen3 = genrerepo.AddGenreToGenreRepository(gen3);
            gen4 = genrerepo.AddGenreToGenreRepository(gen4);


            Movie mov0 = new Movie() { Name = "yyyyy", PrimaryGenre = gen3, IsSponsored = true, Id = 1,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
                Description = "a descrption"

            };
            Movie mov1 = new Movie() { Name = "bbbbb", PrimaryGenre = gen1, IsSponsored = false, Id = 2,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
                Description = "a descrption"

            };
            Movie mov2 = new Movie() { Name = "ccc", PrimaryGenre = gen2, IsSponsored = false, Id = 3,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
                Description = "a descrption"

            };
            Movie mov3 = new Movie() { Name = "aa", PrimaryGenre = gen2, IsSponsored = false, Id = 4,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
                Description = "a descrption"

            };
            Movie mov4 = new Movie() { Name = "awra", PrimaryGenre = gen4, IsSponsored = false, Id = 5,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
                Description = "a descrption"
            };


            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            acc = accountLogic.AddNewAccount(acc);

            Profile prof = new Profile() { Alias = "alias1", Pin = "11111"};
            prof = accountLogic.AddProfile(prof, acc);

            Score score1 = new Score() { Genre = gen3, Points = 10 };
            Score score2 = new Score() { Genre = gen2, Points = 5 };
            Score score3 = new Score() { Genre = gen4, Points = -5 };
            score1 = accountLogic.AddScoreToProfile(prof.Id, score1);
            score2 = accountLogic.AddScoreToProfile(prof.Id, score2 );
            score3 = accountLogic.AddScoreToProfile(prof.Id, score3);

            mov0 = movieLogic.AddNewMovie(mov0, acc);
            mov1 = movieLogic.AddNewMovie(mov1, acc);
            mov2 = movieLogic.AddNewMovie(mov2, acc);
            mov3 = movieLogic.AddNewMovie(mov3, acc);
            mov4 = movieLogic.AddNewMovie(mov4, acc);


            accountLogic.SetCurrentProfile(prof);



            SortContext sortContext = new SortContext();
            sortContext.SetStrategy("By Score", genreLogic, accountLogic);
            IList<Movie> movies = sortContext.Sort(movieLogic.GetAllMovies());

            Assert.AreEqual(movies[0].Id, mov0.Id);
            Assert.AreEqual(movies[1].Id, mov3.Id);
            Assert.AreEqual(movies[2].Id, mov2.Id);
            Assert.AreEqual(movies[3].Id, mov1.Id);
            Assert.AreEqual(movies[4].Id, mov4.Id);


        }

        [TestMethod]
        public void GetToString()
        {
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();

            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);


            ISorting sorter = new SortByScore(genreLogic, accountLogic);
            Assert.AreEqual("By Score", sorter.ToString());

        }
    }
}
