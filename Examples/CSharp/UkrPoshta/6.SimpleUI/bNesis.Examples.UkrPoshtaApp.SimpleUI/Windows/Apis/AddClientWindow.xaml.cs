using System.Windows;
using System.Windows.Input;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;
using bNesis.Sdk;

namespace bNesis.Examples.UkrPoshtaApp.SimpleUI
{
    /// <summary>
    /// Interaction logic for AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        /// <summary>
        /// Customer instance.
        /// </summary>
        public UkrPoshtaCustomerOut Customer { get; private set; }
        /// <summary>
        /// UkrPoshta instance.
        /// </summary>
        private UkrPoshta UkrPoshta { get; }
        public AddClientWindow(UkrPoshta ukrPoshta)
        {
            InitializeComponent();
            //Auto resize window by content.
            SizeToContent = SizeToContent.WidthAndHeight;
            //Set UkrPoshta instance.
            UkrPoshta = ukrPoshta;
            //Initialize new class of CustomerIn.
            UkrPoshtaCustomerIn customerIn = new UkrPoshtaCustomerIn();

            customerIn.email = "GrigoriyBoyko@mail.com";
            //Set address identifier
            customerIn.addressId = 19113;
            //Set first name
            customerIn.firstName = "Grigoriy";
            //Set middle name
            customerIn.middleName = "Boyko";
            //Set last name
            customerIn.lastName = "Bogdanovich";
            //Set individual
            customerIn.individual = true;
            //Set resident
            customerIn.resident = true;

            //Render class to ui
            ClassToEdit.RenderClassToUI(customerIn, propertiesPanel, false);
        }

        /// <summary>
        /// If in 'ok' button triggered click, then try add address to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //Render ui to class
            UkrPoshtaCustomerIn customerIn = ClassToEdit.RenderUItoClass(propertiesPanel) as UkrPoshtaCustomerIn;
            //If AddClient success return CustomerOut
            Customer = UkrPoshta.AddClient(customerIn);
            ErrorInfo errorInfo = UkrPoshta.GetLastError();
            //Check if error info code not equal zero(noError)
            if (errorInfo.Code != ServiceManager.errorCodeNoError)
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = errorInfo.Description;
            }
            else
            {
                //Close this window.
                Close();
            }
        }

        /// <summary>
        /// If in 'cancel' button triggered click, then this window will closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// If on this window triggered preview key down, 
        /// <para/>then if key is Enter invoke okButton_Click or if key is Escape invoke cancelButton_Click.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //Block other events with key
                e.Handled = true;

                OkButton_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                CancelButton_Click(null, null);
            }
        }

    }
}
