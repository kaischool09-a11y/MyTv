using System.Windows.Input;
using MyTv.Services;

namespace MyTv.ViewModels
{
    public class HomeViewModel
    {
        private CurrentUserService currentUserService;

        public string WelcomeMessage { get; set; }

        public ICommand LogoutCommand { get; set; }

        public HomeViewModel(CurrentUserService currentUserService)
        {
            this.currentUserService = currentUserService;

            WelcomeMessage = "Welcome, " +
                currentUserService.CurrentUser.Username + "!!";

            LogoutCommand = new Command(async () =>
            {
                currentUserService.Logout();

                await Shell.Current.GoToAsync("//WelcomePage");
            });
        }
    }
}