﻿using StormLoader.repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StormLoader.modder_control_panel
{
    /// <summary>
    /// Interaction logic for ModderUploadPanel.xaml
    /// </summary>
    public partial class ModderUploadPanel : UserControl
    {
        public string user;
        public ModderUploadPanel()
        {
            InitializeComponent();
        }

        private async void UploadBtn_Click(object sender, RoutedEventArgs e)
        {
            if (Name.Text != "" && Version.Text != "" && Description.Text != "" && ModImagePath.GetLocation() != "" && ModFilePath.GetLocation() != "")
            {
                // ok, this should be a valid upload, guess i need to build the sql query now..... oh god
                SQLManager sqcm = new SQLManager();
                sqcm.connect(GlobalVar.server, GlobalVar.database, GlobalVar.user, GlobalVar.password, GlobalVar.port);
                await sqcm.uploadMod(user, Description.Text, Version.Text, Name.Text, ModImagePath.GetLocation(), ModFilePath.GetLocation());
                

                
            }
        }
    }
}
