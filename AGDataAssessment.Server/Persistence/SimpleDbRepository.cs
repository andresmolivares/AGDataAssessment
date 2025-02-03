using AGData.Services.Models;
using AGDataAssessment.Server.Persistence.Interfaces;

namespace AGDataAssessment.Server.Persistence;

public class SimpleDbRepository : IDocumentRepository
{
    private readonly Dictionary<string, DataDocument> _store;

    public SimpleDbRepository()
    {
        _store = new();
    }

    public void AddDocument(DataDocument model)
    {
        _store.Add(model.Id, model);
    }

    public void UpdateDocument(DataDocument model)
    {
        if(_store.ContainsKey(model.Id))
        {
            _store[model.Id] = model;
        }
    }

    public DataDocument? GetDocument(string id)
    {
        return _store.GetValueOrDefault(id);
    }

    public void DeleteDocument(string id)
    {
        _store.Remove(id);
    }

    public IQueryable<DataDocument> GetDocuments()
    {
        return _store.Values.AsQueryable();
    }
}