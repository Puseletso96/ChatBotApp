# ChatBotApp 

## Project Description

ChatBotApp is a simple C# console-based chatbot application developed using
Visual Studio. The application allows the user to interact with a chatbot by
entering questions or commands. The chatbot processes the user's input and
provides an appropriate response.

The project demonstrates basic C# programming concepts such as classes,
methods, properties, conditional statements, strings, user input and output.

## Features

-  Greets the user.
-  Accepts user input from the console.
-  Provides responses to different questions.
-  Converts user input to lowercase for easier comparison.
-  Handles unknown questions with a default response.
-  Allows the chatbot to use a name.
-  Allows continuous interaction between the user and chatbot.
- Plays a recorded voice greeting on startup.
- Displays an ASCII art logo with colour formatting.
- Validates the user's name and rejects empty input.
- Personalises responses and farewells using the user's name.
- Provides cybersecurity guidance on passwords, phishing, and safe browsing.
 
## Technologies Used

- **C#**
- **.NET**
- **Visual Studio**
- **Console Application**
- **GitHub**

## How to run the application
- Open ChatBotApp.sln in Visual Studio.
- Ensure ChatBotApp is set as the startup project.
- Press F5 or click the green Run button.

# Cybersecurity Awareness Chatbot

##  Project Overview
This is a C# chatbot application developed to educate South African citizens 
about cybersecurity threats in a conversational, engaging, and user-friendly manner. 

This repository contains **two parts** of the project:
- **Part 1:** A console-based chatbot application.
- **Part 2:** A WPF (Windows Presentation Foundation) GUI application that expands 
  on Part 1 by adding a graphical interface, memory, sentiment detection, and more.

##  Part 1: Console Application

### Project Description
ChatBotApp is a simple C# console-based chatbot application developed using Visual Studio. 
The application allows the user to interact with a chatbot by entering questions or 
commands. The chatbot processes the user's input and provides an appropriate response.

The project demonstrates basic C# programming concepts such as classes, methods, 
properties, conditional statements, strings, user input and output.

### Part 1 Features
- Greets the user.
- Accepts user input from the console.
- Provides responses to different questions.
- Converts user input to lowercase for easier comparison.
- Handles unknown questions with a default response.
- Allows the chatbot to use a name.
- Allows continuous interaction between the user and chatbot.
- Plays a recorded voice greeting on startup.
- Displays an ASCII art logo with colour formatting.
- Validates the user's name and rejects empty input.
- Personalises responses and farewells using the user's name.
- Provides cybersecurity guidance on passwords, phishing, and safe browsing.

### How to Run Part 1 (Console App)
1. Open `ChatBotApp.sln` in Visual Studio.
2. Ensure `ChatBotApp` is set as the startup project.
3. Press **F5** or click the green Run button.
   
##  Part 2: WPF GUI Application

### Project Description
This is a WPF (Windows Presentation Foundation) GUI application developed in C#. 
It expands on the Part 1 console application by adding a Graphical User Interface (GUI), 
keyword recognition, random responses, sentiment detection, and memory recall.

### Part 2 Features Implemented

#### 1. Graphical User Interface (GUI)
- Built using WPF with a modern dark purple "cyber" theme.
- Neat layout with a header (ASCII Art), chat history area, and input area.
- Auto-scrolling chat display so the user never misses a message.
- Pressing **Enter** sends the message (no need to click the button every time).

#### 2. Voice Greeting
- Plays a `WelcomeMassege.wav` audio file when the application launches.
- The audio file is checked for existence to prevent the app from crashing if it is missing.

#### 3. Keyword Recognition
The chatbot recognises at least 5 cybersecurity keywords and provides relevant advice:
- **Password**
- **Scam**
- **Privacy**
- **Phishing**
- **Safe Browsing**

#### 4. Random Responses
To keep the conversation engaging and natural, the bot randomly selects a 
response from a list of pre-defined tips for each keyword. 
The bot will not give the same answer twice in a row.

#### 5. Memory and Recall
The chatbot remembers the user's:
- **Name** (used to personalise responses).
- **Favourite Topic** (the bot can recall this when asked: *"What is my favourite topic?"*).

#### 6. Sentiment Detection
The bot detects the user's emotional tone and adjusts its response accordingly:
- **Worried / Scared / Afraid** → Responds with empathy and reassurance.
- **Frustrated / Confused** → Simplifies the explanation.
- **Curious / Interested** → Encourages further learning.

#### 7. Error Handling
- Handles empty or unrecognised inputs gracefully with a polite fallback message.
- Prevents the application from crashing due to unexpected input.
- Allows the user to type **"exit"** to close the application safely.

### How to Run Part 2 (WPF App)

#### Prerequisites
- Windows Operating System
- Visual Studio (2022 or later recommended)
- .NET Desktop Development workload installed

#### Steps to Run
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/Puseletso96/ChatBotApp.git
 ## Author

 - Tshesana Puseletso
 -STUDENT NUMBER: ST10498947
    
 ## References

GitHub (2026) GitHub Documentation. Available at: https://docs.github.com/ 
(Accessed: 10 September 2026).

Microsoft (2026) C# documentation. Microsoft Learn. Available at: 
https://learn.microsoft.com/en-us/dotnet/csharp/ 
(Accessed: 10 September 2026).

Microsoft (2026) .NET documentation. Microsoft Learn. Available at: 
https://learn.microsoft.com/en-us/dotnet/ 
(Accessed: 10 September 2026).

Microsoft (2026) Visual Studio documentation. Microsoft Learn. Available at: 
https://learn.microsoft.com/en-us/visualstudio/ 
(Accessed: 10 September 2026).

OpenAI (2026) ChatGPT. Available at: https://chatgpt.com/ 
(Accessed: 10 September 2026).

W3Schools (2026) C# Tutorial. Available at: https://www.w3schools.com/cs/ 
(Accessed: 10 September 2026).
