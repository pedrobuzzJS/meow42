using System.ComponentModel.DataAnnotations.Schema;

namespace meow42_api.Abstracts;

public class BaseModel
{
    [Column("company_id")]
    public int? CompanyId { get; set; }
    
    [Column("metadata")]
    public string? Metadata { get; set; }
    
    [Column("created_at")]
    public DateTimeOffset? CreatedAt { get; set; }
    
    [Column("updated_at")]
    public DateTimeOffset? UpdatedAt { get; set; }
    
    [Column("deleted_at")]
    public DateTimeOffset? DeletedAt { get; set; }
    public BaseModel() {}
}