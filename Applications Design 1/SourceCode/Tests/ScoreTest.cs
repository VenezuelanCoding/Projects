using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class ScoreTest
    {
        [TestMethod]
        public void CreatingEmptyObject()
        {
            Score score = new Score();
            Assert.IsInstanceOfType(score, typeof(Score));
            Assert.AreEqual(0, score.Points);
        }

        [TestMethod]
        public void CreateScoreWithGenre()
        {
            Genre gen = new Genre();
            gen.Name = "Terror";
            Score score = new Score(gen);
            Assert.AreEqual(gen, score.Genre);
        }

        [TestMethod]
        public void TestID()
        {
            Score score = new Score() { Genre = new Genre() {Name = "genre" } };
            score.Id = 5;

            Assert.AreEqual(5, score.Id);
        }

    }
}
