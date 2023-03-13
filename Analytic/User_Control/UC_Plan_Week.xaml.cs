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
    /// Логика взаимодействия для UC_Plan_Week.xaml
    /// </summary>
    public partial class UC_Plan_Week : UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Plan_Week> _list = new List<Analityc_Plan_Week>();
        private Analityc_Plan_Week _plan;

        public UC_Plan_Week()
        {
            InitializeComponent();
            Update_and_Check_Week();
        }

        public void Update_and_Check_Week()
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            var recordsToUpdate = _context.Analityc_Plan_Week.Where(x => x.Analityc_Plan_Week_Date == time_now).ToList();

            foreach (var duplicate in recordsToUpdate)
            {
                _context.Analityc_Plan_Week.Remove(duplicate);
            }
            _context.SaveChanges();
            _list = _context.Analityc_Plan_Week.ToList();
            LV_Plan_Week_.ItemsSource = _list;

        }


        private void New_Plan_Week_Click(object sender, RoutedEventArgs e)
        {
            New_Plan_Week new_plan_week = new New_Plan_Week(_context, this);
            new_plan_week.ShowDialog();
        }

        private void Edit_Del_Week_Click(object sender, RoutedEventArgs e)
        {
            Edit_Del_Week edit_Del_Week = new Edit_Del_Week(_context, sender, this);
            edit_Del_Week.ShowDialog();
        }
    }
}
