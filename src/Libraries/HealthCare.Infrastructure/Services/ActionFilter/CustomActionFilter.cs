using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HealthCare.Infrastructure.Services.ActionFilter
{
    public class CustomActionFilter : IActionFilter
    {
        private readonly ILogger<CustomActionFilter> logger;

        public CustomActionFilter(ILogger<CustomActionFilter> logger)
        {
            this.logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }
    }
}
