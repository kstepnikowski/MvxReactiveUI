using MvvmCross.ReactiveUI.Core.View;
using SampleApp.Core.ViewModels;
using Xamarin.Forms.Xaml;

namespace SampleApp.Forms.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPageBase<LoginViewModel>
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
