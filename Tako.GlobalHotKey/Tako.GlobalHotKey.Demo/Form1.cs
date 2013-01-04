using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using System.Windows.Input;

namespace Tako.GlobalHotKey.Demo
{
    public partial class Form1 : Form
    {
        private Form2 fm = new Form2();

        public Form1()
        {
            InitializeComponent();

            //this.KeyPreview = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button1");
            fm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button2");
        }

        //protected override bool ProcessDialogKey(Keys keyData)
        //{
        //    if (keyData == (Keys.Control | Keys.Alt | Keys.F5))
        //    {
        //        button1.PerformClick();
        //        return true;
        //    }
        //    return base.ProcessDialogKey(keyData);
        //}

        //protected override bool ProcessCmdKey(ref Message m, Keys keyData)
        //{
        //    if (keyData == (Keys.Control | Keys.Alt | Keys.F5))
        //    {
        //        //TODO:執行功能
        //        button1.PerformClick();
        //        return true;
        //    }
        //    return base.ProcessCmdKey(ref m, keyData);
        //}

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.Alt | Keys.F5))
            {
                button1.PerformClick();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("选单被按下");
        }

        [DllImport("user32.dll")]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint fsModifiers, uint vk);

        [DllImport("user32.dll")]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        private void Form1_Load(object sender, EventArgs e)
        {
            var modifierKeys = (uint)(System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control);
            Boolean success = RegisterHotKey(this.Handle, this.GetType().GetHashCode(), modifierKeys, (uint)KeyInterop.VirtualKeyFromKey(System.Windows.Input.Key.F5));
            if (success == true)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                string binary = System.Convert.ToString(m.LParam.ToInt32(), 2).PadLeft(32, '0');//轉成二進制
                var modifiers = (ushort)m.LParam;//Modifiers key code
                var vk = (ushort)(m.LParam.ToInt32() >> 16);//virtual key code
                var key = KeyInterop.KeyFromVirtualKey(vk);
                var modifiersKey = (ModifierKeys)(modifiers);
                if ((modifiersKey == (System.Windows.Input.ModifierKeys.Alt | System.Windows.Input.ModifierKeys.Control) && key == Key.F5))
                {
                    MessageBox.Show("ctrl+alt+f5 被按下");
                }
            }
            base.WndProc(ref m);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Boolean success = UnregisterHotKey(this.Handle, this.GetType().GetHashCode());
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
        }
    }
}