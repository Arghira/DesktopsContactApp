using DesktopsContactApp.Classes;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace DesktopsContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contacts> contacts;
        public MainWindow()
        {
            InitializeComponent();

            contacts = new List<Contacts>();

            ReadDataBase();
        }

        private void NewButton_Click(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();

            ReadDataBase();
        }

        void ReadDataBase()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dataBasePath))
            {
                conn.CreateTable<Contacts>();
                contacts = conn.Table<Contacts>().ToList().OrderBy(c => c.Name).ToList();
            }

            if (contacts != null)
            {
                contactsListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;

            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();

            contactsListView.ItemsSource = filteredList;
        }

        private void ContactsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (contactsListView.SelectedItem is Contacts selectedContacts)
            {
                ContactDetailsWindow contactDetailsWindow = new ContactDetailsWindow(selectedContacts);
                contactDetailsWindow.ShowDialog();
            }

            ReadDataBase();
        }

    }
}
