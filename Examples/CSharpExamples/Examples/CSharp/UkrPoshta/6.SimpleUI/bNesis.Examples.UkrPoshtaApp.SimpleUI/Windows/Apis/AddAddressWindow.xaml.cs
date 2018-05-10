using System.Windows;
using System.Windows.Input;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;
using bNesis.Sdk;

namespace bNesis.Examples.UkrPoshtaApp.SimpleUI
{
    /// <summary>
    /// Interaction logic for AddAddressWindow.xaml
    /// </summary>
    public partial class AddAddressWindow : Window
    {
        /// <summary>
        /// Address instance.
        /// </summary>
        public UkrPoshtaAddressOut Address { get; private set; }
        /// <summary>
        /// UkrPoshta instance.
        /// </summary>
        private UkrPoshta UkrPoshta { get; }
        public AddAddressWindow(UkrPoshta ukrPoshta)
        {
            InitializeComponent();
            //Auto resize window by content.
            SizeToContent = SizeToContent.WidthAndHeight;
            //Set UkrPoshta instance.
            UkrPoshta = ukrPoshta;
            //Initialize new class of ShipmentIn.
            UkrPoshtaAddressIn addressIn = new UkrPoshtaAddressIn();            
            //This properties used for creating class Address wich need for UkrPoshta
            //We cite it for example, use your own values.
            /// <summary>
            /// Country name for address. (Example: UA)
            /// </summary>
            addressIn.country = "UA";
            /// <summary>
            /// City name for address. 
            /// </summary>
            addressIn.city = "Kiev";
            /// <summary>
            /// Region name for address.
            /// </summary>
            addressIn.region = "Obolon";
            /// <summary>
            /// Street name for address.
            /// </summary>
            addressIn.street = "Obolonskiy prospekt";
            /// <summary>
            /// House number for address.
            /// </summary>
            addressIn.houseNumber = "3";
            /// <summary>
            /// Apartment number for address.
            /// </summary>
            addressIn.apartmentNumber = "36";
            /// <summary>
            /// Post code for address.
            /// </summary>
            addressIn.postcode = "04073";

        //Render class to ui
        ClassToEdit.RenderClassToUI(addressIn, propertiesPanel, false);

        }

        /// <summary>
        /// If in 'ok' button triggered click, then try add address to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //Render ui to class
            UkrPoshtaAddressIn addressIn = ClassToEdit.RenderUItoClass(propertiesPanel) as UkrPoshtaAddressIn;
            //Add address to UkrPoshta if success return instance in AddressOut class.
            Address = UkrPoshta.AddAddress(addressIn);
            ErrorInfo errorInfo = UkrPoshta.GetLastError();
            //If error info code not equal zero(noError)
            if (errorInfo.Code != ServiceManager.errorCodeNoError)
            {
                //Set error description in ui element statusTextBlock
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
        private void cancelButton_Click(object sender, RoutedEventArgs e)
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

                okButton_Click(null, null);
            }
            else if (e.Key == Key.Escape)
            {
                cancelButton_Click(null, null);
            }
        }

    }
}
