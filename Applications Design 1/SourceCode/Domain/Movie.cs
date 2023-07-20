
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Movie
    {

        private int id;

        private List<Genre> _subGenres = new List<Genre>();


        private string _poster;

        private string _description;

        private List<Movie> _relatedMovies = new List<Movie>();


        private List<Member> _directors = new List<Member>();


        public List<Profile> WatchedBy { get; set; }

        public List<Profile> SuperlikedBy { get; set; }
        public List<Profile> LikedBy { get; set; }
        public List<Profile> DislikedBy { get; set; }

        private string _name;

        public int Id { get { return id; } set { id = value; } }
        public string Name
        {
            get => _name;
            set
            {
                if (value is null)
                {
                    throw new ArgumentNullException();
                }
                else if (value.Length == 0)
                {
                    throw new MovieException("The name cannot be empty");
                }
                _name = value;

            }
        }

        public List<Genre> SubGenres { get => _subGenres; set
            {
                if (value != null) {
                    _subGenres = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            } }




        public void AddGenreToSubgenres(Genre aSecondGenre)
        {
            if (this.PrimaryGenre != null)
            {


                if (!GenreIsRepeatead(aSecondGenre))
                {
                    if (aSecondGenre.Name == this.PrimaryGenre.Name)
                    {
                        throw new MovieException("Secondary Genre cannot be the same as the Primary");

                    }
                    else
                    {
                        SubGenres.Add(aSecondGenre);
                    }
                }
                else
                {
                    throw new MovieException("Second Genre already present");
                }
            }
            else
            {
                throw new MovieException("Primary cannot be empty");
            }

        }

        private bool GenreIsRepeatead(Genre aSecondGenre)
        {
            bool result = false;

            foreach (Genre genre in this.SubGenres)
            {
                if (genre.Name == aSecondGenre.Name)

                {
                    result = true;
                }
            }

            return result;

        }


        public Genre PrimaryGenre { get; set; }


        public string Poster
        {
            get => _poster; set
            {

                if (value.Contains("."))
                {


                    string format = value.Split('.').Last();
                    if (format.ToLower() == "jpg" || format.ToLower() == "png")
                    {
                        _poster = value;
                    }
                    else
                    {
                        throw new MovieException("Poster file is not an image");

                    }
                }
                else
                {
                    throw new MovieException("Poster file is not an image");
                }
            }
        }
        public string Description { get => _description; set
            {
                if (value != null)
                {
                    _description = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public bool IsPG { get; set; }
        public bool IsSponsored { get; set; }
        public DateTime ReleaseDate { get; set; }

        public List<Movie> RelatedMovies { get => _relatedMovies; set {
                if (value != null)
                {
                    _relatedMovies = value;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }

        }

        public void AddMovieToRelatedMovies(Movie aMovie)
        {
            if (aMovie != null)
            {
                if (!this.RepeatedMovie(aMovie)) {
                    if (this.id != aMovie.id)
                    {
                        this.RelatedMovies.Add(aMovie);
                    }
                    else
                    {
                        throw new MovieException("Movie cannot relate to itself");
                    }

                }
                else
                {
                    throw new MovieException("Movie already Related");
                }

            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        private bool RepeatedMovie(Movie aMovie)
        {
            bool result = false;
            foreach (Movie mov in this.RelatedMovies)
            {
                if (mov.id == aMovie.id)
                {
                    result = true;
                }
            }

            return result;
        }



        public string GetMovieInfo()
        {
            string text = "";
            text += "Name: " + this.Name;
            if (this.IsPG)
            {
                text += ", IsPG: Yes";
            }
            else
            {
                text += ", IsPG: No";
            }
            if (this.IsSponsored)
            {
                text += ", IsSponsored: Yes";
            }
            else
            {
                text += ", IsSponsored: No";
            }
            text += ", Release Date: " + this.ReleaseDate.ToString();
            text += ", Primary Genre: " + this.PrimaryGenre.Name;
            if (SubGenres.Count > 0)
            {
                text += ", SubGenres: ";
                foreach (Genre sub in SubGenres)
                {
                    text += sub.Name + " ";
                }


            }
            if (RelatedMovies.Count > 0) {
                text += ", Related Movies: ";
                foreach (Movie mov in RelatedMovies)
                {
                    text += mov.Name + " ";
                }
            }

            return text;
        }

        public List<Movie> GetRelatedPGMovies() {
            return RelatedMovies.Where(x => x.IsPG).ToList();

        }
        public override string ToString()
        {
            return _name;
        }

        public Member GetDirectorById(int id) {
            return _directors.FirstOrDefault(x => x.Id == id);
        }

        public List<Member> Directors { get => _directors; set => _directors = value; }
        public void AddDirectors(Member director) {

            if (director == null)
            {
                throw new MovieException("Director is Invalid or is not a Director");
            }
            if ((int)director.Type == 0)
            {
                throw new MovieException("Director is Invalid or is not a Director");

            }
            if (GetDirectorById(director.Id) != null){
                throw new MovieException("Director already added");
            }
            Directors.Add(director);
        }

        public List<ActingRole> ActingRoles { get; set; }


        public ActingRole GetActingRoleByName(string name) {
            return ActingRoles.FirstOrDefault(x => x.Name == name);
        }

        public void AddActingRoles(ActingRole role) {
            if (role == null) {
                throw new MovieException("Role cannot be null");


            }
            if (GetActingRoleByName(role.Name) != null) {
                throw new MovieException("Role already taken by antoher actor");
            }

            ActingRoles.Add(role);
        }

        public Movie()
        {
            WatchedBy = new List<Profile>();
            DislikedBy = new List<Profile>();
            LikedBy = new List<Profile>();
            SuperlikedBy = new List<Profile>();
            ActingRoles = new List<ActingRole>();
        }

    }
}

