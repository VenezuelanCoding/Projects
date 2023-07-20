using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IAccountRepository
    {
        Account AddAccountToRepository(Account aAccount);
        Profile AddProfile(Profile profile, Account account);
        void ChangeChildren(Profile profile, bool v);
        IList<Account> GetAllAccounts();
        void RemoveProfile(Profile profile, Account anAccount);
        Account SearchAccountEmail(string email);
        Account SearchAccountName(string name);
        void AddMovieToWatched(Movie mov, Profile p);
        Profile SearchProfile(int id);
        Score SearchScore(int genreId,int profileId);
        Score AddScore(Score score, int prof);
        Score AddPointsToScore(int scoreId, int points);
        void RemoveMovieOfLikedList(int movieId, int profileId);
        void AddMovieToLikedList(int movieId, int profileId);
        void RemoveMovieOfDislikedList(int movieId, int profileId);
        void AddMovieToDislikedList(int movieId, int profileId);
        void RemoveMovieOfSuperLikedList(int movieId, int profileId);
        void AddMovieToSuperLikedList(int movieId, int profileId);

    }
}

