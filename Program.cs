using TaskManager;

ManageTasks tm = new ManageTasks();
bool cont = true;
tm.LoadFromFile();

while (cont)
{
    string option = tm.MenuChoice();
    switch (option)
    {
        case "1":
            tm.AddTask();
            tm.SaveToFile();
            break;
        case "2":
            tm.ViewTasks();
            break;
        case "3":
            tm.MarkComplete();
            tm.SaveToFile();
            break;
        case "4":
            tm.DeleteTask();
            tm.SaveToFile();
            break;
        case "5":
            tm.SearchTask();
            break; 
        case "6":
            tm.SortTasks();
            break;
        case "7":
            tm.UpdateTask();
            tm.SaveToFile();
            break;
        case "8":
            tm.FilterTasks();
            break;
        case "9":
            tm.PrintJson();
            break;
        case "10":
            cont = false;
            break;
        default:
            Console.WriteLine("Invalid option!");
            break;
    }
    Console.WriteLine();
}
