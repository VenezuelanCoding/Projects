using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class SearchByActor: ISearch
    {
        public IList<Movie> Search(IList<Movie> movies, String query)
        {
            List<Movie> ret = new List<Movie>();
            List<String> actors = query.Split(' ').ToList();
            ret = movies.Where(x => x.ActingRoles.Any(r => NameInQuery(actors, r.Member.Name))).ToList();
            return ret.GroupBy(x => x.Id).Select(y => y.First()).ToList();
        }

        override public string ToString()
        {
            return "By Actor";
        }

        public bool NameInQuery(IList<string> SearchList, string name)
        {
            name = name.ToLower();
            foreach (string possibleName in SearchList)
            {

                if (name.Contains(possibleName.ToLower())) {
                    return true;

                }
            }
            return false;
        }
    }
}
