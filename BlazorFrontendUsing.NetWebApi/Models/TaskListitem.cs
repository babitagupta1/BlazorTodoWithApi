﻿

namespace BlazorFrontendUsing.NetWebApi.Models
{
    public class TaskListitem
    {
        public int Id { get; set; }

       
        public string Title { get; set; }

        
        public string Description { get; set; }

        public bool IsCompleted { get; set; }

        public DateTime? DueDate { get; set; }
    }
}
