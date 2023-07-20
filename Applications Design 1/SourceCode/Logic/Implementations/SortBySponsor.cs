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
    public class SortBySponsor : ISorting
    {
        public IList<Movie> Sort(IList<Movie> movies)
        {
            return movies.OrderByDescending(x => x.IsSponsored).ThenBy(x => x.PrimaryGenre.Name).ThenBy(x => x.Name).ToList();
        }
        override public string ToString()
        {
            return "By Sponsor";
        }
    }


}
