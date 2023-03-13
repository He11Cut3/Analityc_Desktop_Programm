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
    /// Логика взаимодействия для UC_Plan.xaml
    /// </summary>
    public partial class UC_Plan : UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Plan_Day> _list = new List<Analityc_Plan_Day>();
        private Analityc_Plan_Day _plan;
        public UC_Plan()
        {
            InitializeComponent();
            Update_and_Check();
        }

        public void Update_and_Check()
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            var recordsToUpdate = _context.Analityc_Plan_Day.Where(x => x.Analityc_Plan_Day_Date == time_now).ToList();

            foreach (var duplicate in recordsToUpdate)
            {
                _context.Analityc_Plan_Day.Remove(duplicate);
            }
            _context.SaveChanges();
            _list = _context.Analityc_Plan_Day.ToList();
            LV_Plan_Day_.ItemsSource = _list;

        }



        // Добавление
        private void New_Plan_Click(object sender, RoutedEventArgs e)
        {
            New_Plan_Day new_Plan_Day = new New_Plan_Day(_context, this);
            new_Plan_Day.ShowDialog();
        }

        //Изменить/удалить // Изменить
        private void Edit_del_Click(object sender, RoutedEventArgs e)
        {
            Edit_Del_Day edit_Del_Day = new Edit_Del_Day(_context, sender, this);
            edit_Del_Day.ShowDialog();
        }
    }
}
