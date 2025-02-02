using AGData.Services.Dto;
using AGData.Services.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    private readonly IDataService _dataService;
    private readonly IMapper _mapper;

    public DataController(IDataService dataService, IMapper mapper)
    {
        _dataService = dataService;
        _mapper = mapper;
    }

    [HttpPost]
    public IActionResult PostData([FromBody] AddDataModelDto addDto)
    {
        try
        {
            var model = _dataService.SaveData(addDto);
            return Ok(_mapper.Map<DataModelDto>(model));
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}