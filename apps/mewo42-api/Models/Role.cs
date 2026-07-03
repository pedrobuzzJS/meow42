using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbrole", Schema = "adm")]
public class Role : BaseModel
{
    [Column("roleid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    public List<Permission> Permissions { get; } = [];
    
    public Role() {}
}

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasKey(r => r.Id);
        builder.Ignore(r => r.CompanyId);
        builder.Ignore(r => r.Metadata);
    }
}