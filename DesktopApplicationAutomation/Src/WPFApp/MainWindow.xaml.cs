using System.Windows;
using System.Windows.Controls;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"The Description is : {this.DescriptionText.Text}");
        }

        private void ResetButton_OnClick(object sender, RoutedEventArgs e)
        {
            //this.WeldCheckBox.IsChecked = this.AssemblyCheckBox.IsChecked = this.PlasmaCheckBox.IsChecked =
            //    this.LaserCheckBox.IsChecked = this.PurchaseCheckBox.IsChecked = this.LatheCheckBox.IsChecked =
            //        this.DrillCheckBox.IsChecked = this.FoldCheckBox.IsChecked =
            //            this.RollCheckBox.IsChecked = this.SawCheckBox.IsChecked = false;
            this.WeldCheckBox.IsChecked = this.AssemblyCheckBox.IsChecked = this.LatheCheckBox.IsChecked =
                    this.DrillCheckBox.IsChecked = false;
        }

        private void CheckBox_OnChecked(object sender, RoutedEventArgs e)
        {
            this.LengthText.Text += ((CheckBox)sender).Content.ToString();
        }

        private void FinishDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.NoteText == null)
                return;

            var comboBox = (ComboBox)sender;
            var comboBoxItem = (ComboBoxItem)comboBox.SelectedValue;

            this.NoteText.Text = comboBoxItem.Content.ToString();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            FinishDropDown_SelectionChanged(this.FinshDropdown, null);
        }

        private void SupplierNameText_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.MassText.Text = this.SupplierNameText.Text;
        }
    }
}
