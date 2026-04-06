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
            Console.WriteLine("1. Add Task \t\t5. Search task");
            Console.WriteLine("2. View Tasks \t\t6. Filter tasks");
            Console.WriteLine("3. Mark Complete \t7. Update task");
            Console.WriteLine("4. Delete Task \t\t 8. Exit");
            string option = Console.ReadLine();
            return option == null? "": option;
        }

        public void AddTask()
        {
            Console.Write("Enter task title : ");
            string title = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(title)) 
            {
                Console.WriteLine("Task title cannot be empty.");
                return;
            }
            Console.Write("Enter task priority as low, medium or high : ");
            string p = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(p))
            {
                Console.WriteLine("No input; setting priority to default(low).");
                p = "low";
            }
            else if (p.ToLower().Equals("low") || p.ToLower().Equals("medium") || p.ToLower().Equals("high"))
                p = p.ToLower();
            else
            {
                Console.WriteLine("Invalid priority! Setting priority to default(low).");
                p = "low";
            }
            item = new TaskItem();
            item.title = title;
            item.id = ++tempId;
            item.priority = p;
            item.isCompleted = false;
            tasks.Add(item);
            Console.WriteLine($"Task {item.id} successfully added!");
        }

        public void ViewTasks()
        {
            if(tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty!");
                return;
            }
            Console.WriteLine("Following is the list of existing tasks :");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.id}: {task.title} - {task.priority} priority - {(task.isCompleted ? "Done" : "Pending")}");
            }
        }

        public void MarkComplete()
        {
            Console.Write("Enter the Task ID : ");
            int markId;
            bool isValid = int.TryParse(Console.ReadLine(), out markId);
            if (!isValid)
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }
            foreach (TaskItem task in tasks)
            {
                if (task.id == markId)
                {
                    if (task.isCompleted == true)
                        Console.WriteLine("The task is already marked as complete!");
                    else
                    {
                        task.isCompleted = true;
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
            int markId;
            bool isValid = int.TryParse(Console.ReadLine(), out markId);
            if (!isValid)
            {
                Console.WriteLine("Please enter a valid number.");
                return;
            }
            foreach (TaskItem task in tasks)
            {
                if (task.id == markId)
                {
                    tasks.Remove(task);
                    Console.WriteLine($"Task ID {markId} deleted.");
                    markId = -1;
                    break;
                }
            }
            if (markId != -1)
                Console.WriteLine("Task ID not found!");

        }

        public void SearchTask()
        {
            Console.Write("Enter search keyword : ");
            string keyword = Console.ReadLine();
            bool found = false;
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Keyword cannot be empty or white space.");
                return;
            }
            foreach (TaskItem task in tasks)
                if (task.title.ToLower().Contains(keyword.ToLower()))
                {
                    Console.WriteLine($"{task.id}: {task.title} - {task.priority} priority - {(task.isCompleted ? "Done" : "Pending")}");
                    found = true;
                }
            if (!found)
                Console.WriteLine("Keyword not found.");
        }

        public void filterTask()
        {

        }

        public void updateTask()
        {

        }
    }
}
