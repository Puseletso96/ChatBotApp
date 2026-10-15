using CyberChatbotGui;
using System;
using System.Windows;
using System.Windows.Input;

namespace CyberChatBotGui
{
    public partial class MainWindow : Window
    {
        // ============ FIELDS ============
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private ChatbotEngine _engine = new ChatbotEngine();
        private UserSession _session = new UserSession();

        private const string DIVIDER = "================================================";

        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Runs when window loads - plays greeting + shows ASCII art + welcome.
        /// </summary>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // Play voice greeting
            _audioPlayer.PlayGreeting();

            // ASCII art
            string asciiArt = @" 
   ______      __              _____                      _ __           ___                                                   ____        __ 
  / ____/_  __/ /_  ___  _____/ ___/___  _______  _______(_) /___  __   /   |_      ______ _________  ____  ___  __________   / __ )____  / /_
 / /   / / / / __ \/ _ \/ ___/\__ \/ _ \/ ___/ / / / ___/ / __/ / / /  / /| | | /| / / __ `/ ___/ _ \/ __ \/ _ \/ ___/ ___/  / __  / __ \/ __/
/ /___/ /_/ / /_/ /  __/ /   ___/ /  __/ /__/ /_/ / /  / / /_/ /_/ /  / ___ | |/ |/ / /_/ / /  /  __/ / / /  __(__  |__  )  / /_/ / /_/ / /_  
\____/\__, /_.___/\___/_/   /____/\___/\___/\__,_/_/  /_/\__/\__, /  /_/  |_|__/|__/\__,_/_/   \___/_/ /_/\___/____/____/  /_____/\____/\__/  
     /____/                                                 /____/                                                                            
";
            AsciiArtTextBlock.Text = asciiArt;

            // Welcome message
            AppendToChat("Bot: " + DIVIDER);
            AppendToChat("Bot:    WELCOME TO THE CYBERCHATBOT SYSTEM");
            AppendToChat("Bot: " + DIVIDER);
            AppendToChat("Bot: Please enter your name:");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e)
        {
            ProcessUserInput();
        }

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ProcessUserInput();
            }
        }

        private void VoiceButton_Click(object sender, RoutedEventArgs e)
        {
            _audioPlayer.PlayGreeting();
        }

        /// <summary>
        /// Reads user input, validates it, and routes appropriately.
        /// </summary>
        private void ProcessUserInput()
        {
            string input = UserInputTextBox.Text?.Trim();

            // Don't process empty messages
            if (string.IsNullOrEmpty(input)) return;

            // Show user's message
            AppendToChat("You: " + input);
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();

            // If name hasn't been set, save it
            if (string.IsNullOrEmpty(_session.Name))
            {
                _session.Name = input;
                AppendToChat("Bot: " + $"Welcome, {_session.Name}! You are now connected to the CyberChatbot System.");
                AppendToChat("Bot: " + DIVIDER);
                AppendToChat("Bot: " + $"I can help you with passwords, phishing, safe browsing, and privacy. What would you like to know, {_session.Name}?");
            }
            else
            {
                // Fix for the 'ref' error
                string tempTopic = _session.FavouriteTopic;
                string botResponse = _engine.GetResponse(input, _session.Name, ref tempTopic);

                // Save the updated topic back into the session memory
                _session.FavouriteTopic = tempTopic;

                AppendToChat("Bot: " + botResponse);
            }
        }

        /// <summary>
        /// Adds a message to the chat display and scrolls to the bottom.
        /// </summary>
        private void AppendToChat(string message)
        {
            ChatDisplay.Text += message + "\n\n";
            ChatDisplay.ScrollToEnd();
        }
    }
}