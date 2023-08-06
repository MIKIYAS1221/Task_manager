namespace Task_manager;

public class Task_Manager
{
    public List<TaskItem> Tasks { get; set; }
    
    public Task_Manager()
    {
        Tasks = new List<TaskItem>();
    }
    
    public void AddTask(TaskItem task)
    {
        Tasks.Add(task);
    }
    
    
    public void PrintTasks()
    {
        
        Console.WriteLine("Tasks:");
        foreach (var task in Tasks)
        {
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Category: {task.Category}");
            Console.WriteLine($"Is completed: {task.IsCompleted}");
            Console.WriteLine();
        }
    }
    
    public void PrintTasks(TaskCategory category)
    {
        Console.WriteLine($"Tasks with category {category}:");
        var tasksWithCategory = Tasks.Where(task => task.Category == category);
        foreach (var task in tasksWithCategory)
        {
            Console.WriteLine($"Name: {task.Name}");
            Console.WriteLine($"Description: {task.Description}");
            Console.WriteLine($"Category: {task.Category}");
            Console.WriteLine($"Is completed: {task.IsCompleted}");
            Console.WriteLine();
        }
    }
    
    // save tasks to file
    public async Task SaveTasks(string fileName)
    {
        await using var file = new StreamWriter(fileName);
        foreach (var task in Tasks)
        {
            await file.WriteLineAsync($"{task.Name},{task.Description},{task.Category},{task.IsCompleted}");
        }
    }
    
    // load tasks from file
    public async Task LoadTasks(string fileName)
    {
        Tasks.Clear();
        using var file = new StreamReader(fileName);
        string line;
        while ((line = await file.ReadLineAsync()) != null)
        {
            var taskProperties = line.Split(',');
            var task = new TaskItem(taskProperties[0], taskProperties[1], (TaskCategory) Enum.Parse(typeof(TaskCategory), taskProperties[2]));
            task.IsCompleted = bool.Parse(taskProperties[3]);
            Tasks.Add(task);
        }
    }
}