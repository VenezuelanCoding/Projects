using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class ActingRoleTests
    {
        [TestMethod]
        public void CreateEmptyActingRole()
        {
            ActingRole ar = new ActingRole();
        }

        [DataRow("a435jkljsdf")]
        [DataRow("a435jkljkljlk")]
        [TestMethod]
        public void ValidName(string name)
        {
            ActingRole ar = new ActingRole();
            ar.Name = name;
            Assert.AreEqual(name, ar.Name);
        }


        [DataRow(null)]
        [DataRow("234?kd")]
        [DataRow("234?)__k")]
        [DataRow("0123456789%")]
        [TestMethod]
        [ExpectedException(typeof(ActingRoleException), "Name Not valid")]
        public void InvalidName(string name)
        {
            ActingRole ar = new ActingRole();
            ar.Name = name;
        }

        [TestMethod]
        public void ValidActorMember()
        {
            ActingRole ar = new ActingRole();
            Member m = new Member();
            m.Type = MemberType.Actor;
            ar.Member = m;
            Assert.AreEqual(m, ar.Member);
        }

        [TestMethod]
        public void ValidActorAndDirectorMember()
        {
            ActingRole ar = new ActingRole();
            Member m = new Member();
            m.Type = MemberType.ActorAndDirector;
            ar.Member = m;
            Assert.AreEqual(m, ar.Member);
        }

        [TestMethod]
        [ExpectedException(typeof(ActingRoleException), "Member Not valid")]
        public void NullMember()
        {
            ActingRole ar = new ActingRole();
            ar.Member = null;
        }

        [TestMethod]
        [ExpectedException(typeof(ActingRoleException), "Member Not valid")]
        public void InvalidDirectorMember()
        {
            ActingRole ar = new ActingRole();
            Member m = new Member();
            m.Type = MemberType.Director;
            ar.Member = m;
        }



        [TestMethod]
        public void TestID()
        {
            ActingRole role= new ActingRole() { Name = "tests12345" };
            role.Id = 5;    
            Assert.AreEqual(5, role.Id);
        }
        [TestMethod]
        public void Set_Get_ActingMovie()
        {
            ActingRole role = new ActingRole() { Name = "tests12345" };
            Movie mov = new Movie();
            role.ActingMovie = mov;
            Assert.IsTrue(role.ActingMovie == mov);
        }


    }
}
