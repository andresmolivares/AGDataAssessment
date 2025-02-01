using AGData.Services.Dto;
using AGData.Services.Models;
using AGData.Services.Services.Interfaces;
using AGDataAssessment.Server.Persistence.Interfaces;

namespace AGData.Services.Services;

public class DataService : IDataService
{
    private readonly IDataRepository _dataRepository;

    public DataService(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public DataModel SaveData(AddDataModelDto model)
    {
        _dataRepository.SaveData(model.Name, model.Address);
        return _dataRepository.GetData()!;
    }
}
