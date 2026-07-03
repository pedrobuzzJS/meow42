using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbwebhook", Schema = "itg")]
public class Webhook : BaseModel
{
    [Column("wbhid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("uri")]
    public string Uri { get; set; }
    [Column("type")]
    public int Type { get; set; }
    [Column("default")]
    public bool Default { get; set; }
    [Column("mapper")]
    public bool Mapper { get; set; }
    [Column("payload")]
    public string Payload { get; set; }
    [Column("listening")]
    public bool Listening { get; set; }
    
    public Webhook() {}
}

public class WebhookConfiguration : IEntityTypeConfiguration<Webhook>
{
    public void Configure(EntityTypeBuilder<Webhook> builder)
    {
        builder.HasKey(w => w.Id);
    }
}