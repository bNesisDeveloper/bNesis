using System.Threading.Tasks;
using System.Windows;
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
