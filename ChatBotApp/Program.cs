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

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine(@"=======================================================================================================================
 ____             __                         ______                                                                       ____            __      
/\  _`\          /\ \                       /\  _  \                                                                     /\  _`\         /\ \__   
\ \ \/\_\  __  __\ \ \____     __   _ __    \ \ \L\ \  __  __  __     __     _ __    __    ___      __    ____    ____   \ \ \L\ \    ___\ \ ,_\  
 \ \ \/_/_/\ \/\ \\ \ '__`\  /'__`\/\`'__\   \ \  __ \/\ \/\ \/\ \  /'__`\  /\`'__\/'__`\/' _ `\  /'__`\ /',__\  /',__\   \ \  _ <'  / __`\ \ \/  
  \ \ \L\ \ \ \_\ \\ \ \L\ \/\  __/\ \ \/     \ \ \/\ \ \ \_/ \_/ \/\ \L\.\_\ \ \//\  __//\ \/\ \/\  __//\__, `\/\__, `\   \ \ \L\ \/\ \L\ \ \ \_ 
   \ \____/\/`____ \\ \_,__/\ \____\\ \_\      \ \_\ \_\ \___x___/'\ \__/.\_\\ \_\\ \____\ \_\ \_\ \____\/\____/\/\____/    \ \____/\ \____/\ \__\
    \/___/  `/___/> \\/___/  \/____/ \/_/       \/_/\/_/\/__//__/   \/__/\/_/ \/_/ \/____/\/_/\/_/\/____/\/___/  \/___/      \/___/  \/___/  \/__/
               /\___/                                                                                                                             
               \/__/ 
======================================================================================================================================================");
            Console.ResetColor();

            Console.WriteLine();
            Console.WriteLine("=========================================");
            Console.WriteLine("WELCOME TO THE CYBERSECURITY CHATBOT SYSTEM");
            Console.WriteLine("=========================================");

            ResponseHandler response = new ResponseHandler();
            Console.Write($"Please enter your name: {response.Name}");
            response.Name = Console.ReadLine();


            Console.WriteLine($"\nWelcome, {response.Name}! How can I assist you today?");
            Console.WriteLine("Press key to exit...");
            Console.ReadKey();


        }
    }
}