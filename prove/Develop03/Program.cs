using System;
using System.Collections.Generic;
using System.Linq;

class ScriptureMemorizer
{
    private static Dictionary<string, string> scriptures = new Dictionary<string, string>
    {
        { "John 3:16", "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life." },
        { "Proverbs 3:5-6", "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight." },
        { "Philippians 4:13", "I can do all this through him who gives me strength." },
        { "Psalm 23:1-4", "The Lord is my shepherd, I lack nothing. He makes me lie down in green pastures, he leads me beside quiet waters, he refreshes my soul. He guides me along the right paths for his name’s sake. Even though I walk through the darkest valley, I will fear no evil, for you are with me; your rod and your staff, they comfort me." }
    };

    private static string reference;
    private static string[] words;
    private static List<int> hiddenIndices = new List<int>();
    private static Random random = new Random();

    static void Main(string[] args)
    {
        SelectRandomScripture();

        while (true)
        {
            Console.Clear();
            DisplayScripture();

            if (hiddenIndices.Count == words.Length)
            {
                Console.WriteLine("\nAll words are hidden. Program will end.");
                break;
            }

            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }
            else
            {
                HideRandomWords();
            }
        }
    }

    private static void SelectRandomScripture()
    {
        int index = random.Next(scriptures.Count);
        reference = scriptures.Keys.ElementAt(index);
        string scriptureText = scriptures.Values.ElementAt(index);

        words = scriptureText.Split(' ');
    }

    private static void DisplayScripture()
    {
        Console.WriteLine(reference);
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenIndices.Contains(i))
            {
                Console.Write("____ ");
            }
            else
            {
                Console.Write(words[i] + " ");
            }
        }
        Console.WriteLine();
    }

    private static void HideRandomWords()
    {
        int wordsToHide = random.Next(1, 4); // Hide 1 to 3 words at a time
        for (int i = 0; i < wordsToHide; i++)
        {
            int index;
            do
            {
                index = random.Next(words.Length);
            } while (hiddenIndices.Contains(index));

            hiddenIndices.Add(index);
        }
    }
}
