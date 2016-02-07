using FlashLearnW.Models;
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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace FlashLearnW.Views
{
    public sealed partial class Learn_UserControl : UserControl
    {


        public Learn_UserControl()
        {
            this.InitializeComponent();

            App app = App.Current as App;

            CardExplorerNew cardExplorer = new CardExplorerNew();

            CardSet cardSet = CardSetLoader.LoadCardSetByName("FirstTime");
            CardSet learnSet = cardExplorer.ComposeToLearnCardSet(cardSet, DateTime.Today);

            cardExplorer.setCurrentCardSet(app.AppWideUSerSet, learnSet);

            Grid_Card.DataContext = app.AppWideUSerSet.CurrentCard;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // show answer
            // update backing json with serilizer
            // load next cad in prio list
        }
    }
}
