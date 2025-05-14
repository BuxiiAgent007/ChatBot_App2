using System.IO;
using System.Media;
using System;

namespace ChatBot_App2
{
    public class voice_two
    {
        public voice_two()
        {
            //full location of the project
            string full_location = AppDomain.CurrentDomain.BaseDirectory;

            // replace the bin\Debug\Folder in the full_location
            string new_path = full_location.Replace("bin\\Debug\\", "");

            //try and catch statement
            try
            {
                // combine the paths 
                string full_path = Path.Combine(new_path, "greetings.wav");
                // instance for soundplay class
                using (SoundPlayer play = new SoundPlayer(full_path))
                {
                    //method for playing audio
                    play.PlaySync();
                } //end of using
            }

            catch (Exception error)
            {  //end of catch
                Console.Write(error.Message);
            }
        }// end of constructor 
    }// end of class
}// end of namespace
