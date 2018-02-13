using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using bNesis.Sdk;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.Total
{
    public partial class LoginWindow : Window
    {
        /// <summary>
        /// bNesis SDK initialize.
        /// </summary>
        public static ServiceManager manager = new ServiceManager();
        /// <summary>
        /// This property used for checking if client waiting for response it be true.
        /// </summary>
        private bool waitingForResponse { get; set; }

        /// <summary>
        /// Initialize LoginWindow.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// If 'ok' button pressed it start asynchronously and :
        /// <para/> Initilize bNesis SDK;
        /// <para/> Initilize UkrPoshta instance;
        /// <para/> Create new UkrPoshtaApisWindow and show him.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void okButton_Click(object sender, RoutedEventArgs e)
        {
            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(developerIdTextBox.Text))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text =
                    "For using this example, you need bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n";
                return;
            }

            //Check UkrPoshta authentication keys
            if (string.IsNullOrEmpty(ukrPoshtaBearerTextBox.Text) || string.IsNullOrEmpty(ukrPoshtaConterPartyTokenTextBox.Text))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text =
                    "For using this example you need UkrPoshta authentication keys, please contact the UkrPoshta administration to get the keys\n";
                return;
            }

            //Disable some ui elements in window.
            modeBox.IsEnabled = false;
            sdkAddrTextBox.IsEnabled = false;
            sdkAddrRedirectTextBox.IsEnabled = false;
            developerIdTextBox.IsEnabled = false;
            ukrPoshtaBearerTextBox.IsEnabled = false;
            ukrPoshtaConterPartyTokenTextBox.IsEnabled = false;
            okButton.IsEnabled = false;

            //Set waiting for response to true
            waitingForResponse = true;

            //Show status in ui element statusTextBlock.
            statusTextBlock.Text = "Operation in progress. Please wait...";

            //Getting developer identifier from ui element developerIdTextBox.
            string developerID = developerIdTextBox.Text;
            //Getting redirect url from ui element sdAddrRedirectTextBox.
            string redirectUrl = sdkAddrRedirectTextBox.Text;
            //Getting UkrPoshta bearer from  ui element ukrPoshtaBearerTextBox.
            string UkrPoshtaBearer = ukrPoshtaBearerTextBox.Text;
            //Getting UkrPoshta coner party token from ui element ukrPoshtaConterPartyTokenTextBox.
            string UkrPoshtaConterPartyToken = ukrPoshtaConterPartyTokenTextBox.Text;
            //Getting bNesis api end point  from ui element sdkAddrTextBox.
            string bNesisAPIEndPoint = sdkAddrTextBox.Text;
            //Getting mode.
            string mode = (modeBox.SelectedItem as ComboBoxItem).Content.ToString();

            //Creating variable of UkrPoshta, set null.
            UkrPoshta ukrPoshta = null;
            //Creating empty string
            string errorMessage = string.Empty;
            
            //Asynchronous processing.
            await Task.Run(() =>
            {
                //Initialize result code.
                int SDKInitializeResult;

                //Check if mode containts 'Rich'.
                if (mode.Contains("Rich"))
                {
                    //If success initialize return zero code(noError).
                    SDKInitializeResult = manager.InitializeRich(string.Empty);
                }
                else
                {
                    //If success initialize return zero code(noError).
                    SDKInitializeResult = manager.InitializeThin(bNesisAPIEndPoint);
                }

                //Check if result code not equal to zero code(noError). 
                if (SDKInitializeResult != ServiceManager.errorCodeNoError)
                {
                    //Set errorMessage.
                    errorMessage = "Connection problem code: " + SDKInitializeResult;
                }
                else
                {
                    try
                    {
                        // this method authorize at UkrPoshta, return instance. 
                        ukrPoshta = manager.CreateInstanceUkrPoshta(developerID, redirectUrl, UkrPoshtaBearer,
                            UkrPoshtaConterPartyToken, true);
                        //If authorization failed, the bNesisToken be empty/null.
                        if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                        {
                            //if bNesisToken empty - use GetLastError method to get error description.
                            if (!string.IsNullOrEmpty(manager.GetLastError()))
                                errorMessage = manager.GetLastError();
                            else
                                errorMessage = "Auth problem, please check parameters";
                        }
                    }
                    catch (Exception ex)
                    {
                        //Set error message.
                        errorMessage = "Connection status: " + ex.Message;
                    }
                }
            });

            //Set waiting for response to false
            waitingForResponse = false;

            //If instance UkrPoshta not equal null
            //and bNesisToken not empty.
            if (ukrPoshta != null && !string.IsNullOrEmpty(ukrPoshta.bNesisToken))
            {
                //Creating new window and show him.
                new UkrPoshtaApisWindow(ukrPoshta).Show();
                //Close this window.
                Close();

                return;
            }

            //Enable some ui element in window.
            modeBox.IsEnabled = true;
            sdkAddrTextBox.IsEnabled = true;
            sdkAddrRedirectTextBox.IsEnabled = true;
            developerIdTextBox.IsEnabled = true;
            ukrPoshtaBearerTextBox.IsEnabled = true;
            ukrPoshtaConterPartyTokenTextBox.IsEnabled = true;
            okButton.IsEnabled = true;

            //Set error message in ui element statusTextBlock.
            statusTextBlock.Text = errorMessage;
        }

        /// <summary>
        /// If button was clicked and client doesn't waiting for responce this window will closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            //Check if this client waiting for response.
            if (waitingForResponse)
            {
                //Open procces
                Process.Start(sdkAddrRedirectTextBox.Text);
                return;
            }

            //Close this window
            Close();
        }


        /// <summary>
        /// On window if pressed 'Enter'  invoke okButton_Click or if pressed 'Esc' invoke cancelButton_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return) okButton_Click(null, null);
            else
                if (e.Key == Key.Escape) cancelButton_Click(null, null);
        }

        /// <summary>
        /// This event will triggered when an modeBox selection changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void modeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Check if modeBox or selectedItem or apiServerUrlPanel is equal null.
            if ((modeBox == null) || (modeBox.SelectedItem == null) || (apiServerUrlPanel == null)) return;

            //Getting from modeBox content.
            var mode = (modeBox.SelectedItem as ComboBoxItem).Content.ToString();

            //Check if mode contains 'Rich'.
            if (mode.Contains("Rich"))
            {
                //Set apiServerUrlPanel visibility
                apiServerUrlPanel.Visibility = System.Windows.Visibility.Collapsed;
            }
            else
            {
                //Set apiServerUrlPanel visibility
                apiServerUrlPanel.Visibility = System.Windows.Visibility.Visible;
            }
        }

    }
}
