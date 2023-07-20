using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicInterfaces
{
    public interface IExporter 
    {
        void Export(IMovieLogic movieLogic, string Path, Account CurrentAccount);
    
    }
}
