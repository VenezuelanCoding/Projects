using Microsoft.VisualStudio.TestTools.UnitTesting;
using Domain;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class AccountTest
    {
        [TestMethod]
        public void CreatingEmptyObject()
        {
            Account acc = new Account();
            Assert.IsInstanceOfType(acc, typeof(Account));


        }
        [DataRow("asdfasdf@a.com")]
        [DataRow("pepe@josea.com")]
        [DataRow("pepe.jose@pepe.com.uy")]
        [DataRow("pepe-jose@mail.com")]
        [DataRow("pepe.jose-arocena@mail-ort.com")]
        [DataRow("pepe.jose-arocena@mail-ort.cm")]
        [DataRow("a@mail-ort.cm")]
        [TestMethod]
        public void CreateAccountWithValidEmail(string email)
        {
            Account acc = new Account();


            acc.Email = email;

            Assert.AreEqual(email, acc.Email);



        }

        [DataRow("aaaa")]
        [DataRow("aaa@aa")]
        [DataRow("asdfasdf@.com")]
        [DataRow("pepe@josea.m")]
        [DataRow("pepe#jose@pepe.com.uy")]
        [DataRow("pepe&jose@mail.com")]
        [DataRow("@mail-ort.com")]
        [DataRow("pepe.jose-arocena@mail-ort..cm")]
        [DataRow("a@mail_ort.cm")]
        [DataRow(null)]
        [TestMethod]
        [ExpectedException(typeof(AccountException), "Email not valid")]
        public void CreateAccountWithNotValidEmail(string email)
        {
            Account acc = new Account();

            acc.Email = email;



        }
        [DataRow("test")]
        [DataRow("Alias1")]
        [DataRow("Alias2")]
        [DataRow("Alias3")]

        [TestMethod]
        public void AddFirstProfile(string alias)
        {

            Account acc = new Account();
            Profile prof = new Profile();
            prof.Alias = alias;
            acc.AddProfile(prof);
            Assert.IsNotNull(acc.SearchProfile(alias));
            Assert.IsTrue(acc.SearchProfile(alias).IsOwner);
        }




        [DataRow(new string[] { "profile1", "Profile2" })]
        [DataRow(new string[] { "profile1", "Profile2", "profile3" })]
        [DataRow(new string[] { "profile1", "Profile2", "profile3", "profile4" })]
        [TestMethod]
        public void AddMoreThanOneProfile(string[] aliases)
        {

            Account acc = new Account();
            foreach (string alias in aliases)
            {
                Profile prof = new Profile();
                prof.Alias = alias;
                acc.AddProfile(prof);
            }
            int count = 0;
            foreach (string alias in aliases)
            {
                Assert.IsNotNull(acc.SearchProfile(alias));

                if (count == 0)
                {
                    Assert.IsTrue(acc.SearchProfile(aliases[count]).IsOwner);
                }
                else
                {
                    Assert.IsFalse(acc.SearchProfile(aliases[count]).IsOwner);
                }
                count++;

            }

        }

        [DataRow(new string[] { "profile1", "Profile2", "profile3", "profile4", "profile5" })]
        [DataRow(new string[] { "profile1", "Profile2", "profile3", "profile4", "profile5", "profile6" })]
        [DataRow(new string[] { "profile1", "Profile2", "profile3", "profile4", "profile5", "profile6", "profile7" })]
        [TestMethod]
        [ExpectedException(typeof(AccountException), "Error, Profile limit reached")]
        public void AddMoreThanMaxProfiles(string[] aliases)
        {

            Account acc = new Account();
            foreach (string alias in aliases)
            {
                Profile prof = new Profile();
                prof.Alias = alias;
                acc.AddProfile(prof);
            }

        }
        [TestMethod]
        public void CreateAdminAccount()
        {
            Account acc = new Account();
            acc.isAdmin = true;
            Assert.IsTrue(acc.isAdmin);
        }
        [TestMethod]
        public void CreateNonAdminAccount()
        {
            Account acc = new Account();
            acc.isAdmin = false;
            Assert.IsFalse(acc.isAdmin);
        }


        [DataRow("a435jkljsdf")]
        [DataRow("a435jkljkljlk")]
        [TestMethod]
        public void ValidUsername(string username)
        {
            Account acc = new Account();
            acc.UserName = username;
            Assert.AreEqual(username, acc.UserName);
        }


        [DataRow(null)]
        [DataRow("a145678")]
        [DataRow("abcdebfhijklmnloiujkh")]
        [DataRow("234?kd")]
        [DataRow("234?)__k")]
        [DataRow("0123456789%")]
        [TestMethod]
        [ExpectedException(typeof(AccountException), "Username Not valid")]
        public void InvalidUsername(string username)
        {
            Account acc = new Account();
            acc.UserName = username;

        }


        [DataRow("a435jklj?234+js^%&$df")]
        [DataRow("a435jklj?234+_kljlk")]
        [TestMethod]
        public void ValidPassword(string password) {
            Account acc = new Account();
            acc.Password = password;
            Assert.AreEqual(password, acc.Password);
        }



        [DataRow("a435jklj?234+js^%&$dfa34+_kljlka34+_kljlk")]
        [DataRow("a34+_kljl")]
        [TestMethod]
        [ExpectedException(typeof(AccountException), "Password not valid")]
        public void InvalidPassword(string password)
        {
            Account acc = new Account();
            acc.Password = password;
        }
       




        [DataRow(new string[] { "profile1", "Profile2", "Profile2" })]
        [DataRow(new string[] { "Profile2", "Profile2" })]
        [TestMethod]

        [ExpectedException(typeof(AccountException), "Duplicated profile error")]
        public void AddDuplicatedProfileAlias(string[] aliases)
        {
            Account acc = new Account();
            foreach (string alias in aliases)
            {
                Profile prof = new Profile();
                prof.Alias = alias;
                acc.AddProfile(prof);
            }
        }


        [TestMethod]

        public void SetProfileList()
        {
            Account acc = new Account();
            List<Profile> test = new List<Profile>();
            Profile prof = new Profile();
            Profile prof2 = new Profile();
            test.Add(prof);
            test.Add(prof2);

            acc.Profiles = test;

            Assert.AreEqual(test, acc.Profiles);
        }


        [TestMethod]

        public void DeleteProfile()
        {
            Account acc = new Account();
            Profile prof = new Profile() { Alias = "alias1" };
            Profile prof2 = new Profile() { Alias = "alias2"};

            acc.AddProfile(prof);
            acc.AddProfile(prof2);
            acc.RemoveProfile(prof.Alias);


            Assert.IsNull(acc.SearchProfile(prof.Alias));
            Assert.IsNotNull(acc.SearchProfile(prof2.Alias));

        }

        [TestMethod]
        [ExpectedException(typeof(AccountException), "Profile does not exist")]

        public void DeleteNonExistentProfile()
        {
            Account acc = new Account();
            Profile prof = new Profile() { Alias = "alias1" };
            Profile prof2 = new Profile() { Alias = "alias2" };
            acc.AddProfile(prof);


            acc.RemoveProfile(prof2.Alias);




        }
        [TestMethod]
        public void TestToString() {
            Account acc = new Account() { UserName = "tests12345"};
            Assert.AreEqual("tests12345", acc.ToString());
        }

        [TestMethod]
        public void TestID()
        {
            Account acc = new Account() { UserName = "tests12345"};
            acc.Id = 5;

            Assert.AreEqual(5, acc.Id);
        }
    }
}
