using Data.InDatabase;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using UnitTest;

using Data;

namespace Tests.Data
{
    [TestClass]
    public class MemberRepoTest
    {
        private MemberDBRepository _memberDBRepository;
        public MemberRepoTest()
        {
            _memberDBRepository = new MemberDBRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }


        

        [TestMethod]
        public void AddMember()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member() 
            { Name = "Arturo",
            BirthDate = new DateTime(2000, 7, 7), 
            ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            repo.AddMemberToMemberRepository(member);
            bool res = repo.GetAllMembers().Count == 1;
            Assert.IsTrue(res);
        }

        [TestMethod]
        [ExpectedException(typeof(MemberRepoException), "Member already exists")]
        public void AddRepeatedMember()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            repo.AddMemberToMemberRepository(member);
            repo.AddMemberToMemberRepository(member);
        }

        [TestMethod]
        public void GetAllMembers()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            Member member2 = new Member()
            {
                Name = "Alfonso",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            repo.AddMemberToMemberRepository(member);
            repo.AddMemberToMemberRepository(member2);
            int cantM = repo.GetAllMembers().Count;
            Assert.AreEqual(2, cantM);
        }

        [TestMethod]
        public void SearchMember()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            Member member2 = new Member()
            {
                Name = "Alfonso",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            repo.AddMemberToMemberRepository(member);
            repo.AddMemberToMemberRepository(member2);
            Assert.IsNotNull(repo.SearchMemberById(member2.Id));
            Assert.IsNotNull(repo.SearchMemberById(member.Id));
        }

        [TestMethod]
        public void DeleteMemberSuccessfuly()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            Member member2 = new Member()
            {
                Name = "Alfonso",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            repo.AddMemberToMemberRepository(member);
            repo.AddMemberToMemberRepository(member2);
            repo.DeleteMember(member2.Id);
            Assert.IsNull(repo.SearchMemberById(member2.Id));
            Assert.IsNotNull(repo.SearchMemberById(member.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(MemberRepoException), "Member does not exists")]
        public void DeleteNonExistingMember()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            Member member2 = new Member()
            {
                Name = "Alfonso",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            repo.AddMemberToMemberRepository(member);
            repo.DeleteMember(member2.Id);
        }

        [TestMethod]
        public void ModifyMemberSuccessfuly()
        {
            MemberDBRepository repo = _memberDBRepository;
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
           
            member=repo.AddMemberToMemberRepository(member);
            member=repo.ModifyMemberProfileImage(member.Id, "./Images/SpiritedAway.jpg");

            Assert.AreEqual(repo.SearchMemberById(member.Id).ProfilePicture, "./Images/SpiritedAway.jpg");
        }
    }
}
