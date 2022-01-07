using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class ErrorHandlerDto : BaseDto
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
