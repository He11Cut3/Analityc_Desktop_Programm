using Analytic.User_Control;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для Edit_Del_Order.xaml
    /// </summary>
    public partial class Edit_Del_Order : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Order _Main;
        private Analityc_Order _order;

        public Edit_Del_Order(Analytic_dbEntities1 analytic_DbEntities1, object o, UC_Order uC_Order)
        {
            InitializeComponent();
            InitializeComponent();
            _context = analytic_DbEntities1;
            _order = (o as Button).DataContext as Analityc_Order;
            _Main = uC_Order;
            OOrder_Name.Text = _order.Analityc_Order_Name;
            OOrder_Vendor_Code.Text = _order.Analityc_Order_Vendor_Code;
            OOrder_Weight.Text = _order.Analityc_Order_Weight;
            OOrder_Number_Boxes.Text = _order.Analityc_Order_Number_Boxes;
            OOrder_Date.Text = _order.Analityc_Order_Date;
            OOrder_Status.Text = _order.Analityc_Order_Status;
            OOrder_Date.IsEnabled = false;
            OOrder_Status.IsEnabled = false;
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                DragMove();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Order_Del_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Order.Remove(_order);
                _context.SaveChanges();
                _Main.Update_Order();
                this.Close();
            }
        }

        private void Order_Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _order.Analityc_Order_Name = OOrder_Name.Text;
                _order.Analityc_Order_Vendor_Code = OOrder_Vendor_Code.Text;
                _order.Analityc_Order_Weight = OOrder_Weight.Text;
                _order.Analityc_Order_Number_Boxes = OOrder_Number_Boxes.Text;
                _context.SaveChanges();
                _Main.Update_Order();
                this.Close();
            }
        }

        private void Order_Click(object sender, RoutedEventArgs e)
        {
            _order.Analityc_Order_Status = "Задача выполнена ✓";
            _context.SaveChanges();
            _Main.Update_Order();
            this.Close();
        }
    }
}
