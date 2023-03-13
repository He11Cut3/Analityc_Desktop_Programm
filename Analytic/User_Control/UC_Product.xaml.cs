using Analytic.Edit;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Analytic.User_Control
{
    /// <summary>
    /// Логика взаимодействия для UC_Product.xaml
    /// </summary>
    public partial class UC_Product : UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Finished_Products> _list = new List<Analityc_Finished_Products>();
        Edit_Del_Product edit_;
        public UC_Product()
        {
            InitializeComponent();
            Update_and_Check_Product();
        }

        public void Update_and_Check_Product()
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            var recordsToUpdate = _context.Analityc_Finished_Products.Where(x => x.Analityc_Finished_Products_Date == time_now).ToList();

            foreach (var duplicate in recordsToUpdate)
            {
                
            }
            _context.SaveChanges();
            _list = _context.Analityc_Finished_Products.ToList();
            LV_Product_.ItemsSource = _list;

        }

        private void Edit_del_Click(object sender, RoutedEventArgs e)
        {
            Edit_Del_Product edit_Del_Product = new Edit_Del_Product(_context, sender, this);
            edit_Del_Product.ShowDialog();
        }

        private void Product_New_Click(object sender, RoutedEventArgs e)
        {
            New_Product new_Product = new New_Product(_context, this);
            new_Product.ShowDialog();
        }
    }
}
