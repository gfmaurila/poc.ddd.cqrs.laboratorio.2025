using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Domain.Enumerado;
/// <summary>
/// Gênero.
/// </summary>
public enum EGender
{
    /// <summary>
    /// Não informar.
    /// </summary>
    [Description("Não informar")]
    None = 0,

    /// <summary>
    /// Masculino.
    /// </summary>
    [Description("Masculino")]
    Male = 1,

    /// <summary>
    /// Feminino.
    /// </summary>
    [Description("Feminino")]
    Female = 2
}
