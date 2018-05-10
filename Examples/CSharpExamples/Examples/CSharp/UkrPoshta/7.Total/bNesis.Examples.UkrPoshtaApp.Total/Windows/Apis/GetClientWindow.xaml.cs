using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.Total
{
    /// <summary>
    /// Interaction logic for GetClientWindow.xaml
    /// </summary>
    public partial class GetClientWindow : Window
    {
        /// <summary>
        /// Customer instance.
        /// </summary>
        public UkrPoshtaCustomerOut Customer { get; private set; }
        /// <summary>
        /// UkrPoshta instance.
        /// </summary>
        private UkrPoshta UkrPoshta { get; }
        public GetClientWindow(UkrPoshta ukrPoshta)
        {
            InitializeComponent();
            //Auto resize window by content.
            SizeToContent = SizeToContent.WidthAndHeight;
            //Set UkrPoshta instance.
            UkrPoshta = ukrPoshta;
            //Initialize new class of CustomerIn.
            UkrPoshtaCustomerIn customerIn = new UkrPoshtaCustomerIn();        }

        /// <summary>
        /// If in 'ok' button triggered click, then try get client to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void okButton_Click(object sender, RoutedEventArgs e)
        {
            //Check if externalIdTextBox empty.
            if (string.IsNullOrEmpty(externalIdTextBox.Text))
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = "External-ID can't be empty!";
                return;
            }

            //Disable all ui elements in this window.
            this.IsEnabled = false;
            //Set externalId
            string externalId = externalIdTextBox.Text;
            //Creating variable
            UkrPoshtaCustomerOut[] customers = null;
            //If GetClient success return CustomerOut
            await Task.Run(() => customers = UkrPoshta.GetClients(externalId));
            //Check array of customer if not equal null and more then zero
            if (customers != null && customers.Length > 0)
            {
                Customer = customers[0];
            }
            ErrorInfo errorInfo = UkrPoshta.GetLastError();
            //Check if error info code not equal zero(noError)
            if (errorInfo.Code != ServiceManager.errorCodeNoError)
            {
                //Set error message in ui element statusTextBlock
                statusTextBlock.Text = errorInfo.Description;
                //Enabled all ui elements in this window.
                this.IsEnabled = true;
                //Try set focus to this window
                this.Focus();

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
