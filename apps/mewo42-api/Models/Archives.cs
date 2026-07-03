using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbfile", Schema = "sys")]
public class Archives : BaseModel
{
    [Column("fileid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("filename")]
    public string FileName { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("directory")]
    public string Directory { get; set; }
    [Column("mimetype")]
    public string MimeType { get; set; }
    [Column("size")]
    public decimal Size { get; set; }
    [Column("virtual")]
    public bool Virtual { get; set; }
    [Column("url")]
    public string Url { get; set; }
    
    public Archives() {}
}

public class ArchivesConfiguration : IEntityTypeConfiguration<Archives>
{
    public void Configure(EntityTypeBuilder<Archives> builder)
    {
        builder.HasKey(x => x.Id);
    }
}