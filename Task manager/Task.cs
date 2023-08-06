namespace Task_manager;



// Task class with properties
public class TaskItem
{
    public string Name { get; set; }
    public string Description { get; set; }
    public TaskCategory Category { get; set; }
    public bool IsCompleted { get; set; }
    
    public TaskItem()
    {
        
    }
    public TaskItem(string name, string description, TaskCategory category)
    {
        Name = name;
        Description = description;
        Category = category;
        IsCompleted = false;
    }
}