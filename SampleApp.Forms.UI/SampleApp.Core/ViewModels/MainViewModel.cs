using MvvmCross.ReactiveUI.Core.ViewModel;
using SampleApp.Core.NavigationArgs;

namespace SampleApp.Core.ViewModels
{
    public class MainViewModel : MvxReactiveViewModel<UserNavigationArgs,UserNavigationArgs>
    {
        public string Username { get; set; }
        public override void Prepare(UserNavigationArgs user)
        {
            Username = $"Welcome {user.Username} to Xamarin.Forms!";
        }
    }
}
