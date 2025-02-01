using AGData.Services.Dto;
using AGData.Services.Models;

namespace AGData.Services.Services.Interfaces;

public interface IDataService
{
    DataModel SaveData(AddDataModelDto model);
}
