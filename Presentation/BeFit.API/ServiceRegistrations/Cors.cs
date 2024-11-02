namespace BeFit.API;

public static class Cors
{
    public static IServiceCollection AddCorsServices(IServiceCollection services)
    {

        return services;
    }
    public static WebApplication UseCorsServices(this WebApplication app)
    {
        app.UseCors("AllowAll");
        return app;
    }
}