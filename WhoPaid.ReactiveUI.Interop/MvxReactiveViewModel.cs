using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MvvmCross.ViewModels;
using ReactiveUI;
using PropertyChangingEventArgs = ReactiveUI.PropertyChangingEventArgs;
using PropertyChangingEventHandler = ReactiveUI.PropertyChangingEventHandler;

namespace WhoPaid.ReactiveUI.Interop
{
    public abstract class MvxReactiveViewModel<TParameter, TResult> : MvxViewModel<TParameter, TResult>, IMvxReactiveViewModel<TParameter, TResult>
    {
        private readonly MvxReactiveObject _reactiveObj = new MvxReactiveObject();

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObj.Changed;

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _reactiveObj.Changing;

        public IObservable<Exception> ThrownExceptions => _reactiveObj.ThrownExceptions;

        public new event PropertyChangedEventHandler PropertyChanged
        {
            add => _reactiveObj.PropertyChanged += value;
            remove => _reactiveObj.PropertyChanged -= value;
        }

        public new event PropertyChangingEventHandler PropertyChanging
        {
            add => _reactiveObj.PropertyChanging += value;
            remove => _reactiveObj.PropertyChanging -= value;
        }

        public new void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _reactiveObj.RaisePropertyChanged(args.PropertyName);
        }

        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _reactiveObj.RaisePropertyChanging(args.PropertyName);
        }

        public new bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var original = storage;

            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value, propertyName);

            return !EqualityComparer<T>.Default.Equals(original, value);
        }

        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveObj.SuppressChangeNotificationsInterop();
        }

        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            if (_reactiveObj.IsSuppressed)
            {
                return MvxInpcInterceptionResult.DoNotRaisePropertyChanged;
            }

            return base.InterceptRaisePropertyChanged(changedArgs);
        }
    }

    public abstract class MvxReactiveViewModel<TParameter> : MvxViewModel<TParameter>, IMvxReactiveViewModel<TParameter>
    {
        private readonly MvxReactiveObject _reactiveObj = new MvxReactiveObject();

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObj.Changed;

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _reactiveObj.Changing;

        public IObservable<Exception> ThrownExceptions => _reactiveObj.ThrownExceptions;

        public new event PropertyChangedEventHandler PropertyChanged
        {
            add => _reactiveObj.PropertyChanged += value;
            remove => _reactiveObj.PropertyChanged -= value;
        }

        public new event PropertyChangingEventHandler PropertyChanging
        {
            add => _reactiveObj.PropertyChanging += value;
            remove => _reactiveObj.PropertyChanging -= value;
        }

        public new void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _reactiveObj.RaisePropertyChanged(args.PropertyName);
        }

        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _reactiveObj.RaisePropertyChanging(args.PropertyName);
        }

        public new bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var original = storage;

            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value, propertyName);

            return !EqualityComparer<T>.Default.Equals(original, value);
        }

        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveObj.SuppressChangeNotificationsInterop();
        }

        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            if (_reactiveObj.IsSuppressed)
            {
                return MvxInpcInterceptionResult.DoNotRaisePropertyChanged;
            }

            return base.InterceptRaisePropertyChanged(changedArgs);
        }
    }

    public abstract class MvxReactiveViewModel : MvxViewModel, IMvxReactiveViewModel
    {
        private readonly MvxReactiveObject _reactiveObj = new MvxReactiveObject();

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changed => _reactiveObj.Changed;

        public IObservable<IReactivePropertyChangedEventArgs<IReactiveObject>> Changing => _reactiveObj.Changing;

        public IObservable<Exception> ThrownExceptions => _reactiveObj.ThrownExceptions;

        public new event PropertyChangedEventHandler PropertyChanged
        {
            add => _reactiveObj.PropertyChanged += value;
            remove => _reactiveObj.PropertyChanged -= value;
        }

        public new event PropertyChangingEventHandler PropertyChanging
        {
            add => _reactiveObj.PropertyChanging += value;
            remove => _reactiveObj.PropertyChanging -= value;
        }

        public new void RaisePropertyChanged(PropertyChangedEventArgs args)
        {
            _reactiveObj.RaisePropertyChanged(args.PropertyName);
        }

        public void RaisePropertyChanging(PropertyChangingEventArgs args)
        {
            _reactiveObj.RaisePropertyChanging(args.PropertyName);
        }

        public new bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            var original = storage;

            IReactiveObjectExtensions.RaiseAndSetIfChanged(this, ref storage, value, propertyName);

            return !EqualityComparer<T>.Default.Equals(original, value);
        }

        public IDisposable SuppressChangeNotifications()
        {
            return _reactiveObj.SuppressChangeNotificationsInterop();
        }

        protected override MvxInpcInterceptionResult InterceptRaisePropertyChanged(PropertyChangedEventArgs changedArgs)
        {
            if (_reactiveObj.IsSuppressed)
            {
                return MvxInpcInterceptionResult.DoNotRaisePropertyChanged;
            }

            return base.InterceptRaisePropertyChanged(changedArgs);
        }
    }
}