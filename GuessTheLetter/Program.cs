using System;

namespace GuessTheLetter
{
    class Game
    {
        static void Main(string[] args)
        {
            string[] hiddenLetters = { "N", "E", "T" };
            string tryGuess = "";
            int countGuess = 0;
            int guessLimit = 10;
            int lettersGuessedCount = 0;
            bool guessLimitReached = false; // check each time if the user still has a try
            bool[] lettersGuessed = new bool[hiddenLetters.Length]; // An array to track which letters have been guessed

            while (!AllLettersGuessed(lettersGuessed) && !guessLimitReached)
            {
                if (countGuess < guessLimit)
                {
                    Console.Write("Enter the letter you're guessing: ");
                    tryGuess = Console.ReadLine().ToUpper(); // Convert the user input to uppercase to match the hiddenLetters

                    for (int i = 0; i < hiddenLetters.Length; i++)
                    {
                        if (!lettersGuessed[i] && tryGuess == hiddenLetters[i]) // check if letter already has been guessed and if it is one of the hidden letters
                        {
                            lettersGuessed[i] = true;
                            lettersGuessedCount++;
                            Console.WriteLine("Letters guessed: " + lettersGuessedCount);
                        }
                    }

                    countGuess++; // Counting how many times the user has tried to guess
                    Console.WriteLine("Guesses counted: " + countGuess);
                }
                else
                {
                    guessLimitReached = true;
                }
            }

            if (AllLettersGuessed(lettersGuessed))
            {
                Console.WriteLine("Good job! The three letters you had to guess were: " + string.Join(", ", hiddenLetters));
            }
            else
            {
                Console.WriteLine("Guess limit reached! Better luck next time!");
            }

            Console.ReadLine();
        }

        // Helper method to check if all letters have been guessed
        static bool AllLettersGuessed(bool[] lettersGuessed) // loop trough lettersGuessed array
        {
            foreach (bool letterGuessed in lettersGuessed)
            {
                if (!letterGuessed) // check if the current letter has not been guessed yet
                    return false;
            }
            return true;
        }
    }
}
