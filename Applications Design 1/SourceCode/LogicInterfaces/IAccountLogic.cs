using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicInterfaces
{
    public interface IAccountLogic 
    {

        Profile GetCurrentProfile();

        void SetCurrentProfile(Profile profile);
        Account GetCurrentAccount();
        void SetCurrentAccount(Account account);
        Account AddNewAccount(Account anAccount);

        IList<Account> GetAllAccounts();

        Profile SearchProfile(int id);

        Profile AddProfile(Profile profile, Account anAccount);

        void RemoveProfile(Profile profile, Account anAccount);

        Score AddScoreToProfile(int id, Score s);

        Score AddPointsToScore(int scoreId, Profile p, int _points);

        Account SearchAccountByEmail(string email);

        Account SearchAccountByUsername(string username);

        void AddToWatchedMovies(Movie mov, Profile p);

        void ChangeChildren(Profile profile, bool v);
        
        Score SearchScore(int genreId,int profileID);
        void AddToDislikedMovies(int movieId, int profileId);
        void RemoveOfDislikedMovies(int movieId, int profileId);
        void AddToLikedMovies(int movieId, int profileId);
        void RemoveOfLikedMovies(int movieId, int profileId);
        void AddToSuperLikedMovies(int movieId, int profileId);
        void RemoveOfSuperLikedMovies(int movieId, int profileId);
    }
}
