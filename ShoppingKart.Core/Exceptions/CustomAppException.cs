using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingKart.Core.Exceptions
{
    public class CustomAppException: Exception
    {
        public CustomAppException(string message): base(message)
        {
            
        }
    }
}
