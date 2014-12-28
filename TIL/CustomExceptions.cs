using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TIL.CustomExceptions
{
    public class DataAccessException : ApplicationException
    {
        public DataAccessException()
            : base()
        {

        }

        public DataAccessException(string message)
            : base(message)
        {

        }

        public DataAccessException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }

    public class BusinessLogicException : ApplicationException
    {
        public BusinessLogicException()
            : base()
        {

        }

        public BusinessLogicException(string message)
            : base(message)
        {

        }

        public BusinessLogicException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }

    public class PresentationLayerException : ApplicationException
    {
        public PresentationLayerException()
            : base()
        {

        }

        public PresentationLayerException(string message)
            : base(message)
        {

        }

        public PresentationLayerException(string message, Exception ex)
            : base(message, ex)
        {

        }
    }
}