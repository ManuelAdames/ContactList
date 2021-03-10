using System;
using System.Collections.Generic;
using System.Text;
using ContactList.Views;
using Xamarin.Forms;
using System.Windows.Input;
using ContactList.ViewModels;
using ContactList.Models;
using System.Collections.ObjectModel;

namespace ContactList.ViewModels
{
    class AddUserViewModel
    {

        public ICommand RegisterCommand { get; }
        public string Name { get; set; }
        public string Number { get; set; }
        public ObservableCollection<Contact> Contacts { get; }
        public AddUserViewModel(ObservableCollection<Contact>ContactList)
        {
            Contacts = ContactList;
            RegisterCommand = new Command(OnRegister);
        }
        private async void OnRegister()
        {
            Contacts.Add(new Contact(Name, Number));
            await App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
