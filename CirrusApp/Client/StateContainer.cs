using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CirrusApp.Client
{
    public class StateContainer
    {
        public bool IsAuthenticated { get; set; } = false;

        public event Action onChange;

        public void SetProperty()
        {
            IsAuthenticated = !IsAuthenticated;
        }

        private void NotifyStateChanged() => onChange?.Invoke();
    }
}
