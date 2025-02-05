using System.ComponentModel.DataAnnotations;

namespace AGData.Services.Models;

public class DataDocument
{
    public DataDocument(string id, string name, string? address)
    {
        if(name.Length == 0)
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        Id = id;
        Name = name;
        Address = address;
    }

    public string Id { get; }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    public string? Address { get; set; }
}
