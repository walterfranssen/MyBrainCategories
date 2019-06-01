using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MyBrainCategories.Application.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBrainCategories.Api.Utils
{
    public class ExceptionMapperFilterAttribute : ActionFilterAttribute, IExceptionFilter
    {
        private static readonly List<Func<Exception, IActionResult>> Handlers = new List<Func<Exception, IActionResult>>();

        protected static void AddHandler<T>(Func<T, IActionResult> handler) where T : Exception
        {
            Handlers.Add(ex =>
            {
                return ex is T typed ? handler(typed) : null;
            });
        }

        public ExceptionMapperFilterAttribute()
        {
            RegisterHandlers();
        }

        protected virtual IActionResult OnUnhandledException(Exception ex)
        {
            return new ObjectResult(ex.Message) { StatusCode = 500};
        }

        //protected virtual IActionResult HandelNotFoundException(NotFoundException ex)
        //{
        //    return new ApiNotFoundResponse(ex.Message);
        //}

        //protected virtual IActionResult HandelForbiddenException(ForbiddenException ex)
        //{
        //    return new ApiForbiddenResponse(ex.Message);
        //}

        protected virtual IActionResult HandelValidationException(ValidationException ex)
        {
            return new ObjectResult(ex.Message) { StatusCode = 400 };
        }
        protected virtual IActionResult HandelValidationException(MyBrainValidationException ex)
        {
            return new ObjectResult(ex.ValidationErrors) { StatusCode = 400 };
        }
        //
        public void OnException(ExceptionContext context)
        {
            IActionResult result = null;

            foreach (var handler in Handlers)
            {
                result = handler(context.Exception);

                if (result != null)
                {
                    break;
                }
            }

            if (result != null)
            {
                context.Result = result;
            }
        }

        /// <summary>
        /// Default registers the Exception class to handle all unhandled exceptions. 
        /// In order to register other exceptions override this method and call base.RegisterHandlers(); as last.
        /// </summary>
        protected virtual void RegisterHandlers()
        {
            AddHandler<MyBrainValidationException>(HandelValidationException);
            AddHandler<ValidationException>(HandelValidationException);
            AddHandler<Exception>(OnUnhandledException);
        }
    }
}
