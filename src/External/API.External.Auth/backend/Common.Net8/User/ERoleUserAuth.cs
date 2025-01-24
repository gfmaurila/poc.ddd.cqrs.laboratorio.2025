namespace Common.External.Auth.Net8.User;

public enum ERoleUserAuth
{
    // USER
    USER = 1, // All - Create, Update, Delete, GET, GET ID
    CREATE_USER = 2,
    UPDATE_USER = 3,
    DELETE_USER = 4,
    GET_USER = 5,
    GET_BY_ID_USER = 6,

    // Notification
    NOTIFICATION = 11,
    CREATE_NOTIFICATION = 12,
    DELETE_NOTIFICATION = 13,
    GET_NOTIFICATION = 14,

    // Auth
    AUTH_RESET = 21,

    // Oracle - HT
    REGION = 31,

    COUNTRI = 41,

    DEPARTMENT = 51,

    EMPLOYEE = 61,

    JOB = 71,

    JOB_HISTORY = 81,

    LOCATION = 91,

    // MySQL
    MKT_POST = 101,

}
