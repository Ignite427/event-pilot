using EventPilotWeb.Domain;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Xml.Linq;

namespace EventPilotWeb.Infraestructure;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {

    }

    public DbSet<Post> Posts => Set<Post>();
    public DbSet<User> Users => Set<User>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<Profile> Profiles => Set<Profile>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");

        modelBuilder.Entity<User>()
                    .HasDiscriminator<string>("UserType")
                    .HasValue<User>("User")
                    .HasValue<Organizer>("Organizer");

        modelBuilder.Entity<User>()
                    .HasMany(u => u.Subscribers) // Un usuario tiene muchos suscriptores
                    .WithMany() // Configuración de una relación muchos a muchos
                    .UsingEntity(j => j.ToTable("UsersSubscribers"));

        modelBuilder.Entity<User>()
                    .HasMany(a => a.Posts)
                    .WithOne(b => b.Owner)
                    .HasForeignKey(b => b.OwnerId)
                    .OnDelete(DeleteBehavior.NoAction);

        modelBuilder.Entity<Post>()
                    .HasMany(a => a.Comments)
                    .WithOne(b => b.Post)
                    .HasForeignKey(b => b.PostId);

        modelBuilder.Entity<Post>()
                    .HasMany(t => t.Tags)
                    .WithMany(t => t.Posts)
                    .UsingEntity(j => j.ToTable("PostsTags"));

        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}