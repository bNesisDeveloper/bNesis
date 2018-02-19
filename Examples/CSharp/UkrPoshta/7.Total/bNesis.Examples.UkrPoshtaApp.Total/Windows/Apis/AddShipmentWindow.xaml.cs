using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using bNesis.Sdk;
using bNesis.Sdk.Common;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.Total
{
    /// <summary>
    /// Interaction logic for AddShipmentWindow.xaml
    /// </summary>
    public partial class AddShipmentWindow : Window
    {
        /// <summary>
        /// ShipmentOut instance.
        /// </summary>
        public ShipmentOut ShipmentOut { get; private set; }
        /// <summary>
        /// UkrPoshta instance.
        /// </summary>
        private UkrPoshta UkrPoshta { get; }
        public AddShipmentWindow(UkrPoshta ukrPoshta)
        {
            InitializeComponent();
            //Auto resize window by content.
            SizeToContent = SizeToContent.WidthAndHeight;
            //Set UkrPoshta instance.
            UkrPoshta = ukrPoshta;
            //Initialize new class of ShipmentIn.
            ShipmentIn shipmentIn = new ShipmentIn();
            //Render class to ui
            ClassToEdit.RenderClassToUI(shipmentIn, propertiesPanel, false);

        }

        /// <summary>
        /// If in 'ok' button triggered click, then try add shipment to UkrPoshta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void okButton_Click(object sender, RoutedEventArgs e)
        {
            //Disable all ui elements in this window.
            this.IsEnabled = false;
            
            //Render ui to class
            ShipmentIn shipmentIn = ClassToEdit.RenderUItoClass(propertiesPanel) as ShipmentIn;
            //Add shipment to UkrPoshta if success return instance in ShipmentOut class.
            await Task.Run(() => ShipmentOut = UkrPoshta.AddShipment(shipmentIn));
            ErrorInfo errorInfo = UkrPoshta.GetLastError();

            //If error info code not equal zero(noError)
            if (errorInfo.Code != ServiceManager.errorCodeNoError)
            {
                //Set error description in ui element statusTextBlock
                statusTextBlock.Text = errorInfo.Description;
                //Enable all ui elements in this window.
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
