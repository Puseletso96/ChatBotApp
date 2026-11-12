using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatBotGui
{
    internal class DatabaseHelper
    {

        private string connectionString = "Server=localhost;Database=CyberBotDB;Uid=root;Pwd=YOUR_MYSQL_PASSWORD;";
        public void AddTask(String title, string description, DateTime? reminder)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Tasks (Title, Description, ReminderDate, IsCompleted) VALUES (@Title, @Description, @ReminderDate, 0)";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@ReminderDate", reminder.HasValue ? (object)reminder.Value : DBNull.Value);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public List<TaskItem> GetTasks()
        {
            List<TaskItem> tasks = new List<TaskItem>();
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT * FROM Tasks";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        tasks.Add(new TaskItem
                        {
                            TaskID = reader.GetInt32("TaskID"),
                            Title = reader.GetString("Title"),
                            Description = reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader.GetString("Description"),
                            ReminderDate = reader.IsDBNull(reader.GetOrdinal("ReminderDate")) ? (DateTime?)null : reader.GetDateTime("ReminderDate"),
                            IsCompleted = reader.GetBoolean("IsCompleted")
                        });
                    }
                }
            }
            return tasks;
        }
    }
}