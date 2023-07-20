using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;

namespace UnitTest

{
    [TestClass]
    public class ProfileTest
    {
        [TestMethod]
        public void CreatingEmptyObject()
        {
            Profile prof = new Profile();
            Assert.IsInstanceOfType(prof, typeof(Profile));
        }

        [TestMethod]
        [DataRow("joaco")]
        [DataRow("tomas")]
        public void ValidAlias(string alias)
        {
            Profile prof = new Profile();
            prof.Alias = alias;
            Assert.AreEqual(prof.Alias, alias);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("Joaquin Bonifacino")]
        [DataRow("Joaquin 12345")]
        [DataRow(null)]
        [ExpectedException(typeof(ProfileException), "Invalid alias")]
        public void NotAValidAlias(string alias)
        {
            Profile prof = new Profile();
            prof.Alias = alias;
        }

        [TestMethod]
        public void ValidPin() {
            Profile prof = new Profile();
            prof.Pin = "12345";
            Assert.AreEqual(prof.Pin, "12345");
        }

        [TestMethod]
        [DataRow(null)]
        [DataRow("12")]
        [DataRow("123456")]
        [DataRow("12aaa")]
        [DataRow("12aaaaaaa")]
        [ExpectedException(typeof(ProfileException), "Invalid pin")]
        public void InvalidPin(string pin)
        {
            Profile prof = new Profile();
            prof.Pin = pin;
        }

        [TestMethod]

