using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Shapes;
using static System.Net.Mime.MediaTypeNames;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class TerminalHandler
    {
        
        public static string prefix;
        public static string command;
        public static string directory;
        public static void TerminalExecute(RichTextBox TerminalBox,TextBox TerminalHistory, string[] text, string executedLine, Label PrefixLabel, Label CommandLabel, Label DirectoryLabel)
        {
            foreach (string line in text)
            {
                string[] splits = line.Split(" ");
                PrefixLabel.Content = splits[0];
                if (splits.Length>1)
                {
                    CommandLabel.Content = splits[1];
                    prefix = splits[0];
                    command = splits[1];
                }
                else
                {
                    CommandLabel.Content = "";
                }
                if (splits.Length>2)
                {
                    DirectoryLabel.Content = splits[2];
                    prefix = splits[0];
                    command = splits[1];
                    directory = splits[2];
                }
                else
                {
                    DirectoryLabel.Content = "";
                }
            }
            switch(command)
            {
                case "hello":
                    HelloCommand(TerminalHistory, text);
                    break;
                case "help":
                    HelpCommand(TerminalHistory, text);
                    break;
            }
            

        }
        public static void HelloCommand(TextBox TerminalHistory, string[] text)
    {
       TerminalHistory.Text += "Console Reply: Hello User!\n"; 
    }
        public static void HelpCommand(TextBox TerminalHistory, string[] text)
        {
            TerminalHistory.AppendText("Console Reply: Available Commands: hello\n");
        }
        public static void listCommand(TextBox TerminalHistory, string[] text, string Prefix)
        {

        }







            }
            

}
