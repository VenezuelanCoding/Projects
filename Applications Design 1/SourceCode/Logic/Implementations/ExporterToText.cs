using DataInterfaces;
using LogicInterfaces;
using Domain;
using System;
using System.Collections.Generic;
using System.IO;

namespace Logic.Implementations
{
    public class ExporterToText : IExporter
    {
        public void Export(IMovieLogic movieLogic, string Path, Account CurrentAccount)
        {
            if (CurrentAccount.isAdmin)
            {
                IList<Movie> movies = movieLogic.GetAllMovies();
                List<string> lines = new List<string>();

                foreach (Movie mov in movies)
                {
                    lines.Add(mov.GetMovieInfo());
                }
                File.WriteAllLines(Path, lines);
            }
            else {
                throw new PermissionDeniedException("Account is not Admin");

            }
        }

}
}
