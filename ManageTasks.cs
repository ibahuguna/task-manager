using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    internal class ManageTasks
    {
        List<TaskItem> tasks = new List<TaskItem>(); 
        TaskItem item;
        
        int tempId = 0;

        public string MenuChoice()
        {
            Console.WriteLine("Please choose an option : ");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Complete");
            Console.WriteLine("4. Delete Task");
            Console.WriteLine("5. Exit");
            string option = Console.ReadLine();
            return option == null? "": option;
        }

        public void AddTask()
        {
            Console.Write("Enter task title : ");
            string title = Console.ReadLine();
            item = new TaskItem();
            item.Title = title;
            item.Id = ++tempId;
            item.IsCompleted = false;
            tasks.Add(item);
            Console.WriteLine($"Task {item.Id} successfully added!");
        }

        public void ViewTasks()
        {
            Console.WriteLine("Following is the list of existing tasks :");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}: {task.Title} - {(task.IsCompleted ? "Done" : "Pending")}");
            }
        }

        public void MarkComplete()
        {
            Console.Write("Enter the Task ID : ");
            string input = Console.ReadLine();
            int markId = input == ""? 0: Convert.ToInt32(input);
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks.ElementAt(i).Id == markId)
                {
                    if (tasks.ElementAt(i).IsCompleted == true)
                        Console.WriteLine("The task is already marked as complete!");
                    else
                    {
                        tasks.ElementAt(i).IsCompleted = true;
                        Console.WriteLine($"Task {markId} marked as complete.");
                    }
                    markId = -1;
                    break;
                }
            }
            if (markId != -1)
                Console.WriteLine("Task ID not found!");
        }

        public void DeleteTask()
        {
            Console.Write("Enter the Task ID : ");
            string input = Console.ReadLine();
            int markId = input == "" ? 0 : Convert.ToInt32(input);
            for (int i = 0; i < tasks.Count; i++)
            {
                if (tasks.ElementAt(i).Id == markId)
                {
                    tasks.RemoveAt(i);
                    Console.WriteLine($"Task ID {markId} deleted.");
                    markId = -1;
                    break;
                }
            }
            if (markId != -1)
                Console.WriteLine("Task ID not found!");

        }
    }
}
