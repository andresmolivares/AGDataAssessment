using AGData.Services.Models;

namespace AGDataAssessment.Server.Persistence.Interfaces;

public interface IDataRepository
{
    void SaveData(string name, string? address);

    DataModel? GetData();
}
