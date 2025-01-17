using Common.Core._08.Domain.Enumerado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Core._08.Domain.Model;
public static class RoleConstants
{
    // Auth
    public const string ADMIN_AUTH = nameof(ERole.ADMIN_AUTH);
    public const string EMPLOYEE_AUTH = nameof(ERole.EMPLOYEE_AUTH);
}
