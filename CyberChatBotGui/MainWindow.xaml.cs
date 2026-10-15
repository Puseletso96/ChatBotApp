using CyberChatbotGui;
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
        private ChatbotEngine _engine = new ChatbotEngine();
        private UserSession _session = new UserSession();

        private const string DIVIDER = "================================";

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

            // Welcome message (Using the new bubble methods)
            AddBotMessage(DIVIDER);
            AddBotMessage("WELCOME TO THE CYBERCHATBOT SYSTEM");
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

            // Show user's message (Using the new bubble method)
            AddUserMessage(input);
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();

            // If name hasn't been set, save it
            if (string.IsNullOrEmpty(_session.Name))
            {
                _session.Name = input;
                AddBotMessage($"Welcome, {_session.Name}! You are now connected to the CyberChatbot System.");
                AddBotMessage(DIVIDER);
                AddBotMessage($"I can help you with passwords, phishing, safe browsing, and privacy. What would you like to know, {_session.Name}?");
            }
            else
            {
               
                string tempTopic = _session.FavouriteTopic;
                string botResponse = _engine.GetResponse(input, _session.Name, ref tempTopic);

                // Save the updated topic back into the session memory
                _session.FavouriteTopic = tempTopic;

                AddBotMessage(botResponse);
            }
        }

        // ==================== CHAT BUBBLE METHODS ====================

        private void AddUserMessage(string message)
        {
            // Create the text inside the bubble
            TextBlock text = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10, 5, 10, 5)
            };

            // Create the bubble itself
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x3D, 0x27, 0x5E)), // A medium purple
                CornerRadius = new CornerRadius(10),
                Margin = new Thickness(80, 5, 0, 5), // Pushes the bubble to the right
                HorizontalAlignment = HorizontalAlignment.Right,
                MaxWidth = 400, // Prevents the bubble from getting too wide
                Child = text
            };

            // Add the bubble to the chat panel
            ChatStackPanel.Children.Add(bubble);

            // Scroll to the bottom
            ChatScrollViewer.ScrollToEnd();
        }

        private void AddBotMessage(string message)
        {
            // Create the text inside the bubble
            TextBlock text = new TextBlock
            {
                Text = message,
                Foreground = Brushes.White,
                TextWrapping = TextWrapping.Wrap,
                Margin = new Thickness(10, 5, 10, 5)
            };

            // Create the bubble itself
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1A, 0x10, 0x25)), // A dark navy/purple
                CornerRadius = new CornerRadius(10),
                Margin = new Thickness(0, 5, 80, 5), // Pushes the bubble to the left
                HorizontalAlignment = HorizontalAlignment.Left,
                MaxWidth = 400,
                Child = text
            };

            // Add the bubble to the chat panel
            ChatStackPanel.Children.Add(bubble);

            // Scroll to the bottom
            ChatScrollViewer.ScrollToEnd();
        }
    }
}