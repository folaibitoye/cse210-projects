using System;
using System.Collections.Generic;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Mindfulness App");
                Console.WriteLine("Please choose an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine();

                if (choice == "4") break;

                Activity activity;
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        continue;
                }

                activity.StartActivity();
            }
        }
    }

    abstract class Activity
    {
        protected int duration;

        public void StartActivity()
        {
            ShowStartingMessage();
            PrepareToBegin();
            PerformActivity();
            ShowEndingMessage();
        }

        protected abstract void PerformActivity();

        protected void ShowStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"{GetType().Name} Activity");
            Console.WriteLine(GetDescription());
            Console.Write("Enter the duration of the activity in seconds: ");
            duration = int.Parse(Console.ReadLine());
        }

        protected void ShowEndingMessage()
        {
            Console.WriteLine("Good job!");
            PauseWithAnimation(2);
            Console.WriteLine($"You have completed the {GetType().Name} Activity for {duration} seconds.");
            PauseWithAnimation(2);
        }

        protected void PrepareToBegin()
        {
            Console.WriteLine("Prepare to begin...");
            PauseWithAnimation(3);
        }

        protected void PauseWithAnimation(int seconds)
        {
            for (int i = 0; i < seconds; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }

        protected abstract string GetDescription();
    }

    class BreathingActivity : Activity
    {
        protected override void PerformActivity()
        {
            int interval = 5;
            int cycles = duration / interval;
            for (int i = 0; i < cycles; i++)
            {
                Console.WriteLine("Breathe in...");
                PauseWithCountdown(interval / 2);
                Console.WriteLine("Breathe out...");
                PauseWithCountdown(interval / 2);
            }
        }

        protected override string GetDescription()
        {
            return "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.";
        }

        private void PauseWithCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i + " ");
                Thread.Sleep(1000);
            }
            Console.WriteLine();
        }
    }

    class ReflectionActivity : Activity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless."
        };

        private static readonly List<string> Questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            PauseWithAnimation(3);

            int remainingTime = duration;
            while (remainingTime > 0)
            {
                string question = Questions[random.Next(Questions.Count)];
                Console.WriteLine(question);
                PauseWithAnimation(5);
                remainingTime -= 5;
            }
        }

        protected override string GetDescription()
        {
            return "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.";
        }
    }

    class ListingActivity : Activity
    {
        private static readonly List<string> Prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "Who is your mentor?",
            "What are the motivations of your?",
            "When have you meditated on a Book this month?"
        };

        protected override void PerformActivity()
        {
            Random random = new Random();
            string prompt = Prompts[random.Next(Prompts.Count)];
            Console.WriteLine(prompt);
            PauseWithAnimation(3);

            Console.WriteLine("Start listing items:");
            int itemCount = 0;
            DateTime startTime = DateTime.Now;
            while ((DateTime.Now - startTime).TotalSeconds < duration)
            {
                Console.Write("> ");
                Console.ReadLine();
                itemCount++;
            }

            Console.WriteLine($"You listed {itemCount} items.");
        }

        protected override string GetDescription()
        {
            return "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.";
        }
    }
}
