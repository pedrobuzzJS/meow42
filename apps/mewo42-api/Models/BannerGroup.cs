using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbbannergroup", Schema = "web")]
public class BannerGroup : BaseModel
{
    [Column("bangid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("status")]
    public int Status { get; set; }
    [Column("height")]
    public string Height { get; set; }
    [Column("width")]
    public string Width { get; set; }
    
    public BannerGroup() {}
}

public class BannerGroupConfiguration : IEntityTypeConfiguration<BannerGroup>
{
    public void Configure(EntityTypeBuilder<BannerGroup> builder)
    {
        builder.HasKey(b => b.Id);
    }
}