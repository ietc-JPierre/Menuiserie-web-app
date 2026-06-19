namespace Core.Models;

public class User
{
    public int Id_User { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string Password_Hash { get; set; } = string.Empty;

    public string Role { get; set; } = "User";
}