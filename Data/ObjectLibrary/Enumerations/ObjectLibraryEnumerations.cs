

#region using statements

#endregion

namespace ObjectLibrary.Enumerations
{

    #region LogTypeEnum : int
    /// <summary>
    /// These are the types of actions being logged.
    /// </summary>
    public enum LogTypeEnum : int
    {
        Unknown = 0,
        Hide = 1,
        Show = 2,
        Adjust = 3,
        SetColor = 4,
        Swap = 5,
        DrawLine = 6
    }
    #endregion

    #region enum ScreenTypeEnum : int
    /// <summary>
    /// What screen is currently visible
    /// </summary>
    public enum ScreenTypeEnum : int
    {
        MainScreen = 0,
        SignUp = 1,
        Login = 2
    }
    #endregion

    #region enum UserLevelEnum : int
    /// <summary>
    /// What size file can this user upload?
    /// </summary>
    public enum MemberLevelEnum : int
    {
        NotLoggedIn = 0,
        LoggedInFreeUser = 1,
        LoggedInPremiumUser = 2
    }
    #endregion

}
