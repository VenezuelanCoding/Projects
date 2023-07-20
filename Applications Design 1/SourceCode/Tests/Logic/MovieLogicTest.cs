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
    public class MovieLogicTest
    {
        private MovieDBRepository _movieDBRepository;
        private GenreDBRepository _genreDBRepository;


        public MovieLogicTest()
        {
            _genreDBRepository = new GenreDBRepository();
            _movieDBRepository = new MovieDBRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }

        [TestMethod]
        public void NewMovie()
        {
            Account acc = new Account()
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
            }; GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Assert.IsNotNull(logic.GetMovieById(mov.Id));
        }


        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void FailedAdminPermissions()
        {
            Account acc = new Account()
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
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.AddNewMovie(mov, acc);
        }


        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie already exists")]
        public void MovieAlreadyExists()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
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
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            mov2.Id = mov.Id;
            logic.AddNewMovie(mov2, acc);

        }

        [TestMethod]
        public void MovieExists()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.AddNewMovie(mov,acc);
            Assert.IsNotNull(logic.GetMovieById(res.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException))]
        public void MovieDoesNotExists()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.AddNewMovie(mov, acc);
            logic.GetMovieById(res.Id+1);
        }

        [TestMethod]
        public void GetAllMoviesIsEmpty()
        {

            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Assert.AreEqual(0, logic.GetAllMovies().Count);

        }

        [TestMethod]
        public void GetAllMoviesIsNotEmpty()
        {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);

            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov = logic.AddNewMovie(mov, acc);

            Assert.AreNotEqual(0, logic.GetAllMovies().Count);

        }

        [TestMethod]
        public void DeleteExistingMovie()
        {

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
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
                Id = 4,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            mov =  logic.AddNewMovie(mov, acc);
            mov2 = logic.AddNewMovie(mov2, acc);
            logic.DeleteMovie(mov,acc);
            Assert.AreEqual(1, logic.GetAllMovies().Count);
            Assert.IsNotNull(logic.GetMovieById(mov2.Id));
        }


        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]

        public void DeleteExistingMoviePermissionFail()
        {
            Account admin = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = false,
                Password = "user1234567",
                UserName = "user18576asdasd",

            };

            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
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
                Id = 4,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            logic.AddNewMovie(mov, admin);
            logic.AddNewMovie(mov2, admin);
            logic.DeleteMovie(mov, curerntAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie not found")]
        public void DeleteNonExistingMovie()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.AddNewMovie(mov,acc);
            logic.DeleteMovie(new Movie() { Id = 3 },acc);
        }

        [TestMethod]
        public void AddRelatedValidMovieToRelatedMovie()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
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
                Id = 4,
                Name = "Supeman",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov,acc);
            logic.AddMovieToRelatedMovies(mov2, mov, acc);

            mov2 = logic.AddNewMovie(mov2,acc);
            mov = logic.GetMovieById(mov.Id);

            

            Assert.IsTrue(mov.RelatedMovies.Exists(x => x.Id == mov2.Id));
            Assert.IsTrue(mov2.RelatedMovies.Exists(x => x.Id == mov.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]

        public void AddRelatedValidMovieToRelatedMovieFailPermission()
        {
            Account admin = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = false,
                Password = "user1234567",
                UserName = "user1857698789",

            };


            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
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
                Id = 4,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            logic.AddNewMovie(mov, admin);
            logic.AddNewMovie(mov2, admin);
            logic.AddMovieToRelatedMovies(mov2, mov, curerntAccount);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Movie cannot relate to itself")]
        public void MovieAddsItselfToRelatedMovies()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            logic.AddMovieToRelatedMovies(mov, mov, acc);
        }

        [TestMethod]
        public void DeleteMovieThatIsRelatedToOthers()
        {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            GenreDBRepository Genrepo = _genreDBRepository;
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            gen = Genrepo.AddGenreToGenreRepository(gen);
            
            Movie mov = new Movie()
            {
                Id = 1,
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
                Id = 4,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov3 = new Movie()
            {
                Id = 5,
                Name = "Scary Movie3",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            mov = logic.AddNewMovie(mov, acc);
            logic.AddMovieToRelatedMovies(mov2, mov, acc);
            mov2 = logic.AddNewMovie(mov2, acc );
            logic.AddMovieToRelatedMovies(mov3, mov, acc);
            mov3 = logic.AddNewMovie(mov3, acc);
            logic.DeleteMovie(mov, acc);

            mov2 = logic.GetMovieById(mov2.Id);
            mov3 = logic.GetMovieById(mov3.Id);

            Assert.IsFalse(mov3.RelatedMovies.Contains(mov));
            Assert.IsFalse(mov2.RelatedMovies.Contains(mov));
        }

        [TestMethod]
        public void AddValidSubgenre()
        {
            Account acc = new Account()
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
                Name = "fun",
                Description = "A description",
            };
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

            MovieDBRepository repo = _movieDBRepository;
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            gen2 = Genrepo.AddGenreToGenreRepository(gen2);

            MovieLogic logic = new MovieLogic(repo);
            logic.AddGenreToSubgenres(gen2, mov);
            mov = logic.AddNewMovie(mov, acc);
            Assert.IsTrue(mov.SubGenres[0].Id == gen2.Id);

        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), " Secondary Genre cannot be the same as the Primary")]
        public void AddPrimaryToSubgenre()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
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

            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc );
            logic.AddGenreToSubgenres(gen, mov);

        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Second Genre already present")]
        public void AddRepeatedToSubgenre()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Genre gen2 = new Genre()
            {
                Name = "fun",
                Description = "A description",
            };
            gen2 = Genrepo.AddGenreToGenreRepository(gen2);

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

            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            logic.AddGenreToSubgenres(gen2, mov);
            logic.AddGenreToSubgenres(gen2, mov);

            mov = logic.AddNewMovie(mov, acc);

        }

        [TestMethod]
        public void GetAllPGMovies()
        {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            MovieDBRepository repo = _movieDBRepository;
            GenreDBRepository Genrepo = _genreDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };

            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = true,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov2 = new Movie()
            {
                Id = 4,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            mov2 = logic.AddNewMovie(mov2,acc);

            Assert.IsNotNull(logic.GetAllPGMovies().Contains(mov));
            Assert.IsFalse(logic.GetAllPGMovies().Contains(mov2));



        }
        [TestMethod]
        public void GetMovieByGenre() {

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            MovieDBRepository repo = _movieDBRepository;

            Genre gen1 = new Genre() { Name = "Horror" , Description = "a description" };
            Genre gen2 = new Genre() { Name = "Action" , Description = "a description"};

            Genre gen3 = new Genre() { Name = "Doc", Description = "a description" };


            GenreDBRepository Genrepo = _genreDBRepository;
            gen1 = Genrepo.AddGenreToGenreRepository(gen1);
            gen2 = Genrepo.AddGenreToGenreRepository(gen2);
            gen3 = Genrepo.AddGenreToGenreRepository(gen3);

            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen1,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = true,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            Movie mov2 = new Movie()
            {
                Id = 4,
                Name = "Scary Movie",
                PrimaryGenre = gen1,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            mov2.AddGenreToSubgenres(gen2);
            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            mov2 = logic.AddNewMovie(mov2, acc);


            Assert.IsNotNull(logic.GetMoviesByGenre(gen1));
            Assert.IsNotNull(logic.GetMoviesByGenre(gen2));
            Assert.IsTrue(logic.GetMoviesByGenre(gen3).Count == 0);





        }
        [TestMethod]
        public void GetMovieByIdExists()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.AddNewMovie(mov, acc);
            Assert.IsNotNull(logic.GetMovieById(res.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException))]
        public void GetMovieByIdDoesNotExists()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;
  
            MovieLogic logic = new MovieLogic(repo);
            Movie res = logic.AddNewMovie(mov, acc);
            logic.GetMovieById(res.Id+1);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void FailedAdminPermissionActingRole() {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            Account acc2 = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            member = memberLogic.AddNewMember(member, acc);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };

            logic.AddActingRoleToMovie(role, acc2, mov);
        }

        [TestMethod]
        public void AddActingRoleToMovie()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            member = memberLogic.AddNewMember(member, acc);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };

            logic.AddActingRoleToMovie(role, acc, mov);

            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.ActingRoles[0].Name == role.Name);
        }

        [TestMethod]
        public void AddADirectorToAMovie()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member director = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Director, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            director = memberLogic.AddNewMember(director, acc);

            logic.AddDirectorToMovie(director, acc, mov);

            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.Directors[0].Name == director.Name);
        }


        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void InvalidAddingADirector()
        {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            Account acc2 = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member director = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Director, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            director = memberLogic.AddNewMember(director, acc);

            logic.AddDirectorToMovie(director, acc2, mov);
        }


        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void InvalidDetachingADirector()
        {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            Account acc2 = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member director = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Director, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            director = memberLogic.AddNewMember(director, acc);

            logic.AddDirectorToMovie(director, acc, mov);
            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.Directors[0].Name == director.Name);

            logic.DetachDirector(director, acc2, mov);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void InvalidDetachingAnActingRole()
        {
            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            Account acc2 = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            member = memberLogic.AddNewMember(member, acc);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };

            logic.AddActingRoleToMovie(role, acc, mov);

            logic.DetachActingRole(role, acc2, mov);
        }

        [TestMethod]
        public void DetachingADirector()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member director = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Director, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            director = memberLogic.AddNewMember(director, acc);

            logic.AddDirectorToMovie(director, acc, mov);
            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.Directors[0].Name == director.Name);

            logic.DetachDirector(director, acc, mov);
            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.Directors.Count == 0);

        }

        [TestMethod]
        public void DeatchActingRole()
        {
            Account acc = new Account()
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
            GenreDBRepository Genrepo = _genreDBRepository;
            gen = Genrepo.AddGenreToGenreRepository(gen);
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary Movie",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            MovieDBRepository repo = _movieDBRepository;

            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            member = memberLogic.AddNewMember(member, acc);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };

            logic.AddActingRoleToMovie(role, acc, mov);

            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.ActingRoles[0].Name == role.Name);

            logic.DetachActingRole(role, acc, mov);
            mov = logic.GetMovieById(mov.Id);
            Assert.IsTrue(mov.ActingRoles.Count == 0);

        }
    }

}
