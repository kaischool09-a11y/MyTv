using MyTv.ViewModels;
using MyTv.Services;

namespace MyTv.Views;

public partial class HomePage : ContentPage
{
    public HomePage() : this(
        new HomeViewModel(
            new CurrentUserService()))
    {
    }

    public HomePage(HomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}