using AGData.Services.Dto;
using AGData.Services.Models;
using AutoMapper;

namespace AGData.Services.Bootstrap.MapProfiles;

public class DataModelProfile : Profile
{
    public DataModelProfile()
    {
        CreateMap<DataModel, DataModelDto>().ReverseMap();
    }
}
