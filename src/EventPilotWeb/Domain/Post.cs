namespace EventPilotWeb.Domain;

public class Post
{
    public Guid Id { get; set; }
    public required string Title { get; set; }
    public required string PathPhoto { get; set; }
    public long Latitude { get; set; }
    public long Longitude { get; set; }
    public required string Address { get; set; }
    public long Up { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime ExpirationDate { get; set; }
    public bool SoftDelete { get; set; }


    public ICollection<Comment>? Comments { get; set; }
    public ICollection<Tag>? Tags { get; set; }

    public Guid OwnerId { get; set; }
    public required User Owner { get; set; }
}