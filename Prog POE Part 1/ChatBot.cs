using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    // This is the logic of the CyberAwareness Chatbot.
    public class ChatBot
    {
        public string? Username { get; set; }

        public void StartConversation()
        {
            // This is the statement that is said in the voice greeting.
            UIHelper.TypeMessage(" Hello! I am your Cybersecurity Awareness Assistant.");
            UIHelper.TypeMessage(" Before we begin, what is your name? ");

            Console.WriteLine();
            Username = Console.ReadLine();

            // User input validation
            while (string.IsNullOrWhiteSpace(Username))
            {
                Console.WriteLine(" Entry can not be empty. Please enter your name:");
                Username = Console.ReadLine()!;

            }
            UIHelper.TypeMessage($"\n I've been looking forward to meeting you, {Username}!");
            ShowMenu();

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write($"\n [{Username}]: ");
                string? input = Console.ReadLine()?.ToLower().Trim();

                if (string.IsNullOrEmpty(input)) continue;
                // I used the 'switch' statement and 'if' logic to handle the users response choices such as Phishing, Password, and Safe Browsing.
                switch (input)
                {
                    case "how are you?":
                        UIHelper.TypeMessage(" I am running smoothly and ready to help you secure your digital life!");
                        Console.WriteLine("============================================================\n");
                        break;
                    case "what is your purpose?":
                        UIHelper.TypeMessage(" I am part of a national campaign to help South Africans identify and mitigate cyber threats.");
                        Console.WriteLine("============================================================\n");
                        break;
                    case "phishing":
                        ShowPhishingAdvice();
                        break;
                    case "passwords":
                        ShowPasswordAdvice();
                        break;
                    case "browsing":
                        ShowSafeBrowsingAdvice();
                        break;
                    case "exit":
                        UIHelper.TypeMessage(" Keep your data safe! Goodbye.");
                        isRunning = false;
                        break;

                    default:
                        UIHelper.TypeMessage(" I did not quite understand that. Try asking about phishing, passwords, or browsing.");
                        break;
                }
            }
        }
        private void ShowMenu()
        {
            Console.WriteLine("============================================================\n");
            Console.WriteLine("\n You can ask me questions like...: ");
            Console.WriteLine(" - 'how are you?'");
            Console.WriteLine(" - 'What is your purpose?'");
            Console.WriteLine(" -  Or just ask me about 'Phishing' ( Emails & SMS scams)");
            Console.WriteLine(" - 'Passwords' ( Safe practices)"); 
            Console.WriteLine(" - 'Browsing' ( Safe links)");
            Console.WriteLine(" -  Or type in 'Exit' whenever you want to close the program");
            Console.WriteLine("============================================================\n");

        }
        private void ShowPhishingAdvice()
        {
           
            UIHelper.TypeMessage("\n --- Phishing Awareness ---");
            UIHelper.TypeMessage(" 1. Check for 'Urgent' language. Scammers want you to panic.");
            UIHelper.TypeMessage(" 2. Verify the sender. A bank will never ask for your PIN via email.");
            UIHelper.TypeMessage(" 3. Avoid suspicious attachments like zip. or .exe files.");
            Console.WriteLine("============================================================\n");
        }
        private void ShowPasswordAdvice()
        {
            UIHelper.TypeMessage("\n --- Password Saftey ---");
            UIHelper.TypeMessage(" Use a 'Passphrase' instead of a password. It is longer and harder to crack.");
            UIHelper.TypeMessage(" Example: 'MindYourOwnBuisnessIn2026!' is excellent");
            Console.WriteLine("============================================================\n");
        }
        private void ShowSafeBrowsingAdvice()
        {
            UIHelper.TypeMessage("\n--- Safe Browsing ---");
            UIHelper.TypeMessage(" Look for https://' and the padlock icon.");
            UIHelper.TypeMessage(" Never perform banking on public Wi-Fi without a VPN.");
            Console.WriteLine("============================================================\n");
        }

    }
}
