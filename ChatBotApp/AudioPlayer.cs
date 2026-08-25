using System;
using System.Media;


namespace ChatbotApp
{ 
    public class AudioPlayer
    {
        public void PlayWelcomeMessage()
        {
            try
            {
                SoundPlayer play = new SoundPlayer("Welcomemassege.wav");
                play.Play();
            }
            catch (Exception ex) 
                
            {
                Console.WriteLine($"Error playing audio: {ex.Message}");
            }
           
         
        }
    }
   
}