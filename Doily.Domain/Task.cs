namespace Doily.Domain;

public class Task
{
    public int ID { get; private set; }
    public int UserID { get; private set; }
    public string Title { get; private set; } = String.Empty;
    public string Description { get; private set; } = String.Empty;
    public DateTime? Deadline { get; private set; }
    public bool IsCompleted { get; private set; } = false;

    public Task() { }

    public Task(int userID, string title, string description)
    {
        UserID = userID;
        Title = title;
        Description = description;
    }

    public Task(int userID, string title, string description, DateTime deadline) : this(userID, title, description)
    {
        Deadline = deadline;
    }

    public void ToggleCompleteStatus()
    {
        IsCompleted = !IsCompleted;
    }
}
