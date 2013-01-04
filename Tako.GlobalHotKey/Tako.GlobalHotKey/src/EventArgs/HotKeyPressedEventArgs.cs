using System;

namespace Tako.GlobalHotKey
{
    [Serializable]
    public class HotKeyPressedEventArgs : EventArgs
    {
        public HotKeyPressedEventArgs(HotKey HotKey)
        {
            if (HotKey == null)
            {
                throw new ArgumentNullException("HotKey");
            }
            this.HotKey = HotKey;
        }

        public HotKey HotKey { get; private set; }
    }
}