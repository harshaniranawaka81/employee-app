using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeApi.Business.Filters;

namespace EmployeeApi.Business.FilterAttributes
{
    public class CustomerHeaderResultFilterAttribute : TypeFilterAttribute
    {
        public CustomerHeaderResultFilterAttribute() : base(typeof(CustomHeaderResultFilter))
        {
        }
    }
}
