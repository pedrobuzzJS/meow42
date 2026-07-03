using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using meow42_api.Abstracts;

namespace meow42_api.Models;

[Table("tbroutine", Schema = "sys")]
public class Routine : BaseModel
{
    [Column("routineid")]
    public int Id { get; init; }
}

public class RoutineConfiguration : IEntityTypeConfiguration<Routine>
{
    public void Configure(EntityTypeBuilder<Routine> builder)
    {
        builder.HasKey(r => r.Id);
    }
}