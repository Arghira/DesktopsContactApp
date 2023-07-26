using DesktopsContactApp.Classes;
using System;
using System.Windows;
using System.Windows.Controls;

namespace DesktopsContactApp.Controls
{
    /// <summary>
    /// Interaction logic for ContactsControl.xaml
    /// </summary>
    public partial class ContactsControl : UserControl
    {

        public Contacts Contacts
        {
            get { return (Contacts)GetValue(contactsProperty); }
            set { SetValue(contactsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for contacts.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty contactsProperty =
            DependencyProperty.Register("Contacts", typeof(Contacts), typeof(ContactsControl), new PropertyMetadata(new Contacts() { Name = "Name Lastname", Phone = "0748399412", Email = "default@email.com" }, SetText));

        private static void SetText(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactsControl control = d as ContactsControl;

            if(control != null)
            {
                control.nameTextBlock.Text = (e.NewValue as Contacts).Name;
                control.phoneTextBlock.Text = (e.NewValue as Contacts).Phone;
                control.emailTextBlock.Text = (e.NewValue as Contacts).Email;
            }
        }

        public ContactsControl()
        {
            InitializeComponent();
        }
    }
}
