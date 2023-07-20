
using Data;
using Data.InDatabase;
using Domain;
using Logic.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UnitTest;

namespace Logic.Test

{
    [TestClass]
    public class GenreLogicTest
    {
        private GenreDBRepository _genreDBRepository;
        
        public GenreLogicTest()
        {
            _genreDBRepository = new GenreDBRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }


        [TestMethod]
        public void NewGenre()
        {
            Account curerntAccount = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };



            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };

            GenreDBRepository repo = _genreDBRepository;
            GenreLogic logic = new GenreLogic(repo);
            gen = logic.AddNewGenre(gen, curerntAccount);
            Assert.IsTrue(logic.GetAllGenres().Count == 1);
        }
        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]

        public void FailAdminPermissions()
        {
            Account curerntAccount = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = false
            };



            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            gen = logic.AddNewGenre(gen,curerntAccount);
        }


        [TestMethod]
        [ExpectedException(typeof(GenreRepoException))]
        public void GenreAlreadyExists()
        {
            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true
            };
            Genre gen = new Genre { Name = "Horror", Description = "a description"};
            Genre gen2 = new Genre { Name = "Horror", Description = "a description" };
            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            logic.AddNewGenre(gen,curerntAccount);
            logic.AddNewGenre(gen2, curerntAccount);

        }

        [TestMethod]
        public void GetAllGenres()
        {
            Account curerntAccount = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };



            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };

            Genre gen2 = new Genre()
            {
                Name = "Action",
                Description = "A description",
            };
            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            logic.AddNewGenre(gen, curerntAccount);
            logic.AddNewGenre(gen2, curerntAccount);

            Assert.AreEqual(2, logic.GetAllGenres().Count);
        }

        [TestMethod]
        public void GenreDoesNotExists()
        {
            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true
            };
            Genre gen = new Genre() { Name = "Horror" };
            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            logic.AddNewGenre(gen, curerntAccount);
            Assert.IsNull(logic.SearchGenre("Halloween"));
        }

        [TestMethod]
        public void GetAllGenresIsEmpty()
        {

            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            Assert.AreEqual(0, logic.GetAllGenres().Count);

        }

       [TestMethod]
        public void DeleteExistingGenre()
        {
            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true
            };

            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            Genre gen = new Genre { Name = "Saw III", Description = "a description"};
            logic.AddNewGenre(gen, curerntAccount);
            Assert.AreEqual(1, logic.GetAllGenres().Count);
            logic.DeleteGenre(gen.Name, curerntAccount);
            Assert.AreEqual(0, logic.GetAllGenres().Count);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]

        public void DeleteGenreFailPermissions()
        {
            Account admin = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true
            };

            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = false
            };

            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            Genre gen = new Genre { Name = "Saw III" , Description = "a description"};
            logic.AddNewGenre(gen, admin);
            Assert.AreEqual(1, logic.GetAllGenres().Count);
            logic.DeleteGenre(gen.Name, curerntAccount);
        }


        [TestMethod]
        [ExpectedException(typeof(GenreRepoException))]
        public void DeleteNonExistingGenre()
        {
            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true
            };

            Genre gen = new Genre { Name = "Horror" , Description = "a description"};
            GenreDBRepository repo = new GenreDBRepository();
            GenreLogic logic = new GenreLogic(repo);
            Genre res = logic.AddNewGenre(gen,curerntAccount);
            logic.DeleteGenre("Action", curerntAccount);
        }
    }
}
