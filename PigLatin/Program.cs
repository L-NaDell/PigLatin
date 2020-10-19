using System;
using System.Linq;

namespace PigLatin
{
    class Program
    {
        static void Main(string[] args)
        {
            bool again = true;
            char[] vowels = { 'a', 'e', 'i', 'o', 'u' };
            string input;

            Console.WriteLine("Welcome to the Pig Latin Translator!\n");

            do
            {
                Console.Write("Enter a line to be translated: ");
                input = Console.ReadLine().ToLower();
                string[] words = input.Split(" ");

                //check for input
                if (!string.IsNullOrWhiteSpace(input))
                {
                    //run PigLatin method
                    string result = PigLatin(words, vowels);

                    Console.WriteLine("\n" + result + "\n");

                    Console.Write("Translate another line? (y/n): ");
                    again = Console.ReadLine().ToLower().Trim() == "y";
                    Console.WriteLine();
                }
            }
            //run again
            while (again);

            Console.WriteLine("Goodbye!");
        }

        public static string PigLatin(string[] words, char[] vowels)
        {
            //split string into words
            for (int j = 0; j < words.Length; j++)
            {
                string word = words[j];

                //words that begin with a vowel are prefered
                if (vowels.Contains(word[0]))
                {
                    words[j] = $"{word}way";
                }
                //find first vowel
                for (int i = 1; i < word.Length; i++)
                {
                    if (vowels.Contains(word[i]))
                    {
                        //break into pre-vowel and remainder of word
                        string beginning = word.Substring(0, i);
                        string remainder = word.Substring(i);

                        //put word back together
                        words[j] = $"{remainder}{beginning}ay";
                    }
                }
            }
            //put words back together into string
            return string.Join(" ", words);
        }
    }
}
