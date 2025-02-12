using System;

[Serializable]
public class Quest
{
    public string Id;
    public string Title;
    public bool IsCompleted;

    public Quest(string id, string title)
    {
        Id = id;
        Title = title;
        IsCompleted = false;
    }
}