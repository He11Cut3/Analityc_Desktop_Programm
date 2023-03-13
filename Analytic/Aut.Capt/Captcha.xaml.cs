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
using System.Windows.Shapes;

namespace Analytic.Aut.Capt
{
    /// <summary>
    /// Логика взаимодействия для Captcha.xaml
    /// </summary>
    public partial class Captcha : Window
    {
        public Captcha()
        {
            InitializeComponent();
            Captcha1.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
            AnswerTextBlock.Text = Captcha1.CaptchaText;
        }

        private void Cpt_Click(object sender, RoutedEventArgs e)
        {
            if (AnswerTextBlock.Text == Cmb.Text)
            {
                Main main = new Main();
                this.Close();
                main.ShowDialog();
            }
            else
            {
                MessageBox.Show("Повторите попытку");
                Cmb.Text = "";
            }
        }

        private void Cpt_Change_Click(object sender, RoutedEventArgs e)
        {
            Captcha1.CreateCaptcha(EasyCaptcha.Wpf.Captcha.LetterOption.Alphanumeric, 5);
            AnswerTextBlock.Text = Captcha1.CaptchaText;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
    }
}
