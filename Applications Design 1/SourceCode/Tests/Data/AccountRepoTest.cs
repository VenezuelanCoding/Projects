using Data;
using Data.InDatabase;
using DataInterfaces;
using Domain;
using LogicInterfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTest;

namespace Tests.Data
{
    [TestClass]
    public class AccountRepoTest
    {

        private AccountDBRepository _accountDBRepository;
        private MovieDBRepository _movieDBRepository;
        private GenreDBRepository _genreDBRepository;

        public AccountRepoTest()
        {
            _accountDBRepository = new AccountDBRepository();
            _movieDBRepository = new MovieDBRepository();
            _genreDBRepository = new GenreDBRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }




        [TestMethod]
        public void AddAccount()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc = repo.AddAccountToRepository(acc);
            Account acc2 = repo.SearchAccountName(acc.UserName);
            Assert.AreEqual(acc.UserName, acc2.UserName);
            Assert.AreEqual(acc.Email, acc2.Email);
            Assert.AreEqual(acc.Password, acc2.Password);
        }

        [TestMethod]
        public void GetAllAccounts()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            Account acc2 = new Account()
            {
                UserName = "user1234567234",
                Email = "user2@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);
            acc2=repo.AddAccountToRepository(acc2);


            IList<Account> list = repo.GetAllAccounts();
            Assert.IsNotNull(list.FirstOrDefault(x => x.UserName == acc1.UserName));
            Assert.IsNotNull(list.FirstOrDefault(x => x.UserName == acc2.UserName));
        }
        [TestMethod]
        public void SearchAccount()
        {
            AccountDBRepository repo = _accountDBRepository;

            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            Account acc2 = new Account()
            {
                UserName = "user1234567234",
                Email = "user2@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);
            acc2=repo.AddAccountToRepository(acc2);

            Assert.IsNotNull(repo.SearchAccountName(acc1.UserName));
            Assert.IsNotNull(repo.SearchAccountName(acc2.UserName));
            Assert.IsNotNull(repo.SearchAccountEmail(acc1.Email));
            Assert.IsNotNull(repo.SearchAccountEmail(acc2.Email));
        }





        [TestMethod]
        public void SearchAccountNotFound()
        {
            AccountDBRepository repo = _accountDBRepository;

            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            Account acc2 = new Account()
            {
                UserName = "user1234567234",
                Email = "user2@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);


            Assert.IsNotNull(repo.SearchAccountName(acc1.UserName));
            Assert.IsNotNull(repo.SearchAccountEmail(acc1.Email));

            Assert.IsNull(repo.SearchAccountName(acc2.UserName));
            Assert.IsNull(repo.SearchAccountEmail(acc2.Email));
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Account already exists")]
        public void DuplicateAccountUserName()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"

            };
            Account acc2 = new Account()
            {
                UserName = "user1234567234",
                Email = "user2@hotmail.com",
                Password = "user1234567"

            };
            Account acc3 = new Account()
            {
                UserName = "user1234567",
                Email = "asdfasdf@hotmail.com",
                Password = "user1234567"

            };
            repo.AddAccountToRepository(acc1);
            repo.AddAccountToRepository(acc2);
            repo.AddAccountToRepository(acc3);
        }
        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Account already exists")]
        public void DuplicateAccountEmail()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            Account acc2 = new Account()
            {
                UserName = "user1234567234",
                Email = "user2@hotmail.com",
                Password = "user1234567"
            };
            Account acc3 = new Account()
            {
                UserName = "useuser123434r3",
                Email = "user2@hotmail.com",
                Password = "user1234567"
            };
            repo.AddAccountToRepository(acc1);
            repo.AddAccountToRepository(acc2);
            repo.AddAccountToRepository(acc3);
        }

        [TestMethod]
        public void AddingValidProfile()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            repo.AddProfile(p1, acc1);
            repo.AddProfile(p2, acc1);

