using System.Windows;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.SimpleUI
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
            //Show window
            addAddressWindow.ShowDialog();
            //If AddAddressWindow was closed set addressOut from AddAddressWindow.
            AddressOut addressOut = addAddressWindow.Address;
            //Check if shipmentOut not equal null.
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
    }
}
