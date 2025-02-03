using AGData.Services.Dto;
using AGData.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/document")]
public class  DocumentController : ControllerBase
{
    private readonly IDocumentService _documentService;
    private readonly IMapper _mapper;

    public DocumentController(IDocumentService documentService, IMapper mapper)
    {
        _documentService = documentService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostDocument([FromBody] AddDataDocumentDto addDto)
    {
        try
        {
            var model = _documentService.AddDocument(addDto);
            return Ok(_mapper.Map<DataDocumentDto>(model));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    public IActionResult PutDocument([FromBody] UpdateDataDocumentDto updateDto)
    {
        try
        {
            var model = _documentService.UpdateDocument(updateDto);
            return Ok(_mapper.Map<DataDocumentDto>(model));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDocument(string id)
    {
        try
        {
            _documentService.DeleteDocument(id);
            return Ok();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
