using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class ExceptionInfo : BaseEntity
    {
        public string Message { get; set; }
        public string StackTrace { get; set; }
        public string RequestPath { get; set; }
    }
}
