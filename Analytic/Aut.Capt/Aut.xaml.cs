using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Analytic.Aut.Capt
{
    
    public partial class Aut : Window
    {
        private string text = String.Empty;
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();

        public Aut()
        {
            InitializeComponent();
        }
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void pnlControlBar_MouseLeftButtonDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            DragMove();
        }

        private void Avt_Click(object sender, RoutedEventArgs e)
        {
            var login = Login.Text;
            var password = Password.Password;
            Analityc_User users = null;
            using (ApplicationContext applicationContext = new ApplicationContext())
            {
                users = (Analityc_User)_context.Analityc_User.Where(b => b.Analityc_User_Login == login && b.Analityc_User_Password == password).FirstOrDefault();
            }
            if (users != null)
            {
                Captcha captcha = new Captcha();
                this.Close();
                captcha.ShowDialog();
                //Knit_Main knit_Main = new Knit_Main();
                //knit_Main.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Неправильный логин или пароль");
            }
        }

        private void Grid_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {

        }
    }
}
