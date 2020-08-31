using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Forms;

namespace RoboComTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<Item> items;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog myDialog = new FolderBrowserDialog();
            myDialog.ShowDialog();
            lab1.Content = myDialog.SelectedPath;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (lab1.Content != "")
            {
                items = new ObservableCollection<Item>();
                string filename;
                string directory = lab1.Content.ToString();
                string[] files = Directory.GetFiles(directory, "*.dll", SearchOption.AllDirectories);
                Assembly SampleAssembly;
                foreach (string file in files)
                {
                    filename = System.IO.Path.GetFileName(file);
                    Item item = new Item { Name = filename, Items = new ObservableCollection<Item>() };
                    SampleAssembly = Assembly.LoadFrom(file);
                    foreach (Type oType in SampleAssembly.GetTypes())
                    {
                        Item item2 = new Item { Name = oType.Name, Items = new ObservableCollection<Item>() };
                        foreach (MethodInfo members in oType.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.NonPublic))
                        {
                            if (members.IsFamily || members.IsPublic)
                                item2.Items.Add(new Item { Name = members.Name });
                        }
                        item.Items.Add(item2);
                    }
                    items.Add(item);

                }
                viewTree.ItemsSource = items;
            }
        }
    }
}
