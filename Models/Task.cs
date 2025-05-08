using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class Task : ToDoItem
    {
        public DateTime dueDate { get; set; }
        public Task(int id,string name = "", ToDoItemStatus status = ToDoItemStatus.Backlog,
            string description = "", DateTime dueDate = default(DateTime),
            DateTime deadline = default(DateTime), ToDoItemPriority priority = ToDoItemPriority.None)
            : base(id, name, status, description, deadline, priority) {
            this.dueDate = dueDate == default ? DateTime.Now : dueDate; // If no due date, use current date
            this.deadline = deadline == default ? DateTime.Now.AddDays(7) : deadline; // If no deadline, use current date + 7 days
        }

    }
}