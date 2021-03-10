using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using ContactList.Models;
using Xamarin.Forms;
using ContactList.Views;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Essentials;

namespace ContactList.ViewModels
{
    public class HomeViewModel
    {
        public ObservableCollection<Contact> Contacts { get; }
        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }
        private ICommand MoreCommmand { get; }

        public HomeViewModel()
        {
            MoreCommmand = new Command<Contact>(OnMore);
            AddCommand = new Command(OnAddContact);
            DeleteCommand = new Command<Contact>(OnDeleteContact);

            Contacts = new ObservableCollection<Contact>
            {
                //new Contact ("Maicol Martinez", "8095080000"),
                //new Contact ("Jose", "6784390294")
            };
        }

        private async void OnMore(Contact contact)
        {
            string option = await App.Current.MainPage.DisplayActionSheet(null, "Canecel", null, "Call +" + contact.Number, "Cancel");
            if (option == "Call +" + contact.Number)
            {
                try
                {
                    PhoneDialer.Open(contact.Number);
                }
                catch(Exception)
                {
                    await App.Current.MainPage.DisplayAlert("No se pudo realizar la llamada", "Intentelo mas tarde", "Ok");
                }
            }
        }
        private async void OnAddContact()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddUserPage());
            //var result = await App.Current.MainPage.DisplayPromptAsync("Add Name", "Type Name", "Ok");
            //var phone = await App.Current.MainPage.DisplayPromptAsync("Add Number", "Type Number", "Ok");

            //Contacts.Add(new Contact(result, phone));

        }
        private void OnDeleteContact(Contact contact)
        {
            Contacts.Remove(contact);
        }
    }
}
