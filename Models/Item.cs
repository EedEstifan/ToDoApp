using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDoApp.Models
{
    public class Item
    {
        public string name { get; set; }
        public int id { get; }
        public Item(int id,string name)
        {
            this.id = id;
            this.name = name;
        }
    }
}