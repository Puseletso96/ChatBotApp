using System;
using System.Collections.Generic;
using System.Text;

namespace ChatBotApp
{
    internal class ResponseHandler
    {
        public string Name { get; set; }
        public void GetResponse(string input)
        {
            string question = input.ToLower().Trim();

            

               
                if (question == "exit")
                {
                    Console.WriteLine("Goodbye stay safe online!");
                }
                else if (question.Contains("how are you"))
                {
                    Console.WriteLine($"I am doing well and ready to help you, {Name}");
                }
                else if (question.Contains("purpose"))
                {
                    Console.WriteLine(" The purpose is to teach about cyber safety");
                }

                else if (question.Contains("What can i ask ") || question.Contains("topic"))
                {
                    Console.WriteLine(" You can ask me about password, phishing, and safety browsing");
                }
                else if (question.Contains("password"))
                {
                    Console.WriteLine(" A strong password should be at least 12 characters long, include a mix of uppercase and lowercase letters, numbers, and special characters. Avoid using easily guessable information like birthdays or common words.");
                }
                else if (question.Contains("phishing"))
                {
                    Console.WriteLine(" Phishing is a cyber attack where attackers impersonate legitimate organizations to trick individuals into providing sensitive information. Be cautious of unsolicited emails, messages, or links asking for personal information.");
                }
                else if (question.Contains("safety browsing"))
                {
                    Console.WriteLine(" To ensure safe browsing, use secure websites (look for 'https' in the URL), avoid clicking on suspicious links, keep your browser and software updated, and consider using ad-blockers and antivirus software.");
                }
                else
                {
                    Console.WriteLine("I'm sorry, I don't have information on that topic. Please ask about password, phishing, or safety browsing.");
                }


            }
        }
    }

