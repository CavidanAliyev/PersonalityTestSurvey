using PersonalityTest.Services;
using AutoMapper;

namespace PersonalityTest.Extensions;

public static class AutoMapperExtension
{
    public static void AddAutoMapperService(this IServiceCollection services)
    {
        services.AddSingleton(provider => new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new AutoMapperProfile());
        })
        .CreateMapper());
    }
}
