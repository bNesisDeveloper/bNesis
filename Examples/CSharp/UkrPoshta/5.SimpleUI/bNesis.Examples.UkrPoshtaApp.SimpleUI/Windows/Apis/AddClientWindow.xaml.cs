using System.Windows;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;

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
        public CustomerOut Customer { get; private set; }
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
            CustomerIn customerIn = new CustomerIn();
            //Render class to ui
            ClassToEdit.RenderClassToUI(customerIn, propertiesPanel, false);
        }

        /// <summary>
        /// If in 'ok' button triggered click, then try add address to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            //Render ui to class
            CustomerIn customerIn = ClassToEdit.RenderUItoClass(propertiesPanel) as CustomerIn;
            //If AddClient success return CustomerOut
            Customer = UkrPoshta.AddClient(customerIn);
            ErrorInfo errorInfo = UkrPoshta.GetLastError();
            //Check if error info code not equal zero(noError)
            if (errorInfo.Code != bNesis.Common.Constants.ErrorCode.NoError)
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
        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
