using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CyberAwarenessBot
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. This displays the multimedia and visual setup ( from UIHelper.cs )
            UIHelper.PlayGreetingAudio();
            UIHelper.DisplayLogo();

            // 2. Initializes the chatbot ( from Chatbot.cs )
            ChatBot myAssistant = new ChatBot();

            // 3. Start the actual conversation
            myAssistant.StartConversation();

            // Keeps console open so that it does not disappear on its own
            Console.WriteLine("\n  Session ended. Press any key to close...");
            Console.ReadKey();

        }
    }
}
