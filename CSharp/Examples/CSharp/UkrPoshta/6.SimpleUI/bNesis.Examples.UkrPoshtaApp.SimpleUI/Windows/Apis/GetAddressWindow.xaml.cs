using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;
using bNesis.Sdk;

namespace bNesis.Examples.UkrPoshtaApp.SimpleUI
{
    /// <summary>
    /// Interaction logic for GetAddressWindow.xaml
    /// </summary>
    public partial class GetAddressWindow: Window
    {
        /// <summary>
        /// AddressOut instance.
        /// </summary>
        public UkrPoshtaAddressOut AddressOut { get; private set; }
        /// <summary>
        /// UkrPoshta instance.
        /// </summary>
        private UkrPoshta UkrPoshta { get; }
        public GetAddressWindow(UkrPoshta ukrPoshta)
        {
            InitializeComponent();
            //Auto resize window by content.
            SizeToContent = SizeToContent.WidthAndHeight;
            //Set UkrPoshta instance.
            UkrPoshta = ukrPoshta;
        }

        /// <summary>
        /// If in 'ok' button triggered click, then try get address to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            //Check if addressIdTextBox empty.
            if (string.IsNullOrEmpty(addressIdTextBox.Text))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = "AddressID can't be empty";
                return;
            }

            int addressId;
            //Try parse addressIdTextBox to int.
            if (!int.TryParse(addressIdTextBox.Text, out addressId))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = "Use only numbers";
                return;
            }
            //If GetAddress success return instance of AddressOut
             AddressOut = UkrPoshta.GetAddress(addressId);
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
        /// If 'cancel' button click, then this window will closed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// If on this window preview key down, 
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
