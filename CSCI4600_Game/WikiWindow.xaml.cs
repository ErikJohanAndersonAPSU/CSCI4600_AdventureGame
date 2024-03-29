﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CSCI4600_Game
{
    /// <summary>
    /// Interaction logic for WikiWindow.xaml
    /// </summary>
    public partial class WikiWindow : Window
    {
        public WikiWindow()
        {
            InitializeComponent();

            List<WikiEntry> entries = AdventureGameManager.wikiEntries.ToList();

            WikiListBox.ItemsSource = entries;
        }
    }
}
