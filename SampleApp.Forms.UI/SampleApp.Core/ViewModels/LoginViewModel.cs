using Acr.UserDialogs;
using MvvmCross.Navigation;
using MvvmCross.ReactiveUI.Core.ViewModel;
using MvvmCross.ViewModels;
using ReactiveUI;
using SampleApp.Core.NavigationArgs;
using SampleApp.Core.Services.Abstract;

namespace SampleApp.Core.ViewModels
{
    public class LoginViewModel : MvxReactiveViewModel
    {
        private string _username;
        public string Username
        {
            get => _username;
            set => MvxNotifyPropertyChangedExtensions.RaiseAndSetIfChanged(this, ref _username, value);
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => MvxNotifyPropertyChangedExtensions.RaiseAndSetIfChanged(this, ref _password, value);
        }

        public IReactiveCommand LoginCommand { get; }

        public LoginViewModel(ILoginService loginService, IMvxNavigationService navigationService)
        {
            LoginCommand = ReactiveCommand.CreateFromTask(async () =>
            {
                var isValid = await loginService.Login(Username, Password);

                if (isValid)
                {
                    await navigationService.Navigate<MainViewModel, UserNavigationArgs>(new UserNavigationArgs{Username = Username});
                }

                else
                {
                    await UserDialogs.Instance.AlertAsync("Please check your credentials", "Wrong", "Ok");
                }
            });
        }
    }
}
