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
    /// Логика взаимодействия для UC_Order.xaml
    /// </summary>
    public partial class UC_Order : UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Order> _list = new List<Analityc_Order>();

        public UC_Order()
        {
            InitializeComponent();
            LV_Order_.ItemsSource = _context.Analityc_Order.OrderBy(A => A.Analityc_Order_id).ToList();
            Update_Order();
        }

        public void Update_Order()
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            var recordsToUpdate = _context.Analityc_Order.Where(x => x.Analityc_Order_Date == time_now).ToList();

            foreach (var duplicate in recordsToUpdate)
            {
                _context.Analityc_Order.Remove(duplicate);
            }
            _context.SaveChanges();
            _list = _context.Analityc_Order.ToList();
            LV_Order_.ItemsSource = _list;

        }

        private void New_Order_Click(object sender, RoutedEventArgs e)
        {
            New_Order new_Order = new New_Order(_context, this);
            new_Order.ShowDialog();
        }

        private void Edit_del_Order_Click(object sender, RoutedEventArgs e)
        {
            Edit_Del_Order edit_Del_Order = new Edit_Del_Order(_context, sender, this);
            edit_Del_Order.ShowDialog();
        }
    }
}
