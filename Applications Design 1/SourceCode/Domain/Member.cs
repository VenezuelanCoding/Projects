
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Domain
{
    public class Member
    {
        private String _name;

        private DateTime _birthDate;

        private String _profilePicture;

        public MemberType Type { get; set; }

        public int Id { get; set; }

        private bool ValidName(string name)
        {
            if(name is null)
            {
                return false;
            }
            if (ContainsDomainSpecialChar(name)) {

                return false;
            }

            return true;

        }

        private bool ContainsDomainSpecialChar(string subdomain)
        {
            string specialChars = "\\|!#$%&/()=?»«@£§€{};'\"<>_,";
            foreach (char c in subdomain)
            {
                if (specialChars.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        public List<Movie> DirectMovies { get; set; }

        public string Name
        {
            get => _name;
            set
            {


                if (!ValidName(value))
                {
                    throw new MemberException("Name Not valid");
                }

                _name = value;

            }
        }

        public DateTime BirthDate { get => _birthDate; set {

                DateTime todayDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                if (value < todayDate)
                {
                    _birthDate = value;
                }
                else
                {
                    throw new MemberException("Not a valid  date");
                }

            } 
        }

        public string ProfilePicture
        {
            get => _profilePicture; set
            {

                if (value.Contains("."))
                { 
                    string format = value.Split('.').Last();
                    if (format.ToLower() == "jpg" || format.ToLower() == "png")
                    {
                        _profilePicture = value;
                    }
                    else
                    {
                        throw new MemberException("Profile picture file is not an image");

                    }
                }
                else
                {
                    throw new MemberException("Profile picture file is not an image");
                }
            }
        }

        public override string ToString()
        {
            return _name;
        }


        public Member() {
            DirectMovies = new List<Movie>();
        }
    }
}
