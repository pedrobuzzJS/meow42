using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbmenu", Schema = "sys")]
public class Menu : BaseModel
{
    [Column("id")]
    public int Id { get; init; }
    
    [Column("name")]
    public string Name { get; set; }
    
    [Column("parameters")]
    public string? Parameters { get; set; }
    
    [Column("route")]
    public string? Route { get; set; }
    
    [Column("parent_id")]
    public int? ParentId { get; set; }
    
    [Column("has_children")]
    public bool? HasChildren { get; set; }
    
    [Column("icon")]
    public string? Icon { get; set; }
    
    [Column("order")]
    public int? Order { get; set; }
    
    [Column("disabled")]
    public bool Disabled { get; set; }
    
    [Column("divisor")]
    public bool? Divisor { get; set; }
    
    [Column("type")]
    public string? Type { get; set; }
    
    [Column("template")]
    public string? Template { get; set; }
    
    [Column("render")]
    public string? Render { get; set; }

    public Menu() {}
}

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(x => x.Id);
    }
}