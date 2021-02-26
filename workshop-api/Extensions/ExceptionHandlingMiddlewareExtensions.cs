using System.Net;
using BusinessLogic.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using workshop_api.Middlewares;

namespace workshop_api.Extensions
{
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseNativeGlobalExceptionErrorHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var exception = errorFeature.Error;

                    int httpStatusCode;
                    string messageToShow;

                    if (exception is BusinessLogicException httpException || exception is DatabaseException)
                    {
                        httpStatusCode = (int)HttpStatusCode.ServiceUnavailable;
                        messageToShow = exception.Message;
                    }
                    else
                    {
                        httpStatusCode = (int)HttpStatusCode.InternalServerError;
                        messageToShow = "The server occurs an unexpected error.";
                    }

                    var errorModel = new
                    {
                        status = httpStatusCode,
                        message = messageToShow
                    };

                    context.Response.StatusCode = (int)errorModel.status;
                    context.Response.ContentType = "application/json";
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(errorModel));
                });
            });

            return app;
        }

        public static IApplicationBuilder UseGlobalExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            return app;
        }
    }
}
