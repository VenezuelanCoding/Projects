using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicInterfaces
{
    public interface ISearch
    {
        IList<Movie> Search(IList<Movie> movies, String Query);

        bool NameInQuery(IList<String> SearchList, string name);  

    }
}
