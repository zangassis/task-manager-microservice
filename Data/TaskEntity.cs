using System.Collections.Generic;

namespace TaskManager.Data
{
    public class TaskEntity
    {
        public long Counter { get; set; }
        public List<Item> Items { get; set; }
    }

    public class Item
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public bool IsComplete { get; set; }
    }
}