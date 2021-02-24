using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ContactsApp.Entities;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Contact> _contacts;
        public MainWindow()
        {
            InitializeComponent();
            _contacts = new List<Contact>();
            ReadDB();
        }

        private void BtnNewContact_OnClick(object sender, RoutedEventArgs e)
        {
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            ReadDB();
        }

        void ReadDB()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.CreateTable<Contact>();
                _contacts = connection.Table<Contact>().ToList().OrderBy(x => x.Name).ToList();
            }

            if (_contacts != null)
            {
                //foreach (var contact in contacts)
                //{
                //    ListVContacts.Items.Add(new ListViewItem()
                //    {
                //        Content = contact.Name
                //    });
                //}

                ListVContacts.ItemsSource = _contacts;
            }
        }

        private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                TextBox searchTextBox = sender as TextBox;
                var filteredList = _contacts.Where(x => x.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
                ListVContacts.ItemsSource = filteredList;
            }
            catch (Exception)
            {

            }

        }
    }
}
