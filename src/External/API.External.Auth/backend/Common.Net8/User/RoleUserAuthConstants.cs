namespace Common.External.Auth.Net8.User;

public static class RoleUserAuthConstants
{
    // USER
    public const string User = nameof(ERoleUserAuth.USER);
    public const string GetUser = nameof(ERoleUserAuth.GET_USER);
    public const string GetUserById = nameof(ERoleUserAuth.GET_BY_ID_USER);
    public const string PostUser = nameof(ERoleUserAuth.CREATE_USER);
    public const string PutUser = nameof(ERoleUserAuth.UPDATE_USER);
    public const string DeleteUser = nameof(ERoleUserAuth.DELETE_USER);

    // Notification
    public const string Notification = nameof(ERoleUserAuth.NOTIFICATION);
    public const string GetNotification = nameof(ERoleUserAuth.GET_NOTIFICATION);
    public const string PostNotification = nameof(ERoleUserAuth.CREATE_NOTIFICATION);
    public const string DeleteNotification = nameof(ERoleUserAuth.DELETE_NOTIFICATION);

    // AUTH
    public const string AuthReset = nameof(ERoleUserAuth.AUTH_RESET);

    // Regios
    public const string Region = nameof(ERoleUserAuth.REGION);

    // MySQL
    public const string MKT_POST = nameof(ERoleUserAuth.MKT_POST);
}
