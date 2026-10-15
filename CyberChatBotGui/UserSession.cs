using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatbotGui
{
    // This class is used to store all the information the bot needs to remember about the user.
    // It acts as the "Memory" for the chatbot.
    public class UserSession
    {
        // Stores the user's name (e.g., "Blessing")
        public string Name { get; set; }

        // Stores the user's favourite cybersecurity topic (e.g., "password", "privacy")
        public string FavouriteTopic { get; set; }

        // Stores the last detected sentiment of the user (e.g., "worried", "curious")
        public string LastSentiment { get; set; }

        // A constructor to initialize the session with empty values
        public UserSession()
        {
            Name = "";
            FavouriteTopic = "";
            LastSentiment = "";
        }
    }
}
