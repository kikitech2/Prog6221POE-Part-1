// See https://aka.ms/new-console-template for more information
using System;
using System.Media;
using System.Threading;

namespace CyberAwarenessBot
{
    public static class UIHelper
    {
        public static void PlayGreetingAudio()
        {
            try
            {
                // The greeting.wav is the name of the flie.
                SoundPlayer player = new SoundPlayer("greeting.wav");
                player.Play();
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Audio System: File not found, continuing with text only...]");
            }
        }
        public static void DisplayLogo()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;

            // Each string here is exactly the same length to keep the borders straight
            string[] logoLines = {
        "============================================================",
        "  ______ _    _  _   _____  _____  _____  ___   _   _  _____ ",
        " |  ____| |  | || | |  __ \\|  __ \\|_   _|/ _ \\ | \\ | |/ ____|",
        " | |  __| |  | || | | |__) | |  | | | | / /_\\ \\|  \\| | (___  ",
        " | | |_ | |  | || | |  _  /| |  | | | | |  _  || . ` |\\___ \\ ",
        " | |__| | |__| || | | | \\ \\| |__| |_| |_| | | || |\\  |____) |",
        "  \\______|______| |_|_|  \\_\\_____/|_____|_| |_||_| \\_|_____/ ",
        "                                                              ",
        "             --- GUARDIANS OF YOUR INTEGRITY ---             ",
        "============================================================"
    };

            foreach (string line in logoLines)
            {
                Console.WriteLine(line);
                System.Threading.Thread.Sleep(80); // Slightly faster animation
            }

            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.White;
            // Padded with spaces to center it under the logo
            Console.WriteLine("          SA's Leading Cyber Awareness Assistant            ");
            Console.WriteLine("============================================================\n");
            Console.ResetColor();
        }
        // Displays the typing effect for a conversational feel.
        public static void TypeMessage(string message)
        {
            foreach (char c in message)
            {
                Console.Write(c);
                Thread.Sleep(70);
            }
            Console.WriteLine();

        }
    }
}

        