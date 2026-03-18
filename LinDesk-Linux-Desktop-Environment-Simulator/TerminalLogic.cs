using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    class TerminalLogic
    {
        public class TerminalController
        {
            private readonly TextBox terminalBox;
            private readonly string prompt = "user@linux:~$ ";
            private int inputStart;

            public TerminalController(TextBox terminalBox)
            {
                this.terminalBox = terminalBox;
            }

            public void Start()
            {
                terminalBox.Text = prompt;
                inputStart = terminalBox.Text.Length;
                terminalBox.CaretIndex = terminalBox.Text.Length;
                terminalBox.Focus();
            }

            public void HandleKeyDown(KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    e.Handled = true;

                    string currentCommand = GetCurrentCommand();
                    ExecuteCommand(currentCommand);
                }
            }

            public void HandlePreviewKeyDown(KeyEventArgs e)
            {
                if ((e.Key == Key.Back && terminalBox.CaretIndex <= inputStart) ||
                    (e.Key == Key.Left && terminalBox.CaretIndex <= inputStart))
                {
                    e.Handled = true;
                }

                if (e.Key == Key.Home)
                {
                    e.Handled = true;
                    terminalBox.CaretIndex = inputStart;
                }
            }

            public void HandlePreviewMouseDown(MouseButtonEventArgs e)
            {
                if (terminalBox.CaretIndex < inputStart)
                {
                    e.Handled = true;
                    terminalBox.Focus();
                    terminalBox.CaretIndex = terminalBox.Text.Length;
                }
            }

            public void HandleSelectionChanged()
            {
                if (terminalBox.SelectionStart < inputStart)
                {
                    terminalBox.SelectionStart = terminalBox.Text.Length;
                    terminalBox.SelectionLength = 0;
                }
            }

            private string GetCurrentCommand()
            {
                if (terminalBox.Text.Length < inputStart)
                    return "";

                return terminalBox.Text.Substring(inputStart);
            }

            private void ExecuteCommand(string command)
            {
                AppendText(Environment.NewLine);

                string output = ProcessCommand(command);

                if (!string.IsNullOrWhiteSpace(output))
                {
                    AppendText(output);

                    if (!output.EndsWith(Environment.NewLine))
                        AppendText(Environment.NewLine);
                }

                AppendText(prompt);
                inputStart = terminalBox.Text.Length;
                terminalBox.CaretIndex = terminalBox.Text.Length;
                terminalBox.ScrollToEnd();
            }

            private string ProcessCommand(string command)
            {
                command = command.Trim();

                if (string.IsNullOrEmpty(command))
                    return "";

                switch (command.ToLower())
                {
                    case "help":
                        return "Available commands:\nhelp\nclear\necho\nabout";

                    case "about":
                        return "Fake Linux terminal running in WPF.";

                    case "clear":
                        terminalBox.Text = "";
                        AppendText(prompt);
                        inputStart = terminalBox.Text.Length;
                        terminalBox.CaretIndex = terminalBox.Text.Length;
                        return "";

                    default:
                        if (command.StartsWith("echo "))
                            return command.Substring(5);

                        return $"Command not found: {command}";
                }
            }

            private void AppendText(string text)
            {
                terminalBox.Text += text;
            }
        }
    }
}

