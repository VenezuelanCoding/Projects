using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Implementations
{
    public class PermissionDeniedException : Exception
    {
        public PermissionDeniedException(string message) : base(message)
        {
        }
    }
    public class AccountLogicException : Exception
    {
        public AccountLogicException(string message) : base(message)
        {
        }
    }

    public class SortLogicException : Exception
    {
        public SortLogicException(string message) : base(message)
        {
        }
    }

    public class SearchLogicException : Exception
    {
        public SearchLogicException(string message) : base(message)
        {
        }
    }

}


