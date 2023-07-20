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
    public class SortByName: ISorting
    {
        public IList<Movie> Sort(IList<Movie> movies)
        {
            return movies.OrderBy(x => x.PrimaryGenre.Name).ThenBy(x => x.Name).ToList();

        }

        override public string ToString()
        {
            return "By Name";
        }

    }
}
