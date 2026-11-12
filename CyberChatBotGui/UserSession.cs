using System;
using System.Collections.Generic;
using System.Text;

namespace CyberChatBotGui 
{
    public class UserSession
    {
       
        public string Name { get; set; }
        
        public string FavouriteTopic { get; set; }

        public string LastSentiment { get; set; }

        public UserSession()
        {
            Name = "";
            FavouriteTopic = "";
            LastSentiment = "";
        }
    }
}