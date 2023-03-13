using Analytic.User_Control;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для Edit_Del_Product.xaml
    /// </summary>
    public partial class Edit_Del_Product : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Product _Main;
        private Analityc_Finished_Products _product;

        public Edit_Del_Product(Analytic_dbEntities1 analytic_DbEntities1, object o, UC_Product uC_Product)
        {
            InitializeComponent();
            _context = analytic_DbEntities1;
            _product = (o as Button).DataContext as Analityc_Finished_Products;
            _Main = uC_Product;
            PProduct_Name.Text = _product.Analityc_Finished_Products_Name;
            PProduct_Weight.Text = _product.Analityc_Finished_Products_Weight;
            PProduct_Description.Text = _product.Analityc_Finished_Products_Description;
            PProduct_Date.Text = _product.Analityc_Finished_Products_Date;
            PProduct_Boxes.Text = _product.Analityc_Finished_Products_Number_Boxes;
            PProduct_Status.Text = _product.Analityc_Finished_Products_Status;
            PProduct_Boxes.IsEnabled = false;
            PProduct_Date.IsEnabled = false;
            PProduct_Status.IsEnabled = false;
            Update_and_Check_Product_Time();
        }

        public void Update_and_Check_Product_Time()
        {
            Karantin.IsEnabled = false;
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            if (PProduct_Date.Text == time_now)
            {
                PProduct_Boxes.IsEnabled = true;
                Karantin.IsEnabled = true;
                PProduct_Boxes.Text = "";
            }
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

        private void Product_Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _product.Analityc_Finished_Products_Name = PProduct_Name.Text;
                _product.Analityc_Finished_Products_Weight = PProduct_Weight.Text;
                _product.Analityc_Finished_Products_Description = PProduct_Description.Text;
                _product.Analityc_Finished_Products_Date = PProduct_Date.Text;
                _product.Analityc_Finished_Products_Number_Boxes = PProduct_Boxes.Text;
                _product.Analityc_Finished_Products_Status = PProduct_Status.Text;
                _context.SaveChanges();
                _Main.Update_and_Check_Product();
                this.Close();
            }
        }

        private void Karantin_Click(object sender, RoutedEventArgs e)
        {
            _product.Analityc_Finished_Products_Status = "Отправлен на склад";
            _context.SaveChanges();
            _Main.Update_and_Check_Product();
            this.Close();
        }

        private void Product_Del_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Finished_Products.Remove(_product);
                _context.SaveChanges();
                _Main.Update_and_Check_Product();
                this.Close();
            }
        }
    }
}
