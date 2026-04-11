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
            // It plays when the appliaction is launched to welcome the user to the chatbot.
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
            // This is the menu options to allow the user to interact with the chatbot.
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
           // This is the method for when a user types in the option for phishing.
            UIHelper.TypeMessage("\n --- Phishing Awareness ---");
            UIHelper.TypeMessage(" 1. Look out for messages that display 'Urgent' in them as this can intimidate the user to react emotionally as scammers want you to panic.");
            UIHelper.TypeMessage(" 2. A User might receive an email from a bank and believe its real because it comes from a recognised brand. Do not click the message or link immediately. Verify the sender. A bank will never ask for your PIN via email. ");
            UIHelper.TypeMessage(" 3. Avoid suspicious links and attachments like zip. or .exe files. Attackers use fake messages to trick their victims into giving away sensitive information.");
            UIHelper.TypeMessage(" 4. Avoid using the same passwords on every application. If it is easy for you to login quickly it will be easier for the attacker.  Make sure to update your passwords at least every 6 months and choose appropriate statements instead of single or two-worded names that you know you won't forget!");
            Console.WriteLine("========================================================================================================================\n");
        }
        private void ShowPasswordAdvice()
        {
            // This is the method for when a user types in the option for password advice.
            UIHelper.TypeMessage("\n --- Password Saftey ---");
            UIHelper.TypeMessage(" 1. Use a 'Passphrase' instead of a password. It is longer and harder to crack. Example: 'MindYourOwnBuisnessIn2026!' is excellent");
            UIHelper.TypeMessage(" 2. Strong passwords makes them unique and can take up to years to be cracked. ");
            UIHelper.TypeMessage(" 3. If you are in a business, train your employees to identify phishing attacks and how to periodically update their passwords.");
            UIHelper.TypeMessage(" 4. Accounts should be locked after multiple failed login attempts. Having multi-factor layers of protection can prevent attacks.");
            Console.WriteLine("========================================================================================================================\n");
        }
        private void ShowSafeBrowsingAdvice()
        {
            // This is the method for when a user types in the option for safe browsing advice.
            UIHelper.TypeMessage("\n--- Safe Browsing ---");
            UIHelper.TypeMessage(" 1. Look for https://' and the padlock icon.");
            UIHelper.TypeMessage(" 2. Never perform banking on public Wi-Fi without a VPN.");
            UIHelper.TypeMessage(" 3. If theres an instance of a suspicious link, please be encouraged to manually type in the URL in the search bar before clicking the link to see if it exists and is well secured.");
            Console.WriteLine("========================================================================================================================\n");
        }

    }
}
