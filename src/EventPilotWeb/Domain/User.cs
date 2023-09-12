namespace EventPilotWeb.Domain;

public class User
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? WhatsappNro { get; set; }
    public string? WhatsappUrl { get { return $"https://wa.me/+51{WhatsappNro}"; } }

    public ICollection<Post>? Posts { get; set; }
    public ICollection<User>? Subscribers { get; set; }
}