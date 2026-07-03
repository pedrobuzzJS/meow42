using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbevent", Schema = "evt")]
public class Event : BaseModel
{
    [Column("evtid")]
    public int Id { get; init; }
    [Column("title")]
    public string Title { get; set; }
    [Column("description")]
    public string Description { get; set; }
    public ICollection<EventDate> EventDates { get; set; } = new List<EventDate>();
    public ICollection<EventLocal> EventLocals { get; set; } = new List<EventLocal>();
    
    public Event() {}
}

public class EventConfiguration : IEntityTypeConfiguration<Event>
{
    public void Configure(EntityTypeBuilder<Event> builder)
    {
        builder.HasKey(e => e.Id);
    }
}