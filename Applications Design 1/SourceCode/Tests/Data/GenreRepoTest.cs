using Data;
using Data.InDatabase;
using DataInterfaces;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UnitTest;

namespace Tests.Data
{
    [TestClass]
    public class GenreRepoTest
    {
        private GenreDBRepository _genreDBRepository;

        private MovieDBRepository _movieDBRepository;
        
        public GenreRepoTest()
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
        public void AddGenre()
        {
            GenreDBRepository repo = _genreDBRepository;
            Genre genre = new Genre()
            {
                Name = "Horror",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(genre);
            Assert.IsNotNull(repo.SearchGenre(genre.Name));
        }

        [TestMethod]
        public void GetAllGenres()
        {
            GenreDBRepository repo = _genreDBRepository;
            Genre gen1 = new Genre()
            {
                Name = "Horror",
                Description = "A description"
            };
            Genre gen2 = new Genre()
            {
                Name = "Accion",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.AddGenreToGenreRepository(gen2);


            IList<Genre> list = repo.GetAllGenres();
            Assert.IsNotNull(list.FirstOrDefault(x => x.Name == gen1.Name));
            Assert.IsNotNull(list.FirstOrDefault(x => x.Name == gen2.Name));
        }
        [TestMethod]
        public void SearchGenre()
        {
            GenreDBRepository repo = _genreDBRepository;

            Genre gen1 = new Genre()
            {
                Name = "Horror",
                Description = "A description"
            };
            Genre gen2 = new Genre()
            {
                Name = "Accion",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.AddGenreToGenreRepository(gen2);

            Assert.IsNotNull(repo.SearchGenre(gen1.Name));
            Assert.IsNotNull(repo.SearchGenre(gen2.Name));
        }

        [TestMethod]
        public void DeleteGenre() {
            GenreDBRepository repo = _genreDBRepository;

            Genre gen1 = new Genre()
            {
                Name = "Horror",
                Description = "A description"
            };
            Genre gen2 = new Genre()
            {
                Name = "Accion",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.AddGenreToGenreRepository(gen2);

            repo.DeleteGenre(gen1.Name);
            Assert.IsNull(repo.SearchGenre(gen1.Name));

        }


        [TestMethod]
        [ExpectedException(typeof(GenreRepoException), "Genre not found")]
        public void DeleteGenreError()
        {
            GenreDBRepository repo = _genreDBRepository;
            Genre gen1 = new Genre()
            {
                Name = "Horror",
                Description = "A description"
            };
            Genre gen2 = new Genre()
            {
                Name = "Action",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.DeleteGenre(gen2.Name);
        }


        [TestMethod]
        public void SearchGenreNotFound()
        {
            GenreDBRepository repo = _genreDBRepository;

            Genre gen1 = new Genre()
            {
                Name = "Horror",
                Description = "A description"
            };
            Genre gen2 = new Genre()
            {
                Name = "Accion",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            Assert.IsNotNull(repo.SearchGenre(gen1.Name));
            Assert.IsNull(repo.SearchGenre(gen2.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(GenreRepoException), "Genre already exists")]
        public void DuplicateGenre()
        {
            GenreDBRepository repo = _genreDBRepository;
            Genre gen1 = new Genre()
            {
                Name = "Genre",
                Description = "A description"
            };
            Genre gen2 = new Genre()
            {
                Name = "Genre",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.AddGenreToGenreRepository(gen2);
        }

        [TestMethod]
        public void DeleteGenreSuccessfuly()
        {
            GenreDBRepository repo = _genreDBRepository;
            Genre gen1 = new Genre()
            {
                Name = "Genre",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.DeleteGenre(gen1.Name);
            Assert.IsNull(repo.SearchGenre(gen1.Name));
        }

        [TestMethod]
        [ExpectedException(typeof(GenreRepoException), "Genre already exists")]
        public void DeleteGenreDoesNotExists()
        {
            GenreDBRepository repo = _genreDBRepository;
            Genre gen1 = new Genre()
            {
                Name = "Genre",
                Description = "A description"
            };
            repo.AddGenreToGenreRepository(gen1);
            repo.DeleteGenre("Comedy");
        }

        [TestMethod]
        [ExpectedException(typeof(GenreRepoException), "There is at least one movie with this Genre or SubGenre")]
        public void DeleteGenreHasAMovie()
        {
            MovieDBRepository repoMov = _movieDBRepository;
            GenreDBRepository repo = _genreDBRepository;
            Genre gen1 = new Genre()
            {
                Name = "Genre",
                Description = "A description"
            };
            Movie mov = new Movie()
            {
                Name = "Scary Movie",
                PrimaryGenre = gen1,
                Description = "A year after disposing of the body of a man they accidentally killed, a group of dumb teenagers are stalked by a bumbling serial killer.",
                IsPG = false,
                IsSponsored = false,
                Poster = "./Images/ScaryMovie.jpg",
                ReleaseDate = new DateTime(2000, 7, 7),
            };
            repo.AddGenreToGenreRepository(gen1);
            repoMov.AddMovieToMovieRepository(mov);
            repo.DeleteGenre(gen1.Name);
        }
    }
}
