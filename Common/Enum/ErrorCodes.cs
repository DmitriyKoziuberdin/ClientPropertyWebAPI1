namespace Common.Enum
{
    public enum ErrorCodes
    {
        Undefined = 0,

        Property = 1_000,
        PropertyNotFound = 1_001,

        User = 2_000,
        UserNotFound = 2_001,
        UserDuplicateEmail = 2_002
    }
}
