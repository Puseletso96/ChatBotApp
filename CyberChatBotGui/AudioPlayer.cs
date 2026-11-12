using System;
using System.IO;
using System.Media;

namespace CyberChatBotGui
{
    public class AudioPlayer
    {
        public void PlayGreeting()
        {
            try
            {
                string audioPath = Path.Combine(
                    AppDomain.CurrentDomain.BaseDirectory,
                    "WelcomeMassege.wav"
                );

                if (File.Exists(audioPath))
                {
                    SoundPlayer player = new SoundPlayer(audioPath);
                    player.Play(); 
                }
                else
                {
                    System.Windows.MessageBox.Show($"Audio file not found at: {audioPath}\nPlease ensure the .wav file is in the project and set to 'Copy if newer'.");
                }
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show($"Error playing audio: {ex.Message}");
            }
        }
    }
}