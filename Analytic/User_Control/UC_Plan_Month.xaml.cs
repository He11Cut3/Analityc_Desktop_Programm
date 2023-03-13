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
    /// Логика взаимодействия для UC_Plan_Month.xaml
    /// </summary>
    public partial class UC_Plan_Month : UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Plan_Month> _list = new List<Analityc_Plan_Month>();

        public UC_Plan_Month()
        {
            InitializeComponent();
            Update_and_Check_Month();
        }

        public void Update_and_Check_Month()
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            var recordsToUpdate = _context.Analityc_Plan_Month.Where(x => x.Analityc_Plan_Month_Date == time_now).ToList();

            foreach (var duplicate in recordsToUpdate)
            {
                _context.Analityc_Plan_Month.Remove(duplicate);
            }
            _context.SaveChanges();
            _list = _context.Analityc_Plan_Month.ToList();
            LV_Plan_Week_.ItemsSource = _list;

        }

        private void New_Plan_Month_Click(object sender, RoutedEventArgs e)
        {
            New_Plan_Month new_Plan_Month = new New_Plan_Month(_context, this);
            new_Plan_Month.ShowDialog();
        }

        private void Edit_Del_Month_Click(object sender, RoutedEventArgs e)
        {
            Edit_Del_Month edit_Del_Month = new Edit_Del_Month(_context, sender, this);
            edit_Del_Month.ShowDialog();
        }
    }
}
