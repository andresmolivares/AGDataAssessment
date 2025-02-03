using System.ComponentModel.DataAnnotations;

namespace AGData.Services.Dto;

public class AddDataDocumentDto
{
    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; } // Use required modifier in .NET 9.0
    public string? Address { get; set; }
}
