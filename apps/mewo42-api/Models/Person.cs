using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using preponto_api.Abstracts;

namespace preponto_api.Models;

[Table("tbperson", Schema = "uni")]
public class Person : BaseModel
{
    [Column("perid")]
    public int Id { get; init; }
    [Column("name")]
    public string Name { get; set; }
    [Column("gender")]
    public int Gender { get; set; }
    [Column("cpfnpj")]
    public string CpfCnpj { get; set; }
    public List<int> Tags { get; set; } = [];
    public ICollection<PersonContact> PersonContacts { get; } = new List<PersonContact>();
    
    public Person() {}
}

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(p => p.Id);

        // 1. Criamos o comparador de valores para a lista de inteiros
        var tagsComparer = new ValueComparer<List<int>>(
            (c1, c2) => c1.SequenceEqual(c2), // Regra de Igualdade: compara item a item
            c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())), // Regra de Hash: gera um código único baseado no conteúdo
            c => c.ToList() // Regra de Snapshot: cria uma cópia real da lista
        );

        // 2. Aplicamos a conversão e o comparador
        builder.Property(p => p.Tags)
            .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList()
            )
            .HasColumnName("tag")
            .HasComment("Tag da Pessoa");

        // 3. Atribuímos o comparador aos metadados da propriedade
        builder.Property(p => p.Tags)
            .Metadata.SetValueComparer(tagsComparer);

        builder.Property(p => p.CpfCnpj)
            .HasColumnName("cpfcnpj")
            .HasMaxLength(14);
    }
}