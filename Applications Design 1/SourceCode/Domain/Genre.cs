using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Genre
    {
        private string _name;

        public int Id { get; set; }


        public string Name { get => _name; 
            set {
                if(value == null)
                {
                    throw new GenreException("Name cannot be empty");
                } else if(value == "")
                {
                    throw new GenreException("Name cannot be empty");
                }
                _name = value;
            } 
        }

        public List<Movie> Movies { get; set; }

        private string _description;
        public string Description { get => _description; 
            set {
                if(value == null)
                {
                    throw new GenreException("Description Cannot Be Empty");
                }
                _description = value;
            } 
        }

        public Genre() {
            Movies = new List<Movie>();
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
