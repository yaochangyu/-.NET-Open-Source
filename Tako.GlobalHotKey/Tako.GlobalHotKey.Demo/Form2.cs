using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;
using Tako.GlobalHotKey;

namespace Tako.GlobalHotKey.Demo
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            m_provider = new HotKeyProvider();
            m_provider.HotKeyPressed += m_provider_HotKeyPressed;
        }

        private HotKeyProvider m_provider = null;

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private void m_provider_HotKeyPressed(object sender, HotKeyPressedEventArgs e)
        {
            if ((e.HotKey.ModifierKeys == (System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt)) && e.HotKey.Key == Key.F5)
            {
                MessageBox.Show("ctrl+alt+f5");
            }
            else if ((e.HotKey.ModifierKeys == (System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt)) && e.HotKey.Key == Key.F4)
            {
                MessageBox.Show("ctrl+alt+f4");
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            var hotKey1 = new HotKey(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt, Key.F5);
            var hotKey2 = new HotKey(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt, Key.F5);
            if (hotKey1 == hotKey2)
            {
                MessageBox.Show("同款啦");
            }
            MessageBox.Show(m_provider.Register(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt, Key.F5).ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            m_provider.Unregister(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt, Key.F5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_provider.Register(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Alt, Key.F4).ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var list = m_provider.GetRegisteredHotKey();
            this.listBox1.DataSource = list;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_provider.Register(System.Windows.Input.ModifierKeys.Control | System.Windows.Input.ModifierKeys.Shift, Key.F4).ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show(m_provider.Register(System.Windows.Input.ModifierKeys.Shift, Key.D4).ToString());
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            //m_provider.Dispose();
        }
    }
}