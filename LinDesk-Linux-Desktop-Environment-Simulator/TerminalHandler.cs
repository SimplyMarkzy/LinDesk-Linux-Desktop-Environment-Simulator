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
        
        private static string prefix;
        private static string command;
        private static string directory;
        private static DirectoryHandler directoryHandler = new DirectoryHandler();
        public static void TerminalExecute(RichTextBox TerminalBox,RichTextBox TerminalHistory, string[] text, string executedLine, Label PrefixLabel, Label CommandLabel, Label CurrentDirectoryDebug, Label DirectoryLabel, DirectoryConstructor CurrentDirectory, string MainPrefix)
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
                case "ls":
                    listCommand(TerminalHistory, text, prefix, CurrentDirectory);
                    break;
                case "cd":
                    changeDirectoryCommand(TerminalHistory, text, prefix, directory, CurrentDirectory, CurrentDirectoryDebug);
                    break;
            }
            

        }
        public static void HelloCommand(RichTextBox TerminalHistory, string[] text)
        {
            TerminalHistory.AppendText("Console Reply: Hello User!");
        }

        public static void HelpCommand(RichTextBox TerminalHistory, string[] text)
        {
            TerminalHistory.AppendText("Console Reply: Available Commands: hello, ls");
        }
        public static void listCommand(RichTextBox TerminalHistory, string[] text, string MainPrefix, DirectoryConstructor CurrentDirectory)
        {
            Paragraph line = new Paragraph();
            foreach (DirectoryConstructor subDir in CurrentDirectory.SubDirectories)
            {
                Run r = new Run(subDir.DirectoryName + " ");
                r.Foreground = System.Windows.Media.Brushes.Blue;
                line.Inlines.Add(r);
            }
            foreach(string file in CurrentDirectory.Files)
            {
                Run r = new Run(file + " " );
                r.Foreground = System.Windows.Media.Brushes.White;
                line.Inlines.Add(r);
            }
            TerminalHistory.Document.Blocks.Add(line);
            Run Green = new Run();
            Green.Foreground = System.Windows.Media.Brushes.Lime;
            line.Inlines.Add(Green);
            TerminalHistory.AppendText(Environment.NewLine);
            TerminalHistory.AppendText(Environment.NewLine);
        }
        public static void changeDirectoryCommand(RichTextBox TerminalHistory, string[] text, string MainPrefix, string directory, DirectoryConstructor CurrentDirectory, Label CurrentDirectoryDebug)
        {
            if (directory == "")
            {
                CurrentDirectory = directoryHandler.Root;
            }

            else
            {
                foreach (DirectoryConstructor subDir in CurrentDirectory.SubDirectories)
                {
                    if (subDir.DirectoryName == directory)
                    {
                        CurrentDirectory = subDir;
                    }
                }
            }

            MainPrefix = "demo@LinDesk:~/" + CurrentDirectory.DirectoryName + " ";
            CurrentDirectoryDebug.Content = CurrentDirectory.DirectoryName;
        }






    }
            

}
