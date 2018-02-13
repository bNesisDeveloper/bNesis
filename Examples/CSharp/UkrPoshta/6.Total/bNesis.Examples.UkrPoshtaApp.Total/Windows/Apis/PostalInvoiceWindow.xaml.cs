using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using bNesis.Sdk.Delivery.UkrPoshta;

namespace bNesis.Examples.UkrPoshtaApp.Total
{
    /// <summary>
    /// Interaction logic for PostalInvoiceWindow.xaml
    /// </summary>
    public partial class PostalInvoiceWindow : Window
    {
        /// <summary>
        /// Path to directory where files be stored.
        /// </summary>
        private string path { get; set; }
        /// <summary>
        /// UkrPoshta instance property.
        /// </summary>
        private UkrPoshta ukrPoshta { get; }

        /// <summary>
        /// Initialize PostalInvoiceWindow
        /// </summary>
        /// <param name="ukrPoshta">UkrPoshta instance required.</param>
        public PostalInvoiceWindow(UkrPoshta ukrPoshta)
        {
            this.ukrPoshta = ukrPoshta;
            InitializeComponent();
            //Set ShipmentTypeComboBox selected index
            ShipmentTypeComboBox.SelectedIndex = 0;
            //Form103aCheckBox is disabled
            Form103aCheckBox.IsEnabled = false;

            //Getting execution path
            path = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            path = System.IO.Path.Combine(path, "Temp");
            //Creating new directory on path, if directory not exist.
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            //Hide WindowProgress
            WindowProgress.Visibility = Visibility.Collapsed;
        }


