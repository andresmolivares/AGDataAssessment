using AGData.Services.Models;

namespace AGDataAssessment.Server.Persistence.Interfaces;

public class DataRepository : IDataRepository
{
    private DataModel? storedModel;
    const string EmptyAddress = "Empty";

    public void SaveData(string name, string? address)
    {
        var cleanAddress = string.IsNullOrWhiteSpace(address) ? EmptyAddress : address;
        var dataModel = new DataModel(name, cleanAddress);
        storedModel = dataModel;
    }

    public DataModel? GetData()
    {
        return storedModel;
    }
}
