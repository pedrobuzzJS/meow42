using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbticketbatch", Schema = "tkt")]
public class TicketBatch : BaseModel
{
    [Column("tktbid")]
    public int Id { get; init; }
    [Column("tktid")]
    public int TicketId { get; set; }
    public Ticket Ticket { get; set; }
}

public class TicketBatchConfiguraction : IEntityTypeConfiguration<TicketBatch>
{
    public void Configure(EntityTypeBuilder<TicketBatch> builder)
    {
        builder.HasKey(p => new { p.Id, p.TicketId });
    }
}