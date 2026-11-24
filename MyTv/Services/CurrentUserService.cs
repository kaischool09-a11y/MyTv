using MyTv.Models;

namespace MyTv.Services
{
    public class CurrentUserService
    {
        public User CurrentUser { get; set; }

        public bool IsLoggedIn
        {
            get
            {
                return CurrentUser != null;
            }
        }

        public void Logout()
        {
            CurrentUser = null;
        }
    }
}