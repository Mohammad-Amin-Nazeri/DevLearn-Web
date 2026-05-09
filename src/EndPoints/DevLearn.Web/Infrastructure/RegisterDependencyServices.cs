using Common.EventBus.Abstractions;
using Common.EventBus.RabbitMQ;
using DevLearn.Web.Infrastructure.RazorUtils;
using DevLearn.Web.Infrastructure.Services;
using DevLearn.Web.Infrastructure.JwtUtil;

namespace DevLearn.Web.Infrastructure;

public static class RegisterDependencyServices
{
    public static IServiceCollection RegisterWebDependencies(this IServiceCollection services)
    {
        services.AddHttpContextAccessor();

        services.AddSingleton<IEventBus, EventBusRabbitMQ>();
        services.AddTransient<IRenderViewToString, RenderViewToString>();
        services.AddAutoMapper(typeof(RegisterDependencyServices).Assembly);
        services.AddScoped<IHomePageService, HomePageService>();

        return services;
    }
}