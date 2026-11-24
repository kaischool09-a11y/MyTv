using System.Windows.Input;

namespace MyTv.ViewModels
{
    public class WelcomeViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ICommand GoToLoginCommand { get; set; }

        public ICommand GoToRegisterCommand { get; set; }

        public WelcomeViewModel()
        {
            Title = "MyTv";
            Description = "Find movies and TV shows that match your taste.";

            GoToLoginCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("LoginPage");
            });

            GoToRegisterCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("RegisterPage");
            });
        }
    }
}