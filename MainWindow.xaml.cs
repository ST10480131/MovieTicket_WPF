using System.Windows;
using System.Windows.Controls;

namespace MovieTicket_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public MainWindow()
        {
            InitializeComponent();
            cmbMovies.SelectedIndex = 0;
            ticketType.SelectedIndex = 0;

        }
        private void CalculateTicket_Click(object sender, RoutedEventArgs e)
        {

            string name = txtName.Text;

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Please Enter customer name");
                return;
            }
            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity < 0)
            {

                MessageBox.Show("Enter Number of Tickets");
                return;
            }

            ComboBoxItem SelectedMovie = (ComboBoxItem)cmbMovies.SelectedItem;
            ComboBoxItem selectedType = (ComboBoxItem)ticketType.SelectedItem;

            string moviesName = SelectedMovie.Content.ToString();
            string ticketTypeName = selectedType.Content.ToString();

            double moviePrice = Convert.ToDouble(SelectedMovie.Tag);
            double extraPrice = Convert.ToDouble(selectedType.Tag);

            double ticketPrice = moviePrice + extraPrice;
            double total = ticketPrice * quantity;

            txtResult.Text =
                $"Customer Name: {name}\n" +
                $"Movie: {moviesName}\n" +
                $"Ticket Type: {ticketTypeName}\n" +
                $"Quantity: {quantity}\n" +
                $"Price per Ticket: R{ticketPrice}\n" +
                $"Total Amount: R{total}";
        }
    }
}