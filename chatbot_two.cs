using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace ChatBot_App2
{
    public class chatbot_two
    {
        // Class fields and initialization
        private Dictionary<string, Topic> topics;
        private string userName;
        private string favoriteTopic;
        private string lastTopic;
        private Random random = new Random();

        private List<string> positiveSentiments = new List<string> { "curious", "interested", "excited", "happy", "enthusiastic" };
        private List<string> negativeSentiments = new List<string> { "worried", "frustrated", "scared", "concerned", "anxious", "overwhelmed" };

        public chatbot_two()
        {
            // Initializing topics with their responses
            topics = new Dictionary<string, Topic>(StringComparer.OrdinalIgnoreCase)
            {
                ["password"] = new Topic("password", new[]
                {
                    "Make sure to use strong, unique passwords for each account. Avoid using personal details in your passwords.",
                    "Consider using a password manager to generate and store complex passwords securely.",
                    "Change your passwords regularly and avoid reusing them across different accounts.",
                    "Enable two-factor authentication wherever possible for an extra layer of security.",
                    "Avoid using the same password across multiple sites to minimize risk."
                }),
                ["scam"] = new Topic("scam", new[]
                {
                    "Be cautious of unsolicited messages or calls asking for personal information.",
                    "Scammers often disguise themselves as trusted organizations. Always verify before responding.",
                    "If something sounds too good to be true, it probably is. Stay vigilant!",
                    "Never share your personal information over the phone unless you initiated the call.",
                    "Report any suspicious activity to the relevant authorities immediately."
                }),
                ["privacy"] = new Topic("privacy", new[]
                {
                    "Review the privacy settings on your accounts regularly.",
                    "Limit the amount of personal information you share online.",
                    "Use encrypted messaging apps to protect your conversations.",
                    "Be aware of the data you share with apps and websites; read their privacy policies.",
                    "Consider using a VPN to enhance your online privacy."
                }),
                ["phishing"] = new Topic("phishing", new[]
                {
                    "Phishing is a tactic used by hackers to trick users into providing sensitive information.",
                    "Always check the sender's email address and look for signs of phishing, such as poor grammar or urgent requests.",
                    "Never click on links or download attachments from unknown sources, as they may lead to phishing sites.",
                    "Be cautious of emails that create a sense of urgency; they are often phishing attempts.",
                    "Use anti-phishing tools and browser extensions to help identify potential threats."
                }),
                ["safe browsing"] = new Topic("safe browsing", new[]
                {
                    "Use HTTPS, keep software updated, and use reputable security software.",
                    "Be cautious with public Wi-Fi; avoid accessing sensitive information when connected to unsecured networks.",
                    "Always verify the legitimacy of websites before entering personal information.",
                    "Clear your browser cache regularly to protect your privacy.",
                    "Consider using browser extensions that block ads and trackers."
                }),
                ["how are you"] = new Topic("how are you", new[]
                {
                    "I'm feeling chatty and good :)",
                    "I'm here and ready to help you with your cybersecurity questions!",
                    "Feeling great! How about you?"
                }),
                ["what's your purpose"] = new Topic("what's your purpose", new[]
                {
                    "My purpose is to teach you everything I know about Cybersecurity and help you stay safe on the internet.",
                    "I'm here to provide you with information and tips on staying secure online.",
                    "My goal is to assist you in understanding cybersecurity better."
                }),
                ["what can i ask you about"] = new Topic("what can i ask you about", new[]
                {
                    "You can ask me anything about Cybersecurity, and I will tell you everything I know about it, deal?",
                    "Feel free to ask about topics like passwords, scams, privacy, and more!",
                    "I'm here to answer all your questions related to cybersecurity."
                }),
            };

            // Display welcome message and prompt for user details
            Console.ForegroundColor = ConsoleColor.Green;
            DisplayHeader("Welcome to our ChatBot");
            Console.ResetColor();

            Console.Write("Please enter your name: ");
            userName = Console.ReadLine();

            Console.ForegroundColor = ConsoleColor.Red;
            TypeEffect($"\nHello, {userName}! Welcome to our CyberSecurity FAQS. You can ask me about cybersecurity, or type 'exit' to leave");
            Console.ResetColor();

            // Ask for user's favorite topic to personalize conversation
            Console.Write($"\n{userName}, what's your favorite cybersecurity topic (e.g., password, scam, privacy)? ");
            string favInput = Console.ReadLine()?.ToLower().Trim();
            if (!string.IsNullOrWhiteSpace(favInput) && topics.Keys.Any(k => favInput.Contains(k)))
            {
                favoriteTopic = topics.Keys.First(k => favInput.Contains(k));
                Console.ForegroundColor = ConsoleColor.Cyan;
                TypeEffect($"Great! I'll remember that you're interested in {favoriteTopic}. It's a crucial part of staying safe online.");
                Console.ResetColor();
            }

            // Main chat loop, continues until user types 'exit'
            bool chatting = true;
            while (chatting)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write($"\n{userName}: ");
                string userInput = Console.ReadLine()?.ToLower().Trim();
                Console.ResetColor();

                Console.WriteLine(new string('=', 120));

                // Check if user wants to exit
                if (userInput == "exit")
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    TypeEffect("Chatbot: Goodbye! Stay safe online.");
                    Console.ResetColor();
                    chatting = false;
                    continue;
                }

                // Detect sentiment in input
                string sentiment = DetectSentiment(userInput);

                // Generate chatbot response
                string response = GetCyberSecurityResponse(userInput, sentiment);

                // Personalize response if user's favorite topic matches
                if (favoriteTopic != null && userInput.Contains(favoriteTopic))
                {
                    response = $"As someone interested in {favoriteTopic}, {response}";
                }

                Console.ForegroundColor = ConsoleColor.Magenta;
                TypeEffect($"-- Chatbot: {response}");
                Console.ResetColor();
            }
        }

        // Displays a header 
        private void DisplayHeader(string header)
        {
            string border = new string('=', 150);
            Console.WriteLine(border);
            Console.WriteLine(header.PadLeft((border.Length + header.Length) / 2));
            Console.WriteLine(border);
        }

        // Generates response based on user question and detected sentiment
        string GetCyberSecurityResponse(string question, string sentiment)
        {
            if (string.IsNullOrWhiteSpace(question))
            {
                return "I didn't quite understand that. Could you rephrase?";
            }

            // Respond based on negative sentiments
            if (sentiment == "worried" || sentiment == "frustrated" || sentiment == "scared" || sentiment == "concerned" || sentiment == "anxious" || sentiment == "overwhelmed")
            {
                return "It's completely understandable to feel that way. Cybersecurity can be overwhelming, but I'm here to help you and feel safe! " +
                       GetTopicResponse(question);
            }

            // Respond based on positive sentiments
            if (sentiment == "curious" || sentiment == "interested" || sentiment == "excited" || sentiment == "happy" || sentiment == "enthusiastic")
            {
                return "I admire your curiosity! Be careful though because curiosity killed a cat lol " + GetTopicResponse(question);
            }

            // Respond based on topic keywords
            string topicResponse = GetTopicResponse(question);
            if (topicResponse != null)
                return topicResponse;

            // Continue previous topic if user asks for more details
            if (question.Contains("more") && lastTopic != null && topics.ContainsKey(lastTopic))
                return topics[lastTopic].GetRandomResponse();

            // Default fallback response for unrecognized input
            return "I didn't quite understand that. Could you rephrase?";
        }

        // Helper method to get response for topic and update lastTopic
        private string GetTopicResponse(string question)
        {
            foreach (var key in topics.Keys)
            {
                if (question.Contains(key))
                {
                    lastTopic = key;
                    return topics[key].GetRandomResponse();
                }
            }
            return null;
        }

        // Detects sentiment by matching known positive or negative keywords in input
        private string DetectSentiment(string input)
        {
            if (negativeSentiments.Any(s => input.Contains(s)))
                return negativeSentiments.First(s => input.Contains(s));
            if (positiveSentiments.Any(s => input.Contains(s)))
                return positiveSentiments.First(s => input.Contains(s));
            return null;
        }

        // Simulates typing effect for chatbot responses
        private void TypeEffect(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
    }

    // Represents a cybersecurity topic with multiple responses
    public class Topic
    {
        public string Keyword { get; }
        private string[] Responses { get; }

        public Topic(string keyword, string[] responses)
        {
            Keyword = keyword;
            Responses = responses;
        }

        // Returns a random response under this topic
        public string GetRandomResponse()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            int index = random.Next(Responses.Length);
            return Responses[index];
        } // end of constructor
    } // end of class
} // end of namespace
