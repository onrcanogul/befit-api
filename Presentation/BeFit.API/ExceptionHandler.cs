namespace BeFit.API;

public static class ExceptionHandler
{
    public static IServiceCollection AddExceptionHandler(this IServiceCollection services)
    {
        services.AddExceptionHandler<Infrastructure.Extensions.ExceptionHandler>();
        return services;
    }

    public static WebApplication UseExceptionHandler(this WebApplication app)
    {
        app.UseExceptionHandler(options => { });
        return app;
    }
}