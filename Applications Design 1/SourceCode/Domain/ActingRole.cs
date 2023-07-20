
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ActingRole
    {

        private String _name;

        private Member _member;


        public Movie ActingMovie { get; set; }

        public int Id { get; set; }

        public string Name
        {
            get => _name;
            set
            {
                if (!ValidName(value))
                {
                    throw new ActingRoleException("Name Not valid");
                }

                _name = value;

            }
        }

        private bool ValidName(string name)
        {

            if (name is null)
            {
                return false;
            }
            if (ContainsDomainSpecialChar(name))
            {

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

        public Member Member { get { return _member; } set {
                if (value != null)
                {
                    if ((int)value.Type != 1 )
                    {
                        _member = value;
                    }
                    else
                    {
                        throw new ActingRoleException("Member Not valid");
                    }
                }
                else
                {
                    throw new ActingRoleException("Member Not valid");
                }
            } 
        }

        public override string ToString()
        {
            return _name+"-"+Member.Name;
        }

    }
}
