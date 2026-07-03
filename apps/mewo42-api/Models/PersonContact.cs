using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbpersoncontact", Schema = "uni")]
public class PersonContact : BaseModel
{
    [Column("percid")]
    public int Id { get; init; }
    [Column("perid")]
    public int PersonId { get; set; }
    [Column("Type")]
    public string Type { get; set; }
    [Column("value")]
    public string Value { get; set; }
    [Column("principal")]
    public bool Principal { get; set; }
    public Person Person { get; set; }
    
    public PersonContact() {}
}

public class PersonContactConfiguration : IEntityTypeConfiguration<PersonContact>
{
    public void Configure(EntityTypeBuilder<PersonContact> builder)
    {
        builder.HasKey(p => new { p.Id, p.PersonId });
        builder.Ignore(p => p.CompanyId);
    }
}