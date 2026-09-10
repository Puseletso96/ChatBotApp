using System;
using ChatbotApp;
using ChatBotApp;

namespace ChatBotApp
{

    internal class Program
    {
        static void Main()
        {
            AudioPlayer audio = new AudioPlayer();
            audio.PlayWelcomeMessage();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine(@"=======================================================================================================================================================================
                                     ______      __                 _____                      _ __           ___                                                   ____        __ 
  / ____/_  __/ /_  ___  _____   / ___/___  _______  _______(_) /___  __   /   |_      ______ _________  ____  ___  __________   / __ )____  / /_
 / /   / / / / __ \/ _ \/ ___/   \__ \/ _ \/ ___/ / / / ___/ / __/ / / /  / /| | | /| / / __ `/ ___/ _ \/ __ \/ _ \/ ___/ ___/  / __  / __ \/ __/
/ /___/ /_/ / /_/ /  __/ /      ___/ /  __/ /__/ /_/ / /  / / /_/ /_/ /  / ___ | |/ |/ / /_/ / /  /  __/ / / /  __(__  |__  )  / /_/ / /_/ / /_  
\____/\__, /_.___/\___/_/      /____/\___/\___/\__,_/_/  /_/\__/\__, /  /_/  |_|__/|__/\__,_/_/   \___/_/ /_/\___/____/____/  /_____/\____/\__/  
     /____/                                                    /____/                                                                                                                                                     
 
========================================================================================================================================================================================================");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine("WELCOME TO THE CYBERSECURITY CHATBOT SYSTEM");
            Console.WriteLine("=========================================");

            ResponseHandler response = new ResponseHandler();
            Console.Write($"Please enter your name: ");
            response.Name = Console.ReadLine();


            


            // NAME VALIDATION
            while (string.IsNullOrWhiteSpace(response.Name))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Name cannot be empty");
                Console.ResetColor();

                Console.WriteLine("Please enter your name: ");
                response.Name = Console.ReadLine();
            }

            // PERSONALIZED GREETING
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n Hello, {response.Name}! Welcome to the Cybersecurity Chatbot System.");
            Console.WriteLine("I'm here to help stay safe online");
            Console.ResetColor();
            Console.WriteLine("=======================================================================");
           

            string question;
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;

                Console.WriteLine("\nAsk a question or type 'exit' : what can i ask you about? ");
                Console.ResetColor();
                question = Console.ReadLine().ToLower().Trim();



                if (question == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("Goodbye stay safe online!");
                    Console.ResetColor();
                    break;
                }
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.Write("\nAssistant: ");


                // Typing effect
                var writer = new System.IO.StringWriter();
                var original = Console.Out;
                Console.SetOut(writer);
                response.GetResponse(question);
                Console.SetOut(original);
                
                string text = writer.ToString();

                foreach(char c in text)
                {
                    Console.Write(c);
                    System.Threading.Thread.Sleep(20);
                }
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("===========================================================================");
                Console.ResetColor();

            } while (question != "exit");

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine($"Thank you for chatting with me: {response.Name}");
            Console.WriteLine("Remember: Stay safe, Stay secure, Stay Smart!");
            Console.WriteLine("GoodBye!");
            Console.ResetColor();
            Console.WriteLine("============================================================================");

            Console.Write("\nPress any key to exit");

            Console.ReadKey();

        }
    }
}