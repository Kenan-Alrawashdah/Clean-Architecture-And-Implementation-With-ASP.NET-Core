using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Exceptions
{
    public class CustomExceptions: Exception
    {
        public List<string> ErrorMessages { get; set; }

        public CustomExceptions(string message, List<string> errorsMessages): base(message) => ErrorMessages = errorsMessages;
    }
}
