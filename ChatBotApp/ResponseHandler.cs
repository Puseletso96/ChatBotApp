using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotApp
{
    internal class ResponseHandler
    {
        public string Name { get; set; }
        public string GetResponse(string input)
        {
            if (input.Contains("how areyou") || input.Contains("how are u"))

            {
                return $"I'm doing well thanks for asking!";
            }
            else if (input.Contains("purpose"))
            {
                return $" I'm your cyber security bot Assistant{Name}! I'm here to educate you about online safety, phishing scams, password security, and safe browsing habits";

            }
            else if (input.Contains("what can i ask") || input.Contains("what can i ask you"))
            {
                return $" Great question, {Name}! You can ask me about online safety, phishing scams, password security, and safe browsing habits. I'm here to help you stay safe online!";
            }
            else if (input.Contains("help"))
            {
                return $" Here's what i can help you with,{Name}!: \n Password safety tips \n How to spot phishing emails\n safe browsing practice\n Recognising social engineering\n\nType 'exit' to end our chat";
        }
            else
            {
                return $"I'm sorry, {Name}, I didn't understand that. Can you please rephrase your question or ask about online safety, phishing scams, password security, or safe browsing habits?";
            }
        }
    }
}
