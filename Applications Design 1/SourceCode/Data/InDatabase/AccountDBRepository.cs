using DataInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Messaging;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Data.InDatabase
{
    public class AccountDBRepository : IAccountRepository
    {
        public Account AddAccountToRepository(Account aAccount)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Account acc1 = SearchAccountName(aAccount.UserName);
                Account acc2 = SearchAccountEmail(aAccount.Email);
                if (acc1 != null || acc2 != null)
                {
                    throw new AccountRepoException("Account already exists");
                }
                else
                {
                    dbContext.Accounts.Add(aAccount);
                    dbContext.SaveChanges();
                }
                return aAccount;
            }
        }

        public void AddMovieToWatched(Movie mov, Profile p)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movDB = dbContext.Movies.FirstOrDefault(x => x.Id == mov.Id);
                Profile profileDB = dbContext.Profiles.Include("WatchedMovies").FirstOrDefault(x => x.Id == p.Id);
                if (movDB != null)
                {
                    if (profileDB != null)
                    {
                        foreach (var wMov in profileDB.WatchedMovies)
                        {
                            if (wMov == movDB)
                            {
                                throw new AccountRepoException("Movie is already the in watchedList");
                            }
                        }
                        profileDB.WatchedMovies.Add(movDB);
                        dbContext.SaveChanges();
                    }
                    else
                    {
                        throw new AccountRepoException("Profile does not exist");

                    }
                }
                else
                {
                    throw new AccountRepoException("Movie does not exist");
                }

            }

        }

        public Profile AddProfile(Profile profile, Account account)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {

                Account accountDB = SearchAccountName(account.UserName);
                Profile repeatedProfile = accountDB.Profiles.FirstOrDefault(x => x.Alias == profile.Alias);
                if (repeatedProfile == null)
                {
                    int cantP = accountDB.Profiles.Count;
                    if (cantP < 4)
                    {

                        foreach (var aProfile in accountDB.Profiles)
                        {
                            dbContext.Entry(aProfile).State = System.Data.Entity.EntityState.Unchanged;
                        }

                        accountDB.Profiles.Add(profile);
                        dbContext.Entry(accountDB).State = System.Data.Entity.EntityState.Modified;
                        dbContext.Profiles.Add(profile);
                        dbContext.SaveChanges();
                        account = accountDB;
                    }

                    else
                    {
                        throw new AccountRepoException("Cannot add more than 4 profiles");
                    }
                }
                else
                {
                    throw new AccountRepoException("Profile already exists in this account");
                }
            }
            return profile;
        }

        public void ChangeChildren(Profile profile, bool value)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                var profileDB = dbContext.Profiles.FirstOrDefault(x => x.Id == profile.Id);
                if (!profileDB.IsOwner)
                {
                    profileDB.IsChildren = value;
                    dbContext.SaveChanges();
                }
                else
                {
                    throw new AccountRepoException("The profile is Owner, it can't be children");
                }
            }
        }

        public IList<Account> GetAllAccounts()
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Accounts.Include("Profiles").ToList();
            }
        }

        public void RemoveProfile(Profile profile, Account anAccount)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Account accountDB = SearchAccountName(anAccount.UserName);
                Profile res = SearchProfile(profile.Id);
                if (res != null && !res.IsOwner)
                {
                    foreach (var aProfile in accountDB.Profiles)
                    {
                        dbContext.Entry(aProfile).State = System.Data.Entity.EntityState.Unchanged;
                    }

                    var profileDB = dbContext.Profiles.FirstOrDefault(x => x.Id == profile.Id);

                    accountDB.Profiles.Remove(profileDB);
                    dbContext.Entry(accountDB).State = System.Data.Entity.EntityState.Modified;
                    dbContext.Profiles.Remove(profileDB);
                    dbContext.SaveChanges();
                }
                else if (res == null)
                {
                    throw new AccountRepoException("Cannot remove a profile that does not exists");
                }
                else
                {
                    throw new AccountRepoException("Cannot remove an Owner profile");
                }
            }
        }

        public Account SearchAccountEmail(string email)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                var prueba = dbContext.Accounts.Include("Profiles").FirstOrDefault(x => x.Email == email);
                return prueba;
            }

        }

        public Account SearchAccountName(string name)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                var prueba = dbContext.Accounts.Include("Profiles").FirstOrDefault(x => x.UserName == name);
                return prueba;
            }
        }

        public Profile SearchProfile(int id)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                return dbContext.Profiles.Include("WatchedMovies.Directors")
                    .Include("WatchedMovies.ActingRoles.Member")
                    .Include("LikedMovies")
                    .Include("SuperLikedMovies")
                    .Include("DisLikedMovies").Include("Scores.Genre").FirstOrDefault(x => x.Id == id);
            }
        }

        public Score SearchScore(int genreId,int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Profile profile = SearchProfile(profileId);
                return profile.Scores.FirstOrDefault(x => x.Genre.Id == genreId);
            }
        }

        public Score AddScore(Score score, int prof)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Profile profileDb = dbContext.Profiles.Include("Scores").FirstOrDefault(x => x.Id == prof);
                Score scoreDb = SearchScore(score.Id,prof);
                if (scoreDb == null)
                {
                    score.Genre = dbContext.Genres.FirstOrDefault(x => x.Id == score.Genre.Id);
                    profileDb.AddScore(score);
                    dbContext.SaveChanges();
                
                }

                return score;
            }
        }

        public Score AddPointsToScore(int scoreId, int points)
        {

            using (AppDBContext dbContext = new AppDBContext())
            {
                Score scoreDb = dbContext.Scores.Include("Genre").FirstOrDefault(x => x.Id == scoreId);
                if (scoreDb == null) {
                    throw new AccountRepoException("Score does not exists");
                }
                scoreDb.Points += points;
                dbContext.SaveChanges();
                return scoreDb;
            }
        }

        public void AddMovieToLikedList(int movieId, int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDb = dbContext.Movies.Include("LikedBy").FirstOrDefault(x => x.Id==movieId);
                Profile profileDb = dbContext.Profiles.Include("LikedMovies").FirstOrDefault(x => x.Id == profileId);

                if (profileDb != null && movieDb != null) 
                { 
                    profileDb.LikedMovies.Add(movieDb);
                    dbContext.SaveChanges();
                } else if(profileDb == null){
                    throw new AccountRepoException("Profile Not found");
                } else
                {
                    throw new MovieRepoException("Movie Not found");
                }
            }
        }

        public void RemoveMovieOfLikedList(int movieId, int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDb = dbContext.Movies.FirstOrDefault(x => x.Id == movieId);
                Profile profileDb = dbContext.Profiles.Include("LikedMovies").FirstOrDefault(x => x.Id == profileId);

                if (profileDb != null && movieDb != null)
                {
                    profileDb.LikedMovies.Remove(movieDb);
                    dbContext.SaveChanges();
                }
                else if (profileDb == null)
                {
                    throw new AccountRepoException("Profile Not found");
                }
                else
                {
                    throw new MovieRepoException("Movie Not found");
                }
            }
        }

        public void AddMovieToSuperLikedList(int movieId, int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDb = dbContext.Movies.Include("LikedBy").FirstOrDefault(x => x.Id == movieId);
                Profile profileDb = dbContext.Profiles.Include("SuperLikedMovies").FirstOrDefault(x => x.Id == profileId);

                if (profileDb != null && movieDb != null)
                {
                    profileDb.SuperLikedMovies.Add(movieDb);
                    dbContext.SaveChanges();
                }
                else if (profileDb == null)
                {
                    throw new AccountRepoException("Profile Not found");
                }
                else
                {
                    throw new MovieRepoException("Movie Not found");
                }
            }
        }

        public void RemoveMovieOfSuperLikedList(int movieId, int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDb = dbContext.Movies.FirstOrDefault(x => x.Id == movieId);
                Profile profileDb = dbContext.Profiles.Include("SuperLikedMovies").FirstOrDefault(x => x.Id == profileId);

                if (profileDb != null && movieDb != null)
                {
                    profileDb.SuperLikedMovies.Remove(movieDb);
                    dbContext.SaveChanges();
                }
                else if (profileDb == null)
                {
                    throw new AccountRepoException("Profile Not found");
                }
                else
                {
                    throw new MovieRepoException("Movie Not found");
                }
            }
        }

        public void RemoveMovieOfDislikedList(int movieId, int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDb = dbContext.Movies.FirstOrDefault(x => x.Id == movieId);
                Profile profileDb = dbContext.Profiles.Include("DislikedMovies").FirstOrDefault(x => x.Id == profileId);

                if (profileDb != null && movieDb != null)
                {
                    profileDb.DisLikedMovies.Remove(movieDb);
                    dbContext.SaveChanges();
                }
                else if (profileDb == null)
                {
                    throw new AccountRepoException("Profile Not found");
                }
                else
                {
                    throw new MovieRepoException("Movie Not found");
                }
            }
        }

        public void AddMovieToDislikedList(int movieId, int profileId)
        {
            using (AppDBContext dbContext = new AppDBContext())
            {
                Movie movieDb = dbContext.Movies.Include("LikedBy").FirstOrDefault(x => x.Id == movieId);
                Profile profileDb = dbContext.Profiles.Include("DislikedMovies").FirstOrDefault(x => x.Id == profileId);

                if (profileDb != null && movieDb != null)
                {
                    profileDb.DisLikedMovies.Add(movieDb);
                    dbContext.SaveChanges();
                }
                else if (profileDb == null)
                {
                    throw new AccountRepoException("Profile Not found");
                }
                else
                {
                    throw new MovieRepoException("Movie Not found");
                }
            }
        }
    }
}
