// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;

namespace Task_manager;

class Program
{
    static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to Task Manager!");
        Task_Manager taskManager = new Task_Manager();

        // Load tasks from file asynchronously
        await taskManager.LoadTasks("tasks.csv");

        while (true)
        {
            Console.WriteLine("Options:");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View All Tasks");
            Console.WriteLine("3. View Tasks by Category");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    TaskItem task = new TaskItem();
                    Console.Write("Enter Task Name: ");
                    task.Name = Console.ReadLine();
                    Console.Write("Enter Task Description: ");
                    task.Description = Console.ReadLine();
                    Console.Write("Enter Task Category (Personal, Work, Errands, Others): ");
                    if (Enum.TryParse<TaskCategory>(Console.ReadLine(), out TaskCategory category))
                    {
                        task.Category = category;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Category. Defaulting to 'Others'.");
                        task.Category = TaskCategory.Others;
                    }
                    task.IsCompleted = false;
                    taskManager.AddTask(task);
                    break;
                case "2":
                    taskManager.PrintTasks();
                    break;
                case "3":
                    Console.Write("Enter Task Category to Filter (Personal, Work, Errands, Others): ");
                    if (Enum.TryParse<TaskCategory>(Console.ReadLine(), out TaskCategory filterCategory))
                    {
                        taskManager.PrintTasks(filterCategory);
                    }
                    else
                    {
                        Console.WriteLine("Invalid Category.");
                    }
                    break;
                case "4":
                    // Save tasks to file asynchronously before exiting
                    await taskManager.SaveTasks("tasks.csv");
                    break;
                default:
                    Console.WriteLine("Invalid Option.");
                    break;
            }

            Console.WriteLine();
        }
    }
}
    
    
