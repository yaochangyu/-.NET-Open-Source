using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tako.GlobalHotKey.Demo.Winform
{
    public partial class Form1 : Form
    {
        private HotKeyProvider m_Provider;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.m_Provider = new HotKeyProvider();
            this.m_Provider.HotKeyPressed += m_Provider_HotKeyPressed;
        }

        private void button_Register_Click(object sender, EventArgs e)
        {
            var key1 = m_Provider.Register(System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control, Key.F5);
            var key2 = m_Provider.Register(System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control, Key.F4);

            if (key1 && key2)
            {
                MessageBox.Show("success");
            }
        }

        private void button_Unregister_Click(object sender, EventArgs e)
        {
            var key1 = m_Provider.Unregister(System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control, Key.F5);
            var key2 = m_Provider.Unregister(System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control, Key.F4);
            if (key1 && key2)
            {
                MessageBox.Show("success");
            }
        }

        private void m_Provider_HotKeyPressed(object sender, HotKeyPressedEventArgs e)
        {
            if (e.HotKey.ModifierKeys == (System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control) && e.HotKey.Key == Key.F5)
            {
                MessageBox.Show("ctrl+alt+f5");
            }
            else if (e.HotKey.ModifierKeys == (System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control) && e.HotKey.Key == Key.F4)
            {
                MessageBox.Show("ctrl+alt+f4");
            }
        }
    }
}