using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для Edit.xaml
    /// </summary>
    public partial class Edit : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_User _Main;
        private Analityc_Stock _stock;

        public Edit(Analytic_dbEntities1 analytic_DbEntities1, object o, UC_User uC_User)
        {
            InitializeComponent();
            _context = analytic_DbEntities1;
            _stock = (o as Button).DataContext as Analityc_Stock;
            _Main = uC_User;
            SStock_Name.Text = _stock.Analityc_Stock_Name;
            SStock_Feature.Text = _stock.Analityc_Stock_Feature;
            SStock_Weight.Text = _stock.Analityc_Stock_Weight;
            SStock_Description.Text = _stock.Analityc_Stock_Description;
            SStock_Date.Text = _stock.Analityc_Stock_Date;
            SStock_Status.Text = _stock.Analityc_Stock_Status;
            SStock_Date.IsEnabled = false;
            SStock_Status.IsEnabled = false;
        }
        private void Time_Now_Click(object sender, RoutedEventArgs e)
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            _stock.Analityc_Stock_Date = time_now;
            _context.SaveChanges();
            _Main.Update_and_Check_Stock();
            this.Close();

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

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _stock.Analityc_Stock_Name = SStock_Name.Text;
                _stock.Analityc_Stock_Feature = SStock_Feature.Text;
                _stock.Analityc_Stock_Weight = SStock_Weight.Text;
                _stock.Analityc_Stock_Description = SStock_Description.Text;
                _context.SaveChanges();
                _Main.Update_and_Check_Stock();
                this.Close();
            }
        }

        private void Stock_Del_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Stock.Remove(_stock);
                _context.SaveChanges();
                _Main.Update_and_Check_Stock();
                this.Close();
            }
        }
    }
}
