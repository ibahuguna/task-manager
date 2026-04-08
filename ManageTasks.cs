using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace TaskManager
{
    internal class ManageTasks
    {
        List<TaskItem> tasks = new List<TaskItem>(); 
        TaskItem item;
        
        public string MenuChoice()
        {
            Console.WriteLine("Please choose an option : ");
            Console.WriteLine("1. Add Task \t\t\t5. Search task");
            Console.WriteLine("2. View Tasks \t\t\t6. Sort tasks");
            Console.WriteLine("3. Mark Complete \t\t7. Update task");
            Console.WriteLine("4. Delete Task \t\t\t8. Exit");
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
            item = new TaskItem();
            item.Title = title;
            
            Console.Write("Enter task priority as low, medium or high : ");
            string p = Console.ReadLine();
            item.Priority = p;
 
            tasks.Add(item);
            Console.WriteLine($"Task {item.Id} successfully added!");
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
                Console.WriteLine($"{task.Id}: {task.Title} - {task.Priority} priority - {(task.IsCompleted ? "Done" : "Pending")}");
            }
        }

        public void MarkComplete()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty! Cannot perform operation.");
                return;
            }

            Console.Write("Enter the Task ID : ");
            int markId;
            bool isValid = int.TryParse(Console.ReadLine(), out markId);
            if (!isValid)
            {
                Console.WriteLine("Please enter a valid Id.");
                return;
            }
            List<TaskItem> taskList = (from task in tasks
                                       where task.Id == markId
                                       select task).ToList();
            if (taskList.Count == 0)
                Console.WriteLine("Task ID not found!");
            else 
            {
               if(taskList.First().IsCompleted == true)
                    Console.WriteLine("The task is already marked as complete!");
               else
                {
                    taskList.First().IsCompleted = true;
                    Console.WriteLine($"Task {markId} marked as complete.");
                }
            }
        }

        public void DeleteTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty! Cannot perform operation.");
                return;
            }
            Console.Write("Enter the Task ID : ");
            int deleteId;
            bool isValid = int.TryParse(Console.ReadLine(), out deleteId);
            if (!isValid)
            {
                Console.WriteLine("Please enter a valid ID.");
                return;
            }
            int result = tasks.RemoveAll(x => x.Id == deleteId);
            if (result == 0)
                Console.WriteLine("Task ID not found!");
            else
            {
                Console.WriteLine($"Task {deleteId} deleted.");
            }
        }

        public void SearchTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty!");
                return;
            }
            Console.Write("Enter search keyword : ");
            string keyword = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(keyword))
            {
                Console.WriteLine("Keyword cannot be empty or white space.");
                return;
            }
            foreach (TaskItem task in tasks.Where(t => t.Title.ToLower().Contains(keyword)))
                    Console.WriteLine($"{task.Id}: {task.Title} - {task.Priority} priority - {(task.IsCompleted ? "Done" : "Pending")}");
        }

        public void filterTask()
        {

        }

        public void sortTasks()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty! Cannot perform operation.");
                return;
            }
            Console.WriteLine("Sorting tasks by title : ");
            List<TaskItem> taskList = (from task in tasks
                                       orderby task.Title ascending
                                       select task).ToList();
            foreach(var t in taskList)  
                Console.WriteLine($"{t.Id}: {t.Title} - {t.Priority} priority - {(t.IsCompleted ? "Done" : "Pending")}"); 
        }

        public void updateTask()
        {
            if (tasks.Count == 0)
            {
                Console.WriteLine("Tasks list is empty! Cannot perform operation.");
                return;
            }

            Console.WriteLine("1. Change title\t\t\t2. Change priority");
            string input = Console.ReadLine();
            if(string.IsNullOrWhiteSpace(input) || !(input.Equals("1") || input.Equals("2"))){
                Console.WriteLine("Invalid option!");
                return;
            }

            Console.Write("Enter the Task ID : ");
            int taskId;
            bool isValid = int.TryParse(Console.ReadLine(), out taskId);
            if (!isValid)
            {
                Console.WriteLine("Invalid Task ID!");
                return;
            }
            if(input.Equals("1"))
                updateTaskTitle(taskId);
            else if(input.Equals("2"))
                updateTaskPriority(taskId);
        }

        public void updateTaskTitle(int taskId)
        {
            List<TaskItem> newList = tasks.Where(t => t.Id == taskId).ToList();
            if (!newList.Any())
            {
                Console.WriteLine($"Task Id {taskId} not found!");
                return;
            }
            Console.Write("Enter new title : ");
            string newTitle = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(newTitle))
            {
                Console.WriteLine("Task title cannot be empty.");
                return;
            }
            newList.First().Title = newTitle;
            Console.WriteLine("Title updated!");
        }

        public void updateTaskPriority(int taskId)
        {
            List<TaskItem> newList = tasks.Where(t => t.Id == taskId).ToList();
            if (!newList.Any())
            {
                Console.WriteLine($"Task Id {taskId} not found!");
                return;
            }

            Console.Write("Enter task priority as low, medium or high : ");
            string p = Console.ReadLine();
            newList.First().Priority = p;
            Console.WriteLine("Priority updated!");
        }

    }
}
