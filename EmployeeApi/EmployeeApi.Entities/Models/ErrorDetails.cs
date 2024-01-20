using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApp.Entities.Models
{
    public class ErrorDetails 
    {
        public int Code { get; set; }
        public string? Message { get; set; }
    }
}
