using System;

namespace MvvmCross.ReactiveUI.Core.Action
{
    public class DisposableAction : IDisposable
    {
        private readonly System.Action _action;

        public DisposableAction(System.Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }
}
