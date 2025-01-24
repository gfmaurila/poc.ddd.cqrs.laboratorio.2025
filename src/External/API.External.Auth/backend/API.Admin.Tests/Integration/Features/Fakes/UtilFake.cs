using Common.External.Auth.Net8.User;

namespace API.External.Auth.Tests.Integration.Features.Fakes;

public static class UtilFake
{
    public static List<string> Role()
    {
        return new List<string>
                    {
                        ERoleUserAuth.USER.ToString(),
                        ERoleUserAuth.CREATE_USER.ToString(),
                        ERoleUserAuth.UPDATE_USER.ToString(),
                        ERoleUserAuth.DELETE_USER.ToString(),
                        ERoleUserAuth.GET_USER.ToString(),
                        ERoleUserAuth.GET_BY_ID_USER.ToString(),

                        ERoleUserAuth.NOTIFICATION.ToString(),
                        ERoleUserAuth.CREATE_NOTIFICATION.ToString(),
                        ERoleUserAuth.DELETE_NOTIFICATION.ToString(),
                        ERoleUserAuth.GET_NOTIFICATION.ToString(),

                        ERoleUserAuth.REGION.ToString(),
                        ERoleUserAuth.COUNTRI.ToString(),
                        ERoleUserAuth.DEPARTMENT.ToString(),
                        ERoleUserAuth.EMPLOYEE.ToString(),
                        ERoleUserAuth.JOB.ToString(),
                        ERoleUserAuth.JOB_HISTORY.ToString(),
                        ERoleUserAuth.LOCATION.ToString(),

                        ERoleUserAuth.MKT_POST.ToString(),
                    };
    }
}
