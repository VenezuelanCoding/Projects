using DataInterfaces;
using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class AccountLogic : IAccountLogic
    {
        private IAccountRepository _repository;
        public Account _currentAccount;
        public Profile _currentProfile;

        public Account GetCurrentAccount()
        {
            return _repository.SearchAccountEmail(_currentAccount.Email);
        }

        public void SetCurrentProfile(Profile profile)
        {
            _currentProfile = profile;
        }
        public Profile GetCurrentProfile()
        {
            return _repository.SearchProfile(_currentProfile.Id);
        }

        public void SetCurrentAccount(Account account)
        {
            _currentAccount = account;
        }


        public AccountLogic(IAccountRepository repo)
        {
            _repository = repo;
        }

        public Score AddPointsToScore(int scoreId, Profile profile, int _points)
        {
            return _repository.AddPointsToScore(scoreId, _points);
        }

        public Profile AddProfile(Profile profile, Account anAccount)
        {
            return _repository.AddProfile(profile,anAccount);
        }

        public Score AddScoreToProfile(int id, Score s)
        {
            Profile result = _repository.SearchProfile(id);
            if(result == null)
            {
                throw new AccountLogicException("The Score can't be added to a non existing profile");
            } else
            {
                result.AddScore(s);
                return _repository.AddScore(s,result.Id);
            }

        }

        public Account AddNewAccount(Account anAccount)
        {
            if (_repository.SearchAccountEmail(anAccount.Email) != null)
            {
                    throw new AccountLogicException("The email is already linked to an account");
            }
            else if (_repository.SearchAccountName(anAccount.UserName) != null)
            {
                throw new AccountLogicException("This username is already being used");
            }
            else
            {
                
                return _repository.AddAccountToRepository(anAccount);
            }
        }
        
        public IList<Account> GetAllAccounts()
        {
            return _repository.GetAllAccounts();
        }

        public void RemoveProfile(Profile profile, Account anAccount)
        {
            _repository.RemoveProfile(profile,anAccount);
        }


        public Account SearchAccountByEmail(string email)
        {
            Account res = _repository.SearchAccountEmail(email);
            if (res == null)
            {
                throw new AccountLogicException("The email provided wasn't found in the data");
            }
            else
            {
                return res;
            }
        }

        public Account SearchAccountByUsername(string username)
        {
            Account res = _repository.SearchAccountName(username);
            if (res == null)
            {
                throw new AccountLogicException("The username provided wasn't found in the data");
            }
            else
            {
                return res;
            }
        }

        public Profile SearchProfile(int id)
        {
            return _repository.SearchProfile(id);
        }


        public void ChangeChildren(Profile profile, bool v)
        {
            _repository.ChangeChildren(profile, v);
        }

        public void AddToWatchedMovies(Movie mov, Profile p)
        {
            _repository.AddMovieToWatched(mov, p);
        }

        public Score SearchScore(int genreId,int profileId)
        {
            return _repository.SearchScore(genreId, profileId);
        }
        public void AddToDislikedMovies(int movieId, int profileId)
        {
            _repository.AddMovieToDislikedList(movieId, profileId);
        }

        public void RemoveOfDislikedMovies(int movieId, int profileId)
        {
            _repository.RemoveMovieOfDislikedList(movieId, profileId);
        }

        public void AddToLikedMovies(int movieId, int profileId)
        {
            _repository.AddMovieToLikedList(movieId, profileId);
        }

        public void RemoveOfLikedMovies(int movieId, int profileId)
        {
            _repository.RemoveMovieOfLikedList(movieId, profileId);
        }

        public void AddToSuperLikedMovies(int movieId, int profileId)
        {
            _repository.AddMovieToSuperLikedList(movieId, profileId);
        }

        public void RemoveOfSuperLikedMovies(int movieId, int profileId)
        {
            _repository.RemoveMovieOfSuperLikedList(movieId, profileId);
        }
    }
}
