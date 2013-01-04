using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Tako.GlobalHotKey
{
    public interface IHotKeyProvider : IDisposable
    {
        bool Register(ModifierKeys modifierKeys, Key keys);

        bool Register(HotKey hotKey);

        bool Unregister(ModifierKeys modifierKeys, Key keys);

        bool Unregister(HotKey hotKey);

        IEnumerable<HotKey> GetRegisteredHotKey();
    }
}