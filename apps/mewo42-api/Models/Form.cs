using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbform", Schema = "sys")]
public class Form : BaseModel
{
    [Column("formid")]
    public int Id { get; init; }
    [Column("name")]
    public string? Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("fields")]
    public string Fields { get; set; }
}

public class FormConfiguration : IEntityTypeConfiguration<Form>
{
    public void Configure(EntityTypeBuilder<Form> builder)
    {
        builder.HasKey(f => f.Id);
    }
}