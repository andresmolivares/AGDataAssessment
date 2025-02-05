using AGData.Services.Dto;
using AGData.Services.Models;
using AGData.Services.Services.Interfaces;
using AGDataAssessment.Server.Persistence.Interfaces;

namespace AGData.Services.Services;

public class DocumentService : IDocumentService
{
    private readonly IDocumentRepository _documentRepository;

    public DocumentService(IDocumentRepository documentRepository)
    {
        _documentRepository = documentRepository;
    }

    public DataDocument AddDocument(AddDataDocumentDto dto)
    {
        var id = Guid.NewGuid().ToString();
        _documentRepository.AddDocument(new DataDocument(id, dto.Name, dto.Address));
        return _documentRepository.GetDocument(id)!;
    }

    public DataDocument UpdateDocument(UpdateDataDocumentDto dto)
    {
        var document = _documentRepository.GetDocument(dto.Id);

        if(document == null)
        {
            throw new Exception("Document not found");
        }

        document.Name = dto.Name;
        document.Address = dto.Address;
        _documentRepository.UpdateDocument(document);
        return document;
    }

    public void DeleteDocument(string id)
    {
        _documentRepository.DeleteDocument(id);
    }

    public IEnumerable<DataDocument> GetDocuments()
    { 
        return _documentRepository.GetDocuments().ToList();
    }
}
