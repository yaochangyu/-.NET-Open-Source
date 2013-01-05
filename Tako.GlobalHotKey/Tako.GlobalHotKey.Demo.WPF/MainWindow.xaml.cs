using System.Windows;
using System.Windows.Input;

namespace Tako.GlobalHotKey.Demo.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Tako.GlobalHotKey.HotKeyProvider m_Provider;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.m_Provider = new HotKeyProvider();
            this.m_Provider.HotKeyPressed += m_Provider_HotKeyPressed;
        }

        private void m_Provider_HotKeyPressed(object sender, HotKeyPressedEventArgs e)
        {
            if (e.HotKey.ModifierKeys == (ModifierKeys.Alt | ModifierKeys.Control) && e.HotKey.Key == Key.F5)
            {
                MessageBox.Show("ctrl+alt+f5");
            }
            else if (e.HotKey.ModifierKeys == (ModifierKeys.Alt | ModifierKeys.Control) && e.HotKey.Key == Key.F4)
            {
                MessageBox.Show("ctrl+alt+f4");
            }
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            var key1 = m_Provider.Register(ModifierKeys.Alt | ModifierKeys.Control, Key.F5);
            var key2 = m_Provider.Register(ModifierKeys.Alt | ModifierKeys.Control, Key.F4);
            if (key1 && key2)
            {
                MessageBox.Show("success");
            }
        }

        private void Button_Unegister_Click(object sender, RoutedEventArgs e)
        {
            var key1 = m_Provider.Unregister(ModifierKeys.Alt | ModifierKeys.Control, Key.F5);
            var key2 = m_Provider.Unregister(ModifierKeys.Alt | ModifierKeys.Control, Key.F4);
            if (key1 && key2)
            {
                MessageBox.Show("success");
            }
        }
    }
}