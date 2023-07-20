using Data;
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
    public class GenreLogic : IGenreLogic
    {

        private IGenreRepository _repository;
        public GenreLogic(IGenreRepository repo)
        {
            _repository = repo;
        }
        public Genre AddNewGenre(Genre gen, Account currentAccount)
        {

            if (currentAccount.isAdmin)
            {
                if (SearchGenre(gen.Name) != null)
                {
                    throw new GenreRepoException("Duplicate Genre");
                }
                else
                {
                    _repository.AddGenreToGenreRepository(gen);
                }
                return gen;
            }
            else {

                throw new PermissionDeniedException("Account is not Admin");
            }


        }

        public void DeleteGenre(string name, Account currentAccount)
        {
            if (currentAccount.isAdmin)
            {
                _repository.DeleteGenre(name);
            }
            else {
                throw new PermissionDeniedException("Account is not Admin");
            }
               
        }

        public IList<Genre> GetAllGenres()
        {
            return _repository.GetAllGenres();
        }

        public Genre SearchGenre(string name)
        {
            return _repository.SearchGenre(name);

        }
    }
}
