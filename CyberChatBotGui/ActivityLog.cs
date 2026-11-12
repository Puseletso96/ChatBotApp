using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatBotGui
{
    internal class ActivityLog
    {
        public List<string> Logs { get; private set; } = new List<string>();
        public void AddAction(string action)
        {
            string logEntry = $"[{DateTime.Now: yyyy-MM-dd HH:mm:ss}] {action}";
            Logs.Add(logEntry);

            if (Logs.Count > 10)
            {
                Logs.RemoveAt(0);
            }
        }
        public string GetLogSummary()
        {
            if(Logs.Count == 0) return "No actions recorded yet";
            String summary = "Here is a summary of recent actions:\n";
            for (int i = 0; i < Logs.Count; i++)
            {
                summary += $"{i + 1}. {Logs[i]}\n";
            }
            return summary;
        }
    }
}