            Assert.AreEqual(2, repo.SearchAccountName("user1234567").Profiles.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile already exists in this account")]
        public void AddingRepeatedProfile()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p2 = new Profile()
            {
                Alias = "Rafael",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            repo.AddProfile(p1, acc1);
            repo.AddProfile(p2, acc1);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Cannot add more than 4 profiles")]
        public void MaxProfilesReached()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p3 = new Profile()
            {
                Alias = "Daniel",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p4 = new Profile()
            {
                Alias = "Andrea",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p5 = new Profile()
            {
                Alias = "Alejandro",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            repo.AddProfile(p1, acc1);
            repo.AddProfile(p2, acc1);
            repo.AddProfile(p3, acc1);
            repo.AddProfile(p4, acc1);
            repo.AddProfile(p5, acc1);
        }
        [TestMethod]
        public void ChangeChildrenNotOwnerProfile()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p3 = new Profile()
            {
                Alias = "Daniel",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p4 = new Profile()
            {
                Alias = "Andrea",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            p1=repo.AddProfile(p1, acc1);
            p2=repo.AddProfile(p2, acc1);
            p3=repo.AddProfile(p3, acc1);
            p4=repo.AddProfile(p4, acc1);
            repo.ChangeChildren(p3, true);
            bool res = repo.SearchAccountName("user1234567").Profiles[2].IsChildren;
            Assert.IsTrue(res);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "The profile is Owner, it can't be children")]
        public void ChangeChildrenOwnerProfile()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p3 = new Profile()
            {
                Alias = "Daniel",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            Profile p4 = new Profile()
            {
                Alias = "Andrea",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            p1 = repo.AddProfile(p1, acc1);
            p2 = repo.AddProfile(p2, acc1);
            p3 = repo.AddProfile(p3, acc1);
            p4 = repo.AddProfile(p4, acc1);
            repo.ChangeChildren(p1, true);
        }

        [TestMethod]
        public void RemoveProfileSuccessfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            p1 = repo.AddProfile(p1, acc1);
            p2 = repo.AddProfile(p2, acc1);
            repo.RemoveProfile(p2, acc1);
            int cantP = repo.SearchAccountName("user1234567").Profiles.Count;
            Assert.AreEqual(1, cantP);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Cannot remove a profile that does not exists")]
        public void RemoveNotExistingProfile()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = false,
            };
            p1 = repo.AddProfile(p1, acc1);
            repo.RemoveProfile(p2, acc1);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Cannot remove an Owner profile")]
        public void RemoveOwnerProfile()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            p2 = repo.AddProfile(p2, acc1);
            repo.RemoveProfile(p2, acc1);
        }

        [TestMethod]

        public void SearchProfileTest()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1=repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Profile p2 = new Profile()
            {
                Alias = "Antonio",
                Pin = "22342",
                IsChildren = false,
                IsOwner = true,
            };
            p1=repo.AddProfile(p1, acc1);
            p2=repo.AddProfile(p2, acc1);
            Assert.IsNotNull(repo.SearchProfile(p2.Id));
        }

        
        [TestMethod]
        public void AddMovieToLikedSuccesfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            
            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            mov1 = MovieRepo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToLikedList(mov.Id, p1.Id);
            repo.AddMovieToLikedList(mov1.Id, p1.Id);
            p1 = repo.SearchProfile(p1.Id);
            Assert.IsTrue(p1.LikedMovies[0].Id == mov.Id);
            Assert.IsTrue(p1.LikedMovies[1].Id == mov1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile Not found")]
        public void AddMovieToLikedProfileException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            repo.AddMovieToLikedList(mov.Id, p1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie Not found")]
        public void AddMovieToLikedMovieException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            repo.AddMovieToLikedList(mov.Id, p1.Id);

        }







        [TestMethod]
        public void AddMovieToDisLikedSuccesfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            mov1 = MovieRepo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToDislikedList(mov.Id, p1.Id);
            repo.AddMovieToDislikedList(mov1.Id, p1.Id);
            p1 = repo.SearchProfile(p1.Id);
            Assert.IsTrue(p1.DisLikedMovies[0].Id == mov.Id);
            Assert.IsTrue(p1.DisLikedMovies[1].Id == mov1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile Not found")]
        public void AddMovieToDisLikedProfileException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            repo.AddMovieToDislikedList(mov.Id, p1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie Not found")]
        public void AddMovieToDisLikedMovieException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            repo.AddMovieToDislikedList(mov.Id, p1.Id);

        }







        [TestMethod]
        public void AddMovieToSuperLikedSuccesfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            mov1 = MovieRepo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToSuperLikedList(mov.Id, p1.Id);
            repo.AddMovieToSuperLikedList(mov1.Id, p1.Id);
            p1 = repo.SearchProfile(p1.Id);
            Assert.IsTrue(p1.SuperLikedMovies[0].Id == mov.Id);
            Assert.IsTrue(p1.SuperLikedMovies[1].Id == mov1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile Not found")]
        public void AddMovieToSuperLikedProfileException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            repo.AddMovieToSuperLikedList(mov.Id, p1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie Not found")]
        public void AddMovieToSuperLikedMovieException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            repo.AddMovieToSuperLikedList(mov.Id, p1.Id);

        }



        [TestMethod]
        public void RemoveMovieToLikedSuccesfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            mov1 = MovieRepo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToLikedList(mov.Id, p1.Id);
            repo.AddMovieToLikedList(mov1.Id, p1.Id);
            p1 = repo.SearchProfile(p1.Id);
            Assert.IsTrue(p1.LikedMovies[0].Id == mov.Id);
            Assert.IsTrue(p1.LikedMovies[1].Id == mov1.Id);
            repo.RemoveMovieOfLikedList(mov.Id, p1.Id);
            Assert.IsTrue(p1.LikedMovies[0].Id == mov.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile Not found")]
        public void RemoveMovieToLikedProfileException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            repo.RemoveMovieOfLikedList(mov.Id, p1.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie Not found")]
        public void RemoveMovieToLikedMovieException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            repo.RemoveMovieOfLikedList(mov.Id, p1.Id);
        }







        [TestMethod]
        public void RemoveMovieToDisLikedSuccesfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            mov1 = MovieRepo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToDislikedList(mov.Id, p1.Id);
            repo.AddMovieToDislikedList(mov1.Id, p1.Id);
            p1 = repo.SearchProfile(p1.Id);
            Assert.IsTrue(p1.DisLikedMovies[0].Id == mov.Id);
            Assert.IsTrue(p1.DisLikedMovies[1].Id == mov1.Id);
            repo.RemoveMovieOfDislikedList(mov.Id, p1.Id);
            Assert.IsTrue(p1.DisLikedMovies[0].Id == mov.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile Not found")]
        public void RemoveMovieToDisLikedProfileException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            repo.RemoveMovieOfDislikedList(mov.Id, p1.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie Not found")]
        public void RemoveMovieToDisLikedMovieException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            repo.RemoveMovieOfDislikedList(mov.Id, p1.Id);
        }


        [TestMethod]
        public void RemoveMovieToSuperLikedSuccesfuly()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            mov1 = MovieRepo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToSuperLikedList(mov.Id, p1.Id);
            repo.AddMovieToSuperLikedList(mov1.Id, p1.Id);
            p1 = repo.SearchProfile(p1.Id);
            Assert.IsTrue(p1.SuperLikedMovies[0].Id == mov.Id);
            Assert.IsTrue(p1.SuperLikedMovies[1].Id == mov1.Id);
            repo.RemoveMovieOfSuperLikedList(mov.Id, p1.Id);
            Assert.IsTrue(p1.SuperLikedMovies[0].Id == mov.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile Not found")]
        public void RemoveMovieToSuperLikedProfileException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            mov = MovieRepo.AddMovieToMovieRepository(mov);
            repo.AddMovieToSuperLikedList(mov.Id, p1.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie Not found")]
        public void RemoveMovieToSuperLikedMovieException()
        {
            AccountDBRepository repo = _accountDBRepository;
            Account acc1 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567"
            };
            acc1 = repo.AddAccountToRepository(acc1);
            Profile p1 = new Profile()
            {
                Alias = "Rafael",
                Pin = "12345",
                IsChildren = false,
                IsOwner = true,
            };
            p1 = repo.AddProfile(p1, acc1);
            Genre gen = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov1 = new Movie()
            {
                Name = "Scary Movie 2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository MovieRepo = _movieDBRepository;
            repo.RemoveMovieOfSuperLikedList(mov.Id, p1.Id);
        }
    }
}



