using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberChatBotGui
{
    public partial class MainWindow : Window
    {
        // ============ FIELDS ============
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private string _userName = "";
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
            AddBotMessage(DIVIDER);
            AddBotMessage("   WELCOME TO THE CYBERCHATBOT SYSTEM");
            AddBotMessage(DIVIDER);
            AddBotMessage("Please enter your name:");
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
            AddUserMessage(input);

            // If name hasn't been set, save it
            if (string.IsNullOrEmpty(_userName))
            {
                _userName = input;
                AddBotMessage($"Welcome, {_userName}! You are now connected to the CyberChatbot System.");
                AddBotMessage(DIVIDER);
                AddBotMessage($"I can help you with passwords, phishing, safe browsing, and privacy. What would you like to know, {_userName}?");
            }
            else
            {
                // Get bot response (basic keyword matching)
                string botResponse = GetBotResponse(input);
                AddBotMessage(botResponse);
            }

            // Reset input
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();
        }

        /// <summary>
        /// Basic keyword matching for bot responses.
        /// </summary>
        private string GetBotResponse(string input)
        {
            string lowerInput = input.ToLower();

            if (lowerInput.Contains("password"))
            {
                return $"{_userName}, use strong, unique passwords for every account. Consider a password manager!";
            }
            else if (lowerInput.Contains("phishing"))
            {
                return $"{_userName}, never click suspicious links in emails. Verify the sender first.";
            }
            else if (lowerInput.Contains("privacy"))
            {
                return $"{_userName}, review your privacy settings on social media regularly.";
            }
            else if (lowerInput.Contains("hello") || lowerInput.Contains("hi"))
            {
                return $"Hello, {_userName}! How can I help with your cybersecurity questions?";
            }
            else
            {
                return $"I'm still learning about that, {_userName}. Ask me about passwords, phishing, or privacy!";
            }
        }

        /// <summary>
        /// Adds a user message to the chat.
        /// </summary>
        private void AddUserMessage(string message)
        {
            TextBlock userText = new TextBlock
            {
                Text = "You: " + message,
                Foreground = Brushes.LightGreen,
                Margin = new Thickness(0, 5, 0, 5),
                TextWrapping = TextWrapping.Wrap
            };
            ChatStackPanel.Children.Add(userText);
            ScrollToBottom();
        }

        /// <summary>
        /// Adds a bot message to the chat.
        /// </summary>
        private void AddBotMessage(string message)
        {
            TextBlock botText = new TextBlock
            {
                Text = "Bot: " + message,
                Foreground = Brushes.LightBlue,
                Margin = new Thickness(0, 5, 0, 5),
                TextWrapping = TextWrapping.Wrap
            };
            ChatStackPanel.Children.Add(botText);
            ScrollToBottom();
        }

        /// <summary>
        /// Scrolls the chat to the bottom.
        /// </summary>
        private void ScrollToBottom()
        {
            ChatScrollViewer.ScrollToEnd();
        }
    }
}