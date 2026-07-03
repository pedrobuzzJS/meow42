using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbpage", Schema = "web")]
public class Page : BaseModel
{
    [Column("pgid")]
    public int Id { get; init; }
    [Column("title")]
    public string Title { get; set; }
    [Column("slug")]
    public string Slug { get; set; }
    [Column("active")]
    public bool Active { get; set; }
    [Column("mobile")]
    public bool Mobile { get; set; }
    [Column("type")]
    public int Type { get; set; }
    [Column("widgets")]
    public string Widgets { get; set; }
    [Column("redirect")]
    public string Redirect { get; set; }
    [Column("htmlkeywords")]
    public string HtmlKeywords { get; set; }
    [Column("htmldescription")]
    public string HtmlDescription { get; set; }
    
    public Page() {}
}

public class PageConfiguration : IEntityTypeConfiguration<Page>
{
    public void Configure(EntityTypeBuilder<Page> builder)
    {
        builder.HasKey(p => p.Id);
    }
}