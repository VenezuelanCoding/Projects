using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class AccountRepoException : Exception
    {
        public AccountRepoException(string message) : base(message)
        {
        }

    }


    public class GenreRepoException : Exception
    {
        public GenreRepoException(string message) : base(message)
        {
        }

    }
    public class MemberRepoException : Exception
    {
        public MemberRepoException(string message) : base(message)
        {
        }

    }
    public class MovieRepoException : Exception
    {
        public MovieRepoException(string message) : base(message)
        {
        }

    }

}
