using Xamarin.Forms;
using Proyecto.ViewModels;
using Proyecto.Services;
using System;

namespace Proyecto.Views
{
    public partial class MainPage : ContentPage
    {
        private DatabaseService _databaseService;

        public MainPage()
        {
            InitializeComponent();
            _databaseService = new DatabaseService();
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            var username = UsernameEntry.Text;
            var password = PasswordEntry.Text;
            var rol = "admin";

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                await DisplayAlert("Error", "Por favor ingresa un nombre de usuario y una contraseña.", "OK");
                return;
            }

            bool isAuthenticated = await _databaseService.AuthenticateUser(username, password);
            DisplayAlert("User",username,"Ok");
            DisplayAlert("Pass",password,"ok") ;

            if (isAuthenticated)
            {
                // Aquí puedes navegar a una nueva página si el login es exitoso
                await DisplayAlert("Éxito", "Login exitoso", "OK");
                // Por ejemplo, navega a otra página: 
                // await Navigation.PushAsync(new HomePage());
            }
            else
            {
                await DisplayAlert("Error", "Nombre de usuario o contraseña incorrectos.", "OK");
            }
        }
    }
}

