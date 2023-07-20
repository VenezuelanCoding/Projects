using DataInterfaces;
using Domain;
using LogicInterfaces;
using Logic.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using Data.InDatabase;
using UnitTest;

namespace Logic.Test
{
    [TestClass]
    public class ExporterTest
    {
        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }



        [TestMethod]
        public void WriteEmptyFile()
        {
            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true

            };
            string path = "./test.txt";

            IMovieRepository repo = new MovieDBRepository();
            IMovieLogic movieLogic = new MovieLogic(repo);
            IExporter exporter = new ExporterToText();

            exporter.Export(movieLogic, path, curerntAccount);

            using (StreamReader sr = File.OpenText(path))
            {
                Assert.AreEqual(null, sr.ReadLine());
            }

        }
        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void FailForNotAdmin()
        {
            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = false
            };

            string path = "./test.txt";

            IMovieRepository repo = new MovieDBRepository();
            IMovieLogic movieLogic = new MovieLogic(repo);
            IExporter exporter = new ExporterToText();

            exporter.Export(movieLogic, path, curerntAccount);

        }
        [TestMethod]
       
        public void WriteNonEmptyFile() {

            Account curerntAccount = new Account()
            {
                Email = "aaa@aaaa.com",
                isAdmin = true
            };

            IMovieRepository repo = new MovieDBRepository();
            IMovieLogic movieLogic = new MovieLogic(repo);
            IGenreRepository genrepo = new GenreDBRepository();


            Genre gen = new Genre()
            {
                Name = "Horror",
                Description = "a description"

            };
            Genre gen2 = new Genre()
            {
                Name = "Funny",
                Description = "a description"
            };

            gen = genrepo.AddGenreToGenreRepository(gen);
            gen2 = genrepo.AddGenreToGenreRepository(gen2);
            Movie mov = new Movie()
            {
                Name = "Scary movie",
                PrimaryGenre = gen,
                ReleaseDate = DateTime.Now,
                IsPG = true,
                IsSponsored = false,
                Poster = "aa.jpg",
                Description = "a description"
            };
            mov.SubGenres.Add(gen2);
            System.Threading.Thread.Sleep(2000);

            Movie mov2 = new Movie()
            {
                Name = "JEJE",
                PrimaryGenre = gen,
                ReleaseDate = DateTime.Now,
                IsPG = false,
                IsSponsored = true,
                Poster = "aa.jpg",
                Description = "a description"
            };

   
            mov = repo.AddMovieToMovieRepository(mov);
            mov2.AddMovieToRelatedMovies(mov);
            mov2 = repo.AddMovieToMovieRepository(mov2);

            string path = "./test.txt";
            IExporter exporter = new ExporterToText();

            exporter.Export(movieLogic, path, curerntAccount);
   
            string result1 = "Name: " + mov.Name + ", IsPG: Yes, IsSponsored: No, Release Date: " + mov.ReleaseDate.ToString() + ", Primary Genre: " + mov.PrimaryGenre.Name + ", SubGenres: Funny , Related Movies: JEJE ";
            string result2 = "Name: " + mov2.Name + ", IsPG: No, IsSponsored: Yes, Release Date: " + mov2.ReleaseDate.ToString() + ", Primary Genre: " + mov2.PrimaryGenre.Name + ", Related Movies: Scary movie ";

            using (StreamReader sr = File.OpenText(path))
            {
                Assert.AreEqual(result1, sr.ReadLine());
                Assert.AreEqual(result2, sr.ReadLine());
            }

        }


    }
}
