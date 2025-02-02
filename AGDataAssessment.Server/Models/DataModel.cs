using System.ComponentModel.DataAnnotations;

namespace AGData.Services.Models;

public class DataModel
{
    public DataModel(string name, string? address)
    {
        if(name.Length == 0)
            throw new ArgumentException("Name cannot be empty.", nameof(name));

        Name = name;
        Address = address;
    }

    [Required(ErrorMessage = "Name is required.")]
    public string Name { get; set; }
    public string? Address { get; set; }
}
