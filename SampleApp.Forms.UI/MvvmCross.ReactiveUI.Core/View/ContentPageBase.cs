using System;
using System.Reactive.Disposables;
using ReactiveUI;
using ReactiveUI.XamForms;

namespace MvvmCross.ReactiveUI.Core.View
{
    public class ContentPageBase<TViewModel> : ReactiveContentPage<TViewModel> where TViewModel : class
    {
        protected override void OnAppearing()
        {
            base.OnAppearing();
            this.WhenActivated(disposables =>
            {
                this.WhenAnyValue(v => v.ViewModel)
                    .Subscribe(vm => BindingContext = vm)
                    .DisposeWith(disposables);
            });
        }
    }
}
