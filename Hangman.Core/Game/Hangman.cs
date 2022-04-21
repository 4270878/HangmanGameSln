using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;

        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {
            _renderer.Render(5, 5, 6);
           
            int lives = 6;
            
            bool win = false; //when player wins or loses

            int words = 0; //to show player the word they were trying to guess
            

            string[] storedwords = { "Tokyo", "Delhi", "Shanghai", "Sao Paulo", "Mexico City", "Dhaka", "Cairo", "Beijing", "Mumbai", "Cape Town", "Karachi",
                "Chongqing", "Istanbul", "Buenos Aires", "Durban", "Kinshasa", " Lagos", "Tianjin", "East Landon" };

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            var nextGuess = Console.ReadLine();

            //while (win && lives){}

            //_renderer.Render(5, 5, lives)
        }

    }
}
