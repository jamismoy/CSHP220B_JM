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
using ContactApp.Models;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            InitializeComponent();
            LoadContacts();
        }

        private void LoadContacts()
        {
            var contacts = App.ContactRepository.GetAll();

            uxContactList.ItemsSource = contacts
                .Select(t => ContactModel.ToModel(t))
                .ToList();

            // OR
            //var uiContactModelList = new List<ContactModel>();
            //foreach (var repositoryContactModel in contacts)
            //{
            //    This is the .Select(t => ... )
            //    var uiContactModel = ContactModel.ToModel(repositoryContactModel);
            //
            //    uiContactModelList.Add(uiContactModel);
            //}

            //uxContactList.ItemsSource = uiContactModelList;
        }


        private void uxFileNew_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();

            if (window.ShowDialog() == true)
            {
                var uiContactModel = window.Contact;

                var repositoryContactModel = uiContactModel.ToRepositoryModel();

                App.ContactRepository.Add(repositoryContactModel);

                // OR
                //App.ContactRepository.Add(window.Contact.ToRepositoryModel());
            }
        }
        private void uxFileChange_Click(object sender, RoutedEventArgs e)
        {
            var window = new ContactWindow();
            window.Contact = selectedContact.Clone();

            if (window.ShowDialog() == true)
            {
                App.ContactRepository.Update(window.Contact.ToRepositoryModel());
                LoadContacts();
            }
        }

        private void uxFileChange_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileChange.IsEnabled = (selectedContact != null);
            uxContextFileChange.IsEnabled = uxFileChange.IsEnabled;
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.ContactRepository.Remove(selectedContact.Id);
            selectedContact = null;
            LoadContacts();
        }

        private void uxFileDelete_Loaded(object sender, RoutedEventArgs e)
        {
            uxFileDelete.IsEnabled = (selectedContact != null);
            uxContextFileDelete.IsEnabled = uxFileDelete.IsEnabled;
        }

        private ContactModel selectedContact;
        private void uxContactList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedContact = (ContactModel)uxContactList.SelectedValue;
        }

        private void UxContactList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            uxFileChange_Click(null, null);
        }
    }
}
