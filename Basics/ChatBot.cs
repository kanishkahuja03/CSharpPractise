using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;
using System.Linq;

namespace ChatBot
{
    class Program
    {
        static void Main()
        {
            ChatBot bot = new ChatBot("CSharpBot");
            bot.Start();
        }
    }
    class ChatBot
    {
        private readonly string _name;

        // Keywords
        private Dictionary<string, List<string>> _intentKeywords;

        // Responses
        private Dictionary<string, List<string>> _responses;

        // Session memory
        private BotMemory _memory;

        private Random _random = new Random();

        public ChatBot(string name)
        {
            _name = name;
            _memory = new BotMemory();
            InitializeKnowledge();
        }

        public void Start()
        {
            Console.WriteLine($"Hello! I am {_name}. Type /help for commands.");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                    continue;

                if (HandleCommand(input))
                    continue;

                string response = GenerateResponse(input);
                Console.WriteLine(response);
            }
        }

        // COMMAND HANDLER
        private bool HandleCommand(string input)
        {
            if (!input.StartsWith("/"))
                return false;

            switch (input.ToLower())
            {
                case "/help":
                    Console.WriteLine("Commands:");
                    Console.WriteLine("/teach - teach me something");
                    Console.WriteLine("/stats - show memory");
                    Console.WriteLine("/exit - quit");
                    return true;

                case "/teach":
                    Teach();
                    return true;

                case "/stats":
                    ShowStats();
                    return true;

                case "/exit":
                    Environment.Exit(0);
                    return true;

                default:
                    Console.WriteLine("Unknown command.");
                    return true;
            }
        }

        // RESPONSE ENGINE
        private string GenerateResponse(string input)
        {
            input = input.ToLower();

            // Learned knowledge has priority
            if (_memory.LearnedKnowledge.ContainsKey(input))
                return _memory.LearnedKnowledge[input];

            string bestIntent = DetectIntent(input);

            if (bestIntent == "unknown")
                return "I don't understand that yet.";

            _memory.LastIntent = bestIntent;

            return GetRandomResponse(bestIntent);
        }

        // INTENT DETECTION
        private string DetectIntent(string input)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>();

            foreach (var intent in _intentKeywords)
            {
                int score = 0;

                foreach (string keyword in intent.Value)
                {
                    if (input.Contains(keyword))
                        score++;
                }

                scores[intent.Key] = score;
            }

            var bestMatch = scores.OrderByDescending(s => s.Value).First();

            return bestMatch.Value > 0 ? bestMatch.Key : "unknown";
        }

        // RESPONSE SELECTION
        private string GetRandomResponse(string intent)
        {
            List<string> possibleResponses = _responses[intent];
            return possibleResponses[_random.Next(possibleResponses.Count)];
        }

        // LEARNING
        private void Teach()
        {
            Console.Write("What should I respond to? ");
            string question = Console.ReadLine().ToLower();

            Console.Write("What is the correct answer? ");
            string answer = Console.ReadLine();

            _memory.LearnedKnowledge[question] = answer;

            Console.WriteLine("I learned something new!");
        }

        // STATS
        private void ShowStats()
        {
            Console.WriteLine("BOT MEMORY");
            Console.WriteLine($"Learned phrases: {_memory.LearnedKnowledge.Count}");
            Console.WriteLine($"Last intent: {_memory.LastIntent}");
        }

        // INITIAL DATA
        private void InitializeKnowledge()
        {
            _intentKeywords = new Dictionary<string, List<string>>
            {
                { "greeting", new List<string>{ "hello", "hi", "hey" } },
                { "name", new List<string>{ "name", "who are you" } },
                { "csharp", new List<string>{ "c#", "csharp", "dotnet" } },
                { "mood", new List<string>{ "how are you", "feeling" } }
            };

            _responses = new Dictionary<string, List<string>>
            {
                { "greeting", new List<string>
                    {
                        "Hello there!",
                        "Hi! Nice to meet you.",
                        "Hey!"
                    }
                },
                { "name", new List<string>
                    {
                        $"I am {_name}, written in C#.",
                        "I'm a C# console chatbot."
                    }
                },
                { "csharp", new List<string>
                    {
                        "C# is a modern, object-oriented language.",
                        "C# works great with .NET."
                    }
                },
                { "mood", new List<string>
                    {
                        "I'm just code, but I'm running fine!",
                        "Feeling logical today."
                    }
                }
            };

            _memory.LearnedKnowledge = new Dictionary<string, string>();
        }
    }

    // MEMORY
    class BotMemory
    {
        public string LastIntent { get; set; } = "none";
        public Dictionary<string, string> LearnedKnowledge;
    }
}

