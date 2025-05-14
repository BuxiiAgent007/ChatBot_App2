using System.IO;
using System;
using System.Drawing;


namespace ChatBot_App2
{
    public class logo_two
    {
        public logo_two()
        {
            // Get full location of the project 
            string fullLocation = AppDomain.CurrentDomain.BaseDirectory;

            // Replace bin/Debug/
            string newLocation = fullLocation.Replace("bin\\Debug\\", "");

            // Combine file paths
            string fullPath = Path.Combine(newLocation, "logo.jpg");

            // Creating the Bitmap class
            Bitmap image = new Bitmap(fullPath);
            // Then set the size 
            image = new Bitmap(image, new Size(150, 120));

            // Outer and inner loop
            for (int height = 0; height < image.Height; height++)
            {
                // Inner loop
                for (int width = 0; width < image.Width; width++)
                {
                    Color pixelColor = image.GetPixel(width, height);
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                    // Adjusted thresholds for better visibility
                    char asciiChar = gray > 230 ? '&' :
                                     gray > 200 ? '=' :
                                     gray > 170 ? '*' :
                                     gray > 140 ? '.' :
                                     gray > 100 ? '0' :
                                     gray > 70 ? '#' :
                                     '@';

                    Console.Write(asciiChar);
                } // End of inner
                Console.WriteLine();
            } // End of outer

        }//end of constructor 
    } //end of class
} // end of name space

