using FlashLearnW.Data;
using FlashLearnW.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Resources;
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
    public sealed partial class Overview_UserControl : UserControl
    {
        public Overview_UserControl()
        {
            this.InitializeComponent();

            App app = App.Current as App;

            UserSet foo = app.AppWideUserSet;

            LearnCardSets_Overview.DataContext = foo;

            //var bar = foo.AllCardSets[0].
        }

        /// <summary>
        /// Shows the details of an item clicked on in the <see cref="ItemPage"/>
        /// </summary>
        /// <param name="sender">The GridView displaying the item clicked.</param>
        /// <param name="e">Event data that describes the item clicked.</param>
        private void ItemView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var itemId = ((CardSet)e.ClickedItem).ID;

            

            bool pageCanBeLoaded = App.RootFrame.Navigate((typeof(OverviewDetail_Page)), itemId);

            if (!pageCanBeLoaded)
            {
                var resourceLoader = ResourceLoader.GetForCurrentView("Resources");
                throw new Exception(resourceLoader.GetString("NavigationFailedExceptionMessage"));
            }
        }
    }
}
