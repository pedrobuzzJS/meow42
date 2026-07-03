using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbcompany", Schema = "uni")]
public class Company : BaseModel
{
    [Column("companyid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("domain")]
    public string? Domain { get; set; }
    [Column("subdomain")]
    public string? SubDomain { get; set; }
    [Column("status")]
    public int Status { get; set; }
    [Column("pln")]
    public string Plan { get; set; }
    
    public Company() {}
}

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Ignore(c => c.CompanyId);
    }
}