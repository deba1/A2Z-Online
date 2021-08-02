using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BaseException : Exception
    {
        public BaseException(string message) : base(message)
        {
            this.Timestamp = DateTime.UtcNow;
        }

        public DateTime Timestamp { get; set; }
    }
}
