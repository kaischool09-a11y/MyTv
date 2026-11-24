using System.Windows.Input;
using MyTv.Data;
using MyTv.Models;
using MyTv.Services;
using MyTv.Views;

namespace MyTv.ViewModels
{
    public class LoginViewModel
    {
        private DatabaseService database;
        private CurrentUserService currentUserService;

        public string Username { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand { get; set; }

        public LoginViewModel(
            DatabaseService database,
            CurrentUserService currentUserService)
        {
            this.database = database;
            this.currentUserService = currentUserService;

            LoginCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Username) ||
                    string.IsNullOrWhiteSpace(Password))
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Please enter username and password", "OK");
                    return;
                }

                User user = await database.GetUserByUsername(Username);

                if (user == null || user.Password != Password)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Incorrect username or password", "OK");
                    return;
                }

                if (user.IsBlocked)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Your account is blocked", "OK");
                    return;
                }

                currentUserService.CurrentUser = user;

                await Shell.Current.DisplayAlertAsync(
                    "Success", "Login successful!", "OK");

                await Shell.Current.Navigation.PushAsync(
                    new HomePage(new HomeViewModel(currentUserService)));
            });
        }
    }
}