using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbsetting", Schema = "sys")]
public class Setting : BaseModel
{
    [Column("settingid")]
    public int Id { get; init; }
    [Column("Name")]
    public string Name { get; set; }
    [Column("value")]
    public string Value { get; set; }
    [Column("moduleid")]
    public int ModuleId { get; set; }
    public Module Module { get; set; } = null;
    
    public Setting() {}
}

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.HasKey(s => s.Id);
        builder.HasOne(s => s.Module)
            .WithMany(m => m.Settings)
            .HasForeignKey(s => s.ModuleId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}