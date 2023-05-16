using CrossplatformHW.Server.Middlewares;

namespace CrossplatformHW.Server.Common.Extensions;

public static class ApplicationExtensions
{
    public static void UseExceptionManager(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionManager>();
    }
}