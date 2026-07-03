using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbeventlocal", Schema = "evt")]
public class EventLocal : BaseModel
{
    [Column("evtlocalid")]
    public int Id { get; set; }
    [Column("evtid")]
    public int EventId { get; set; }
    public Event Event { get; set; }
    
    public EventLocal() {}
}

public class EventLocalConfiguration : IEntityTypeConfiguration<EventLocal>
{
    public void Configure(EntityTypeBuilder<EventLocal> builder)
    {
        builder.HasKey(p => new { p.Id, p.EventId });
    }
}