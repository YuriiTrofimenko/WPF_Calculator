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

namespace WPF_Calculator.Pages
{
    /// <summary>
    /// Логика взаимодействия для ExtraPage.xaml
    /// </summary>
    public partial class ExtraPage : Page
    {
        #region Instancing
        static private ExtraPage _Instance;
        static public ExtraPage Instance { get { if (_Instance is null) _Instance = new ExtraPage(); return _Instance; } }
        #endregion
        #region Events
        public event Action<object, RoutedEventArgs> OnChagePage;
        public event Action<object, RoutedEventArgs> OnButtonPresed;

        #endregion
        public ExtraPage()
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
