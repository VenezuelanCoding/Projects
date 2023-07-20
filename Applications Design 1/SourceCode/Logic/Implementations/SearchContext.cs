using Domain;
using LogicInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class SearchContext
    {
        private ISearch SearchStrategy { get; set; }
        public void SetStrategy(string type)
        {
        
            if (type == "By Director")
            {
                SearchStrategy = new SearchByDirector();
            }
            else if (type == "By Actor")
            {
                SearchStrategy = new SearchByActor();
            }
            else
            {
                throw new SearchLogicException("Search type " + type + " not available");
            }
        }
        public IList<Movie> Search(IList<Movie> movies, String query)
        {
            return SearchStrategy.Search(movies, query);
        }

        public override string ToString()
        {
            return SearchStrategy.ToString();
        }

    }
}
