using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class AccountException : Exception
    {
        public AccountException(string message) : base(message)
        {
        }
    }

    public class GenreException : Exception
    {
        public GenreException(string message) : base(message)
        {
        }
    }
    public class ActingRoleException : Exception
    {
        public ActingRoleException(string message) : base(message)
        {
        }
    }
    public class MemberException : Exception
    {
        public MemberException(string message) : base(message)
        {
        }
    }
    public class MovieException : Exception
    {
        public MovieException(string message) : base(message)
        {
        }
    }
    public class ProfileException : Exception
    {
        public ProfileException(string message) : base(message)
        {
        }
    }
}
