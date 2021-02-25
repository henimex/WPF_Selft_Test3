using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using ContactsApp.Entities;
using SQLite;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for ContactDetailsWindow.xaml
    /// </summary>
    public partial class ContactDetailsWindow : Window
    {
        private Contact _contact;
        public ContactDetailsWindow(Contact contact)
        {
            InitializeComponent();
            _contact = contact;

            TxtDetailName.Text = _contact.Name;
            TxtDetailEmail.Text = _contact.Email;
            TxtDetailPhone.Text = _contact.Phone;
        }

        private void BtnUpdate_OnClick(object sender, RoutedEventArgs e)
        {
            _contact.Name = TxtDetailName.Text;
            _contact.Email = TxtDetailEmail.Text;
            _contact.Phone = TxtDetailPhone.Text;

            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Update(_contact);
            }

            Close();
        }

        private void BtnDelete_OnClick(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                connection.Delete(_contact);
            }

            Close();
        }
    }
}
