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
        private App app = App.Current as App;

        public Learn_UserControl()
        {
            this.InitializeComponent();

            CardExplorerNew cardExplorer = new CardExplorerNew();

            CardSet cardSet = CardSetLoader.LoadCardSetByName("FirstTime");
            CardSet learnSet = cardExplorer.ComposeToLearnCardSet(cardSet, DateTime.Today);

            cardExplorer.setCurrentCardSet(app.AppWideUSerSet, learnSet);

            Grid_Card.DataContext = app.AppWideUSerSet.CurrentCard;
            Answer_TextBox.DataContext = "";
        }

        private void ShowAnswer_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Answer_TextBox.Text.Length == 0)
            {
                ShowAnswer_Button.Content = "Hide";
                Answer_TextBox.Text = app.AppWideUSerSet.CurrentCard.Answer;
            }
            else
            {
                ShowAnswer_Button.Content = "Show";
                Answer_TextBox.Text = "";
            }
        }
    }
}
