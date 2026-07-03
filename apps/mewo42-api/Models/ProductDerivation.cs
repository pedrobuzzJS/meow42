using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbproductderivation", Schema = "pro")]
public class ProductDerivation : BaseModel
{
    [Column("prodderivid")]
    public int Id { get; init; }
    
    public ProductDerivation() {}
}

public class ProductDerivationConfiguration : IEntityTypeConfiguration<ProductDerivation>
{
    public void Configure(EntityTypeBuilder<ProductDerivation> builder)
    {
        builder.HasKey(p => p.Id);
    }
}