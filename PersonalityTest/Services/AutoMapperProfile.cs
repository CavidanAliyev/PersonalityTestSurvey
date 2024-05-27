using AutoMapper;
using PersonalityTest.Contracts.Response;
using PersonalityTest.Data.Models;

namespace PersonalityTest.Services;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Question, GetQuestionDTO>();
        CreateMap<Option, OptionDTO>();
    }
}
