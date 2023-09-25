using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeApi.Business.Filters
{
    public class ExceptionHandlingFilter : IAsyncExceptionFilter
    {
        private readonly IModelMetadataProvider _modelMetadataProvider;
        public ExceptionHandlingFilter(
            IModelMetadataProvider modelMetadataProvider)
        {
            _modelMetadataProvider = modelMetadataProvider;
        }

        public async Task OnExceptionAsync(ExceptionContext context)
        {
            context.Result = new ContentResult
            {
                Content = context.Exception.ToString()
            };
        }
    }
}
