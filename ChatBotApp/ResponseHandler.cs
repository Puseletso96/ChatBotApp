using System;

namespace ChatBotApp
{
    internal class ResponseHandler
    {
        public string Name { get; set; }

        public void GetResponse(string input)
        {
            // 1. INPUT VALIDATION: Handle null or empty inputs (fixes exception issue)
            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("I didn't catch that. Please type a question or topic.");
                return;
            }

            // Convert to lowercase and trim for consistent matching
            string question = input.ToLower().Trim();

            // 2. BASIC RESPONSE SYSTEM: Fixed mismatches and case issues
            if (question == "exit")
            {
                Console.WriteLine("Goodbye, stay safe online!");
            }
            else if (question.Contains("how are you"))
            {
                // 3. GREETING: Added null check for Name
                string userName = string.IsNullOrEmpty(Name) ? "there" : Name;
                Console.WriteLine($"I am doing well and ready to help you, {userName}.");
            }
            else if (question.Contains("purpose"))
            {
                Console.WriteLine("The purpose is to teach about cyber safety.");
            }
            // Fixed the phrase mismatch: "what can i ask you about"
            else if (question.Contains("what can i ask") || question.Contains("topic"))
            {
                Console.WriteLine("You can ask me about passwords, phishing, and safe browsing.");
            }
            else if (question.Contains("password"))
            {
                Console.WriteLine("A strong password should be at least 12 characters long, include a mix of uppercase and lowercase letters, numbers, and special characters. Avoid using easily guessable information like birthdays or common words.");
            }
            else if (question.Contains("phishing"))
            {
                Console.WriteLine("Phishing is a cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information. Be cautious of unsolicited emails, messages, or links asking for personal information.");
            }
            // Fixed the mismatch: Changed "safety browsing" to "safe browsing"
            else if (question.Contains("safe browsing"))
            {
                Console.WriteLine("To ensure safe browsing, use secure websites (look for 'https' in the URL), avoid clicking on suspicious links, keep your browser and software updated, and consider using ad-blockers and antivirus software.");
            }
            else
            {
                // Expanded fallback for edge cases
                Console.WriteLine("I'm sorry, I don't have information on that topic. Please ask about passwords, phishing, or safe browsing.");
            }
        }
    }
}