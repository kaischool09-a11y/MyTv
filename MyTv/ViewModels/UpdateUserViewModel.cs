using System.Windows.Input;
using MyTv.Data;
using MyTv.Services;

namespace MyTv.ViewModels
{
    public class UpdateUserViewModel
    {
        private DatabaseService database;
        private CurrentUserService currentUserService;

        public string Username { get; set; }

        public ICommand UpdateCommand { get; set; }

        public UpdateUserViewModel(
            DatabaseService database,
            CurrentUserService currentUserService)
        {
            this.database = database;
            this.currentUserService = currentUserService;

            Username = currentUserService.CurrentUser.Username;

            UpdateCommand = new Command(async () =>
            {
                if (string.IsNullOrWhiteSpace(Username))
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Username cannot be empty", "OK");
                    return;
                }

                var existingUser =
                    await database.GetUserByUsername(Username);

                if (existingUser != null &&
                    existingUser.UserId != currentUserService.CurrentUser.UserId)
                {
                    await Shell.Current.DisplayAlertAsync(
                        "Error", "Username already exists", "OK");
                    return;
                }

                currentUserService.CurrentUser.Username = Username;

                await database.UpdateUser(
                    currentUserService.CurrentUser);

                await Shell.Current.DisplayAlertAsync(
                    "Success", "Username updated successfully", "OK");
            });
        }
    }
}