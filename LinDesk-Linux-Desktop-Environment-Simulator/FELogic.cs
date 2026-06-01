using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LinDesk_Linux_Desktop_Environment_Simulator
{
    public class FELogic
    {
        public static DirectoryConstructor LastDirectory;

        public static void Refresh(ItemsControl FEItemsControl, ref DirectoryConstructor CurrentDirectory, RoutedEventHandler clickHandler)
        {
            FEItemsControl.Items.Clear();

            foreach (var folder in CurrentDirectory.SubDirectories)
            {
                Button folderButton = new Button();

                folderButton.Style = (Style)Application.Current.FindResource("FileExplorerButtonStyle");
                folderButton.Content = folder.DirectoryName;
                folderButton.Tag = "/images/folder.png";
                folderButton.Click += clickHandler;

                FEItemsControl.Items.Add(folderButton);
            }

            foreach (var file in CurrentDirectory.Files)
            {
                Button fileButton = new Button();

                fileButton.Style = (Style)Application.Current.FindResource("FileExplorerButtonStyle");
                fileButton.Content = file.Name;
                fileButton.Tag = "/images/document.png";
                fileButton.Click += clickHandler;

                FEItemsControl.Items.Add(fileButton);
            }

            LastDirectory = CurrentDirectory;
        }
    }
}
