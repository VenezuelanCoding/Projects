using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicInterfaces
{
    public interface IGenreLogic 
    {
        void DeleteGenre(string name, Account currentAccount);


        Genre AddNewGenre(Genre gen, Account currentAccount);

        IList<Genre> GetAllGenres();

        Genre SearchGenre(string name);
   



    }
}
