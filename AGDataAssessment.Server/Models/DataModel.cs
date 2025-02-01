namespace AGData.Services.Models;

public class DataModel
{
    public DataModel(string name, string address)
    {
        if(string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name is required.", nameof(name));

        Name = name;
        Address = address;
    }

    public string? Name { get; set; }
    public string? Address { get; set; }
}
