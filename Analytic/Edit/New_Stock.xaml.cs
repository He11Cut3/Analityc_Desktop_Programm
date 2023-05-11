using Analytic.Edit;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analytic
{
    /// <summary>
    /// Логика взаимодействия для New_Edit_Del_Stock.xaml
    /// </summary>
    public partial class New_Edit_Del_Stock : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_User _uc;

        public New_Edit_Del_Stock(Analytic_dbEntities1 analytic_DbEntities1,  UC_User uC_User)
        {
            InitializeComponent();
            this._context = analytic_DbEntities1;
            this._uc = uC_User;
            SStock_Status.IsEnabled = false;
            SStock_Status.Text = "2-х недельное тестирование";
            SStock_Date.IsEnabled = false;
            string time_2_week = DateTime.Now.AddDays(14).ToString("dd.MM.yyyy");
            SStock_Date.Text = time_2_week;
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

        private void Stock_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Stock.Add(new Analityc_Stock()
                {
                    Analityc_Stock_Name = SStock_Name.Text,
                    Analityc_Stock_Feature = SStock_Feature.Text,
                    Analityc_Stock_Weight = SStock_Weight.Text,
                    Analityc_Stock_Description = SStock_Description.Text,
                    Analityc_Stock_Date = SStock_Date.Text,
                    Analityc_Stock_Status = SStock_Status.Text,
                });
                _context.SaveChanges();
                _uc.Update_and_Check_Stock();
                this.Close();
            }
        }
    }
}
