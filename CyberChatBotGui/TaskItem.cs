using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatBotGui
{
    internal class TaskItem
    {
        public int TaskID { get; set; }
        public string Title { get; set; }     
        public string Description { get; set; } 
        public DateTime? ReminderDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
