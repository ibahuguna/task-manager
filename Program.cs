using TaskManager;

List<TaskItem> tasks = new List<TaskItem>();
TaskItem item = null;

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
            // Add task code
            break;
        case "2":
            //View tasks code
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
