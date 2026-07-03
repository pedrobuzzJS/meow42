using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbeventdate", Schema = "evt")]
public class EventDate : BaseModel
{
    [Column("evtdateid")]
    public int Id { get; set; }
    [Column("evtid")]
    public int EventId { get; set; }
    public Event Event { get; set; }
    
    public EventDate() {}
}

public class EventDateConfiguration : IEntityTypeConfiguration<EventDate>
{
    public void Configure(EntityTypeBuilder<EventDate> builder)
    {
        builder.HasKey(p => new { p.Id, p.EventId });
    }
}