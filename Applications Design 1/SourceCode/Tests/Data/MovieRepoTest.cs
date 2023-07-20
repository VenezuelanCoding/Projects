using DataInterfaces;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using UnitTest;
using Data.InDatabase;
using System;
using System.Linq;
using Data;
using LogicInterfaces;
using Logic.Implementations;

namespace Tests.Data
{
    [TestClass]
    public class MovieRepoTest
    {
        private MovieDBRepository _movieDBRepository;
        private GenreDBRepository _genreDBRepository;
        public MovieRepoTest()
        {
            _movieDBRepository = new MovieDBRepository();
            _genreDBRepository = new GenreDBRepository();

        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }

        [TestMethod]
        public void AddMovie()
        {
            MovieDBRepository repo = _movieDBRepository;
            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            Genre gen2 = new Genre()
            {
                Name = "comedy",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            gen2 = GenreRepo.AddGenreToGenreRepository(gen2);

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
            Movie mov2 = new Movie()
            {
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            repo.AddMovieToMovieRepository(mov2);

            mov.AddGenreToSubgenres(gen2);
            repo.AddMovieToMovieRepository(mov);
            Assert.IsNotNull(repo.SearchMovieByName(mov.Name));
            Assert.IsNotNull(repo.SearchMovieByName(mov2.Name));
        }


        [TestMethod]
        public void SearchMovie()
        {
            MovieDBRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            repo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToMovieRepository(mov2);

            Assert.IsNotNull(repo.SearchMovieById(mov1.Id));
            Assert.IsNotNull(repo.SearchMovieById(mov2.Id));
        }

        [TestMethod]
        public void SearchMovieNotFound()
        {
            MovieDBRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            repo.AddMovieToMovieRepository(mov1);
            Assert.IsNotNull(repo.SearchMovieById(mov1.Id));
            Assert.IsNull(repo.SearchMovieById(mov2.Id));
        }


        [TestMethod]
        public void DeleteMovie()
        {
            IMovieRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            repo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToMovieRepository(mov2);
            repo.DeleteMovie(mov1.Id);
            Assert.IsNotNull(repo.SearchMovieById(mov2.Id));
            Assert.IsNull(repo.SearchMovieById(mov1.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieRepoException), "Movie not found")]
        public void DeleteMovieError()
        {
            IMovieRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            repo.AddMovieToMovieRepository(mov1);
            repo.DeleteMovie(mov2.Id);
        }

        [TestMethod]
        public void SearchAnExistingMovieById()
        {
            MovieDBRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            repo.AddMovieToMovieRepository(mov1);
            repo.AddMovieToMovieRepository(mov2);

            Assert.IsNotNull(repo.SearchMovieById(mov1.Id));
            Assert.IsNotNull(repo.SearchMovieById(mov2.Id));
        }

        [TestMethod]
        public void SearchMovieByIdNotFound()
        {
            MovieDBRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            repo.AddMovieToMovieRepository(mov1);
            Assert.IsNotNull(repo.SearchMovieById(mov1.Id));
            Assert.IsNull(repo.SearchMovieById(mov2.Id));
        }

        [TestMethod]
        public void GetAllMovies()
        {
            MovieDBRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
                Id = 1,
                Name = "Scary Movie2",
                PrimaryGenre = gen,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };

            repo.AddMovieToMovieRepository(mov1);
            IList<Movie> movies = repo.GetAllMovies();
            Assert.AreEqual(1, movies.Count);
        }

        [TestMethod]
        public void GetMovieByName()
        {
            MovieDBRepository repo = _movieDBRepository;

            Genre gen = new Genre()
            {
                Name = "horror",
                Description = "A description",
            };
            GenreDBRepository GenreRepo = _genreDBRepository;
            gen = GenreRepo.AddGenreToGenreRepository(gen);
            Movie mov1 = new Movie()
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
            repo.AddMovieToMovieRepository(mov1);
            Assert.IsNotNull(repo.SearchMovieByName(mov1.Name));
        }

        [TestMethod]
        public void AddActingRoleToMovie()
        {
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
            mov = repo.AddMovieToMovieRepository(mov);

            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };
            MemberDBRepository memberRepo = new MemberDBRepository();
            member = memberRepo.AddMemberToMemberRepository(member);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };

            repo.AddActingRoleToMovie(role, mov.Id);

            mov = repo.SearchMovieById(mov.Id);
            Assert.IsTrue(mov.ActingRoles[0].Name == role.Name);
        }


        [TestMethod]

        [ExpectedException(typeof(MovieRepoException), "Acting Role with that name already present in this Movie")]
        public void AddDuplicateActingRoleToMovie()
        {
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
            mov = repo.AddMovieToMovieRepository(mov);

            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };
            MemberDBRepository memberRepo = new MemberDBRepository();
            member = memberRepo.AddMemberToMemberRepository(member);

            Member member2 = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "Pepe", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };
            member2 = memberRepo.AddMemberToMemberRepository(member2);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };
            ActingRole role2 = new ActingRole() { Name = "PeterParker", Member = member };
            ActingRole role3 = new ActingRole() { Name = "PeterParker", Member = member2 };



            repo.AddActingRoleToMovie(role, mov.Id);
            mov = repo.SearchMovieById(mov.Id);

            repo.AddActingRoleToMovie(role2, mov.Id);
            mov = repo.SearchMovieById(mov.Id);

            repo.AddActingRoleToMovie(role3, mov.Id);
        }

        [TestMethod]

        [ExpectedException(typeof(MovieRepoException), "Movie does not exist")]
        public void AddActingRoleToMovieThatNotExists()
        {
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

            Member member = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };
            MemberDBRepository memberRepo = new MemberDBRepository();
            member = memberRepo.AddMemberToMemberRepository(member);

            Member member2 = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "Pepe", Type = MemberType.Actor, ProfilePicture = "aa.jpg" };
            member2 = memberRepo.AddMemberToMemberRepository(member2);

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };


            repo.AddActingRoleToMovie(role, mov.Id);
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
        [ExpectedException(typeof(MovieRepoException))]
        public void InvalidAccountAddingADirector()
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
            Member director = new Member() { BirthDate = new DateTime(2000, 7, 7), Name = "jose", Type = MemberType.Director, ProfilePicture = "aa.jpg" };

            MemberDBRepository memberRepo = new MemberDBRepository();
            MemberLogic memberLogic = new MemberLogic(memberRepo);

            director = memberLogic.AddNewMember(director, acc);

            logic.AddDirectorToMovie(director, acc, mov);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberRepoException))]
        public void InvalidMemberAddingADirector()
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
            logic.AddDirectorToMovie(director, acc, mov);
        }

    }
}
