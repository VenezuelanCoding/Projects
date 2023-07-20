
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Profile
    {
        private string _alias;
        private string _pin;
        private bool _isChildren;

        public int Id { get; set; }

        public bool IsOwner { get; set; }
     

        public string Alias { get=>_alias; set {

                if (HasAValidAlias(value))
                {
                    _alias = value;
                }
                else
                {
                    throw new ProfileException("Invalid alias");
                }
            
            } 
        }

        private bool HasAValidAlias(string alias)
        {
            if (alias is null)
            {
                return false;
            }

            if (alias.Length == 0 || alias.Length >= 15)
            {
                return false;
            }


            if (!alias.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;
        }


        public string Pin
        {
            get => _pin; set
            {
                bool result = int.TryParse(value, out _);
                if (value != null && value.Length == 5 && result)
                {
                    _pin = value;
                }
                else
                {
                    throw new ProfileException("Invalid pin");
                }
            }
        }



        public bool IsChildren { get=>_isChildren; set {

                if (this.IsOwner && !value)
                {
                    _isChildren = value;
                }
                else if(this.IsOwner && value)
                {
                    throw new ProfileException("An owner profile cant be children");
                }
                else
                {
                    _isChildren = value;
                }
            } 
        }

        public List<Movie> WatchedMovies { get; set; }

        public List<Movie> LikedMovies { get; set; }

        public List<Movie> SuperLikedMovies { get; set; }

        public List<Movie> DisLikedMovies { get; set; }


        public void AddMovieToLiked(Movie aMovie) {
            if (aMovie != null)
            {
                if (!this.IsALikedMovie(aMovie))
                {
                    if (!this.IsASuperlikedMovie(aMovie) && !this.IsADislikedMovie(aMovie))
                    {
                        this.LikedMovies.Add(aMovie);
                    }
                    else {
                        throw new ProfileException("Movie is already in another list");
                    }
                }
                else
                {
                    throw new ProfileException("Movie is already in Liked list");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddMovieToSuperLiked(Movie aMovie)
        {
            if (aMovie != null)
            {
                if (!this.IsASuperlikedMovie(aMovie))
                {
                    if (!this.IsALikedMovie(aMovie) && !this.IsADislikedMovie(aMovie))
                    {
                        this.SuperLikedMovies.Add(aMovie);
                    }
                    else {
                        throw new ProfileException("Movie is already in another list");
                    }
                }
                else
                {
                    throw new ProfileException("Movie is already in Superliked list");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void AddMovieToDisLiked(Movie aMovie)
        {
            if (aMovie != null)
            {
                if (!this.IsADislikedMovie(aMovie))
                {
                    if (!this.IsALikedMovie(aMovie) && !this.IsASuperlikedMovie(aMovie))
                    {
                        this.DisLikedMovies.Add(aMovie);
                    }
                    else {

                        throw new ProfileException("Movie is already in another list");

                    }
                }
                else
                {
                    throw new ProfileException("Movie is already in Disliked list");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }


        public void AddMovieToWatched(Movie aMovie)
        {
            if (aMovie != null)
            {
                if (!this.IsAWatchedMovie(aMovie))
                {
                    this.WatchedMovies.Add(aMovie);
                }
                else
                {
                    throw new ProfileException("Movie is already in watched list");
                }
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public void RemoveMovieLiked(Movie aMovie) {
            if (IsALikedMovie(aMovie))
            {
                this.LikedMovies.Remove(aMovie);
            }
            else {
                throw new ProfileException("Movie not in liked List");
            }
        }


        public void RemoveMovieDisliked(Movie aMovie)
        {
            if (IsADislikedMovie(aMovie))
            {
                this.DisLikedMovies.Remove(aMovie);
            }
            else
            {
                throw new ProfileException("Movie not in Disliked List");
            }
        }

        public void RemoveMovieSuperLiked(Movie aMovie)
        {
            if (IsASuperlikedMovie(aMovie))
            {
                this.SuperLikedMovies.Remove(aMovie);
            }
            else
            {
                throw new ProfileException("Movie not in SuperLiked List");
            }
        }


        public bool IsAWatchedMovie(Movie aMovie) {

            Movie mov = WatchedMovies.FirstOrDefault(x => x.Id == aMovie.Id);
            if (mov == null) {
                return false;
            }
            else
            {
                return true;
            }
        }

        public bool IsALikedMovie(Movie aMovie)
        {
            bool exists = false;
            foreach (var movie in this.LikedMovies)
            {
                if (movie.Id == aMovie.Id)
                {
                    exists = true;
                }
            }

            return exists;

        }

        public bool IsADislikedMovie(Movie aMovie)
        {

            bool exists = false;
            foreach (var movie in this.DisLikedMovies)
            {
                if (movie.Id == aMovie.Id)
                {
                    exists = true;
                }
            }

            return exists;
        }

        public bool IsASuperlikedMovie(Movie aMovie)
        {

            bool exists = false;
            foreach (var movie in this.SuperLikedMovies)
            {
                if (movie.Id == aMovie.Id)
                {
                    exists = true;
                }
            }

            return exists;
        }


        public List<Score> Scores { get; set; }
    

        public void AddScore(Score aScore)
        {
            if (SearchScore(aScore.Genre) == null)
            {
                this.Scores.Add(aScore);
            } else
            {
                throw new ProfileException("Score Already Exists");
            }
        }

        public Score SearchScore(Genre aGenre)
        {
            return this.Scores.Where(x => x.Genre == aGenre).FirstOrDefault();
        }

        public void AddPointsToScore(Genre genre, int Points)
        {
            Score s = this.Scores.Where(x => x.Genre == genre).FirstOrDefault();
            if (s != null)
            {
                s.Points += Points;
            } else
            {
                Score newScore = new Score()
                {
                    Genre = genre,
                };
                newScore.Points = Points;
                this.AddScore(newScore);
            }
        }

        public override string ToString()
        {
            return _alias;
        }

        public Profile()
        {
            Scores = new List<Score>();
            WatchedMovies = new List<Movie>();
            LikedMovies = new List<Movie>();
            DisLikedMovies = new List<Movie>();
            SuperLikedMovies = new List<Movie>();

        }

    }
}
