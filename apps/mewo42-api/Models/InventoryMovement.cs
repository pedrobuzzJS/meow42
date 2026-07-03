using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbinventorymovement", Schema = "log")]
public class InventoryMovement : BaseModel
{
    [Column("invtmid")]
    public int Id { get; init; }
    
    public InventoryMovement() {}
}

public class InventoryMovementConfiguration : IEntityTypeConfiguration<InventoryMovement>
{
    public void Configure(EntityTypeBuilder<InventoryMovement> builder)
    {
        builder.HasKey(m => m.Id);
    }
}