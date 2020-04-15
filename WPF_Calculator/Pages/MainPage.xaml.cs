using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Calculator
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        #region Instancing
        static private MainPage _Instance;
        static public MainPage Instance { get { if (_Instance is null) _Instance = new MainPage(); return _Instance; } }
        #endregion
        #region Events
        public event Action<object,RoutedEventArgs> OnChagePage;
        public event Action<object,RoutedEventArgs> OnButtonPresed;
        #endregion
        public MainPage()
        {
            InitializeComponent();
        }

        private void ChangePage(object sender, RoutedEventArgs e)
        {
            OnChagePage?.Invoke(sender, e);
        }

        private void ButtonPresed(object sender, RoutedEventArgs e)
        {
            OnButtonPresed?.Invoke(sender, e);
        }
    }
}
