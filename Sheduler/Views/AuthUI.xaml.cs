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

namespace Sheduler.Views
{
    /// <summary>
    /// Interaction logic for AuthUI.xaml
    /// </summary>
    public partial class AuthUI : Window
    {
        public AuthUI()
        {
            InitializeComponent();
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Btn_Close_Click(object sender, RoutedEventArgs e)
        {
            //DialogResult = true;
            Close();
        }
    }
}
