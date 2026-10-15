# Cybersecurity Awareness Chatbot (Part 2)

##  Project Overview
This is a WPF (Windows Presentation Foundation) GUI application developed in C#. 
The purpose of this chatbot is to educate South African citizens about cybersecurity 
threats in a conversational, engaging, and user-friendly manner. 

This project is Part 2 of the assignment, which expands on the Part 1 console 
application by adding a Graphical User Interface (GUI), voice greeting, keyword 
recognition, random responses, sentiment detection, and memory recall.

##  Features Implemented

### 1. Graphical User Interface (GUI)
- Built using WPF with a modern dark purple "cyber" theme.
- Neat layout with a header (ASCII Art), chat history area, and input area.
- Auto-scrolling chat display so the user never misses a message.
- Pressing **Enter** sends the message (no need to click the button every time).

### 2. Voice Greeting
- Plays a `WelcomeMassege.wav` audio file when the application launches.
- The audio file is checked for existence to prevent the app from crashing if it is missing.

### 3. Keyword Recognition
The chatbot recognises at least 5 cybersecurity keywords and provides relevant advice:
- **Password**
- **Scam**
- **Privacy**
- **Phishing**
- **Safe Browsing**

### 4. Random Responses
To keep the conversation engaging and natural, the bot randomly selects a 
response from a list of pre-defined tips for each keyword. 
The bot will not give the same answer twice in a row.

### 5. Memory and Recall
The chatbot remembers the user's:
- **Name** (used to personalise responses).
- **Favourite Topic** (the bot can recall this when asked: *"What is my favourite topic?"*).

### 6. Sentiment Detection
The bot detects the user's emotional tone and adjusts its response accordingly:
- **Worried / Scared / Afraid** → Responds with empathy and reassurance.
- **Frustrated / Confused** → Simplifies the explanation.
- **Curious / Interested** → Encourages further learning.

### 7. Error Handling
- Handles empty or unrecognised inputs gracefully with a polite fallback message.
- Prevents the application from crashing due to unexpected input.

##  Technologies Used
- **Language:** C#
- **Framework:** .NET (WPF)
- **IDE:** Visual Studio
- **Version Control:** Git & GitHub

##  How to Run the Project

### Prerequisites
- Windows Operating System
- Visual Studio (2022 or later recommended)
- .NET Desktop Development workload installed

### Steps to Run
1. Clone this repository to your local machine:
   ```bash
   git clone https://github.com/Puseletso96/ChatBotApp.git

##  Author          
- **Student Name:** Tshesana Puseletso
- **Student Number:** ST10498947
- **Module:** PRO6221
- **Institution:** The Independent Institute of Education (IIE)

##  References      

GitHub (2026) *GitHub Documentation*. Available at: https://docs.github.com/ 
(Accessed: 10 September 2026).

Microsoft (2026) *C# documentation*. Microsoft Learn. Available at: 
https://learn.microsoft.com/en-us/dotnet/csharp/ 
(Accessed: 10 September 2026).

Microsoft (2026) *.NET documentation*. Microsoft Learn. Available at: 
https://learn.microsoft.com/en-us/dotnet/ 
(Accessed: 10 September 2026).

Microsoft (2026) *Visual Studio documentation*. Microsoft Learn. Available at: 
https://learn.microsoft.com/en-us/visualstudio/ 
(Accessed: 10 September 2026).

OpenAI (2026) *ChatGPT*. Available at: https://chatgpt.com/ 
(Accessed: 10 September 2026).

Pieterse, H. 2021. The Cyber Threat Landscape in South Africa: A 10-Year Review. 
*The African Journal of Information and Communication*, 28(28). 
doi: https://doi.org/10.23962/10539/32213.

W3Schools (2026) *C# Tutorial*. Available at: https://www.w3schools.com/cs/ 
(Accessed: 10 September 2026).
   
