using System;
using System.Threading.Tasks;

namespace com.N8Dev.Allete.Utilities
{
    public static class AsyncUtilities
    {
        public static async void Invoke(this object _caller, Action _action, float _seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            if (!(_caller is null))
                _action.Invoke();
        }
    }
}