using System;
using System.Threading.Tasks;
using Object = UnityEngine.Object;

namespace com.N8Dev.Brackeys.Utilities
{
    public static class AsyncUtil
    {
        public static async void Invoke(this Object _caller, Action _action, float _seconds)
        {
            await Task.Delay(TimeSpan.FromSeconds(_seconds));
            if (_caller != null)
                _action.Invoke();
        }
    }
}