        /// <summary>
        /// If in 'btnGetPDF' button triggered click, then try downloading file(s).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnGetPDF_Click(object sender, RoutedEventArgs e)
        {
            //Un-Hide WindowProgress
            WindowProgress.Visibility = Visibility.Visible;
            //Disable all ui elements on window
            this.IsEnabled = false;

            try
            {
                //If 'Shipment' type selected it be true.
                bool selectedFirstType = ShipmentTypeComboBox.SelectedIndex == 0;
                //If LabelCkeckBox is checked it be true.
                bool labelChecked = LabelCheckBox.IsChecked == true;
                //If StickerCheckBox is checked it be true.
                bool stickerChecked = StickerCheckBox.IsChecked == true;
                //If Form103a is checked and selected type is 'ShipmentGroup' it be true.
                bool form103aChecked = Form103aCheckBox.IsChecked == true && ShipmentTypeComboBox.SelectedIndex == 1;
                //Set uuid
                string uuid = UUIDTextBox.Text;

                //Check if identifier is empty/null.
                if (string.IsNullOrWhiteSpace(uuid))
                {
                    //Throw exception with error message
                    throw new Exception($"'{ShipmentUUIDTextBlock.Text}' can't be empty!");
                }

                //Run task and wait while his runned.
                Exception taskException = await Task.Run(() =>
                {
                    try
                    {
                        //Creating variables.
                        Stream stream;
                        string fileName;
                        
                        //Check if labelChecked is true.
                        if (labelChecked)
                        {
                            //Check if selected 'Shipment' type.
                            if (selectedFirstType)
                            {
                                //Getting shipment label by uuid.
                                stream = ukrPoshta.GetShipmentLabel(uuid, 0);
                                //Set file name
                                fileName = "Shipment=" + uuid + "=Label.pdf";
                            }
                            else //else is "ShipmentGroup' type.
                            {
                                //Getting shipment group label by uuid.
                                stream = ukrPoshta.GetShipmentGroupLabel(uuid);
                                //Set file name
                                fileName = "ShipmentGroup=" + uuid + "=Label.pdf";
                            }
                            //Create file in destination path.
                            path = System.IO.Path.Combine(path, fileName);
                            CreateFile(stream, path);
                            //Check if file not exist in destination path. 
                            EnsureExistFile(path);
                        }

                        //Check if stickerCheck is true
                        if (stickerChecked)
                        {
                            //Check if selected 'Shipment' type.
                            if (selectedFirstType)
                            {
                                //Getting shipment label by uuid.
                                stream = ukrPoshta.GetShipmentSticker(uuid);
                                fileName = "Shipment=" + uuid + "=Sticker.pdf";
                            }
                            else //else is "ShipmentGroup' type.
                            {
                                //Getting shipment group sticker by uuid.
                                stream = ukrPoshta.GetShipmentGroupSticker(uuid);
                                fileName = "ShipmentGroup=" + uuid + "=Sticker.pdf";
                            }
                            //Create file in destination path.
                            path = System.IO.Path.Combine(path, fileName);
                            CreateFile(stream, System.IO.Path.Combine(path, fileName));
                            //Check if file not exist in destination path. 
                            EnsureExistFile(path);
                        }

                        //Check if form103aChecked is true.
                        if (form103aChecked)
                        {
                            //Getting shipment group form103 by uuid.
                            stream = ukrPoshta.GetShipmentGroupForm103a(uuid);
                            fileName = "ShipmentGroup=" + uuid + "=Form103a.pdf";
                            //Create file in destination path.
                            path = System.IO.Path.Combine(path, fileName);
                            CreateFile(stream, System.IO.Path.Combine(path, fileName));
                            //Check if file not exist in destination path. 
                            EnsureExistFile(path);
                        }
                    }
                    catch (Exception ex)
                    {
                        //Return exception.
                        return ex;
                    }
                    
                    //Return null(no errors).
                    return null;
                });
                
                //Check if task exception not equal null.
                if (taskException != null)
                {
                    throw taskException;
                }

                //Check if all checkBox not checked.
                if (!labelChecked && !stickerChecked && !form103aChecked)
                {
                    throw new Exception("Please, set 'check' one of type's!");
                }

                //Show message box.
                MessageBoxResult result = MessageBox.Show("File(s) downloaded, show folder?", "Success.",
                    MessageBoxButton.YesNo);

                //Check if MessageBoxResult is equal 'Yes'.
                if (result == MessageBoxResult.Yes)
                {
                    //Open file explorer in destination path.
                    Process.Start(path);
                }
            }
            catch (Exception exception)
            {
                //Show message box with error message.
                MessageBox.Show("Reason:" + exception.Message, "Can't create file(s).");
            }
            //Enable all ui elements in window
            this.IsEnabled = true;
            //Hide WindowProgress
            WindowProgress.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// This event is triggered when an ShipmentTypeComboBox selection changed.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShipmentTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //Check if selected index equal one (ShipmentGroup) then enable Forma103aCheckBox.
            Form103aCheckBox.IsEnabled = ShipmentTypeComboBox.SelectedIndex == 1;
            //Check if selected index equal one (ShipmentGroup) then change text.
            ShipmentUUIDTextBlock.Text = ShipmentTypeComboBox.SelectedIndex == 1 ? "ShipmentGroupUUID" : "ShipmentUUID";
        }

        /// <summary>
        /// Check if file not exist in destination path it will throw exception with error message.
        /// </summary>
        /// <param name="path">Destination path.</param>
        private void EnsureExistFile(string path)
        {
            if (File.Exists(path)) return;

            throw new Exception("File not exist! Reason:" + ukrPoshta.GetLastError());
        }

        /// <summary>
        /// Custom method for creating file.
        /// </summary>
        /// <param name="stream">Input stream.</param>
        /// <param name="path">Path where be created file.</param>
        private static void CreateFile(Stream stream, string path)
        {
            //Stream null return
            if (stream == null) { return; }
            //Check if file exist
            if (File.Exists(path))
            {
                //Remove exist file.
                File.Delete(path);
            }

            //Creating new file on destination path.
            using (var file = File.Create(path))
            {
                //Copy bytes to file.
                stream.CopyTo(file);
            }
        }
    }
}
