using MyTv.ViewModels;

namespace MyTv.Views;

public partial class RegisterPage : ContentPage
{
    public RegisterPage() : this(new RegisterViewModel())
    {
    }

    public RegisterPage(RegisterViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}