using System.ComponentModel.DataAnnotations;

namespace meow42_api.Enums;

public enum EnumAction
{
    [Display(Name = "Listar")]
    ActionList = 1,
    [Display(Name = "Exibir")]
    ActionShow = 2,
    [Display(Name = "Criar")]
    ActionCreate = 3,
    [Display(Name = "Alterar")]
    ActionUpdate = 4,
    [Display(Name = "Deletar")]
    ActionDelete = 5,
    [Display(Name = "Exclusão Lógica")]
    ActionSoftDele = 5,
}