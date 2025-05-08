using System;

namespace ToDoApp.Models
{
    public enum ToDoItemStatus
    {
        ToDo,
        InProgress,
        Done,
        Backlog
    }

    public enum ToDoItemPriority
    {
        None,
        Low,
        Medium,
        High
    }

    public class ToDoItem : Item
    {
        public ToDoItemStatus status { get; set; }
        public string description { get; set; }
        public DateTime deadline  { get; set; }
        public ToDoItemPriority priority { get; set; }
        public ToDoItem(int id,string name = "", ToDoItemStatus status = ToDoItemStatus.Backlog,
            string description = "", DateTime deadline = default(DateTime), ToDoItemPriority priority = ToDoItemPriority.None)
        : base(id,name)
        {
            this.status = status;
            this.description = description;
            this.deadline = deadline;
            this.priority = priority;
        }
    }
}