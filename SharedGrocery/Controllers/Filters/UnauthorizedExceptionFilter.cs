using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace SharedGrocery.Controllers.Filters
{
    public class UnauthorizedExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is InvalidJwtException)
            {
                context.Result = new UnauthorizedResult();
            }
        }
        
    }
}