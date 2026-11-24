using System.Windows.Input;
using MyTv.Data;
using MyTv.Models;

namespace MyTv.ViewModels
{
    public class RegisterViewModel
    {
        private DatabaseService database;

        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public ICommand RegisterCommand { get; set; }

        public RegisterViewModel()
        {
            database = new DatabaseService();

            RegisterCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Username) ||
                    string.IsNullOrWhiteSpace(Password) ||
                    string.IsNullOrWhiteSpace(ConfirmPassword))
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Please fill in all fields", "OK");
                    return;
                }

                if (Password != ConfirmPassword)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Passwords do not match", "OK");
                    return;
                }

                User existingUser = await database.GetUserByUsername(Username);

                if (existingUser != null)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Username already exists", "OK");
                    return;
                }

                User newUser = new User
                {
                    Username = Username,
                    Password = Password,
                    Role = "User",
                    IsBlocked = false
                };

                await database.AddUser(newUser);

                await Shell.Current.DisplayAlertAsync(
                    "Success", "Registration completed!", "OK");
            });
        }
    }
}