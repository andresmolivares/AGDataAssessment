using AGData.Services.Dto;
using AGData.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/document/query")]
public class DocumentQueryController: ControllerBase
{
    private readonly IDocumentService _documentService;
    private readonly IMapper _mapper;

    public DocumentQueryController(IDocumentService documentService, IMapper mapper)
    {
        _documentService = documentService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDocuments()
    {
        var results = _documentService.GetDocuments();
        return Ok(_mapper.Map<IEnumerable<DataDocumentDto>>(results));
    }
}