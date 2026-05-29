using System;
using System.Collections.Generic; // The generic collection namespace is for the use of the generic List structure.
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CyberAwarenessBotGUI1
{
    /// <summary>
    /// Cybersecurity Awareness Chatbot Graphical User Interface Interaction logic class manages the desktop window visual to make the system more engaging and user-friendly.
    /// Question 1. GUI design and Implementation - of event handlers to manage UI state changes and input processing when a user interacts with the bot.
    /// </summary>
    public partial class MainWindow : Window
    {
        // Question 5. Memory and recall - This instantiates a private List collection to remember the conversation history when
        // users information are put throughout the chatbot. This feature makes cybersecurity tips more engaging to assist personalised responses by the user.
        private List<string> conversationHistory = new List<string>();

        // The empty string allows a user to enter their name to make their personalised responses more meaningful.
        // Initializes the empty string to determine whether the program is in Phase 1 or Phase 2.
        private string userName = "";

        /// <summary>
        /// Default window constructor executes automatically upon application creation.
        /// Loads XAML layout elements and triggers external audio greeting sequences.
        /// </summary>
        public MainWindow()
        {
            // Crucial WPF framework method that parses XAML markup to instantiate visual layout elements
            InitializeComponent();
            
            try
            {
                // Voice implementation in the GUI application.
                CyberAwarenessBot.UIHelper.PlayGreetingAudio();
            }
            catch (Exception ex)
            {
            
            }

            // Append foundational visual introduction parameters directly into the TextBox control console
            txtChatLog.AppendText("System: CyberAwareness Assistant UI Initialized successfully.\n");
            txtChatLog.AppendText("Bot: Hello! I am your Cyber Security Awareness Assistant. What is your name?\n\n");
        }

        /// <summary>
        /// Event-driven method responding to user click interactions on the cyan SEND button control.
        /// Manages data extraction, validation, keyword matching, and log synchronization sequentially.
        /// </summary>
        private void BtnSend_Click(object sender, RoutedEventArgs e)
        {
            // INPUT VALIDATION FILTER: Trims blank space characters to guarantee that 
            // empty submissions are ignored, safeguarding memory list allocations from junk rows.
            if (txtUserInput.Text.Trim() != "")
            {
                // Extract clean data directly from the interactive text layout field property
                string userMessage = txtUserInput.Text.Trim();

                // Normalization step to ensure case-insensitive sequence checking operations
                string lowerMessage = userMessage.ToLower();

                // Intercepts structural utility inputs explicitly standing standalone to execute framework instructions
                if (lowerMessage == "/clear" || lowerMessage == "clear")
                {
                    txtChatLog.Clear();
                    txtChatLog.AppendText("System: Chat log terminal cleared successfully.\n\n");
                    txtUserInput.Clear();
                    return; 
                }

                if (lowerMessage == "/exit" || lowerMessage == "exit")
                {
                    this.Close(); // Invokes safe terminal window environment shutdown process
                    return;
                }

                // DATA PERSISTENCE: Captures and saves the user transaction index inside the RAM collection list
                conversationHistory.Add(userMessage);

                // Phase 1 of identifying the user

                if (string.IsNullOrEmpty(userName))
                {
                    // Registers the absolute first valid sequence transmission directly as the user identity profile name
                    userName = userMessage;

                    // Synchronize the display terminal with user feedback markup
                    txtChatLog.AppendText("User: " + userName + "\n");

                    // Dynamic personalized greeting reflecting user identity mapping
                    txtChatLog.AppendText("Bot: Nice to meet you, " + userName + "! How can I protect your data today?\n");
                    txtChatLog.AppendText(">>> [SYSTEM MEMORY REGISTER: Interaction #" + conversationHistory.Count + " saved to session log] <<<\n\n");

                    // Clear active layout buffers and advance the cursor position tracking frame downward
                    txtUserInput.Clear();
                    ChatScrollViewer.ScrollToBottom();
                    return; // Short-circuit route to block identity profiles from scanning cybersecurity warnings
                }

               
                // Phase 2 scans threats

                // Format output view string using localized user instance identities dynamically
                txtChatLog.AppendText(userName + ": " + userMessage + "\n");

                // Working variable placeholder block utilized to host selected dynamic threat messaging strings
                string botResponse = "";

                // Question 2, 3 & 4: Validates user threat parameters sequentially. Keyword recognition, Random responses and conversation flow
                if (lowerMessage.Contains("phishing") || lowerMessage.Contains("email") || lowerMessage.Contains("link"))
                {
                    botResponse = "Bot Warning: Phishing detected! Never click on suspicious links or provide personal details in unsolicited emails. Always verify the sender's address.";
                }
                else if (lowerMessage.Contains("password") || lowerMessage.Contains("login") || lowerMessage.Contains("credential"))
                {
                    botResponse = "Bot Advice: Ensure your passwords are at least 12 characters long, combining uppercase, lowercase, numbers, and symbols. Never reuse passwords across accounts!";
                }
                else if (lowerMessage.Contains("malware") || lowerMessage.Contains("virus") || lowerMessage.Contains("hacked"))
                {
                    botResponse = "Bot Alert: Keep your operating system and antivirus software updated daily to patch vulnerabilities. Run a full system scan immediately if you suspect infection.";
                }
                else if (lowerMessage.Contains("ransomware") || lowerMessage.Contains("encrypt") || lowerMessage.Contains("bitcoin"))
                {
                    botResponse = "Bot Critical Alert: Ransomware threat detected! If your files are locked, isolate the machine from the network immediately. Never pay the ransom; rely on off-site data backups.";
                }
                else if (lowerMessage.Contains("spyware") || lowerMessage.Contains("webcam") || lowerMessage.Contains("tracking"))
                {
                    botResponse = "Bot Security Warning: Spyware risk! Cover your webcam when not in use, check your app permissions, and run a dedicated anti-spyware scan to detect unauthorized background logging.";
                }
                else if (lowerMessage.Contains("2fa") || lowerMessage.Contains("mfa") || lowerMessage.Contains("authentication") || lowerMessage.Contains("otp"))
                {
                    botResponse = "Bot Educational Info: Two-Factor Authentication (2FA/MFA) adds an essential secondary verification layer. Always enable it using an Authenticator App rather than standard SMS text messages.";
                }
                else if (lowerMessage.Contains("safe") || lowerMessage.Contains("fine") || lowerMessage.Contains("good") || lowerMessage.Contains("thank"))
                {
                    botResponse = "Bot: You are very welcome, " + userName + "! I am glad to hear you feel secure. Stay vigilant and let me know if any other security questions come up!";
                }
                else
                {
                    // Fallback block if token validation checks return negative indicators across all matrices
                    botResponse = "Bot: I am processing your message, " + userName + ". Please mention keywords like 'phishing', 'password', 'ransomware', 'spyware', or '2fa' so I can provide specific security guidance.";
                }

                // Append parsed threat response data onto the screen control view layout container
                txtChatLog.AppendText(botResponse + "\n");

              
                // Question 6: Sentiment dection engine
              
                string detectedSentiment = "Neutral / Inquiring"; // Establishes baseline sentiment structural value

                // Sequential scanning logic mapping user word triggers to emotional distress thresholds
                if (lowerMessage.Contains("scared") || lowerMessage.Contains("panicking") || lowerMessage.Contains("worried") || lowerMessage.Contains("help"))
                {
                    detectedSentiment = "High Distress / Panic Alert";
                }
                else if (lowerMessage.Contains("safe") || lowerMessage.Contains("fine") || lowerMessage.Contains("good") || lowerMessage.Contains("thank"))
                {
                    detectedSentiment = "Confident / Secure";
                }

                // TELEMETRY VISUALIZATION: Direct stream generation feeding metadata into display boxes live
                txtChatLog.AppendText(">>> [SYSTEM MEMORY REGISTER: Interaction #" + conversationHistory.Count + " saved to session log] <<<\n");
                txtChatLog.AppendText(">>> [SENTIMENT TELEMETRY: User state evaluated as: " + detectedSentiment + " ] <<<\n\n");

                // Reset inputs to clean defaults and force ScrollViewer focus tracking to latest text nodes
                txtUserInput.Clear();
                ChatScrollViewer.ScrollToBottom();
            }
        }

        /// <summary>
        /// Question 7 & 8: Hardware key intercept method checking inputs inside the interactive textbox field property.
        /// Captures user keyboard events to allow convenient 'Enter Key' processing logic loops.
        /// </summary>
        private void TxtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            // Key Enumeration parsing check against systemic hardware input statuses
            if (e.Key == Key.Enter)
            {
                // Intercepts and redirects user focus events directly into our Send action click algorithm
                BtnSend_Click(this, new RoutedEventArgs());
            }
        }
    }
}
