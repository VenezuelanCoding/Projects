using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Score
    {

        public int Id { get; set ;  }

        public int Points{ get ; set;  }

        public Genre Genre { get; set; }

        public Score() {
            this.Points = 0;
        }

        public Score(Genre aGenre) {
            this.Genre = aGenre;
        }
    }
}
