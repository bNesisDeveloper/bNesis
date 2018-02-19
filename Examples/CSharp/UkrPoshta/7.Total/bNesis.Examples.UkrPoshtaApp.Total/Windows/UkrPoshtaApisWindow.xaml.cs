using System.Windows;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.Total
{
    /// <summary>
    /// Interaction logic for ShipmentWindow.xaml
    /// </summary>
    public partial class UkrPoshtaApisWindow : Window
    {
        /// <summary>
        /// UkrPoshta instance property.
        /// </summary>
        private UkrPoshta UkrPoshta { get; }

        /// <summary>
        /// Initiliaze UkrPoshta window.
        /// </summary>
        /// <param name="ukrPoshta">UkrPoshta instance required.</param>
        public UkrPoshtaApisWindow(UkrPoshta ukrPoshta)
        {
            UkrPoshta = ukrPoshta;
            InitializeComponent();
        }

        /// <summary>
        /// If in 'AddAddress' button triggered click, then open new AddAddressWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddAddress_Click(object sender, RoutedEventArgs e)
        {
            //Creating new AddAddressWindow.
            AddAddressWindow addAddressWindow = new AddAddressWindow(UkrPoshta);
            //Show window.
            addAddressWindow.ShowDialog();
            //If AddAddressWindow was closed set addressOut from AddAddressWindow.
            AddressOut addressOut = addAddressWindow.AddressOut;
            //Check if addressOut not equal null.
            if (addressOut != null)
            {
                propertiesPanel.Children.Clear();
                ClassToEdit.RenderClassToUI(addressOut, propertiesPanel, true);
            }
        }


        /// <summary>
        /// If in 'GetAddress' button triggered click, then open new GetAddressWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetAddress_Click(object sender, RoutedEventArgs e)
        {
            //Creating new GetAddressWindow.
            GetAddressWindow getAddressWindow = new GetAddressWindow(UkrPoshta);
            //Show window.
            getAddressWindow.ShowDialog();
            //If GetAddressWindow was closed set addressOut from GetAddressWindow.
            AddressOut addressOut = getAddressWindow.AddressOut;
            //Check if addressOut not equal null
            if (addressOut != null)
            {
                propertiesPanel.Children.Clear();
                ClassToEdit.RenderClassToUI(addressOut, propertiesPanel, true);
            }
        }

        /// <summary>
        /// If in 'AddClient' button triggered click, then open new AddClientWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            //Creating new AddClientWindow.
            AddClientWindow addClientWindow = new AddClientWindow(UkrPoshta);
            //Show window.
            addClientWindow.ShowDialog();
            //If AddClientWindow was closed set customerOut from AddClientWindow.
            CustomerOut customerOut = addClientWindow.Customer;
            //Check if customerOut not equal null
            if (customerOut != null)
            {
                propertiesPanel.Children.Clear();
                ClassToEdit.RenderClassToUI(customerOut, propertiesPanel, true);
            }

        }

        /// <summary>
        /// If in 'GetClient' button triggered click, then open new GetClientWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetClient_Click(object sender, RoutedEventArgs e)
        {
            //Creating new GetClientWindow.
            GetClientWindow addClientWindow = new GetClientWindow(UkrPoshta);
            //Show window.
            addClientWindow.ShowDialog();
            //If GetClientWindow was closed set customerOut from GetClientWindow.
            CustomerOut customerOut = addClientWindow.Customer;
            //Check if customerOut not equal null
            if (customerOut != null)
            {
                propertiesPanel.Children.Clear();
                ClassToEdit.RenderClassToUI(customerOut, propertiesPanel, true);
            }

        }

        /// <summary>
        /// If in 'AddShipment' button triggered click, then open new AddShipmentWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddShipment_Click(object sender, RoutedEventArgs e)
        {
            //Creating new AddShipmentWindow.
            AddShipmentWindow addShipmentWindow = new AddShipmentWindow(UkrPoshta);
            //Show window
            addShipmentWindow.ShowDialog();
            //If AddShipmentWindow was closed set shipmentOut from AddShipmentWindow.
            ShipmentOut shipmentOut = addShipmentWindow.ShipmentOut;
            //Check if shipmentOut not equal null.
            if (shipmentOut != null)
            {
                propertiesPanel.Children.Clear();
                ClassToEdit.RenderClassToUI(shipmentOut, propertiesPanel, true);
            }
        }

        /// <summary>
        /// If in 'GetShipmentWindow' button triggered click, then open new GetShipmentWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GetShipment_Click(object sender, RoutedEventArgs e)
        {
            //Creating new AddShipmentWindow.
            GetShipmentWindow getShipmentWindow = new GetShipmentWindow(UkrPoshta);
            //Show window.
            getShipmentWindow.ShowDialog();
            //If GetShipmentWindow was closed set shipmentOut from GetShipmentWindow.
            ShipmentOut shipmentOut = getShipmentWindow.ShipmentOut;
            //Check if shipmentOut not equal null
            if (shipmentOut != null)
            {
                propertiesPanel.Children.Clear();
                ClassToEdit.RenderClassToUI(shipmentOut, propertiesPanel, true);
            }
        }

        /// <summary>
        /// If in 'PostalInvoice' button triggered click, then open new PostalInvoiceWindow.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PostalInvoice_Click(object sender, RoutedEventArgs e)
        {
            new PostalInvoiceWindow(UkrPoshta).ShowDialog();
        }
    }
}