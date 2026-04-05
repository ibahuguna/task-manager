using TaskManager;

List<TaskItem> tasks = new List<TaskItem>();
TaskItem item;
int tempId = 0;

bool cont = true;

while (cont)
{
    Console.WriteLine("Please choose an option : ");
    Console.WriteLine("1. Add Task");
    Console.WriteLine("2. View Tasks");
    Console.WriteLine("3. Mark Complete");
    Console.WriteLine("4. Exit");
    String option = Console.ReadLine();
    switch (option)
    {
        case "1":
            Console.Write("Enter task title : ");
            string title = Console.ReadLine();
            item = new TaskItem();
            item.Title = title;
            item.Id = ++tempId;
            item.IsCompleted = false;
            tasks.Add(item);
            Console.WriteLine($"Task {item.Id} successfully added!");
            break;
        case "2":
            Console.WriteLine("Following is the list of existing tasks :");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}: {task.Title} - {(task.IsCompleted ? "Done" : "Pending")}");
            }
            break;
        case "3":
            Console.Write("Enter the Task ID : ");
            int markId = Convert.ToInt32(Console.ReadLine());
            for(int i = 0; i < tasks.Count; i++)
            {
                if(tasks.ElementAt(i).Id == markId)
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
            break;
        case "4":
            cont = false;
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
    Console.WriteLine();
}
