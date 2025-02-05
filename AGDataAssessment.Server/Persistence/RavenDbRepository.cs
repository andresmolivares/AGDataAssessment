using AGData.Services.Models;
using AGDataAssessment.Server.Persistence.Interfaces;
using Raven.Client.Documents;

namespace AGDataAssessment.Server.Persistence;

public class RavenDbRepository : IDocumentRepository
{
    private readonly IDocumentStore _store;

    public RavenDbRepository(IDocumentStore store)
    {
        _store = store;
    }

    public void AddDocument(DataDocument model)
    {
        using var session = _store.OpenSession();
        session.Store(model);
        session.SaveChanges();
    }

    public void UpdateDocument(DataDocument model)
    {
        using var session = _store.OpenSession();
        session.Store(model);
        session.SaveChanges();
    }

    public DataDocument GetDocument(string id)
    {
        using var session = _store.OpenSession();
        return session.Load<DataDocument>(id);
    }

    public void DeleteDocument(string id)
    {
        using var session = _store.OpenSession();
        var document = session.Load<DataDocument>(id);
        session.Delete(document);
        session.SaveChanges();
    }

    public IEnumerable<DataDocument> GetDocuments()
    {
        using var session = _store.OpenSession();
        return session.Query<DataDocument>().ToList();
    }
}
