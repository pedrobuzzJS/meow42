using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbpermission", Schema = "adm")]
public class Permission : BaseModel
{
    [Column("permid")]
    public int Id { get; init; }
    [Column("name")]
    public string Nome { get; set; }
    public List<Role> Roles { get; } = [];
    
    public Permission() {}
}

public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
{
    public void Configure(EntityTypeBuilder<Permission> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Ignore(p => p.CompanyId);
        builder.Ignore(p => p.Metadata);
    }
}