using System;
using System.Collections.Generic;

namespace CyberChatbotGui
{
    public class ChatbotEngine
    {
        // ==========================================
        // 1. RANDOM RESPONSES (Dictionary & Lists)
        // ==========================================
        
        private Dictionary<string, List<string>> keywordResponses = new Dictionary<string, List<string>>()
        {
            { "password", new List<string> {
                "Make sure to use strong, unique passwords for each account.",
                "Avoid using personal details like birthdays in your passwords.",
                "Consider using a password manager to keep track of complex passwords.",
                "A strong password should be at least 12 characters long and include a mix of letters, numbers, and symbols."
            }},
            { "scam", new List<string> {
                "Never click on links in unsolicited emails or texts.",
                "If an offer sounds too good to be true, it probably is a scam.",
                "Always verify the sender's identity before sharing personal information.",
                "Scammers often create a sense of urgency. Take a moment to breathe and verify."
            }},
            { "privacy", new List<string> {
                "Review your social media privacy settings regularly.",
                "Be cautious about what personal information you share online.",
                "Use a VPN when connecting to public Wi-Fi to protect your data.",
                "Check which apps have permission to access your location and microphone."
            }},
            { "phishing", new List<string> {
                "Check the sender's email address carefully. Phishers often use addresses that look almost real.",
                "Hover over links before clicking them to see where they actually lead.",
                "Legitimate companies will never ask for your password via email.",
                "If you suspect a phishing attempt, report it and delete the email immediately."
            }},
            { "safe browsing", new List<string> {
                "Always look for 'https://' in the URL before entering any personal information.",
                "Keep your web browser and antivirus software updated.",
                "Avoid clicking on pop-up ads, even if they claim you've won a prize.",
                "Consider using an ad-blocker to prevent malicious ads from loading."
            }}
        };

        // A Random object to pick a random index from the lists above
        private Random random = new Random();

        // ==========================================
        // 2. MAIN PROCESSING METHOD
        // ==========================================
        public string GetResponse(string input, string userName, ref string favouriteTopic)
        {
            //  ERROR HANDLING 
            if (string.IsNullOrWhiteSpace(input))
            {
                return "Please type a message so I can help you.";
            }

            // Convert to lowercase for easy matching
            string question = input.ToLower().Trim();

            // --- SENTIMENT DETECTION ---
            
            string sentimentPrefix = DetectSentiment(question);

            // --- MEMORY RECALL  ---
            // If the user asks about their favourite topic, recall it from memory
            if (question.Contains("favourite topic") || question.Contains("favorite topic"))
            {
                if (!string.IsNullOrEmpty(favouriteTopic))
                {
                    return $"You mentioned you are interested in {favouriteTopic}. It's a crucial part of staying safe online. As someone interested in {favouriteTopic}, you might want to review your security settings.";
                }
                else
                {
                    return "You haven't told me your favourite cybersecurity topic yet! Ask me about passwords, scams, privacy, phishing, or safe browsing.";
                }
            }

            // --- KEYWORD RECOGNITION & RANDOM RESPONSES ---
            // Loop through all the keywords in our dictionary
            foreach (var keyword in keywordResponses.Keys)
            {
                if (question.Contains(keyword))
                {
                    // Save this to memory so we can recall it later
                    favouriteTopic = keyword;

                    // Pick a random response from the list for this keyword
                    int randomIndex = random.Next(keywordResponses[keyword].Count);
                    string randomTip = keywordResponses[keyword][randomIndex];

                    // Combine the sentiment prefix (if any) with the random tip
                    return sentimentPrefix + randomTip;
                }
            }

            // --- FALLBACK / UNRECOGNISED INPUT ---
            // If nothing matches, return a default response (Error Handling)
            return "I'm not sure I understand. Can you try rephrasing? You can ask me about passwords, scams, privacy, phishing, or safe browsing.";
        }

        // ==========================================
        // 3. SENTIMENT DETECTION HELPER METHOD
        // ==========================================
        private string DetectSentiment(string input)
        {
            if (input.Contains("worried") || input.Contains("scared") || input.Contains("afraid") || input.Contains("anxious"))
            {
                return "It's completely understandable to feel that way. Scammers can be very convincing. Let me share some tips to help you stay safe. ";
            }
            if (input.Contains("frustrated") || input.Contains("annoying") || input.Contains("confusing") || input.Contains("hate"))
            {
                return "I hear you, this can be frustrating. Let me break it down simply for you. ";
            }
            if (input.Contains("curious") || input.Contains("wondering") || input.Contains("interested"))
            {
                return "That's a great question! Let's dive into it. ";
            }

            // If no sentiment is detected, return an empty string (so nothing is added to the front)
            return "";
        }
    }
}