using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class SearchByDirector: ISearch
    {
        public IList<Movie> Search(IList<Movie> movies, String query)
        {
            List<Movie> ret = new List<Movie>();
            List<String> directors = query.Split(' ').ToList();
            ret = movies.Where(x => x.Directors.Any(d=> NameInQuery(directors, d.Name))).ToList();
            return ret.GroupBy(x => x.Id).Select(y => y.First()).ToList();
        }

        override public string ToString()
        {
            return "By Director";
        }

        public bool NameInQuery(IList<string> SearchList, string name)
        {
            name = name.ToLower();
            foreach (string possibleName in SearchList) {
                if (name.Contains(possibleName.ToLower())) {
                    return true;
                }
         
            }
            return false;
        }
    }
}
