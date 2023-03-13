using Analytic.User_Control;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для New_Product.xaml
    /// </summary>
    public partial class New_Product : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Product _uc;

        public New_Product(Analytic_dbEntities1 analytic_DbEntities1, UC_Product uC_Product)
        {
            InitializeComponent();
            this._context = analytic_DbEntities1;
            this._uc = uC_Product;
            PProduct_Boxes.IsEnabled = false;
            PProduct_Status.IsEnabled = false;
            PProduct_Date.IsEnabled = false;
            PProduct_Status.Text = "2-х дневный карантин";
            string time_now = DateTime.Now.AddDays(2).ToString("dd.MM.yyyy");
            PProduct_Date.Text = time_now;
            PProduct_Boxes.Text = "В ожидании";
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

        private void New_Product_Add_Click(object sender, RoutedEventArgs e)
        {
            string time_now = DateTime.Now.AddDays(2).ToString("dd.MM.yyyy");
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Finished_Products.Add(new Analityc_Finished_Products()
                {
                    Analityc_Finished_Products_Name = PProduct_Name.Text,
                    Analityc_Finished_Products_Date = time_now,
                    Analityc_Finished_Products_Weight = PProduct_Weight.Text,
                    Analityc_Finished_Products_Number_Boxes = PProduct_Boxes.Text,
                    Analityc_Finished_Products_Description = PProduct_Description.Text,
                    Analityc_Finished_Products_Status = "Отбор эталонный образца",
                });
                _context.SaveChanges();
                _uc.Update_and_Check_Product();

                this.Close();
            }
        }
    }
}
