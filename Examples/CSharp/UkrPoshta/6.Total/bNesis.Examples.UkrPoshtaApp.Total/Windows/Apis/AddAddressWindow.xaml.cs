using System.Threading.Tasks;
using System.Windows;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.Total
{
    /// <summary>
    /// Interaction logic for AddAddressWindow.xaml
    /// </summary>
    public partial class AddAddressWindow : Window
    {
        /// <summary>
        /// AddressOut instance.
        /// </summary>
        public AddressOut AddressOut { get; private set; }
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
            //Initialize new class of AddressIn.
            AddressIn addressIn = new AddressIn();
            //Render class to ui
            ClassToEdit.RenderClassToUI(addressIn, propertiesPanel, false);

        }

        /// <summary>
        /// If in 'ok' button triggered click, then try add address to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void okButton_Click(object sender, RoutedEventArgs e)
        {
            //Disable all ui elements in this window.
            this.IsEnabled = false;

            //Render ui to class
            AddressIn addressIn = ClassToEdit.RenderUItoClass(propertiesPanel) as AddressIn;
            //Add address to UkrPoshta if success return instance in AddressOut class.
            await Task.Run(() => AddressOut = UkrPoshta.AddAddress(addressIn));
            ErrorInfo errorInfo = UkrPoshta.GetLastError();
            //If error info code not equal zero(noError)
            if (errorInfo.Code != bNesis.Common.Constants.ErrorCode.NoError)
            {
                //Set error description in ui element statusTextBlock
                statusTextBlock.Text = errorInfo.Description;
                //Enable all ui elements in this window.
                this.IsEnabled = true;
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
    }
}
