using DesktopsContactApp.Classes;
using SQLite;
using System.Windows;

namespace DesktopsContactApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        public Contacts contacts;

        public ContactDetailsWindow(Contacts contacts)
        {
            InitializeComponent();

            this.contacts = contacts;

            nameTextBox.Text = contacts.Name;
            phoneTextBox.Text = contacts.Phone;
            emailTextBox.Text = contacts.Email;
        }

        private void UpdateButton_Click(object sender, RoutedEventArgs e)
        {
            contacts.Name = nameTextBox.Text;
            contacts.Phone = phoneTextBox.Text;
            contacts.Email = emailTextBox.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<Contacts>();
                connection.Update(contacts);
            }

            Close();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.dataBasePath))
            {
                connection.CreateTable<Contacts>();
                connection.Delete(contacts);
            }

            Close();
        }
    }
}
