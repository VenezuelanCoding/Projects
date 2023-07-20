using Domain;
using Logic.Implementations;
using DataInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using LogicInterfaces;
using System.Collections.Generic;
using Data.InDatabase;
using UnitTest;

namespace Test.Search
{
    [TestClass]
    public class SearchByDirectorsTests

    {

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }
        [TestMethod]
        public void SerachCorrectly()
        {

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            IMovieRepository movierepo = new MovieDBRepository();
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();
            IMemberRepository memberrepo = new MemberDBRepository();

            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);
            IMemberLogic memeberLogic = new MemberLogic(memberrepo);



            Genre gen1 = new Genre() { Name = "aaaa",Description = "a description"};
            Genre gen2 = new Genre() { Name = "bbbb", Description = "a description"};
            Genre gen3 = new Genre() { Name = "zzzzzzzz", Description = "a description"};
            gen1 = genrerepo.AddGenreToGenreRepository(gen1);
            gen2 = genrerepo.AddGenreToGenreRepository(gen2);
            gen3 = genrerepo.AddGenreToGenreRepository(gen3);

            Member director1 = new Member() { Name = "pepe", BirthDate = new DateTime(2000, 7, 7),ProfilePicture = "a.jpg",Type = MemberType.Director };
            Member director2 = new Member() { Name = "juan", BirthDate = new DateTime(2000, 7, 7), ProfilePicture = "a.jpg", Type = MemberType.Director };
            Member director3 = new Member() { Name = "xuan", BirthDate = new DateTime(2000, 7, 7), ProfilePicture = "a.jpg", Type = MemberType.Director };
            Member director4 = new Member() { Name = "pukan", BirthDate = new DateTime(2000, 7, 7), ProfilePicture = "a.jpg", Type = MemberType.Director };

            director1 = memeberLogic.AddNewMember(director1,acc);
            director2 = memeberLogic.AddNewMember(director2, acc);
            director3 = memeberLogic.AddNewMember(director3, acc);
            director4 = memeberLogic.AddNewMember(director4, acc);

            Movie mov0 = new Movie() { Name = "yyyyy", PrimaryGenre = gen3,
                ReleaseDate = new DateTime(2000, 7, 7),
                Poster = "a.jpg",
                Description = "a description"
            };
            Movie mov1 = new Movie() { Name = "bbbbb", PrimaryGenre = gen1, 
                ReleaseDate = new DateTime(2000, 7, 7),
                Poster = "a.jpg",
                Description = "a description"
            };
            Movie mov2 = new Movie() { Name = "ccc", PrimaryGenre = gen2,
                ReleaseDate = new DateTime(2000, 7, 7),
                Poster = "a.jpg",
                Description = "a description"
            };

            Movie mov3 = new Movie() { Name = "aa", PrimaryGenre = gen2,
                ReleaseDate = new DateTime(2000, 7, 7),
                Poster = "a.jpg",
                Description = "a description"
            };

            Movie mov4 = new Movie()
            {
                Name = "aakkj",
                PrimaryGenre = gen2,
    
                ReleaseDate = new DateTime(2000, 7, 7),
                Poster = "a.jpg",
                Description = "a description"
            };


            mov0 = movierepo.AddMovieToMovieRepository(mov0);
            movieLogic.AddDirectorToMovie(director1,acc,mov0);
            mov0 = movieLogic.GetMovieById(mov0.Id);
            movieLogic.AddDirectorToMovie(director2, acc, mov0);
            mov0 = movieLogic.GetMovieById(mov0.Id);

            mov1 = movierepo.AddMovieToMovieRepository(mov1);
            movieLogic.AddDirectorToMovie(director1, acc, mov1);
            mov1 = movieLogic.GetMovieById(mov1.Id);

            mov2 = movierepo.AddMovieToMovieRepository(mov2);
            movieLogic.AddDirectorToMovie(director1, acc, mov2);
            mov2 = movieLogic.GetMovieById(mov2.Id);
            movieLogic.AddDirectorToMovie(director2, acc, mov2);
            mov2 = movieLogic.GetMovieById(mov2.Id);
            movieLogic.AddDirectorToMovie(director3, acc, mov2);
            mov2 = movieLogic.GetMovieById(mov2.Id);

            

            mov3 = movierepo.AddMovieToMovieRepository(mov3);
            mov3 = movieLogic.GetMovieById(mov3.Id);
            movieLogic.AddDirectorToMovie(director3, acc, mov3);
            mov3 = movieLogic.GetMovieById(mov3.Id);





            mov4 = movierepo.AddMovieToMovieRepository(mov4);
            mov4 = movieLogic.GetMovieById(mov4.Id);
            movieLogic.AddDirectorToMovie(director4, acc, mov4);
            mov4 = movieLogic.GetMovieById(mov4.Id);




            SearchContext searchContext = new SearchContext();
            searchContext.SetStrategy("By Director");
            
            IList<Movie> movies = searchContext.Search(movieLogic.GetAllMovies(), "xuan pe");
            Assert.IsTrue(movies[0].Id == mov0.Id);
            Assert.IsTrue(movies[2].Id == mov2.Id);

            Assert.IsTrue(movies[1].Id == mov1.Id);

            Assert.IsTrue(movies[3].Id == mov3.Id);
            Assert.IsFalse(movies.Count >4);

        }
        [TestMethod]
        [ExpectedException(typeof(SearchLogicException), "Search type " + "By Date" +" not available")]
        public void IncorrectSearchType()
        {
            IMovieRepository movierepo = new MovieDBRepository();
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();

            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);

            SearchContext searchContext = new SearchContext();
            searchContext.SetStrategy("By Date");


        }

        [TestMethod]
        public void GetToString() {
            ISearch searcher = new SearchByDirector();
            Assert.AreEqual("By Director", searcher.ToString());

        }
    }
}
