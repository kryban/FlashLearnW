using System;
using System.Collections.Generic;
//using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Data.Json;

using FlashLearnW.Interfaces;
using Newtonsoft.Json; // http://james.newtonking.com/json
using System.IO;
using Windows.Storage;
using Windows.Storage.Pickers;
using FlashLearnW.Models;
using System.Text.RegularExpressions;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using Windows.ApplicationModel.Activation;

namespace FlashLearnW.Common
{
    public class DataSerializer : ISerializer, IFileOpenPickerContinuable
    {
        private JsonSerializer jsonSerializer;
		private string DefaultPathUserSet;

        public bool SerializeResult { get; private set; }

        public DataSerializer()
        {
            jsonSerializer = new JsonSerializer();
            jsonSerializer.NullValueHandling = NullValueHandling.Ignore;
        }

        public bool SerializeToLocalFolder(string name, object objectToSerialize)
        {
            bool SerializeResult;

            try
            {
                string tmpName = Regex.Replace(name, "[^0-9a-zA-Z]+", "") + ".json";

                Stream stream = ApplicationData.Current.LocalFolder.OpenStreamForWriteAsync(tmpName, CreationCollisionOption.ReplaceExisting).Result;

                using (StreamWriter streamWriter = new StreamWriter(stream))
                using (JsonTextWriter jsonTextWriter = new JsonTextWriter(streamWriter))
                {
                    jsonSerializer.Serialize(jsonTextWriter, objectToSerialize);
                }

                SerializeResult = true;
            }
            catch (Exception)
            {
                SerializeResult = false;
                throw;
            }

            return SerializeResult;
        }

        private Frame CreateRootFrame()
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();

                // Set the default language
                rootFrame.Language = Windows.Globalization.ApplicationLanguages.Languages[0];
                rootFrame.NavigationFailed += OnNavigationFailed;

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            return rootFrame;
        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        // All about filepicker in Windows Phone App
        // https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn631755.aspx
        // https://msdn.microsoft.com/en-us/library/windows/apps/xaml/dn614994.aspx

        public bool Deserialize(string path, out UserSet retval)
        {
            Stream stream = ApplicationData.Current.LocalFolder.OpenStreamForReadAsync(path).Result;

            bool deserializeResult = false;

            try
            {
                //string tmpName = Regex.Replace(path, "[^0-9a-zA-Z]+", "") + ".json";

                FileOpenPicker fileOpenPicker = new FileOpenPicker();
                fileOpenPicker.SuggestedStartLocation = PickerLocationId.DocumentsLibrary;
                fileOpenPicker.FileTypeFilter.Add(".json");
                fileOpenPicker.ViewMode = PickerViewMode.List;
                fileOpenPicker.PickSingleFileAndContinue();

                // the app will be suspended after calling this 'andContinue' method
                // The handler for the Application.Suspending event in the app.xaml.cs file calls 
                // the SaveAsync method of the SuspensionManager helper class to save application state.
                // 
                // When user finish their task, this app is reactivated. 
                // In the app.xaml.cs file, in the OnActivated event handler, restore application state by calling 
                // the RestoreAsync method of the SuspensionManager helper class. Then check whether this activation is a continuation. 
                //If this activation is a continuation, call the Continue method of the ContinuationManager helper class.




                using (StreamReader streamReader = new StreamReader(stream))
                using (JsonTextReader jsonTextReader = new JsonTextReader(streamReader))
                {
                    //retval = JsonConvert.DeserializeObject<UserSet>(jsonTextReader);
                }


                deserializeResult = true;


            }
            catch (Exception)
            {
                retval = null;
                deserializeResult = false;
                throw;
            }

            retval = null;
            return deserializeResult;
        }

        public void ContinueFileOpenPicker(FileOpenPickerContinuationEventArgs args)
        {
            throw new NotImplementedException();
        }

        //public string LoadUserSetPath()
        //{
        //    return Convert.ToString(ConfigurationManager.AppSettings["UserSetPath"]);
        //}

        //public void SaveToFile(object objectToSerialize, string userSetPath = null)
        //{
        //	string path = userSetPath == null ? LoadUserSetPath() : userSetPath;

        //	Serialize(path, objectToSerialize);
        //}
    }
}
