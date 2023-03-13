using Analytic.Edit;
using Analytic.User_Control;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Analytic
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Stock> _material = new List<Analityc_Stock>();
        public Main()
        {
            InitializeComponent();
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            DragMove();
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
       

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_Plan_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();


            UC_User uC_User = new UC_User();
            LV_User_Grid.Children.Add(uC_User);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();

            UC_Order uC_Order = new UC_Order();
            LV_Order.Children.Add(uC_Order);

        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Order.Children.Clear();

            UC_Product uC_Product = new UC_Product();
            LV_Product.Children.Add(uC_Product);
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;

            LV_User_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();

            UC_Plan uC_Plan = new UC_Plan();
            LV_Plan_Grid.Children.Add(uC_Plan);
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;

            LV_User_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Order.Children.Clear();
            LV_Product.Children.Clear();


            UC_Plan_Week uC_Plan_Week = new UC_Plan_Week();
            LV_Plan_Week_Grid.Children.Add(uC_Plan_Week);
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;

            LV_User_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();

            UC_Plan_Month uC_Plan_Month = new UC_Plan_Month();
            LV_Plan_Month_Grid.Children.Add(uC_Plan_Month);
        }

        private void RadioButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Order.Children.Clear();
            LV_Product.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
        }

        private void RadioButton_Checked_7(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Product.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();

            UC_Recipe uC_Recipe = new UC_Recipe();
            LV_Recipe.Children.Add(uC_Recipe);
        }
    }
}
