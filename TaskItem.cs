using System;
using System.Collections.Generic;
using System.Text;

namespace TaskManager
{
    internal class TaskItem
    {
        private string priority;

        public int Id { get; set; }
        public string Title { get; set; }
        public bool IsCompleted { get; set; }
        public string Priority { 
            get { return priority; } 
            set {
                if (string.IsNullOrWhiteSpace(value))
                {
                    Console.WriteLine("No input; setting priority to default(low).");
                    priority = "low";
                }
                else if (value.ToLower().Equals("low") || value.ToLower().Equals("medium") || value.ToLower().Equals("high"))
                    priority = value.ToLower();
                else
                {
                    Console.WriteLine("Invalid priority! Setting priority to default(low).");
                    priority = "low";
                }
            } 
        }

        public TaskItem() { }

        public TaskItem(int id, string title, string priority)
        {
            IsCompleted = false;
            Id = id;
            Title = title;
            Priority = priority;
        }
    }
}
