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
    public class MemberLogicTest
    {
        private MemberDBRepository _memberDBRepository;
        private AccountDBRepository _accountDBRepository;
        private GenreDBRepository _genreDBRepository;


        public MemberLogicTest()
        {
            _accountDBRepository = new AccountDBRepository();
            _memberDBRepository = new MemberDBRepository();
            _genreDBRepository = new GenreDBRepository();
        }

        [TestCleanup]
        public void TestCleanup()
        {
            DbCleanUp.DbCleanup();
        }


        [TestMethod]
        public void AddMember()
        {
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };

            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            bool res = _memberLogic.GetAllMembers().Count == 1;
            Assert.IsTrue(res);
        }

        [TestMethod]
        public void GetAllMembers()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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

            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            member2 = _memberLogic.AddNewMember(member2, acc);
            int cantM = _memberLogic.GetAllMembers().Count;
            Assert.AreEqual(2, cantM);
        }

        [TestMethod]
        public void SearchMember()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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

            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            member2 = _memberLogic.AddNewMember(member2, acc);
            Assert.IsNotNull(_memberLogic.SearchMemberById(member2.Id));
            Assert.IsNotNull(_memberLogic.SearchMemberById(member.Id));
        }

        [TestMethod]
        [ExpectedException(typeof(MemberRepoException))]
        public void DeleteMemberWithActingRoles()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);
            GenreDBRepository Genrepo = _genreDBRepository;

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg",
                Type = MemberType.Actor
            };
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

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };



            MovieDBRepository repo = new MovieDBRepository();



            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            logic.AddActingRoleToMovie(role, acc,mov);
            _memberLogic.DeleteMember(member.Id, acc);

        }


        [TestMethod]
        [ExpectedException(typeof(MemberRepoException))]
        public void DeleteMemberWithDirectedMovies()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);
            GenreDBRepository Genrepo = _genreDBRepository;

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg",
                Type = MemberType.Director
            };
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

            MovieDBRepository repo = new MovieDBRepository();



            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            logic.AddDirectorToMovie(member, acc, mov);
            _memberLogic.DeleteMember(member.Id, acc);

        }

        [TestMethod]
        [ExpectedException(typeof(MemberRepoException))]
        public void DeleteMemberWithActingRolesAndDirectedMovies()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);
            GenreDBRepository Genrepo = _genreDBRepository;

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg",
                Type = MemberType.ActorAndDirector
            };
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

            ActingRole role = new ActingRole() { Name = "Spiderman", Member = member };



            MovieDBRepository repo = new MovieDBRepository();



            MovieLogic logic = new MovieLogic(repo);
            mov = logic.AddNewMovie(mov, acc);
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            logic.AddActingRoleToMovie(role, acc, mov);
            _memberLogic.DeleteMember(member.Id, acc);

        }

        [TestMethod]
        [ExpectedException(typeof(MemberRepoException), "Member does not exists")]
        public void DeleteNonExistingMember()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            _memberLogic.DeleteMember(member2.Id, acc);
        }

        [TestMethod]
        public void ModifyMemberSuccessfuly()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            member = _memberLogic.ModifyMemberProfileImage(member.Id, "./Images/SpiritedAway.jpg", acc);

            Assert.AreEqual(_memberLogic.SearchMemberById(member.Id).ProfilePicture, "./Images/SpiritedAway.jpg");
        }
        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void ModifyMemberUnsuccessfuly()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = false
            };
            Account acc2 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc2);
            member = _memberLogic.ModifyMemberProfileImage(member.Id, "./Images/SpiritedAway.jpg", acc);
        }

        [TestMethod]
        public void DeleteMemberSuccessfuly()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            member2 = _memberLogic.AddNewMember(member2, acc);
            _memberLogic.DeleteMember(member2.Id, acc);
            Assert.IsNull(_memberLogic.SearchMemberById(member2.Id));
            Assert.IsNotNull(_memberLogic.SearchMemberById(member.Id));
        }


        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void DeleteMemberUnsuccessfuly()
        {
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = false
            };
            Account acc2 = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = true
            };
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
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc2);

            _memberLogic.DeleteMember(member.Id, acc);
        }

        [TestMethod]
        [ExpectedException(typeof(PermissionDeniedException))]
        public void AddMemberFailed()
        {
            MemberLogic _memberLogic = new MemberLogic(_memberDBRepository);
            AccountLogic _accountLogic = new AccountLogic(_accountDBRepository);

            Account acc = new Account()
            {
                UserName = "user1234567",
                Email = "user1@hotmail.com",
                Password = "user1234567",
                isAdmin = false
            };

            Member member = new Member()
            {
                Name = "Arturo",
                BirthDate = new DateTime(2000, 7, 7),
                ProfilePicture = "./Images/ScaryMovie.jpg"
            };
            acc = _accountLogic.AddNewAccount(acc);
            member = _memberLogic.AddNewMember(member, acc);
            bool res = _memberLogic.GetAllMembers().Count == 1;
            Assert.IsTrue(res);
        }

    }
}
