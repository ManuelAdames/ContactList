using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContactList.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ContactList.Models;

namespace ContactList.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddUserPage : ContentPage
    {
        public AddUserPage(ObservableCollection<Contact>ContactList)
        {
            InitializeComponent();
            BindingContext = new AddUserViewModel(ContactList);
        }
    }
}