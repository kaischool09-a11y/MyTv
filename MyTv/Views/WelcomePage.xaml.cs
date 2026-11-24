using MyTv.ViewModels;

namespace MyTv.Views;

public partial class WelcomePage : ContentPage
{
    public WelcomePage() : this(new WelcomeViewModel())
    {
    }

    public WelcomePage(WelcomeViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}