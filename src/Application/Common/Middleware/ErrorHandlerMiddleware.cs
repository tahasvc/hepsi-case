using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Common.Models;
using Core.DataAccess.Repositories;
using Core.Entities;

namespace Application.Common.Middleware
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private IExceptionRepository exceptionRepository;
        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, IExceptionRepository exceptionRepository)
        {
            try
            {
                this.exceptionRepository = exceptionRepository;
                await _next(httpContext);
                
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }
        private Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";
            Log(ex, context);

            if (ex is MissingMemberException || ex is KeyNotFoundException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            }

            return context.Response.WriteAsync(new ErrorHandlerDto()
            {
                StatusCode = context.Response.StatusCode,
                Message = ex.Message
            }.ToString());
        }

        private void Log(Exception exception, HttpContext context)
        {
            var exceptionInfo = new ExceptionInfo
            {
                Message = exception.Message,
                RequestPath = context.Request.Path,
                StackTrace = exception.StackTrace
            };

            exceptionRepository.AddAsync(exceptionInfo);
        }
    }
}
