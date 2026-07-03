using System.ComponentModel;

namespace meow42_api.Enums;

public enum EnumUser
{
    [Description("Administrador")]
    TIPO_ADMIN = 1,
    [Description("Interno")]
    TIPO_INTERNO = 2,
    [Description("Externo")]
    TIPO_EXTERNO = 3
}