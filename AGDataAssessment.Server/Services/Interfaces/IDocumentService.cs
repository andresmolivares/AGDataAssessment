using AGData.Services.Dto;
using AGData.Services.Models;

namespace AGData.Services.Services.Interfaces;

public interface IDocumentService
{
    DataDocument AddDocument(AddDataDocumentDto dto);

    DataDocument UpdateDocument(UpdateDataDocumentDto dto);

    void DeleteDocument(string id);

    IEnumerable<DataDocument> GetDocuments();
}
