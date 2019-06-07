using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.ReactiveUI.Core.Action;
using MvvmCross.ReactiveUI.Core.Model;
using MvvmCross.ViewModels;
using ReactiveUI;
using INotifyPropertyChanging = System.ComponentModel.INotifyPropertyChanging;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace MvvmCross.ReactiveUI.Core.ViewModel
{
    public class MvxReactiveViewModel : MvxViewModel, IReactiveNotifyPropertyChanged<IReactiveObject>, IReactiveObject
    {
        private readonly MvxReactiveObject _mvxReactiveObject = new MvxReactiveObject();
        private bool _suppressNpc;

        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs) => _suppressNpc ? MvxInpcInterceptionResult.DoNotRaisePropertyChanged : base.InterceptRaisePropertyChanged(changedArgs);

        public virtual IDisposable SuppressChangeNotifications()
        {
            _suppressNpc = true;
            var suppressor = _mvxReactiveObject.SuppressChangeNotifications();

            return new DisposableAction(() =>
            {
                _suppressNpc = false;
                suppressor.Dispose();
            });
        }

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _mvxReactiveObject.Changing;
        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _mvxReactiveObject.Changed;
        public new event PropertyChangingEventHandler PropertyChanging
        {
            add => _mvxReactiveObject.PropertyChanging += value;
            remove => _mvxReactiveObject.PropertyChanging -= value;
        }

        public virtual void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _mvxReactiveObject.RaisePropertyChanging(args.PropertyName);
        }

        public new virtual void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _mvxReactiveObject.RaisePropertyChanged(args.PropertyName);
        }

        public new bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var original = storage;
            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value, propertyName);

            return !EqualityComparer<T>.Default.Equals(original,value);
        }
    }

    public abstract class MvxReactiveViewModel<T, TReturn> : MvxViewModel<T, TReturn>, IReactiveNotifyPropertyChanged<IReactiveObject>,
       IReactiveObject, INotifyPropertyChanged, INotifyPropertyChanging
    {
        private readonly MvxReactiveObject _mvxReactiveObject = new MvxReactiveObject();
        private bool _suppressNpc;

        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs) => _suppressNpc ? MvxInpcInterceptionResult.DoNotRaisePropertyChanged : base.InterceptRaisePropertyChanged(changedArgs);

        public virtual IDisposable SuppressChangeNotifications()
        {
            _suppressNpc = true;
            IDisposable suppressor = _mvxReactiveObject.SuppressChangeNotifications();
            return (IDisposable)new DisposableAction(() =>
            {
                _suppressNpc = false;
                suppressor.Dispose();
            });
        }

        public virtual void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _mvxReactiveObject.RaisePropertyChanging(args.PropertyName);
        }

        public new void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _mvxReactiveObject.RaisePropertyChanged(args.PropertyName);
        }

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _mvxReactiveObject.Changing;

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _mvxReactiveObject.Changed;

        public new event PropertyChangingEventHandler PropertyChanging
        {
            add => _mvxReactiveObject.PropertyChanging += value;
            remove => _mvxReactiveObject.PropertyChanging -= value;
        }

        public new bool SetProperty<TStore>(ref TStore storage, TStore value, [CallerMemberName] string propertyName = null)
        {
            TStore x = storage;
            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value,
                propertyName);
            return !EqualityComparer<TStore>.Default.Equals(x, value);
        }
    }
}
