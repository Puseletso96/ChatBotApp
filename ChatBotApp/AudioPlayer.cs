using System;
using System.Media;


namespace ChatBotApp
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