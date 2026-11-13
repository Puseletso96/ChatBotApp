using System;
using System.Collections.Generic;

namespace CyberChatBotGui
{
    public class Quiz
    {
        
        public class QuizQuestion
        {
            public string QuestionText { get; set; }
            public string[] Options { get; set; }
            public int CorrectAnswerIndex { get; set; }
        }

        private List<QuizQuestion> _questions;
        private int _currentQuestionIndex;
        public int Score { get; private set; }

        public Quiz()
        {
            Score = 0;
            _currentQuestionIndex = 0;
            LoadQuestions();
        }

        private void LoadQuestions()
        {
            _questions = new List<QuizQuestion>
            {
                new QuizQuestion { QuestionText = "What should you do if you receive an email asking for your password?", Options = new[] { "A) Reply with your password", "B) Delete the email", "C) Report it as phishing", "D) Ignore it" }, CorrectAnswerIndex = 2 },
                new QuizQuestion { QuestionText = "True or False: It is safe to use the same password for all accounts.", Options = new[] { "A) True", "B) False", "C) Only for social media", "D) None of the above" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "What does 'HTTPS' at the beginning of a URL mean?", Options = new[] { "A) The site is fast", "B) The site is secure", "C) The site is free", "D) The site is popular" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "What is a common sign of a phishing scam?", Options = new[] { "A) Urgent language demanding action", "B) Poor grammar and spelling", "C) Unknown sender address", "D) All of the above" }, CorrectAnswerIndex = 3 },
                new QuizQuestion { QuestionText = "Which of the following is a strong password?", Options = new[] { "A) password123", "B) 12345678", "C) P@ssw0rd!2024", "D) qwerty" }, CorrectAnswerIndex = 2 },
                new QuizQuestion { QuestionText = "What should you do before clicking a link in an email?", Options = new[] { "A) Click it immediately", "B) Hover over it to see the real URL", "C) Forward it to a friend", "D) Delete the whole email" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "What is social engineering?", Options = new[] { "A) Building social media apps", "B) Manipulating people to reveal information", "C) A type of firewall", "D) A programming language" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "True or False: Public Wi-Fi is always safe to use for banking.", Options = new[] { "A) True", "B) False", "C) Only if it has a password", "D) None of the above" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "What is malware?", Options = new[] { "A) A type of hardware", "B) Malicious software", "C) A secure network", "D) An email protocol" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "Why should you keep your software updated?", Options = new[] { "A) To get new emojis", "B) To patch security vulnerabilities", "C) To make your PC louder", "D) To use more data" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "What is Two-Factor Authentication (2FA)?", Options = new[] { "A) A password with two numbers", "B) An extra layer of security requiring a second form of verification", "C) Using two different passwords", "D) A type of antivirus software" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "If a website asks you to install a strange plugin to watch a video, what should you do?", Options = new[] { "A) Install it immediately", "B) Close the website and leave", "C) Ask a friend to install it", "D) Turn off your antivirus" }, CorrectAnswerIndex = 1 },
                new QuizQuestion { QuestionText = "Why is it dangerous to use public Wi-Fi without a VPN?", Options = new[] { "A) It is slower", "B) Hackers can intercept your unencrypted data", "C) It drains your battery", "D) It costs money" }, CorrectAnswerIndex = 1 }
            };
        }

        public QuizQuestion GetCurrentQuestion()
        {
            if (_currentQuestionIndex < _questions.Count)
                return _questions[_currentQuestionIndex];
            return null;
        }

        public bool CheckAnswer(int selectedIndex)
        {
            bool isCorrect = selectedIndex == _questions[_currentQuestionIndex].CorrectAnswerIndex;
            if (isCorrect) Score++;
            return isCorrect;
        }

        public void MoveToNextQuestion()
        {
            _currentQuestionIndex++;
        }

        public bool IsFinished()
        {
            return _currentQuestionIndex >= _questions.Count;
        }

        public int TotalQuestions()
        {
            return _questions.Count;
        }
    }
}