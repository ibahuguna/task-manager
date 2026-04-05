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
            Console.WriteLine("Task successfully added!");
            break;
        case "2":
            Console.WriteLine("Following is the list of existing tasks :");
            foreach (var task in tasks)
            {
                Console.WriteLine($"{task.Id}: {task.Title} - {(task.IsCompleted ? "Done" : "Pending")}");
            }
            break;
        case "3":
            //Mark complete code
            break;
        case "4":
            cont = false;
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
}
