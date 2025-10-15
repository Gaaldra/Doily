namespace Doily.Domain;

public class User
{
    public int ID { get; private set; }
    public string FirstName { get; private set; } = String.Empty;

    public string LastName { get; private set; } = String.Empty;
    public string Username { get; private set; } = String.Empty;
    public string Password { get; private set; } = String.Empty;

    public User() { }

    public User(string firstName, string lastName, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
    }
}
