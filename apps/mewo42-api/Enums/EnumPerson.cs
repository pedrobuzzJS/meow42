using System.ComponentModel.DataAnnotations;

namespace meow42_api.Enums;

public enum EnumPerson
{
    [Display(Name = "Fisica")]
    PersonNatural = 1,
    [Display(Name = "Juridica")]
    PersonJuridical = 2,
}