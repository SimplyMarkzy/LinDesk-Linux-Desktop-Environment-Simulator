using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
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
        public static void TerminalExecute(RichTextBox TerminalBox,TextBox TerminalHistory, string[] text, string executedLine, Label PrefixLabel, Label CommandLabel, Label DirectoryLabel)
        {
            foreach (string line in text)
            {
                string[] splits = line.Split(" ");
                PrefixLabel.Content = splits[0];
                if (splits.Length>1)
                {
                    CommandLabel.Content = splits[1];
                }
                else
                {
                    CommandLabel.Content = "";
                }
                if (splits.Length>2)
                {
                    DirectoryLabel.Content = splits[2];
                }
                else
                {
                    DirectoryLabel.Content = "";
                }
                // ak je splits 3 throwexception
                if (splits.Length > 1)
                {
                    if (splits[1].Contains("Hello"))
                    {
                        TerminalHistory.Text += "Console Reply: Hello User!\n";
                    }
                    if (splits[1].Contains("Clear"))
                    {
                        TerminalHistory.Clear();
                        TerminalHistory.Text = "";
                    }
                }
                else if (splits.Length>2)
                {

                }
                
                 
                   
                
            }
            

        }
    }
}
