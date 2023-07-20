using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;

namespace UnitTest
{
    [TestClass]
    public class MemberTest
    {
        [TestMethod]
        public void CreateEmptyObject()
        {
            Member m = new Member();
            Assert.IsInstanceOfType(m, typeof(Member));
        }

        [DataRow("a435jkljsdf")]
        [DataRow("a435jkljkljlk")]
        [TestMethod]
        public void ValidUsername(string name)
        {
            Member m = new Member();
            m.Name = name;
            Assert.AreEqual(name, m.Name);
        }


        [DataRow(null)]
        [DataRow("234?kd")]
        [DataRow("234?)__k")]
        [DataRow("0123456789%")]
        [TestMethod]
        [ExpectedException(typeof(MemberException), "Name Not valid")]
        public void InvalidName(string name)
        {
            Member m = new Member();
            m.Name = name;
        }

        [TestMethod]
        [ExpectedException(typeof(MemberException), "Not a valid  date")]

        public void InvalidBirthDate()
        {
            Member m = new Member();
            DateTime date = new DateTime(3000, 12, 12);
            m.BirthDate = date;
        }

        [TestMethod]
        public void ValidBirthDate()
        {
            Member m = new Member();
            DateTime date = new DateTime(1999, 12, 12);
            m.BirthDate = date;
            Assert.AreEqual(date, m.BirthDate);
        }

        [TestMethod]
        [DataRow("/picture.jpg")]
        [DataRow("/picture.png")]
        public void ProfilePictureIsAnImage(string path)
        {
            Member m = new Member();
            m.ProfilePicture = path;
            Assert.AreEqual(m.ProfilePicture, path);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberException), "Profile picture file is not an image")]
        public void ProfilePictureIsNotAnImage()
        {
            Member m = new Member();
            m.ProfilePicture = "probando.mp4";
        }

        [TestMethod]
        public void ValidId()
        {
            Member m = new Member();
            m.Id = 0;
            Assert.AreEqual(m.Id, 0);
        }

        [TestMethod]
        public void ValidActorType()
        {
            Member m = new Member();
            m.Type = MemberType.Actor;
            Assert.AreEqual((int)m.Type, 0);
        }

        [TestMethod]
        public void ValidDirectorType()
        {
            Member m = new Member();
            m.Type = MemberType.Director;
            Assert.AreEqual((int)m.Type, 1);
        }

        [TestMethod]
        public void ValidActorAndDirectorType()
        {
            Member m = new Member();
            m.Type = MemberType.ActorAndDirector;
            Assert.AreEqual((int)m.Type, 2);
        }


        [TestMethod]
        [DataRow("/poster.jpg")]
        [DataRow("/poster.png")]
        public void ProfielPicIsAnImage(string path)
        {
            Member m = new Member();
            m.Name = "Prueba";
            m.ProfilePicture = path;
            Assert.AreEqual(m.ProfilePicture, path);
        }
        [DataRow("prueba.mp4")]
        [DataRow("asdf")]
        [TestMethod]
        [ExpectedException(typeof(MemberException), "Profile picture file is not an image")]
        public void ProfilePicIsNotAnImage(string path)
        {
            Member m = new Member();
            m.Name = "Prueba";
            m.ProfilePicture = path;

        }


        [TestMethod]
        public void Get_Set_DirectedMovies()
        {
            Member m = new Member();
            m.Type = MemberType.ActorAndDirector;
            Movie mov = new Movie() { Name = "sss" };
            List<Movie> list = new List<Movie>();
            list.Add(mov);
            m.DirectMovies = list;
            Assert.IsTrue(m.DirectMovies.Contains(mov));
        }


        [TestMethod]
        public void MemberToString()
        {
            Member m = new Member();
            m.Type = MemberType.ActorAndDirector;
            m.Name = "nombre";
            Assert.IsTrue(m.ToString() == "nombre");
        }
    }
}
