using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CirrusApp.Client
{
    public class AuthContainer
    {
        private bool _isAuthenticated = false;
        public bool IsAuthenticated { get { return this._isAuthenticated; } }

        public event Action onChange;

        public void SetProperty()
        {
            _isAuthenticated = !_isAuthenticated;
            StateChanged();
        }

        private void StateChanged() => onChange?.Invoke();
    }
}
