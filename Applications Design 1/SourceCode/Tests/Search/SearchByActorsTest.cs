using Domain;
using Logic.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataInterfaces;
using LogicInterfaces; 
using System.Collections.Generic;
using Data.InDatabase;
using UnitTest;

namespace Test.Search
{
    [TestClass]
    public class SearchByActorsTests

    {
        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }
        [TestMethod]
        public void SerachCorrectly()
        {


            IMovieRepository movierepo = new MovieDBRepository();
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();
            IMemberRepository memberrepo = new MemberDBRepository();


            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);
            IMemberLogic memeberLogic = new MemberLogic(memberrepo);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            Genre gen1 = new Genre() { Name = "aaaa", Description = "a description" };
            Genre gen2 = new Genre() { Name = "bbbb", Description = "a description" };
            Genre gen3 = new Genre() { Name = "zzzzzzzz", Description = "a description" };
            gen1 = genrerepo.AddGenreToGenreRepository(gen1);
            gen2 = genrerepo.AddGenreToGenreRepository(gen2);
            gen3 = genrerepo.AddGenreToGenreRepository(gen3);


            Member actor1 = new Member() { Name = "pepe", BirthDate = new DateTime(2000, 7, 7), ProfilePicture = "a.jpg", Type = MemberType.Actor };
            Member actor2 = new Member() { Name = "juan", BirthDate = new DateTime(2000, 7, 7), ProfilePicture = "a.jpg", Type = MemberType.Actor };
            Member actor3 = new Member() { Name = "xuan", BirthDate = new DateTime(2000, 7, 7), ProfilePicture = "a.jpg", Type = MemberType.ActorAndDirector };
            actor1 = memeberLogic.AddNewMember(actor1, acc);
            actor2 = memeberLogic.AddNewMember(actor2, acc);
            actor3 = memeberLogic.AddNewMember(actor3, acc);




            ActingRole role1 = new ActingRole() {Member = actor1, Name = "spiderman" };

            ActingRole role2 = new ActingRole() { Member = actor2 , Name = "PeterParker" };
            ActingRole role3 = new ActingRole() { Member = actor3, Name = "Jose" };
            ActingRole role4 = new ActingRole() { Member = actor1, Name = "spiderman" };
            ActingRole role5 = new ActingRole() { Member = actor3, Name = "Jose" };
            ActingRole role6 = new ActingRole() { Member = actor1, Name = "spiderman" };
            ActingRole role7 = new ActingRole() { Member = actor2, Name = "PeterParker" };
            ActingRole role8 = new ActingRole() { Member = actor1, Name = "spiderman" };






            Movie mov0 = new Movie()
            {
                Name = "yyyyy",
                PrimaryGenre = gen3,
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
                Description = "a description",
            };
            Movie mov3 = new Movie() { Name = "aa", PrimaryGenre = gen2,
                ReleaseDate = new DateTime(2000, 7, 7),
                Poster = "a.jpg",
                Description = "a description"
            };


            mov0 = movierepo.AddMovieToMovieRepository(mov0);
            movieLogic.AddActingRoleToMovie(role1, acc, mov0);
            mov0 = movieLogic.GetMovieById(mov0.Id);
            movieLogic.AddActingRoleToMovie(role2, acc, mov0);
            mov0 = movieLogic.GetMovieById(mov0.Id);



            mov1 = movierepo.AddMovieToMovieRepository(mov1);
            movieLogic.AddActingRoleToMovie(role4, acc, mov1);
            mov1 = movieLogic.GetMovieById(mov1.Id);
            movieLogic.AddActingRoleToMovie(role5, acc, mov1);
            mov1 = movieLogic.GetMovieById(mov1.Id);

            mov2 = movierepo.AddMovieToMovieRepository(mov2);
            mov2 = movieLogic.GetMovieById(mov2.Id);
            movieLogic.AddActingRoleToMovie(role6, acc, mov2);
            mov2 = movieLogic.GetMovieById(mov2.Id);
            movieLogic.AddActingRoleToMovie(role7, acc, mov2);
            mov2 = movieLogic.GetMovieById(mov2.Id);


            mov3 = movierepo.AddMovieToMovieRepository(mov3);
            movieLogic.AddActingRoleToMovie(role8, acc, mov3);
            mov3 = movieLogic.GetMovieById(mov3.Id);




            SearchContext searchContext = new SearchContext();
            searchContext.SetStrategy("By Actor");
            
            IList<Movie> movies = searchContext.Search(movieLogic.GetAllMovies(), "uan");



            Assert.IsTrue(movies[0].Id == mov0.Id);
            Assert.IsTrue(movies[2].Id == mov2.Id);

            Assert.IsTrue(movies[1].Id == mov1.Id);

            Assert.IsFalse(movies.Count > 3);

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
            IMovieRepository movierepo = new MovieDBRepository();
            IGenreRepository genrerepo = new GenreDBRepository();
            IAccountRepository accounterepo = new AccountDBRepository();

            IMovieLogic movieLogic = new MovieLogic(movierepo);
            IGenreLogic genreLogic = new GenreLogic(genrerepo);
            IAccountLogic accountLogic = new AccountLogic(accounterepo);

            SearchContext searchContext = new SearchContext();
            searchContext.SetStrategy("By Actor");
            Assert.AreEqual("By Actor", searchContext.ToString());


        }
    }
}
