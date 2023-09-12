namespace EventPilotWeb.Domain;

public class Comment
{
    public Guid Id { get; set; }
    public required string Descripcion { get; set; }
    public int Up { get; set; }



    public Guid PostId { get; set; }
    public required Post Post { get; set; }

    public Guid OwnerId { get; set; }
    public required User Owner { get; set; }
}