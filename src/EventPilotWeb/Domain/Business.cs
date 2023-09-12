namespace EventPilotWeb.Domain;

public class Business
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required long Latitude { get; set; }
    public required long Longitude { get; set; }
    public required string Address { get; set; }
    public string? RUC { get; set; }
}