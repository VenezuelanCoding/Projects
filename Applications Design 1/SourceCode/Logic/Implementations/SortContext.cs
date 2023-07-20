using Domain;
using Logic.Implementations;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class SortContext
    {
        private ISorting SortStrategy { get; set; }
        public void SetStrategy(string type, IGenreLogic genreLogic, IAccountLogic accountLogic) {
            if (type == "By Name")
            {
                SortStrategy = new SortByName();
            }
            else if (type == "By Sponsor")
            {
                SortStrategy = new SortBySponsor();
            }
            else if (type == "By Score")
            {
                SortStrategy = new SortByScore(genreLogic, accountLogic);
            }
            else {
                throw new SortLogicException("Sorting type " + type + " not available");
            }
        }
        public IList<Movie> Sort(IList<Movie> movies) {
            return SortStrategy.Sort(movies);
        }

        public override string ToString()
        {
            return SortStrategy.ToString();
        }

    }
}
