using MvvmCross.ReactiveUI.Core.View;
using SampleApp.Core.ViewModels;

namespace SampleApp.Forms.Views
{
    public partial class MainPage : ContentPageBase<MainViewModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}
