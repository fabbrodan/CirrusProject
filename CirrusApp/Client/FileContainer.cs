using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace CirrusApp.Client
{
    public class FileContainer
    {
        private List<dynamic> _files = new List<dynamic>();
        public List<dynamic> Files { get { return _files; } }

        public event Action onChange;

        public void AddFile(dynamic File)
        {
            _files.Add(File);
            StateChanged();
        }
        private void StateChanged() => onChange?.Invoke();
    }
}
