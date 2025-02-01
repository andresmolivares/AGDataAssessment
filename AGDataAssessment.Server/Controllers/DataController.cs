using AGData.Services.Dto;
using AGData.Services.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/data")]
public class DataController : ControllerBase
{
    private readonly IDataService _dataService;

    public DataController(IDataService dataService)
    {
        _dataService = dataService;
    }

    [HttpPost]
    public IActionResult PostData([FromBody] AddDataModelDto model)
    {
        if(string.IsNullOrEmpty(model.Name))
        {
            return BadRequest("Name is required for request.");
        }
        var newModel = _dataService.SaveData(model);
        return Ok(newModel);
    }
}