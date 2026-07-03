using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbdocumentsignature", Schema = "doc")]
public class DocumentSignature : BaseModel
{
    [Column("docsigid")]
    public int Id { get; init; }
    
    public DocumentSignature() {}
}

public class DocumentSignatureConfiguration : IEntityTypeConfiguration<DocumentSignature>
{
    public void Configure(EntityTypeBuilder<DocumentSignature> builder)
    {
        builder.HasKey(d => d.Id);
    }
}