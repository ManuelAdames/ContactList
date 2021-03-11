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
        public ICommand MoreCommand { get; }
        public HomeViewModel()
        {
            MoreCommand = new Command<Contact>(OnMore);
            AddCommand = new Command(OnAddContact);
            DeleteCommand = new Command<Contact>(OnDeleteContact);

            Contacts = new ObservableCollection<Contact>
            {
            };
        }

        private async void OnMore(Contact contact)
        {
            string option = await App.Current.MainPage.DisplayActionSheet(null, "Cancel", null, "Call +" + contact.Number, "Edit");
            if (option == "Call +" + contact.Number)
            {
                try
                {
                    PhoneDialer.Open(contact.Number);
                }
                catch (Exception)
                {
                    await App.Current.MainPage.DisplayAlert("No se pudo realizar la llamada", "Intentelo mas tarde", "Ok");
                }
            }
            else if (option == "Edit") 
            {
                int newIndex = Contacts.IndexOf(contact);
                var result = await App.Current.MainPage.DisplayPromptAsync("Add New Name", "Type Name", "Ok");
                var phone = await App.Current.MainPage.DisplayPromptAsync("Add New Number", "Type Number", "Ok");
                Contacts.Remove(contact);
                Contacts.Add(new Contact(result, phone));
                int oldIndex = Contacts.Count - 1;
                Contacts.Move(oldIndex,newIndex);
            }
        }
        private async void OnAddContact()
        {
            await App.Current.MainPage.Navigation.PushAsync(new AddUserPage(Contacts));
        }
        private void OnDeleteContact(Contact contact)
        {
            Contacts.Remove(contact);
        }
    }
}
