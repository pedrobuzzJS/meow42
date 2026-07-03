using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbdocumenttemplate", Schema = "doc")]
public class DocumentTemplate : BaseModel
{
    [Column("doctid")]
    public int Id { get; init; }
    
    public DocumentTemplate() {}
}

public class DocumentTemplateConfiguration : IEntityTypeConfiguration<DocumentTemplate>
{
    public void Configure(EntityTypeBuilder<DocumentTemplate> builder)
    {
        builder.HasKey(t => t.Id);
    }
}