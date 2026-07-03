namespace meow42_api.Dtos;

public class MenuDto {
    public int Id { get; init; }
    public string Name { get; set; }
    public string Label { get; set; }
    public string? Parameters { get; set; }
    public string? Route { get; set; }
    public string? Type { get; set; }
    public bool? Divisor { get; set; }
    public int? ParentId { get; set; }
    public bool? HasChildren { get; set; }
    public string? Icon { get; set; }
    public int? Order { get; set; }
    public bool Disabled { get; set; }
    public string? Template { get; set; }
    public string? Render { get; set; }
    public List<MenuDto>? DeepChildren { get; set; }
}