using AGData.Services.Dto;
using AGData.Services.Models;
using AutoMapper;

namespace AGData.Services.Bootstrap.MapProfiles;

public class DataDocumentProfile : Profile
{
    public DataDocumentProfile()
    {
        CreateMap<DataDocument, DataDocumentDto>().ReverseMap();
        CreateMap<DataDocument, AddDataDocumentDto>().ReverseMap();
    }
}