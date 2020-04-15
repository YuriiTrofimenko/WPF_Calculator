using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
using WPF_Calculator.Pages;
namespace WPF_Calculator
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static DependencyProperty AnswerProperty;
        static MainWindow()
        {
            AnswerProperty =
                DependencyProperty.Register("Answer", typeof(string), typeof(MainWindow));
        }
        private bool IsAnswerClear { get; set; } = true;
        //public string History { get; set; } = "Welcome!";
        public string Answer {
            get { return (string)GetValue(AnswerProperty); }
            set { SetValue(AnswerProperty, value); }
        }


        public MainWindow()
        {
            InitializeComponent();

            OutputView.Content = MainPage.Instance.Content;
            MainPage.Instance.OnChagePage += (s, a) => { OutputView.Content = ExtraPage.Instance.Content; };
            ExtraPage.Instance.OnChagePage += (s, a) => { OutputView.Content = MainPage.Instance.Content; };
            ExtraPage.Instance.OnButtonPresed += HandleButtonPress;
            MainPage.Instance.OnButtonPresed += HandleButtonPress;

            this.DataContext = this;
        }


        private void HandleButtonPress(object sender, RoutedEventArgs args)
        {
            args.Handled = true;

            var button = sender as Button;
            Console.WriteLine("Event");
            if (Regex.IsMatch(button.Content.ToString(), @"Ce|C|="))
            {
                switch (button.Content)
                {
                    case "C":
                        if (Answer.ToString() != "" && !IsAnswerClear)
                        {
                            Answer = Answer.ToString().Remove(Answer.ToString().Length - 1);
                            if (Answer.ToString() == "")
                            {
                                Answer = "0";
                                IsAnswerClear = true;
                                History.Content = "";
                            }
                        }
                        break;
                    case "CE":
                        Answer = "0";
                        IsAnswerClear = true;
                        History.Content = "";
                        break;
                    case "=":
                        var expression = Answer.ToString();
                        History.Content = expression;
                        StringMath.Calculator calc = new StringMath.Calculator();
                        expression = expression.Replace("+-", "-");
                        Answer = calc.Evaluate(expression).ToString();
                        break;
                    default:
                        break;
                }
            }
            else
            {
                if (IsAnswerClear)
                    Answer = button.Content.ToString();
                else
                    Answer += button.Content.ToString();
                IsAnswerClear = false;
            }




            //switch (button.Content)
            //{
            //    case string val when new Regex(@"\d").IsMatch(val):
            //        if (IsAnswerClear)
            //        {
            //            Answer = val;
            //            IsAnswerClear = false;
            //        }
            //        else
            //            Answer = (string)Answer + val;
            //        break;
            //    case "C":
            //        if (Answer.ToString() != "" && !IsAnswerClear)
            //        {
            //            Answer = Answer.ToString().Remove(Answer.ToString().Length - 1);
            //            if (Answer.ToString() == "")
            //            {
            //                Answer = "0";
            //                IsAnswerClear = true;
            //            }
            //        }
            //        break;
            //    case "CE":
            //        Answer = "0";
            //        IsAnswerClear = true;
            //        break;
            //    default:
            //        break;
            //}


        }
    }
}
