using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Effects;
using bNesis.Sdk;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.SimpleUI
{
    public partial class LoginWindow : Window
    {
        /// <summary>
        /// bNesis SDK initialize.
        /// </summary>
        public static ServiceManager manager = new ServiceManager();

        /// <summary>
        /// Initialize LoginWindow.
        /// </summary>
        public LoginWindow()
        {
            InitializeComponent();

#if (ExampleMode)
            /// Use this method only for testing and demonstration applications
            /// The use of this method does not protect your data
            developerIdTextBox.Text = manager.GetKey("exampleDeveloperId");
            clientIdTextBox.Text = manager.GetKey("exampleUkrPoshtaBearer");
            clientSecretTextBox.Text = manager.GetKey("exampleUkrPoshtaCounterPartyToken");            
#endif

        }


        /// <summary>
        /// If 'ok' button pressed it will:
        /// <para/> Initilize bNesis SDK;
        /// <para/> Initilize UkrPoshta instance;
        /// <para/> Then create new UkrPoshtaApisWindow and show him.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //disable textBox elements when Auth process started
            BlurEffect blurEffect = new BlurEffect();
            blurEffect.Radius = 3;
            controlsStackPanel.Effect = blurEffect;
            hideControlsGrid.Visibility = Visibility.Visible;
            hideControlsGrid.UpdateLayout();
            Application.Current.Dispatcher.Invoke(System.Windows.Threading.DispatcherPriority.Background, new Action(delegate { }));

            //Check bNesisDeveloperID
            if (string.IsNullOrEmpty(developerIdTextBox.Text))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = "For using this example, you need bNesis Developer Id. You can get it from https://api.bnesis.com site - free of charge\n";
            }
            else  //Check UkrPoshta authentication keys

            if (string.IsNullOrEmpty(clientIdTextBox.Text) || string.IsNullOrEmpty(clientSecretTextBox.Text))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = "For using this example you need UkrPoshta authentication keys, please contact the UkrPoshta administration to get the keys\n";

            }
            else
            {
                //Getting mode
                string mode = (modeBox.SelectedItem as ComboBoxItem).Content.ToString();
                //Initialize result code
                int SDKInitializeResult;

                //Check if mode containts 'Rich'
                if (mode.Contains("Rich"))
                {
                    //If success initialize return zero code(noError)
                    SDKInitializeResult = manager.InitializeRich(string.Empty);
                }
                else
                {
                    //If success initialize return zero code(noError)
                    SDKInitializeResult = manager.InitializeThin((sdkAddrComboBox.SelectedItem as ComboBoxItem).Content.ToString());
                }

                //Check if result code not equal to zero code(noError) 
                if (SDKInitializeResult != ServiceManager.errorCodeNoError)
                {
                    //Set message in ui element statusTextBlock
                    statusTextBlock.Text = "Connection problem code: " + manager.GetErrorDescription(SDKInitializeResult);
                }
                else
                {
                    try
                    {
                        // this method authorize at UkrPoshta, return instance. 
                        UkrPoshta ukrPoshta = manager.CreateInstanceUkrPoshta(developerIdTextBox.Text, sdkAddrRedirectTextBox.Text, clientIdTextBox.Text, clientSecretTextBox.Text, true);
                        //If authorization failed, the bNesisToken be empty/null.
                        if (string.IsNullOrEmpty(ukrPoshta.bNesisToken))
                        {
                            //if bNesisToken empty - use GetLastError method to get error description
                            if (!string.IsNullOrEmpty(manager.GetLastError())) statusTextBlock.Text = manager.GetLastError();
                            else
                                statusTextBlock.Text = "Auth problem, please check parameters";
                        }
                        else
                        {
                            //Creating new window and show him.
                            new UkrPoshtaApisWindow(ukrPoshta).Show();
                            //Close this window.
                            Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        //Set error message in ui element statusTextBlock
                        statusTextBlock.Text = "Connection status: " + ex.Message;
                    }
                }
            }

            //enable textBox elements when Auth process started
            hideControlsGrid.Visibility = Visibility.Hidden;
            controlsStackPanel.Effect = null;            
        }

        /// <summary>
        /// If in 'cancel' button triggered click, then this window will closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// On window if pressed 'Enter' it will invoke okButton_Click or if pressed 'Esc' it will invoke cancelButton_Click
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
        /// If modeBox change selectedItem it will change visibility for ui element apiServerUrlPanel.
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
