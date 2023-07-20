
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain
{
    public class Account
    {

        protected const int MaxProfiles = 4;

        private string _email;

        private string _username;

        private string _password;

        public int Id { get; set; }
        public string Email
        {


            get => _email;


            set
            {

                if (!EmailIsValid(value))
                {
                    throw new AccountException("Email not valid");
                }
                _email = value;

            }


        }

        private bool EmailIsValid(string email)
        {

            if (email is null)
            {
                return false;
            }

            string[] parts = email.Split('@');
            if (parts.Length != 2)
            {
                return false;
            }
            string[] subdomains = parts[1].Split('.');
            if (subdomains.Length < 2)
            {
                return false;
            }
            foreach (string subdomain in subdomains)
            {

                //subdomain cant contain special char, except dot. (".")
                if (ContainsDomainSpecialChar(subdomain))
                {
                    return false;
                }
                //Possible double dot ("aaa..com")
                if (subdomain.Length < 1)
                {
                    return false;
                }
            }
            //last subdomain must be at least 2 chars long
            if (subdomains.Last().Length < 2)
            {
                return false;
            }

            //check username
            if (ContainsSpecialChar(parts[0]) || parts[0].Length == 0 || parts[0] is null)
            {
                return false;
            }
            return true;
        }

        private bool ContainsSpecialChar(string username)
        {
            string specialChars = "\\|!#$%&/()=?»«@£§€{};'\"<>,";
            foreach (char c in username)
            {
                if (specialChars.Contains(c))
                {
                    return true;
                }
            }
            return false;
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
        public string UserName
        {
            get => _username;
            set
            {


                if (!ValidUsername(value))
                {
                    throw new AccountException("Username Not valid");
                }

                _username = value;

            }
        }

        private bool ValidUsername(string username)
        {

            if (username is null)
            {
                return false;
            }

            if (username.Length < 10 || username.Length > 20)
            {
                return false;
            }


            if (!username.All(char.IsLetterOrDigit))
            {
                return false;
            }

            return true;

        }

        public string Password
        {
            get => _password;
            set
            {

                if (!ValidPassword(value))
                {
                    throw new AccountException("Password not valid");
                }

                _password = value;
            }
        }

        private bool ValidPassword(string password)
        {
            return !(password.Length < 10 || password.Length > 30);

        }

        public bool isAdmin { get; set; }

        public List<Profile> Profiles { get; set; }


        public void RemoveProfile(string alias) {

            Profile prof = SearchProfile(alias);

            if (prof == null)
            {
                throw new AccountException("Profile does not exist");
            }
            else {
                Profiles.Remove(prof);
            }
        }


        public Profile SearchProfile(string alias)
        {
            return this.Profiles.Where(x => x.Alias == alias).FirstOrDefault();
        }
        public void AddProfile(Profile profile)
        {
            if (SearchProfile(profile.Alias) != null)
            {
                throw new AccountException("Duplicated profile error");
            }

            if (FirstProfile(profile))
            {
                profile.IsOwner = true;
                this.Profiles.Add(profile);
            }
            else
            {
                if (LimitExceded(Profiles))
                {
                    throw new AccountException("Error, Profile limit reached");
                }
                else
                {
                    profile.IsOwner = false;
                    this.Profiles.Add(profile);

                }
            }

        }

        private bool LimitExceded(List<Profile> Profiles)
        {
            if (this.Profiles.Count is Account.MaxProfiles)
            {
                return true;
            }
            return false;
        }

        private bool FirstProfile(Profile profile)
        {
            if (this.Profiles.Count < 1)
            {
                return true;
            }
            return false;
        }




        public Account()
        {
            Profiles = new List<Profile>();
        }

        public override string ToString()
        {
            return _username;
        }
    }
}
