namespace EventPilotWeb.Domain;

public class Tag
{
    public Guid Id { get; set; }
    public required string KeyWord { get; set; }
    public long Count { get; set; }
    public ICollection<Post>? Posts { get; set; }
}