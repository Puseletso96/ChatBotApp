using CyberChatBotGui;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace CyberChatBotGui
{
    public partial class MainWindow : Window
    {
        private DatabaseHelper _db = new DatabaseHelper();
        private AudioPlayer _audioPlayer = new AudioPlayer();
        private ChatbotEngine _engine = new ChatbotEngine();
        private UserSession _session = new UserSession();
        private ActivityLog _activityLog = new ActivityLog();

        // The Quiz Class instance
        private Quiz _quiz = new Quiz();
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
            RefreshTasks();

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

            string tempTopic = _session.FavouriteTopic;
            string botResponse = _engine.GetResponse(input, _session.Name, ref tempTopic);
            _session.FavouriteTopic = tempTopic;

            // Catch Part 3 Triggers
            if (botResponse == "NLP_QUIZ_TRIGGER")
            {
                AddBotMessage("Starting the Cybersecurity Mini-Game...");
                _activityLog.AddAction("User started the Quiz");
                StartQuiz(); // FIX: Actually call the StartQuiz method!
                return;
            }

            if (botResponse == "NLP_TASK_TRIGGER")
            {
                string taskTitle = lowerInput.Replace("add task", "").Replace("remind me to", "").Trim();
                _db.AddTask(taskTitle, "Added via chat NLP", null);
                _activityLog.AddAction($"Task added: {taskTitle}");
                AddBotMessage($"Task added: '{taskTitle}'. You can view it in the Tasks tab.");
                TaskDataGrid.ItemsSource = _db.GetTasks();
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

        // ==================== TASKS TAB METHODS ====================
        private void RefreshTasks_Click(object sender, RoutedEventArgs e) => RefreshTasks();

        private void RefreshTasks()
        {
            TaskDataGrid.ItemsSource = _db.GetTasks();
        }

        private void AddTaskForm_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskTitleInput.Text.Trim();
            string desc = TaskDescInput.Text.Trim();
            DateTime? reminder = TaskDateInput.SelectedDate;

            if (string.IsNullOrEmpty(title))
            {
                MessageBox.Show("Please enter a task title.");
                return;
            }

            _db.AddTask(title, desc, reminder);
            TaskDataGrid.ItemsSource = _db.GetTasks();
            _activityLog.AddAction($"Task added from form: {title}");

            TaskTitleInput.Clear();
            TaskDescInput.Clear();
            TaskDateInput.SelectedDate = null;
        }

        private void CompleteTask_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                int taskId = int.Parse(btn.Tag.ToString());
                _db.MarkTaskCompleted(taskId);
                TaskDataGrid.ItemsSource = _db.GetTasks();
            }
        }

        private void DeleteTask_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn != null && btn.Tag != null)
            {
                int taskId = int.Parse(btn.Tag.ToString());
                _db.DeleteTask(taskId);
            }
        }

        // ==================== QUIZ TAB METHODS (Using the Quiz Class) ====================
        private void StartQuiz()
        {
            _quiz = new Quiz(); // Reset the quiz logic
            QuizPanel.Visibility = Visibility.Visible;
            ChatScrollViewer.Visibility = Visibility.Collapsed;
            QuizCloseBtn.Visibility = Visibility.Collapsed;
            ShowQuestion();
        }

        private void ShowQuestion()
        {
            if (_quiz.IsFinished())
            {
                QuizQuestionText.Text = "Quiz Complete!";
                QuizBtnA.Visibility = Visibility.Collapsed;
                QuizBtnB.Visibility = Visibility.Collapsed;
                QuizBtnC.Visibility = Visibility.Collapsed;
                QuizBtnD.Visibility = Visibility.Collapsed;
                QuizFeedbackText.Text = "";
                QuizScoreText.Text = $"Final Score: {_quiz.Score} / {_quiz.TotalQuestions()}";
                QuizCloseBtn.Visibility = Visibility.Visible;
                return;
            }

            var q = _quiz.GetCurrentQuestion();
            QuizQuestionText.Text = q.QuestionText;

            QuizBtnA.Content = q.Options[0]; QuizBtnA.Visibility = Visibility.Visible; QuizBtnA.IsEnabled = true;
            QuizBtnB.Content = q.Options[1]; QuizBtnB.Visibility = Visibility.Visible; QuizBtnB.IsEnabled = true;
            QuizBtnC.Content = q.Options[2]; QuizBtnC.Visibility = Visibility.Visible; QuizBtnC.IsEnabled = true;
            QuizBtnD.Content = q.Options[3]; QuizBtnD.Visibility = Visibility.Visible; QuizBtnD.IsEnabled = true;

            QuizFeedbackText.Text = "";
            QuizScoreText.Text = $"Current Score: {_quiz.Score}";
        }

        private void QuizAnswer_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int selectedIndex = int.Parse(btn.Tag.ToString());

            if (_quiz.CheckAnswer(selectedIndex))
            {
                QuizFeedbackText.Text = "Correct!";
                QuizFeedbackText.Foreground = Brushes.LightGreen;
            }
            else
            {
                QuizFeedbackText.Text = $"Incorrect. The answer was {_quiz.GetCurrentQuestion().Options[_quiz.GetCurrentQuestion().CorrectAnswerIndex]}";
                QuizFeedbackText.Foreground = Brushes.Red;
            }

            QuizBtnA.IsEnabled = false; QuizBtnB.IsEnabled = false;
            QuizBtnC.IsEnabled = false; QuizBtnD.IsEnabled = false;

            var timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1.5);
            timer.Tick += (s, ev) =>
            {
                timer.Stop();
                _quiz.MoveToNextQuestion();
                ShowQuestion();
            };
            timer.Start();
        }

        private void QuizClose_Click(object sender, RoutedEventArgs e)
        {
            QuizPanel.Visibility = Visibility.Collapsed;
            ChatScrollViewer.Visibility = Visibility.Visible;
            AddBotMessage("You returned from the quiz. What else can I help you with?");
        }
    }
}