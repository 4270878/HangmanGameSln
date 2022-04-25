using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

            int word = 0; //to show player the word they were trying to guess
            string inner;
            char outter;

            List<char> correctAnswer = new List<char>();
            List<char> incorrectAnswer = new List<char>();

            string[] storedwords = { "Tokyo", "Delhi", "Shanghai", "Sao Paulo", "Mexico City", "Dhaka", "Cairo", "Beijing", "Mumbai", "Cape Town", "Karachi",
                "Chongqing", "Istanbul", "Buenos Aires", "Durban", "Kinshasa", " Lagos", "Tianjin", "East Landon" };

            Random random = new Random();

            string GuessedWord = storedwords[random.Next(0, storedwords.Length)];
            string wordToGuessLowercase = GuessedWord.ToLower();


            StringBuilder ShowToPlayer = new StringBuilder(GuessedWord.Length);
            for (int i = 0; i < GuessedWord.Length; i++)
                ShowToPlayer.Append('_');

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;

            Console.Write("What is your next guess: ");
            Console.WriteLine("--------------");

            var nextGuess = Console.ReadLine();
            Random randGen = new Random();
            var idx = randGen.Next(0, 9);
            string Myanswer = storedwords[idx];

            char[] guess = new char[Myanswer.Length];
            inner = Console.ReadLine().ToLower();
            outter = inner[0];

            //for (int p = 0; p < Myanswer.Length; p++)
            //   guess[p] = '*';

            while (win && lives > 0)
            {
                Console.Write("Guess a letter: ");
                Console.WriteLine("--------------");

                inner = Console.ReadLine().ToLower();
                outter = inner[0];

                if (correctAnswer.Contains(outter))
                {
                    Console.WriteLine("you've alreadly tried'{0'and it was correct!", guess);
                    continue;
                }
                else if (incorrectAnswer.Contains(outter))
                {
                    Console.WriteLine("You've already tired ' ', and it was wrong!", guess);
                    continue;
                }
                if (wordToGuessLowercase.Contains(outter))
                {
                    correctAnswer.Add(outter);

                    for (int i = 0; i < guess.Length; i++)
                    {
                        if (wordToGuessLowercase[i] == outter)
                        {
                            ShowToPlayer[i] = GuessedWord[i];
                            word++;
                        }
                    }

                    if (word == GuessedWord.Length)
                        win = true;
                }
                else
                {
                    incorrectAnswer.Add(outter);
                    Console.WriteLine("No, there's no ' ' in it!", guess);
                    lives--;
                }
                Console.WriteLine(ShowToPlayer.ToString());

            }
            if (win)
                Console.WriteLine("You won!");
            else
                Console.WriteLine("You lost! It was ' '", GuessedWord);


            Console.Write("Press Enter to exit...");
            Console.ReadLine();


            //_renderer.Render(5, 5, lives);
        }

    }
}
