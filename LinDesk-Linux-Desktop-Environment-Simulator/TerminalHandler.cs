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
        private static string message;
        private static DirectoryHandler directoryHandler = new DirectoryHandler();
        public static void TerminalExecute(RichTextBox TerminalBox, RichTextBox TerminalHistory, string[] text, string executedLine, Label PrefixLabel, Label CommandLabel, Label CurrentDirectoryDebug, Label DirectoryLabel, ref DirectoryConstructor CurrentDirectory, ref string MainPrefix)
        {
            directory = "";
            foreach (string line in text)
            {
                string[] splits = line.Split(" ");
                PrefixLabel.Content = splits[0];
                if (splits.Length > 1)
                {
                    CommandLabel.Content = splits[1];
                    prefix = splits[0];
                    command = splits[1];
                }
                else
                {
                    CommandLabel.Content = "";
                }
                if (splits.Length > 2)
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
                //ai recommended this bit here for echo command, it just takes everything after the first two splits and makes it the message to be echoed
                message = string.Join(" ", splits.Skip(2));
            }
            switch (command)
            {
                case "hello":
                    HelloCommand(TerminalHistory, text);
                    break;
                case "help":
                    HelpCommand(TerminalHistory, text);
                    break;
                case "ls":
                    listCommand(TerminalHistory, text, ref prefix, CurrentDirectory);
                    break;
                case "cd":
                    changeDirectoryCommand(TerminalHistory, text, ref MainPrefix, directory, ref CurrentDirectory, CurrentDirectoryDebug);
                    break;
                case "mkdir":
                    MakeDirectoryCommand(TerminalHistory, text, prefix, directory, ref CurrentDirectory);
                    break;
                case "pwd":
                    WhereamiCommand(TerminalHistory, text, prefix, ref CurrentDirectory);
                    break;
                case "touch":
                    Touch(TerminalHistory, text, prefix, directory, ref CurrentDirectory);
                    break;
                case "rm":
                    remove(TerminalHistory, text, prefix, directory, ref CurrentDirectory);
                    break;
                case "clear":
                    ClearTerminal(TerminalHistory);
                    break;
                case "cat":
                    WriteFileContent(TerminalHistory, text, prefix, directory, ref CurrentDirectory);
                    break;
                case "echo":
                    echo(TerminalHistory);
                    break;
                case "whoami":
                    whoami(TerminalHistory);
                    break;
                case "date":
                    CurrentDateTime(TerminalHistory);
                    break;
            }


        }
        public static string BuildPrefix(DirectoryConstructor currentDirectory)
        {
            // ai made this so my prompting would be easier, it builds the prefix based on the current directory and its parent directories :D
            if (currentDirectory.ParentDirectory == null)
            {
                return "demo@LinDesk:~$ ";
            }

            string path = currentDirectory.DirectoryName;
            DirectoryConstructor current = currentDirectory.ParentDirectory;

            while (current != null && current.ParentDirectory != null)
            {
                path = current.DirectoryName + "/" + path;
                current = current.ParentDirectory;
            }

            return "demo@LinDesk:~/" + path + "$ ";
        }
        public static string BuildPath(DirectoryConstructor currentDirectory)
        {
            // ai made this so pwd would work without any hassle
            if (currentDirectory.ParentDirectory == null)
                return "~";

            string path = currentDirectory.DirectoryName;
            DirectoryConstructor current = currentDirectory.ParentDirectory;

            while (current != null && current.ParentDirectory != null)
            {
                path = current.DirectoryName + "/" + path;
                current = current.ParentDirectory;
            }

            return "~/" + path;
        }
        public static void HelpCommand(RichTextBox TerminalHistory, string[] text)
        {
            TerminalHistory.AppendText("Available Commands: hello, ls, cd, mkdir, pwd, touch, rm,\r\n clear, cat, echo, whoami, date, nano :( ");
            TerminalHistory.AppendText(Environment.NewLine);
        }
        public static void HelloCommand(RichTextBox TerminalHistory, string[] text)
        {
            TerminalHistory.AppendText("Hello User!");
        }
        public static void listCommand(RichTextBox TerminalHistory, string[] text, ref string MainPrefix, DirectoryConstructor CurrentDirectory)
        {
            Paragraph line = new Paragraph();
            foreach (DirectoryConstructor subDir in CurrentDirectory.SubDirectories)
            {
                Run r = new Run(subDir.DirectoryName + " ");
                r.Foreground = System.Windows.Media.Brushes.Blue;
                line.Inlines.Add(r);
            }
            foreach (FileConstructor file in CurrentDirectory.Files)
            {
                Run r = new Run(file.Name + " ");
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
        public static void changeDirectoryCommand(RichTextBox TerminalHistory, string[] text, ref string MainPrefix, string directory, ref DirectoryConstructor CurrentDirectory, Label CurrentDirectoryDebug)
        {
            if (string.IsNullOrEmpty(directory))
            {
                CurrentDirectory = directoryHandler.Root;
            }
            else if (directory == "..")
            {
                CurrentDirectory = CurrentDirectory.ParentDirectory;
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

            MainPrefix = BuildPrefix(CurrentDirectory);
            CurrentDirectoryDebug.Content = CurrentDirectory.DirectoryName;
        }
        public static void MakeDirectoryCommand(RichTextBox TerminalHistory, string[] text, string MainPrefix, string directory, ref DirectoryConstructor CurrentDirectory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                TerminalHistory.AppendText("No directory name provided.");
            }
            else
            {
                DirectoryConstructor newDir = new DirectoryConstructor(directory, CurrentDirectory);
                CurrentDirectory.SubDirectories.Add(newDir);
                newDir.ParentDirectory = CurrentDirectory;
            }
        }
        public static void WhereamiCommand(RichTextBox TerminalHistory, string[] text, string MainPrefix, ref DirectoryConstructor CurrentDirectory)
        {
            string path = BuildPath(CurrentDirectory);
            TerminalHistory.AppendText(Environment.NewLine);
            TerminalHistory.AppendText(path);
            TerminalHistory.AppendText(Environment.NewLine);

        }
        public static void Touch(RichTextBox TerminalHistory, string[] text, string MainPrefix, string directory, ref DirectoryConstructor CurrentDirectory)
        {
            if (string.IsNullOrEmpty(directory))
            {
                TerminalHistory.AppendText("No file name provided.");
                TerminalHistory.AppendText(Environment.NewLine);
            }
            else if (CurrentDirectory.Files.Any(file => file.Name == directory))
            {
                TerminalHistory.AppendText("A file with that name already exists.");
                TerminalHistory.AppendText(Environment.NewLine);
            }
            else
            {
                FileConstructor newFile = new FileConstructor(directory);
                CurrentDirectory.Files.Add(newFile);
            }
        }
        public static void remove(RichTextBox TerminalHistory, string[] text, string MainPrefix, string directory, ref DirectoryConstructor CurrentDirectory)
        {
            if (CurrentDirectory.SubDirectories.Any(subDir => subDir.DirectoryName == directory))
            {
                CurrentDirectory.SubDirectories.Remove(CurrentDirectory.SubDirectories.First(subDir => subDir.DirectoryName == directory));
            }
            else if (CurrentDirectory.Files.Any(file => file.Name == directory))
            {
                CurrentDirectory.Files.Remove(CurrentDirectory.Files.First(file => file.Name == directory));
            }
            else
            {
                TerminalHistory.AppendText("No such file or directory found");
                TerminalHistory.AppendText(Environment.NewLine);
            }

        }
        public static void ClearTerminal(RichTextBox TerminalHistory)
        {
            TerminalHistory.Document.Blocks.Clear();
            TerminalHistory.AppendText(Environment.NewLine);
        }
        public static void WriteFileContent(RichTextBox TerminalHistory, string[] text, string MainPrefix, string directory, ref DirectoryConstructor CurrentDirectory)
        {
            FileConstructor file = CurrentDirectory.Files.FirstOrDefault(f => f.Name == directory);
            if (file != null)
            {
                TerminalHistory.AppendText(Environment.NewLine);
                TerminalHistory.AppendText(file.Content);
                TerminalHistory.AppendText(Environment.NewLine);
            }
            else
            {
                TerminalHistory.AppendText("file not found");
                TerminalHistory.AppendText(Environment.NewLine);
            }
        }
        public static void echo(RichTextBox TerminalHistory)
        {
            TerminalHistory.AppendText(Environment.NewLine);
            TerminalHistory.AppendText(message);
            TerminalHistory.AppendText(Environment.NewLine);
        }
        public static void whoami(RichTextBox TerminalHistory)
        {
            TerminalHistory.AppendText(Environment.NewLine);
            TerminalHistory.AppendText("demo");
            TerminalHistory.AppendText(Environment.NewLine);
        }
        public static void CurrentDateTime(RichTextBox TerminalHistory)
        {
            TerminalHistory.AppendText(Environment.NewLine);
            TerminalHistory.AppendText(DateTime.Now.ToString());
            TerminalHistory.AppendText(Environment.NewLine);
        }
    }
}
