using CyberChatBotGui;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CyberChatBotGui
{
    public partial class MainWindow : Window
    {
        private DatabaseHelper _db = new DatabaseHelper();
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private ChatbotEngine _engine = new ChatbotEngine();
        private UserSession _session = new UserSession();
        private ActivityLog _activityLog = new ActivityLog();
        private bool _isLoaded = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (_isLoaded) return;
            _isLoaded = true;

            _audioPlayer.PlayGreeting();

            string asciiArt = @" 
   ______      __              _____                      _ __           ___                                                   ____        __ 
  / ____/_  __/ /_  ___  _____/ ___/___  _______  _______(_) /___  __   /   |_      ______ _________  ____  ___  __________   / __ )____  / /_
 / /   / / / / __ \/ _ \/ ___/\__ \/ _ \/ ___/ / / / ___/ / __/ / / /  / /| | | /| / / __ `/ ___/ _ \/ __ \/ _ \/ ___/ ___/  / __  / __ \/ __/
/ /___/ /_/ / /_/ /  __/ /   ___/ /  __/ /__/ /_/ / /  / / /_/ /_/ /  / ___ | |/ |/ / /_/ / /  /  __/ / / /  __(__  |__  )  / /_/ / /_/ / /_  
\____/\__, /_.___/\___/_/   /____/\___/\___/\__,_/_/  /_/\__/\__, /  /_/  |_|__/|__/\__,_/_/   \___/_/ /_/\___/____/____/  /_____/\____/\__/  
     /____/                                                 /____/                                                                            
";
            AsciiArtTextBlock.Text = asciiArt;

            AddBotMessage("==============================================");
            AddBotMessage("WELCOME TO THE CYBERCHATBOT SYSTEM");
            AddBotMessage("==============================================");
            AddBotMessage("Please enter your name:");
        }

        private void SendButton_Click(object sender, RoutedEventArgs e) => ProcessUserInput();

        private void UserInputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                e.Handled = true;
                ProcessUserInput();
            }
        }

        private void VoiceButton_Click(object sender, RoutedEventArgs e) => _audioPlayer.PlayGreeting();

        private void ProcessUserInput()
        {
            string input = UserInputTextBox.Text?.Trim() ?? "";
            if (string.IsNullOrEmpty(input)) return;

            AddUserMessage(input);
            UserInputTextBox.Clear();
            UserInputTextBox.Focus();

            string lowerInput = input.ToLower();

            if (lowerInput == "exit" || lowerInput == "quit" || lowerInput == "bye")
            {
                string name = string.IsNullOrEmpty(_session.Name) ? "friend" : _session.Name;
                AddBotMessage($"Goodbye, {name}! Remember: Stay Safe, Stay Secure, Stay Smart!");
                System.Threading.Thread.Sleep(1500);
                Application.Current.Shutdown();
                return;
            }

            if (string.IsNullOrEmpty(_session.Name))
            {
                _session.Name = input;
                AddBotMessage($"Welcome, {_session.Name}! I can help you with passwords, phishing, safe browsing, scams, and privacy.");
                return;
            }

            // 3. Pass input to the Chatbot Engine (NLP, Sentiment, Memory)
            string tempTopic = _session.FavouriteTopic;
            string botResponse = _engine.GetResponse(input, _session.Name, ref tempTopic);
            _session.FavouriteTopic = tempTopic;

            // 4. Catch Part 3 Triggers from the Engine
            if (botResponse == "NLP_QUIZ_TRIGGER")
            {
                AddBotMessage("Starting the Cybersecurity Mini-Game...");
                _activityLog.AddAction("User started the Quiz");


                AddBotMessage("Quiz finished! What else can I help you with?");
                return;
            }

            if (botResponse == "NLP_TASK_TRIGGER")
            {
                string taskTitle = lowerInput.Replace("add task", "").Replace("remind me to", "").Trim();

                _db.AddTask(taskTitle, "Added via chat NLP", null);
                _activityLog.AddAction($"Task added: {taskTitle}");

                AddBotMessage($"Task added: '{taskTitle}'. You can view it in the Tasks tab.");
                TaskListBox.ItemsSource = _db.GetTasks();
                return;
            }

            if (botResponse == "NLP_LOG_TRIGGER")
            {
                AddBotMessage(_activityLog.GetLogSummary());
                return;
            }

            AddBotMessage(botResponse);
        }

        private void AddUserMessage(string message)
        {
            TextBlock text = new TextBlock { Text = message, Foreground = Brushes.White, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(10, 5, 10, 5) };
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x3D, 0x27, 0x5E)),
                CornerRadius = new CornerRadius(10),
                Margin = new Thickness(80, 5, 0, 5),
                HorizontalAlignment = HorizontalAlignment.Right,
                MaxWidth = 400,
                Child = text
            };
            ChatStackPanel.Children.Add(bubble);
            Dispatcher.BeginInvoke(new Action(() => ChatScrollViewer.ScrollToEnd()));
        }

        private void AddBotMessage(string message)
        {
            TextBlock text = new TextBlock { Text = message, Foreground = Brushes.White, TextWrapping = TextWrapping.Wrap, Margin = new Thickness(10, 5, 10, 5) };
            Border bubble = new Border
            {
                Background = new SolidColorBrush(Color.FromRgb(0x1A, 0x10, 0x25)),
                CornerRadius = new CornerRadius(10),
                Margin = new Thickness(0, 5, 80, 5),
                HorizontalAlignment = HorizontalAlignment.Left,
                MaxWidth = 400,
                Child = text
            };
            ChatStackPanel.Children.Add(bubble);
            Dispatcher.BeginInvoke(new Action(() => ChatScrollViewer.ScrollToEnd()));
        }

        private void RefreshTasks_Click(object sender, RoutedEventArgs e)
        {
            TaskListBox.ItemsSource = _db.GetTasks();
        }
    }
}