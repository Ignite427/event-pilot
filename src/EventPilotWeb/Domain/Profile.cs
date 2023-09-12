namespace EventPilotWeb.Domain;

public class Profile
{
    public Guid Id { get; set; }
    public string? Persentation { get; set; }

    public Guid OwnerId { get; set; }
    public required User Owner { get; set; }
}