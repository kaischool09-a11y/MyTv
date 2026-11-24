using Microsoft.Extensions.DependencyInjection;
using MyTv.ViewModels;

namespace MyTv.Views;

public partial class LoginPage : ContentPage
{
    public LoginPage() : this(CreateViewModel())
    {
    }

    private static LoginViewModel CreateViewModel()
    {
        var services = Application.Current?.Handler?.MauiContext?.Services;

        return services!.GetRequiredService<LoginViewModel>();
    }

    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}