using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbbrand", Schema = "pro")]
public class Brand : BaseModel
{
    [Column("brandid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    
    public Brand() {}
}

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        builder.HasKey(c => c.Id);
    }
}