using PersonalityTest.Services.Abstracts;
using PersonalityTest.Services.Concretes;

namespace PersonalityTest.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IPersonalityTestService, PersonalityTestService>();
    }
}