        public void CanBeChildren()
        {
            Profile prof = new Profile();
            prof.IsChildren = true;
            Assert.IsTrue(prof.IsChildren);
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileException), "An owner profile cant be children")]
        public void CannotBeChildren()
        {
            Profile prof = new Profile();
            prof.IsOwner = true;
            prof.IsChildren = true;
        }


        [TestMethod]
        public void AddMovieToWatched()
        {
            Profile prof = new Profile();

            Movie mov = new Movie();
            mov.Name = "Prueba";

            prof.AddMovieToWatched(mov);
            Assert.IsTrue(prof.IsAWatchedMovie(mov));
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in watched list")]
        public void IsAWatchedMovie()
        {
            Profile prof = new Profile();
            Movie mov = new Movie();
            mov.Name = "Prueba";

            prof.AddMovieToWatched(mov);
            prof.AddMovieToWatched(mov);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsANullMovie()
        {
            Profile prof = new Profile();

            prof.AddMovieToWatched(null);
        }

        [TestMethod]
        public void setWatchedMovies()
        {
            Profile prof = new Profile();
            List<Movie> test = new List<Movie>();
            Movie mov = new Movie() { Name = "Scary Movie" };
            test.Add(mov);
            prof.WatchedMovies = test;
        }

        
        [TestMethod]
        public void ScoresIsNotNull()
        {
            Profile p = new Profile();
            Assert.IsNotNull(p.Scores);

        }

        [TestMethod]
        public void ScoreSet()
        {
            Score s = new Score();
            Profile p = new Profile();
            List<Score> scores = new List<Score>();
            scores.Add(s);
            p.Scores = scores;
        }

        [TestMethod]
        public void AddNewScore()
        {

            Profile p = new Profile();
            Score s = new Score(new Genre());
            p.AddScore(s);
            Assert.IsTrue(p.Scores.Contains(s));
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Score Already Exists")]
        public void AddExistingScore()
        {
            Profile p = new Profile();
            Score s = new Score(new Genre());
            p.AddScore(s);
            p.AddScore(s);
        }

        [TestMethod]
        public void ScoreDoesExists()
        {
            Profile p = new Profile();
            Genre gen = new Genre();
            Score s = new Score(gen);
            p.AddScore(s);
            Assert.AreEqual(s, p.SearchScore(gen));
        }

        [TestMethod]
        public void ScoreDoesNotExists()
        {
            Profile p = new Profile();
            Genre gen = new Genre();
            Genre gen2 = new Genre();
            Score s = new Score(gen);
            p.AddScore(s);
            Assert.IsNull(p.SearchScore(gen2));
        }

        [TestMethod]
        public void AddPointsToAnExistingScore()
        {
            Profile p = new Profile();
            Genre gen = new Genre();
            Score s = new Score(gen);
            p.AddScore(s);

            p.AddPointsToScore(gen, 2);

            Assert.AreEqual(2, s.Points);
        }

        [TestMethod]

        public void AddPointsToANonExistingScore()
        {
            Profile p = new Profile();
            Genre gen = new Genre();
            Genre gen2 = new Genre();
            Score s = new Score(gen);

            p.AddScore(s);
            p.AddPointsToScore(gen2, 6);

            Assert.AreEqual(6, p.SearchScore(gen2).Points);
        }

        [TestMethod]
        public void TestToString()
        {
            Profile prof = new Profile()
            {
                Alias = "test1",
            };
            Assert.AreEqual("test1", prof.ToString());
        }
        [TestMethod]
        public void LikeMovie()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToLiked(mov);
            Assert.IsTrue(p.LikedMovies.Contains(mov));
        }
        [TestMethod]
        public void SuperLikeMovie()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToSuperLiked(mov);
            Assert.IsTrue(p.SuperLikedMovies.Contains(mov));
        }
        [TestMethod]
        public void DisLikeMovie()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToDisLiked(mov);
            Assert.IsTrue(p.DisLikedMovies.Contains(mov));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LikeNullMovie(){
            Profile p = new Profile();
            Movie mov = null;
            p.AddMovieToLiked(mov);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SuperLikeNullMovie() {
            Profile p = new Profile();
            Movie mov = null;
            p.AddMovieToSuperLiked(mov);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DiskLikeNullMovie() {
            Profile p = new Profile();
            Movie mov = null;
            p.AddMovieToDisLiked(mov);
        }

        [TestMethod]
        public void SetDisLikedMovies()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            List<Movie> list = new List<Movie>();
            list.Add(mov);
            p.DisLikedMovies = list;
            Assert.AreEqual(list, p.DisLikedMovies);
        }
        [TestMethod]
        public void SetSuperLikedMovies()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            List<Movie> list = new List<Movie>();
            list.Add(mov);
            p.SuperLikedMovies = list;
            Assert.AreEqual(list, p.SuperLikedMovies);
        }
        [TestMethod]
        public void SetLikedMovies()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            List<Movie> list = new List<Movie>();
            list.Add(mov);
            p.LikedMovies = list;
            Assert.AreEqual(list, p.LikedMovies);
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in another list")]

        public void MovieAlreadyInAnotherlikedList1()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToLiked(mov);
            p.AddMovieToDisLiked(mov);
        }
        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in another list")]

        public void MovieAlreadyInAnotherlikedList2()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToLiked(mov);
            p.AddMovieToSuperLiked(mov);
        }
        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in another list")]

        public void MovieAlreadyInAnotherlikedList3()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToSuperLiked(mov);
            p.AddMovieToLiked(mov);
        }
        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in Disliked list")]

        public void MovieAlreadyDisliked()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToDisLiked(mov);
            p.AddMovieToDisLiked(mov);
        }
        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in Liked list")]

        public void MovieAlreadyLiked()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToLiked(mov);
            p.AddMovieToLiked(mov);
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie is already in Superliked list")]

        public void MovieAlreadySuperLiked()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.AddMovieToSuperLiked(mov);
            p.AddMovieToSuperLiked(mov);
        }


        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie not in Disliked List")]

        public void MovieNotInDisLikedList()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.RemoveMovieDisliked(mov);
        }

        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie not in Liked List")]

        public void MovieNotInLikedList()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.RemoveMovieLiked(mov);
        }
        [TestMethod]
        [ExpectedException(typeof(ProfileException), "Movie not in SuperLiked List")]

        public void MovieNotInSuperLikedList()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };
            p.RemoveMovieSuperLiked(mov);
        }

        [TestMethod]
        public void RemoveLikedMovie() {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };


            p.AddMovieToLiked(mov);
            p.RemoveMovieLiked(mov);

            Assert.IsFalse(p.IsALikedMovie(mov));


        }
        [TestMethod]
        public void RemoveSuperLikedMovie()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };


            p.AddMovieToSuperLiked(mov);
            p.RemoveMovieSuperLiked(mov);

            Assert.IsFalse(p.IsASuperlikedMovie(mov));
        }
        [TestMethod]
        public void RemoveDisLikedMovie()
        {
            Profile p = new Profile();
            Movie mov = new Movie() { Name = "sss" };


            p.AddMovieToDisLiked(mov);
            p.RemoveMovieDisliked(mov);

            Assert.IsFalse(p.IsADislikedMovie(mov));
        }


        [TestMethod]
        public void TestID()
        {
            Profile prof = new Profile() { Alias = "tests12345" };
            prof.Id = 5;

            Assert.AreEqual(5, prof.Id);
        }

        [TestMethod]
        public void TestChildren()
        {
            
            Profile prof = new Profile() { Alias = "tests12345" };
            prof.IsOwner = true;
            prof.IsChildren = false;
            Assert.IsFalse(prof.IsChildren);
        }




    }
}
