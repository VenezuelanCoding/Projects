using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataInterfaces
{
    public interface IGenreRepository
    {
        Genre AddGenreToGenreRepository(Genre aGenre);

        IList<Genre> GetAllGenres();

        Genre SearchGenre(string name);

        void DeleteGenre(string name);

    }
}
