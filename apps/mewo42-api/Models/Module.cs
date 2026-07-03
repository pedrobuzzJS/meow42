using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbmodule", Schema = "sys")]
public class Module : BaseModel
{
    [Column("moduleid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    public ICollection<Setting> Settings { get; } = new List<Setting>();
    
    public Module() {}
}

public class ModuleConfiguration : IEntityTypeConfiguration<Module>
{
    public void Configure(EntityTypeBuilder<Module> builder)
    {
        builder.HasKey(m => m.Id);
    }
}