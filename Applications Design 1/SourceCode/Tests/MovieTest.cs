using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTest
{
    [TestClass]
    public class MovieTest
    {
        [TestMethod]
        public void creatingEmptyObject()
        {
            Movie mov = new Movie();
            Assert.IsInstanceOfType(mov, typeof(Movie));

        }

        [TestMethod]
        public void NullName()
        {
            Movie mov = new Movie();
            mov.Name = "ScaryMovie";
            Assert.IsNotNull(mov.Name);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NotNullName()
        {
            Movie mov = new Movie() { Name = null };

        }


        [TestMethod]
        [ExpectedException(typeof(MovieException), "The name cannot be empty")]
        public void NameIsEmpty()
        {
            Movie mov = new Movie();
            mov.Name = "";
        }


        [TestMethod]
        public void AddPrimaryGenreToMovie()
        {
            Genre aGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };
            Movie mov = new Movie();
            mov.PrimaryGenre = aGenre;

            Assert.IsNotNull(mov.PrimaryGenre);
            Assert.AreEqual(mov.PrimaryGenre, aGenre);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "The added Subgenre is the same as the primary genre of the movie")]
        public void SubgenreSameAsPrimaryGenre()
        {
            Genre aGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };


            Genre aSecondGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };
            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.PrimaryGenre = aGenre;
            mov.AddGenreToSubgenres(aSecondGenre);
        }


        [TestMethod]
        [ExpectedException(typeof(MovieException), "Primary cannot be empty")]
        public void AddSubGenreWhenPrimaryIsNull()
        {
            Genre aGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };

            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.AddGenreToSubgenres(aGenre);
        }


        [TestMethod]
        [ExpectedException(typeof(MovieException), "Second Genre already present")]
        public void RepeatedSecondaryGenreInMovie()
        {
            Genre aGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };

            Genre aSecondGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };

            Genre anotherGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Drama",
            };

            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.PrimaryGenre = anotherGenre;
            mov.AddGenreToSubgenres(aGenre);
            mov.AddGenreToSubgenres(aSecondGenre);
        }

        [TestMethod]
        public void AddSecundaryGenreToMovie()
        {
            Genre aGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Horror",
            };

            Genre anotherGenre = new Genre()
            {
                Description = "Horror Movies",
                Name = "Drama",
            };

            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.PrimaryGenre = anotherGenre;
            mov.AddGenreToSubgenres(aGenre);
            Assert.IsTrue(mov.SubGenres.Contains(aGenre));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullSubgenres()
        {
            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.SubGenres = null;

        }

        [TestMethod]
        public void SetSubgenres()
        {
            Movie mov = new Movie();
            mov.Name = "Prueba";
            List<Genre> SubGenres = new List<Genre>();

            mov.SubGenres = SubGenres;
            Assert.AreEqual(mov.SubGenres, SubGenres);

        }

        [TestMethod]
        [DataRow("/poster.jpg")]
        [DataRow("/poster.png")]
        public void PosterIsAnImage(string path)
        {
            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.Poster = path;
            Assert.AreEqual(mov.Poster, path);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Poster file is not an image")]
        public void PosterIsNotAnImage()
        {
            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.Poster = "probando.mp4";

        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Poster file is not an image")]
        public void PosterIsNotAPath()
        {
            Movie mov = new Movie();
            mov.Name = "Prueba";
            mov.Poster = "probando";

        }

        [TestMethod]
        public void IsPG()
        {
            Movie mov = new Movie();
            mov.IsPG = true;
            Assert.IsTrue(mov.IsPG);
        }

        [TestMethod]
        public void IsNotPG()
        {
            Movie mov = new Movie();
            mov.IsPG = false;
            Assert.IsFalse(mov.IsPG);
        }


        [TestMethod]
        public void IsSponsored()
        {
            Movie mov = new Movie();
            mov.IsSponsored = true;
            Assert.IsTrue(mov.IsSponsored);
        }

        [TestMethod]
        public void IsNotSponsored()
        {
            Movie mov = new Movie();
            mov.IsSponsored = false;
            Assert.IsFalse(mov.IsSponsored);
        }


        [TestMethod]
        public void AddMovieToRelatedMovies()
        {
            Movie mov = new Movie() { Id = 1};
            mov.Name = "Scary Movie";
            Movie mov2 = new Movie() { Id = 4 };
            mov2.Name = "Ratatouille";

            mov.AddMovieToRelatedMovies(mov2);
            Assert.IsTrue(mov.RelatedMovies.Contains(mov2));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Movie already Related")]
        public void AddRepeatedMovieToRelatedMovies()
        {
            Movie mov = new Movie() { Id = 1 };
            mov.Name = "Scary Movie";
            Movie mov2 = new Movie() { Id = 4 };
            mov2.Name = "Ratatouille";

            mov.AddMovieToRelatedMovies(mov2);
            mov.AddMovieToRelatedMovies(mov2);
        }
        [TestMethod]
        [ExpectedException(typeof(MovieException),"Secondary Genre cannot be the same as the Primary")]
        public void AddMovieSameNameAsPrincipalToRelatedMovies()
        {
            Movie mov = new Movie() { Id = 1 };
            mov.Name = "Scary Movie";
            Movie mov2 = new Movie() { Id = 1 };
            mov2.Name = "Scary Movie";

            mov.AddMovieToRelatedMovies(mov2);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullToRelatedMovies()
        {
            Movie mov = new Movie() { Id = 1 };
            mov.Name = "Scary Movie";

            mov.AddMovieToRelatedMovies(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetNullToRelatedMovies()
        {
            Movie mov = new Movie();
            mov.Name = "Scary Movie";

            mov.RelatedMovies = null;
        }


        [TestMethod]
        [DataRow("example1")]
        [DataRow("example2")]
        public void AddDescriptionToAMovie(string description)

        {
            Movie mov = new Movie();
            mov.Name = "Scary Movie";
            mov.Description = description;
            Assert.AreEqual(mov.Description, description);
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void AddNullAdescriptionToAMovie()
        {
            Movie mov = new Movie();
            mov.Name = "Scary Movie";
            mov.Description = null;
        }

        [TestMethod]
        public void SetReleaseDate()
        {
            Movie mov = new Movie();
            mov.Name = "Scary Movie";
            DateTime date1 = new DateTime(2015, 12, 25);
            mov.ReleaseDate = date1;
            Assert.AreEqual(mov.ReleaseDate, date1);
        }

        [TestMethod]
        public void setRelatedMovies()
        {
            Movie mov = new Movie();
            mov.Name = "Scary Movie";
            List<Movie> test = new List<Movie>();
            Movie mov2 = new Movie();
            mov.Name = "Scary Movie 2";
            Movie mov3 = new Movie();
            mov.Name = "Scary Movie 3";
            test.Add(mov2);
            test.Add(mov3);

            mov.RelatedMovies = test;
        }

        [TestMethod]
        public void GetMovieInfo()
        {
            Genre gen = new Genre()
            {
                Name = "Horror"

            };
            Genre gen2 = new Genre()
            {
                Name = "Funny"
            };
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary movie",
                PrimaryGenre = gen,
                ReleaseDate = new DateTime(),
                IsPG = true,
                IsSponsored = false,
            };
            mov.SubGenres.Add(gen2);

            Movie mov2 = new Movie()
            {
                Id = 2,
                Name = "JEJE",
                PrimaryGenre = gen,
                ReleaseDate = new DateTime(),
                IsPG = false,
                IsSponsored = true,
            };
            mov2.AddMovieToRelatedMovies(mov);

            string result1 = "Name: " + mov.Name + ", IsPG: Yes, IsSponsored: No, Release Date: " + mov.ReleaseDate.ToString() + ", Primary Genre: " + mov.PrimaryGenre.Name + ", SubGenres: Funny ";
            string result2 = "Name: " + mov2.Name + ", IsPG: No, IsSponsored: Yes, Release Date: " + mov2.ReleaseDate.ToString() + ", Primary Genre: " + mov2.PrimaryGenre.Name + ", Related Movies: Scary movie ";
            Assert.AreEqual(result1, mov.GetMovieInfo());
            Assert.AreEqual(result2, mov2.GetMovieInfo());



        }
        [TestMethod]
        public void GetAllPGRelatedMovies()
        {
            Movie mov = new Movie()
            {
                Id = 1,
                Name = "Scary movie",
                IsPG = true,
            };
            Movie mov2 = new Movie()
            {
                Id = 2,

                Name = "JEJE",
                IsPG = false,
            };
            Movie mov3 = new Movie()
            {
                Id = 3,

                Name = "JJJ",
                IsPG = false,
            };
            mov3.AddMovieToRelatedMovies(mov);
            mov3.AddMovieToRelatedMovies(mov2);

            Assert.IsTrue(mov3.GetRelatedPGMovies().Contains(mov));
            Assert.IsFalse(mov3.GetRelatedPGMovies().Contains(mov2));

        }

        [TestMethod]
        public void TestToString()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Assert.AreEqual("Scary movie", mov.ToString());

        }

        [TestMethod]
        public void AddValidDirectorToDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member director = new Member();
            director.Type = MemberType.Director;
            mov.AddDirectors(director);
            Assert.IsTrue(mov.Directors.Contains(director));
        }

        [TestMethod]
        public void AddValidDirectorAndActorToDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member directorAndActor = new Member();
            directorAndActor.Type = MemberType.ActorAndDirector;
            mov.AddDirectors(directorAndActor);
            Assert.IsTrue(mov.Directors.Contains(directorAndActor));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Director already added")]
        public void AddRepeatedDirectorToDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member directorAndActor = new Member();
            directorAndActor.Type = MemberType.ActorAndDirector;
            mov.AddDirectors(directorAndActor);
            mov.AddDirectors(directorAndActor);
        }
        
        [TestMethod]
        [ExpectedException(typeof(MovieException), "Director is Invalid or is not a Director")]
        public void AddActorToDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member Actor = new Member();
            Actor.Type = MemberType.Actor;
            mov.AddDirectors(Actor);
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Director is Invalid or is not a Director")]
        public void AddNullToDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            mov.AddDirectors(null);
        }


        [TestMethod]
        public void GetADirectorFromDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member director = new Member();
            director.Type = MemberType.Director;
            director.Id = 0;
            mov.AddDirectors(director);
            Assert.AreEqual(director, mov.GetDirectorById(director.Id));
        }

        [TestMethod]
        public void GetANullFromDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Assert.AreEqual(null, mov.GetDirectorById(0));
        }


        [TestMethod]
        public void AddValidActingRoleToActingRoles()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member actor = new Member();
            actor.Type = MemberType.Actor;

            ActingRole aRole = new ActingRole();
            aRole.Member = actor;
            aRole.Name = "Spiderman";

            mov.AddActingRoles(aRole);
            Assert.IsTrue(mov.ActingRoles.Contains(aRole));
        }

        [TestMethod]
        public void AddValidDirectorAndActorToActingRoles()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member directorAndActor = new Member();
            directorAndActor.Type = MemberType.ActorAndDirector;

            ActingRole aRole = new ActingRole();
            aRole.Member = directorAndActor;
            aRole.Name = "Spiderman";
            mov.AddActingRoles(aRole);

            Assert.IsTrue(mov.ActingRoles.Contains(aRole));
        }

        
        [TestMethod]
        [ExpectedException(typeof(MovieException), "Role cannot be null")]
        public void AddNullToActingRoles()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            mov.AddActingRoles(null);
        }


        [TestMethod]
        public void GetAnActingRoleFromActingRoles()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member actor = new Member();
            actor.Type = MemberType.Actor;
            actor.Id = 0;

            ActingRole ar = new ActingRole();
            ar.Member = actor;
            ar.Name = "Papel";

            mov.AddActingRoles(ar);
            Assert.AreEqual(ar, mov.GetActingRoleByName(ar.Name));
        }

        [TestMethod]
        public void GetANullFromActingRoles()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            
            Assert.AreEqual(null, mov.GetActingRoleByName("lal"));
        }

        [TestMethod]
        public void AddTwoRolesToActor()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member actor = new Member();
            actor.Type = MemberType.Actor;
            actor.Id = 0;

            ActingRole arSpiderman = new ActingRole();
            arSpiderman.Member = actor;
            arSpiderman.Name = "Spiderman";

            mov.AddActingRoles(arSpiderman);

            ActingRole arPeterParker = new ActingRole();
            arPeterParker.Member = actor;
            arPeterParker.Name = "PeterParker";

            mov.AddActingRoles(arPeterParker);


            Assert.IsTrue(mov.ActingRoles.Contains(arSpiderman));
            Assert.IsTrue(mov.ActingRoles.Contains(arPeterParker));
        }

        [TestMethod]
        [ExpectedException(typeof(MovieException), "Role already taken by antoher actor")]
        public void AddTwoActorsToARole()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            Member actor = new Member();
            actor.Type = MemberType.Actor;
            actor.Id = 0;

            Member actor2 = new Member();
            actor.Type = MemberType.Actor;
            actor.Id = 0;

            ActingRole arSpiderman = new ActingRole();
            arSpiderman.Member = actor;
            arSpiderman.Name = "Spiderman";

            mov.AddActingRoles(arSpiderman);

            ActingRole arSpiderman2 = new ActingRole();
            arSpiderman2.Member = actor;
            arSpiderman2.Name = "Spiderman";

            mov.AddActingRoles(arSpiderman2);
        }


        [TestMethod]
        public void SetActingRoles() {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            List<ActingRole> list = new List<ActingRole>();

            mov.ActingRoles = list;

            Assert.AreEqual(list, mov.ActingRoles);
            
        }

        [TestMethod]
        public void SetDirectors()
        {
            Movie mov = new Movie()
            {
                Name = "Scary movie",
            };
            List<Member> list = new List<Member>();

            mov.Directors = list;

            Assert.AreEqual(list, mov.Directors);

        }

        [TestMethod]
        public void Set_Get_LikedBy()
        {
            Movie mov1 = new Movie() { Name = "movie1" };
            Profile prof = new Profile() { Alias = "pepe" };
            List<Profile> list = new List<Profile>();
            list.Add(prof);
            mov1.LikedBy = list;
           
            Assert.IsTrue(mov1.LikedBy.Contains(prof));
        }

        [TestMethod]
        public void Set_Get_SuperLikedBy()
        {
            Movie mov1 = new Movie() { Name = "movie1" };
            Profile prof = new Profile() { Alias = "pepe" };
            List<Profile> list = new List<Profile>();
            list.Add(prof);
            mov1.SuperlikedBy = list;

            Assert.IsTrue(mov1.SuperlikedBy.Contains(prof));
        }
        [TestMethod]
        public void Set_Get_DislikedBy()
        {
            Movie mov1 = new Movie() { Name = "movie1" };
            Profile prof = new Profile() { Alias = "pepe" };
            List<Profile> list = new List<Profile>();
            list.Add(prof);
            mov1.DislikedBy = list;

            Assert.IsTrue(mov1.DislikedBy.Contains(prof));
        }

        [TestMethod]
        public void Set_Get_WatchedBy()
        {
            Movie mov1 = new Movie() { Name = "movie1" };
            Profile prof = new Profile() { Alias = "pepe" };
            List<Profile> list = new List<Profile>();
            list.Add(prof);
            mov1.WatchedBy = list;

            Assert.IsTrue(mov1.WatchedBy.Contains(prof));
        }
    }
}
