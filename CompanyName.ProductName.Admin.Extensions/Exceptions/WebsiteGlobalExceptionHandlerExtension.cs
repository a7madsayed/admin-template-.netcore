namespace CompanyName.ProductName.Admin.Extensions.Exceptions
{
    using System;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.Extensions.Logging;

    public static class WebsiteGlobalExceptionHandlerExtension
    {
        public static IApplicationBuilder UseWebsiteExceptionHandler(this IApplicationBuilder app)
        {
            var loggerFactory = app.ApplicationServices.GetService(typeof(ILoggerFactory)) as ILoggerFactory;

            return app.UseExceptionHandler(HandleException(loggerFactory));
        }

        public static Action<IApplicationBuilder> HandleException(ILoggerFactory loggerFactory) => appBuilder =>
        {
#pragma warning disable CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
            appBuilder.Run(async context =>
#pragma warning restore CS1998 // This async method lacks 'await' operators and will run synchronously. Consider using the 'await' operator to await non-blocking API calls, or 'await Task.Run(...)' to do CPU-bound work on a background thread.
            {
                var exceptionHandlerFeature = context.Features.Get<IExceptionHandlerFeature>();

                if (exceptionHandlerFeature != null)
                {
                    var logger = loggerFactory.CreateLogger("Serilog Global exception logger");
                    logger.LogError(500, exceptionHandlerFeature.Error, exceptionHandlerFeature.Error.Message);
                }

                context.Response.Redirect($"/Error/Status/{context.Response.StatusCode}");
            });
        };
    }
}
