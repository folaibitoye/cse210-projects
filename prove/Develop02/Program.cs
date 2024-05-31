using System;
using System.Collections.Generic;
using System.IO;

namespace DailyJournal
{
    class Program
    {
        static List<string> prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?",
            "What were the privacy concerns of my day?",
            "What was the greatest motivation of today?"
        };

        static List<Entry> journal = new List<Entry>();

        static void Main(string[] args)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("Daily Journal");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Exit");
                Console.Write("Choose an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        WriteNewEntry();
                        break;
                    case "2":
                        DisplayJournal();
                        break;
                    case "3":
                        SaveJournalToFile();
                        break;
                    case "4":
                        LoadJournalFromFile();
                        break;
                    case "5":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void WriteNewEntry()
        {
            Random random = new Random();
            int index = random.Next(prompts.Count);
            string prompt = prompts[index];

            Console.WriteLine(prompt);
            string response = Console.ReadLine();
            string date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            journal.Add(new Entry { Prompt = prompt, Response = response, Date = date });

            Console.WriteLine("Entry recorded.");
        }

        static void DisplayJournal()
        {
            if (journal.Count == 0)
            {
                Console.WriteLine("The journal is empty.");
                return;
            }

            foreach (var entry in journal)
            {
                Console.WriteLine($"Date: {entry.Date}");
                Console.WriteLine($"Prompt: {entry.Prompt}");
                Console.WriteLine($"Response: {entry.Response}");
                Console.WriteLine();
            }
        }

        static void SaveJournalToFile()
        {
            Console.Write("Enter the filename to save the journal: ");
            string filename = Console.ReadLine();

            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var entry in journal)
                {
                    writer.WriteLine(entry.Date);
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Response);
                    writer.WriteLine();
                }
            }

            Console.WriteLine("Journal saved.");
        }

        static void LoadJournalFromFile()
        {
            Console.Write("Enter the filename to load the journal: ");
            string filename = Console.ReadLine();

            if (!File.Exists(filename))
            {
                Console.WriteLine("File does not exist.");
                return;
            }

            journal.Clear();

            using (StreamReader reader = new StreamReader(filename))
            {
                string date, prompt, response;

                while ((date = reader.ReadLine()) != null)
                {
                    prompt = reader.ReadLine();
                    response = reader.ReadLine();
                    reader.ReadLine(); // Consume the empty line

                    journal.Add(new Entry { Date = date, Prompt = prompt, Response = response });
                }
            }

            Console.WriteLine("Journal loaded.");
        }

        class Entry
        {
            public string Date { get; set; }
            public string Prompt { get; set; }
            public string Response { get; set; }
        }
    }
}
