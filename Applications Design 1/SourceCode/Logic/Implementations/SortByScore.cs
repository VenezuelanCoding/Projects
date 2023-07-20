using DataInterfaces;
using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class SortByScore : ISorting
    {
        private IGenreLogic _genreLogic;
        private IAccountLogic _accountLogic;


        public SortByScore(IGenreLogic genreLogic, IAccountLogic accountLogic) {
            
            _genreLogic = genreLogic;
            _accountLogic = accountLogic;

        }
        public IList<Movie> Sort(IList<Movie> movies)
        {
            IList<Score> scores = _accountLogic.GetCurrentProfile().Scores;
            IList<Genre> allGenres = _genreLogic.GetAllGenres();
            foreach ( Genre genre in allGenres)
            {
                if (scores.FirstOrDefault(x => x.Genre.Id == genre.Id) == null) {
                    scores.Add(new Score() { Genre = genre, Points = 0 });
                }
            }
           
            IList<Score> ordered_scores = scores.OrderByDescending(x => x.Points).ToList();
            IList<int> ordered_genres = ordered_scores.Select(x => x.Genre.Id).ToList();

            return movies.OrderBy(x => ordered_genres.IndexOf(x.PrimaryGenre.Id)).ThenBy(x => x.Name).ToList();

        }
        override public string ToString()
        {
            return "By Score";
        }
    }
}
