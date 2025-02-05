using AGData.Services.Models;

namespace AGDataAssessment.Server.Persistence.Interfaces;

public interface IDocumentRepository
{
    void AddDocument(DataDocument dataModel);

    void UpdateDocument(DataDocument dataModel);

    DataDocument? GetDocument(string id);

    void DeleteDocument(string id);

    IEnumerable<DataDocument> GetDocuments();
}
