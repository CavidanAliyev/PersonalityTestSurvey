using PersonalityTest.Infrastructure.Options;

namespace PersonalityTest.Extensions;

public static class OptionsExtension
{
    public static void AddOptionsService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MockServerOptions>(
            configuration.GetSection(key: nameof(MockServerOptions)));
    }
}
