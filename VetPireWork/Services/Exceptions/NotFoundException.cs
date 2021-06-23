using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VetPireWork.Services.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string msg) : base(msg)
        {

        }
    }
}
