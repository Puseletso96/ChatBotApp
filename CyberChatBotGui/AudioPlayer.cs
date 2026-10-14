using System;
using System.IO;
using System.Media;

namespace CyberChatBotGui
{

    /// Plays the voice greeting WAV file.
    /// </summary>
    public class AudioPlayer
    {

        /// Plays the greeting WAV file.
        /// </summary>
        public void PlayGreeting()
        {
            try
            {
                // Look for the WAV file in the output folder
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
                    Console.WriteLine($"Audio file not found at: {audioPath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
        }
    }
}