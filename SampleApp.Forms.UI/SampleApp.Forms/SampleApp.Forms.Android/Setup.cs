using Acr.UserDialogs;
using MvvmCross;
using MvvmCross.Forms.Platforms.Android.Core;
using MvvmCross.Platforms.Android;
using MvvmCross.ViewModels;
using SampleApp.Core;

namespace SampleApp.Forms.Droid
{
    public class Setup : MvxFormsAndroidSetup<App,FormsApp>
    {
        protected override void InitializeFirstChance()
        {
            base.InitializeFirstChance();
            UserDialogs.Init(() => Mvx.IoCProvider.Resolve<IMvxAndroidCurrentTopActivity>().Activity);
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }
    }
}