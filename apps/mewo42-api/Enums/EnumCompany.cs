using System.ComponentModel.DataAnnotations;

namespace preponto_api.Enums;

public enum EnumCompany
{
    [Display(Name = "Ativa")]
    StatusActive = 1,
    [Display(Name = "Inativa")]
    StatusInactive = 2,
}