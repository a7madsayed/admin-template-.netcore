namespace CompanyName.ProductName.Admin.Extensions.Exceptions
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Logging;

    public static class AspNetCoreGlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder UseAspNetCoreExceptionHandler(this IApplicationBuilder app)
        {
            var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

            return app.UseExceptionHandler(HandleException(loggerFactory));
        }

        public static Action<IApplicationBuilder> HandleException(ILoggerFactory loggerFactory) => appBuilder =>
                {
                    appBuilder.Run(async context =>
                    {
                        var path = context.Response.HttpContext.Request.Path;
                        var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                        if (exceptionHandlerFeature != null)
                        {
                            var logger = loggerFactory.CreateLogger("Serilog Global exception logger");
                            logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                        }

                        if (path.HasValue && path.Value.Contains("api", StringComparison.InvariantCulture))
                        {
                            context.Response.StatusCode = 500;
                            await context.Response.WriteAsync("An unexpected fault happened. Try again later.");
                            return;
                        }
                        else
                        {
                            context.Response.Redirect($"/Error/Status/{context.Response.StatusCode}");
                        }
                    });
                };
    }
}
