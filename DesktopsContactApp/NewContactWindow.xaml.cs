using DesktopsContactApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopsContactApp
{
    /// <summary>
    /// Interaction logic for NewContactWindow.xaml
    /// </summary>
    public partial class NewContactWindow : Window
    {
        public NewContactWindow()
        {
            InitializeComponent();

            Owner = Application.Current.MainWindow;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Contacts contacts = new Contacts()
            {
                Name = nameTextBox.Text,
                Email = emailTextBox.Text,
                Phone = phoneTextBox.Text
            };

            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<Contacts>();
                connection.Insert(contacts);
            }

            Close();
        }
    }
}
