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
    public class AccountLogicTest
    {
        private AccountDBRepository _accountDBRepository;
        private MovieDBRepository _movieDBRepository;
        private GenreDBRepository _genreDBRepository;


        public AccountLogicTest()
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
        [ExpectedException(typeof(AccountLogicException), "The Score can't be added to a non existing profile")]
        public void AddScoreProfileNotExists()
        {
            Account _account = new Account { Email = "rafael.cadenas88@gmail.com" };
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            Score s = new Score(gen);
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            logic.AddNewAccount(_account);
            logic.AddScoreToProfile(2, s);
        }

        [TestMethod]
        public void AddScoreProfile()
        {
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            gen = _genreDBRepository.AddGenreToGenreRepository(gen);

            Score s = new Score(gen);
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);

            _account = logic.AddNewAccount(_account);
            p = logic.AddProfile(p, _account);
            s = logic.AddScoreToProfile(p.Id, s);
            Assert.IsNotNull(logic.SearchScore(s.Genre.Id,p.Id));
        }

        [TestMethod]
        public void AddPointsToAnExistingScore()
        {
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            Score s = new Score(gen);
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);

            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            s=logic.AddScoreToProfile(p.Id, s);
            s=logic.AddPointsToScore(s.Id, p, 2);
            Assert.AreEqual(2, s.Points);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Score does not exists")]
        public void AddPointsToANonExistingScore()
        {
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" }; 
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            logic.AddPointsToScore(13, p, 2);

        }

        [TestMethod]
        public void RemoveExistingProfile()
        {
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            logic.RemoveProfile(p, _account);
            _account = logic.SearchAccountByEmail(_account.Email);
            Assert.IsNull(logic.SearchProfile(p.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Cannot remove a profile that does not exists")]
        public void RemoveNonExistingProfile()
        {
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            Profile p2 = new Profile { Alias = "Luis", Pin = "11111" };
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            logic.RemoveProfile(p2, _account);

        }

        [TestMethod]
        public void GetAllAccountsIsEmpty()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Assert.AreEqual(0, logic.GetAllAccounts().Count);

        }

        [TestMethod]
        public void GetAllAccountsIsNotEmpty()
        {
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            _account=logic.AddNewAccount(_account);
            Assert.AreNotEqual(0, logic.GetAllAccounts().Count);

        }

        [TestMethod]
        public void AddProfile()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            Assert.IsNotNull(logic.SearchAccountByEmail(_account.Email));

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Profile already exists in this account")]
        public void AddExistingProfile()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Alfonso", Pin = "11111" };
            Profile p2 = new Profile { Alias = "Alfonso", Pin = "11111" };
            _account = logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            _account = logic.SearchAccountByEmail(_account.Email);
            p2=logic.AddProfile(p2, _account);
        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Cannot add more than 4 profiles")]
        public void AddFifthProfile()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Alfonso", Pin = "11111" };
            Profile p2 = new Profile { Alias = "Romina", Pin = "11111" };
            Profile p3 = new Profile { Alias = "Alejandro", Pin = "11111"  };
            Profile p4 = new Profile { Alias = "Raul", Pin = "11111" };
            Profile p5 = new Profile { Alias = "Victoria", Pin = "11111"  };
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            p2=logic.AddProfile(p2, _account);
            p3=logic.AddProfile(p3, _account);
            p4=logic.AddProfile(p4, _account);
            p5=logic.AddProfile(p5, _account);
        }

        [TestMethod]
        public void SuccesfulSearchProfile()
        {
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            _account = logic.SearchAccountByEmail(_account.Email);
            Assert.IsNotNull(logic.SearchProfile(p.Id));

        }

        [TestMethod]
        public void ProfileNotFound()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Profile p = new Profile { Alias = "Rodolfo", Pin = "11111" };
            _account=logic.AddNewAccount(_account);
            p=logic.AddProfile(p, _account);
            _account = logic.SearchAccountByEmail(_account.Email);
            Assert.IsNull(logic.SearchProfile(p.Id+1));

        }

        [TestMethod]
        public void NewAccount()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            _account=logic.AddNewAccount(_account);
            Assert.IsNotNull(logic.SearchAccountByEmail(_account.Email));

        }

        [TestMethod]
        [ExpectedException(typeof(AccountLogicException), "This username is already being used" )]
        public void AccountAlreadyExistsByEmail()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account
            {
                Email = "rafael.cadena88@gmail.com",
                UserName = "pepeepepepepe",
                Password = "user1234567"
            };
            Account _account2 = new Account
            {
                Email = "rafael.cadena88@gmail.com",
                UserName = "pepepeepepepe",
                Password = "user1234567"
            };
            _account = logic.AddNewAccount(_account);
            _account2 = logic.AddNewAccount(_account2);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountLogicException), "This username is already being used")]
        public void AccountAlreadyExistsByUserName()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Account _account2 = new Account { Email = "rafael.cadena@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            _account=logic.AddNewAccount(_account);
            _account=logic.AddNewAccount(_account2);

        }

        [TestMethod]

        public void SuccessfulAccountSearchByEmail()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Account _account2 = new Account { Email = "rafael.cadena@gmail.com", UserName = "Chainzzz3105", Password = "user1234567" };
            _account=logic.AddNewAccount(_account);
            _account2=logic.AddNewAccount(_account2);
            Account res = logic.SearchAccountByEmail("rafael.cadena88@gmail.com");
            Assert.IsNotNull(res);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountLogicException), "The email provided wasn't found in the data")]
        public void AccountNotFoundByEmail()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Account _account2 = new Account { Email = "rafael.cadena@gmail.com", UserName = "Chainz310502", Password = "user1234567" };
            _account=logic.AddNewAccount(_account);
            _account2=logic.AddNewAccount(_account2);
            logic.SearchAccountByEmail("jabr7@gmail.com");

        }

        [TestMethod]

        public void SuccessfulAccountSearchByUsername()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Account _account2 = new Account { Email = "rafael.cadena@gmail.com", UserName = "Chainzzz3105", Password = "user1234567" };
            _account=logic.AddNewAccount(_account);
            _account2=logic.AddNewAccount(_account2);
            Account res = logic.SearchAccountByUsername("Chainz3105");
            Assert.IsNotNull(res);

        }

        [TestMethod]
        [ExpectedException(typeof(AccountLogicException), "The username provided wasn't found in the data")]
        public void AccountNotFoundByUsername()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105" };
            Account _account2 = new Account { Email = "rafael.cadena@gmail.com", UserName = "Chainz310502" };
            _account=logic.AddNewAccount(_account);
            _account2=logic.AddNewAccount(_account2);
            logic.SearchAccountByUsername("Rakkun1811");

        }
        [TestMethod]
        public void AddMovieToWatchedList()
        {

            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            MovieDBRepository repomov = new MovieDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();


            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov2 = new Movie()
            {
                Id = 0,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Profile p = new Profile() { Alias = "alias1", Pin = "11111" };
            _account = logic.AddNewAccount(_account);
            mov = repomov.AddMovieToMovieRepository(mov);
            mov2 = repomov.AddMovieToMovieRepository(mov2);

            p=logic.AddProfile(p, _account);
            _account = logic.SearchAccountByEmail(_account.Email);
            p = logic.SearchProfile(p.Id);
            logic.AddToWatchedMovies(mov, p);
            logic.AddToWatchedMovies(mov2, p);
            p = logic.SearchProfile(p.Id);

            Assert.IsTrue(p.IsAWatchedMovie(mov));

        }

        [TestMethod]
        [ExpectedException(typeof(AccountRepoException), "Movie is already the in watchedList")]
        public void MovieAlreadyAddedToWatchedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            MovieDBRepository repomov = new MovieDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();


            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            Profile p = new Profile() { Alias = "alias1", Pin = "11111" };
            _account = logic.AddNewAccount(_account);
            mov = repomov.AddMovieToMovieRepository(mov);
          
            p = logic.AddProfile(p, _account);
            _account = logic.SearchAccountByEmail(_account.Email);
            p = logic.SearchProfile(p.Id);
            logic.AddToWatchedMovies(mov, p);
            logic.AddToWatchedMovies(mov, p);

        }

        [TestMethod]
        public void GetCurrentAccount()
        {
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            _account = repo.AddAccountToRepository(_account);

            logic.SetCurrentAccount(_account);
            Assert.AreEqual(logic.GetCurrentAccount().Id, _account.Id);
        }

        [TestMethod]
        public void GetCurrentProfile()
        {
            AccountDBRepository repo = new AccountDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111"};
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile,_account);

            logic.SetCurrentProfile(_profile);
            Assert.AreEqual(logic.GetCurrentProfile().Id, _profile.Id);
        }

        [TestMethod]
        public void AddToDislikedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111" };
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile, _account);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov=_movieDBRepository.AddMovieToMovieRepository(mov);

            logic.AddToDislikedMovies(mov.Id, _profile.Id);
            _profile = logic.SearchProfile(_profile.Id);
            Assert.AreEqual(_profile.DisLikedMovies[0].Id,mov.Id);
        }

        [TestMethod]
        public void RemoveToDislikedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111" };
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile, _account);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov = _movieDBRepository.AddMovieToMovieRepository(mov);

            logic.AddToDislikedMovies(mov.Id, _profile.Id);
            logic.RemoveOfDislikedMovies(mov.Id, _profile.Id);
            _profile = logic.SearchProfile(_profile.Id);
            Assert.IsTrue(_profile.DisLikedMovies.Count==0);
        }

        [TestMethod]
        public void AddToLikedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111" };
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile, _account);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov = _movieDBRepository.AddMovieToMovieRepository(mov);

            logic.AddToLikedMovies(mov.Id, _profile.Id);
            _profile = logic.SearchProfile(_profile.Id);
            Assert.AreEqual(_profile.LikedMovies[0].Id, mov.Id);
        }

        [TestMethod]
        public void RemoveToLikedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111" };
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile, _account);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov = _movieDBRepository.AddMovieToMovieRepository(mov);

            logic.AddToLikedMovies(mov.Id, _profile.Id);
            logic.RemoveOfLikedMovies(mov.Id, _profile.Id);
            _profile = logic.SearchProfile(_profile.Id);
            Assert.IsTrue(_profile.LikedMovies.Count == 0);
        }

        [TestMethod]
        public void AddToSuperLikedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111" };
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile, _account);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov = _movieDBRepository.AddMovieToMovieRepository(mov);

            logic.AddToSuperLikedMovies(mov.Id, _profile.Id);
            _profile = logic.SearchProfile(_profile.Id);
            Assert.AreEqual(_profile.SuperLikedMovies[0].Id, mov.Id);
        }

        [TestMethod]
        public void RemoveToSuperLikedMovies()
        {
            AccountDBRepository repo = new AccountDBRepository();
            GenreDBRepository genreRepo = new GenreDBRepository();
            AccountLogic logic = new AccountLogic(repo);
            Account _account = new Account { Email = "rafael.cadena88@gmail.com", UserName = "Chainz3105", Password = "user1234567" };

            Profile _profile = new Profile() { Alias = "pepe", Pin = "11111" };
            _account = repo.AddAccountToRepository(_account);
            _profile = repo.AddProfile(_profile, _account);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = genreRepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 0,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov = _movieDBRepository.AddMovieToMovieRepository(mov);

            logic.AddToSuperLikedMovies(mov.Id, _profile.Id);
            logic.RemoveOfSuperLikedMovies(mov.Id, _profile.Id);
            _profile = logic.SearchProfile(_profile.Id);
            Assert.IsTrue(_profile.SuperLikedMovies.Count == 0);
        }


    }
}
