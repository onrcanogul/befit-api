namespace BeFit.API;

public static class Cors
{
    public static IServiceCollection AddCors(IServiceCollection services)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
        return services;
    }


    public static WebApplication UseCors(this WebApplication app)
    {
        app.UseCors("AllowAll");
        return app;
    }
}