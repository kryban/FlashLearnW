using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

using FlashLearnW.Models;

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlashLearnW.Views
{
    public sealed partial class Learn_UserControl : UserControl
    {
        public Learn_UserControl()
        {
            this.InitializeComponent();

            var Loader = new CardSetLoader();
            Loader.LoadCardSetByName("default");

            Learn_UCtrl.DataContext = Loader.usrSet;

            // TextBox_Question.DataContext = Loader.usrSet.Cards.First();
            Card_grid.DataContext = Loader.usrSet.Cards.First();
        }
    }
}
