using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Input;
using System.Windows.Interop;

namespace Tako.GlobalHotKey
{
    public class HotKeyProvider : IHotKeyProvider
    {
        //constant
        private readonly int WM_HOTKEY = 0x0312;

        //event
        public event EventHandler<HotKeyPressedEventArgs> HotKeyPressed;

        //fields

        private bool m_Disposed = false;
        private int m_RegisterIndex = 0;

        private readonly Dictionary<HotKey, int> m_RegisteredList = null;
        private HwndSource m_HandleSource = null;

        //win32 api define
        [DllImport("user32.dll", EntryPoint = "RegisterHotKey")]
        private static extern bool s_RegisterHotKey(IntPtr handle, int id, uint modifiers, uint virtualCode);

        [DllImport("user32.dll", EntryPoint = "UnregisterHotKey")]
        private static extern bool s_UnregisterHotKey(IntPtr handle, int id);

        //constructor
        public HotKeyProvider()
        {
            if (this.m_HandleSource == null)
            {
                this.m_HandleSource = new HwndSource(new HwndSourceParameters());

                // this.m_HandleSource.AddHook(HwndSourceHook);
                this.m_HandleSource.AddHook(messagesHandler);
            }
            if (this.m_RegisteredList == null)
            {
                this.m_RegisteredList = new Dictionary<HotKey, int>();
            }
        }

        protected virtual IntPtr HwndSourceHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY)
            {
                var modifiers = (ushort)lParam;//Modifiers key code
                var vk = (ushort)(lParam.ToInt32() >> 16);//virtual key code
                var vkey = KeyInterop.KeyFromVirtualKey(vk);
                var modifiersKey = (ModifierKeys)(modifiers);

                OnKeyPressed(new HotKeyPressedEventArgs(new HotKey(modifiersKey, vkey)));

                handled = true;
                return new IntPtr(1);
            }

            return IntPtr.Zero;
        }

        protected virtual void OnKeyPressed(HotKeyPressedEventArgs e)
        {
            if (e == null)
            {
                throw new ArgumentNullException("e");
            }
            if (this.HotKeyPressed != null)
            {
                this.HotKeyPressed.Invoke(this, e);
            }
        }

        public bool Register(ModifierKeys modifierKeys, Key Key)
        {
            var hotKey = new HotKey(modifierKeys, Key);
            return Register(hotKey);
        }

        public bool Register(HotKey hotKey)
        {
            if (this.m_RegisteredList.ContainsKey(hotKey))
            {
                return false;
            }
            this.m_RegisterIndex++;
            this.m_RegisteredList.Add(hotKey, this.m_RegisterIndex);
            var virtualCode = KeyInterop.VirtualKeyFromKey(hotKey.Key);
            return s_RegisterHotKey(this.m_HandleSource.Handle, this.m_RegisterIndex, (uint)hotKey.ModifierKeys, (uint)virtualCode);
        }

        public bool Unregister(ModifierKeys modifierKeys, Key Key)
        {
            var hotKey = new HotKey(modifierKeys, Key);
            return Unregister(hotKey);
        }

        public bool Unregister(HotKey hotKey)
        {
            if (!this.m_RegisteredList.ContainsKey(hotKey))
            {
                return false;
            }
            var id = this.m_RegisteredList[hotKey];
            this.m_RegisteredList.Remove(hotKey);
            return s_UnregisterHotKey(this.m_HandleSource.Handle, id);
        }

        public IEnumerable<HotKey> GetRegisteredHotKey()
        {
            return m_RegisteredList.Select(hotkey => hotkey.Key).ToList();
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private IntPtr messagesHandler(IntPtr handle, int message, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (message == WM_HOTKEY)
            {
                // Extract key and modifiers from the message.
                var key = KeyInterop.KeyFromVirtualKey(((int)lParam >> 16) & 0xFFFF);
                var modifiers = (ModifierKeys)((int)lParam & 0xFFFF);

                var hotKey = new HotKey(modifiers, key);

                //onKeyPressed(new KeyPressedEventArgs(hotKey));

                handled = true;
                return new IntPtr(1);
            }

            return IntPtr.Zero;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (this.m_Disposed)
                return;

            if (disposing)
            {
                //clean management resource
                if (HotKeyPressed != null)
                {
                    HotKeyPressed = null;
                }
            }

            //clean unmanagement resource

            //UnregisterHotKey
            foreach (var register in m_RegisteredList)
            {
                s_UnregisterHotKey(this.m_HandleSource.Handle, register.Value);
            }

            if (this.m_HandleSource != null)
            {
                //this.m_HandleSource.RemoveHook(HwndSourceHook);
                this.m_HandleSource.RemoveHook(messagesHandler);
                this.m_HandleSource.Dispose();

                this.m_HandleSource = null;
            }

            //change flag
            this.m_Disposed = true;
        }

        ~HotKeyProvider()
        {
            this.Dispose(false);
        }
    }
}