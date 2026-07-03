using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbproduct", Schema = "pro")]
public class Product : BaseModel
{
    [Column("productid")]
    public int Id { get; init; }
    
    public Product() {}
}

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.ToTable("tbproduct", "pro");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("productid");
    }
}