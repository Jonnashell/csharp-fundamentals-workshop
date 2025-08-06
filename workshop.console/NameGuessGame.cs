using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workshop.console
{
    public class NameGuessGame
    {
        private string _name;
        private int _count = 0;
        private Dictionary<int, char> guesses = new Dictionary<int, char>();
        private Dictionary<char, int> letterCount = new Dictionary<char, int>();
        //private Dictionary<char, int> letterCountGuessed = new Dictionary<char, int>();


        public NameGuessGame(string name)
        {
            _name = name.ToLower();
        }

        public void Start()
        {
            // Dictionary to track count of each letter in name
            foreach (char letter in _name)
            {
                // Increment value by 1
                if (letterCount.Keys.Contains(letter)) {
                    letterCount[letter]++;
                }
                else
                {
                    // Initialize value to 1 for new letters
                    letterCount[letter] = 1;
                }
            }

            while (true)
            {
                _count++;

                if (guesses.Count > 0)
                {
                    if (guesses.Count == _name.Length)
                    {
                        Console.WriteLine("Well done... you guessed the name!");
                        break;
                    }

                    foreach (KeyValuePair<int, char> kvp in guesses)
                    {
                        Console.WriteLine($"Key:{kvp.Key} Value: {kvp.Value}");
                    }

                }

                Console.WriteLine("Enter a single letter, or qqq to quit!");
                string input = Console.ReadLine();

                if (input == "qqq") break;

                if (input.Length != 1)
                {
                    Console.WriteLine($"Invalid input: {input}");
                    continue;
                }

                // Check if letter is in the name
                if (_name.Contains(input, StringComparison.OrdinalIgnoreCase))
                {

                    // Check if letter is already guessed enough times
                    if (guesses.ContainsValue(Convert.ToChar(input)) && letterCount[Convert.ToChar(input)] <= 0)
                    {
                        continue;
                    }

                    Console.WriteLine("Letter is in the name!");

                    // Update guessing variables
                    guesses.Add(_count, char.Parse(input));
                    letterCount[Convert.ToChar(input)] -= 1;
                }
            }
        }
    }
}
