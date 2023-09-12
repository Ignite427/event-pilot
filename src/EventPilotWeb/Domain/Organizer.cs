namespace EventPilotWeb.Domain;

public class Organizer : User
{
    public required Business Business { get; set; }
}