using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTest
{
    [TestClass]
    public class GenreTest
    {
        [TestMethod]
        public void creatingEmptyObject()
        {
            Genre gen = new Genre();
            Assert.IsInstanceOfType(gen, typeof(Genre));

        }
        [TestMethod]
        [ExpectedException(typeof(GenreException), "Name cannot be empty")]
        public void NameIsNull()
        {
            Genre gen = new Genre();
            gen.Name = null;

        }

        [TestMethod]
        [ExpectedException(typeof(GenreException), "Name cannot be empty")]
        public void NameIsEmpty()
        {
            Genre gen = new Genre();
            gen.Name = "";

        }

        [TestMethod]
        public void NameIsValid()
        {
            Genre gen = new Genre();
            gen.Name = "Romance";
            Assert.AreNotEqual("", gen.Name);

        }

        [TestMethod]
        public void DescriptionIsValid()
        {
            Genre gen = new Genre();
            gen.Description = "This genre is for those who likes amazing love stories, fulfilled with passion and adventure";
            Assert.AreNotEqual("", gen.Description);

        }

        [TestMethod]
        [ExpectedException(typeof(GenreException), "Description Cannot Be Empty")]
        public void DescriptionIsNull()
        {
            Genre gen = new Genre();
            gen.Description = null;

        }


        [TestMethod]
        public void TestToString()
        {
            Genre gen = new Genre() { Name = "Horror"};
            Assert.AreEqual("Horror", gen.ToString());
        }


        [TestMethod]
        public void TestID()
        {
            Genre gen = new Genre() { Name = "tests12345" };
            gen.Id = 5;

            Assert.AreEqual(5, gen.Id);
        }


        [TestMethod]
        public void TestMovies()
        {
            Genre gen = new Genre() { Name = "tests12345" };
            Movie mov1 = new Movie() { Name = "movie1" };
            Movie mov2 = new Movie() { Name = "movie2" };
            List<Movie> list = new List<Movie>();
            list.Add(mov1);
            list.Add(mov2);
            gen.Movies = list;
            Assert.IsTrue(gen.Movies.Contains(mov1));
            Assert.IsTrue(gen.Movies.Contains(mov2));
        }
    }


}
