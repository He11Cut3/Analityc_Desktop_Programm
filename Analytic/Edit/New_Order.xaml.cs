using Analytic.User_Control;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для New_Order.xaml
    /// </summary>
    public partial class New_Order : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Order _uc;

        public New_Order(Analytic_dbEntities1 analytic_DbEntities1, UC_Order _uc_order)
        {
            InitializeComponent();
            this._context = analytic_DbEntities1;
            this._uc = _uc_order;
            OOrder_Status.IsEnabled = false;
            OOrder_Status.Text = "В сборке";
            OOrder_Date.IsEnabled = false;
            string time_2_week = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
            OOrder_Date.Text = time_2_week;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Order.Add(new Analityc_Order()
                {
                    Analityc_Order_Name = OOrder_Name.Text,
                    Analityc_Order_Vendor_Code = OOrder_Vendor_Code.Text,
                    Analityc_Order_Weight = OOrder_Weight.Text,
                    Analityc_Order_Number_Boxes = OOrder_Number_Boxes.Text,
                    Analityc_Order_Date = OOrder_Date.Text,
                    Analityc_Order_Status = OOrder_Status.Text,
                });
                _context.SaveChanges();
                _uc.Update_Order();
                this.Close();
            }
        }
    }
}
