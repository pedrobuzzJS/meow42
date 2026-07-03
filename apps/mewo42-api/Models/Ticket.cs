using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbticket", Schema = "tkt")]
public class Ticket : BaseModel
{
    [Column("tktid")]
    public int Id { get; init; }
    public ICollection<TicketBatch> TicketBatchs { get; } = new List<TicketBatch>();
}

public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
{
    public void Configure(EntityTypeBuilder<Ticket> builder)
    {
        builder.HasKey(t => t.Id);
    }
}