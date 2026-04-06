using TaskManager;

ManageTasks tm = new ManageTasks();
bool cont = true;

while (cont)
{
    string option = tm.MenuChoice();
    switch (option)
    {
        case "1":
            tm.AddTask();
            break;
        case "2":
            tm.ViewTasks();
            break;
        case "3":
            tm.MarkComplete();
            break;
        case "4":
            tm.DeleteTask();
            break;
        case "5":
            tm.SearchTask();
            break; 
        case "6":
            tm.filterTask();
            break;
        case "7":
            tm.updateTask();
            break;
        case "8":
            cont = false;
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
    Console.WriteLine();
}
