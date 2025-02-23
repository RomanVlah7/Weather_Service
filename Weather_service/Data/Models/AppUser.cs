namespace Weather_service.Models;

public class AppUser(string userName, string userPassword, long userId)
{
    private string _userName = userName;
    private string _userPassword = userPassword;
    private long _userId = userId;

    public string UserName
    {
        get => userName;
        set => userName = value ?? throw new ArgumentNullException(nameof(value));
    }

    public string UserPassword
    {
        get => userPassword;
        set => userPassword = value ?? throw new ArgumentNullException(nameof(value));
    }

    public long UserId
    {
        get => userId;
        set => userId = value;
    }
}