namespace Doily.Domain.Entities;

public class User
{
    public int ID { get; private set; }
    public string FirstName { get; private set; } = string.Empty;

    public string LastName { get; private set; } = string.Empty;
    public string Username { get; private set; } = string.Empty;
    public string Password { get; private set; } = string.Empty;

    public List<Task> Tasks { get; private set; } = [];

    public User() { }

    public User(string firstName, string lastName, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
    }
}
