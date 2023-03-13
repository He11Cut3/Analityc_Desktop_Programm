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
    /// Логика взаимодействия для UC_Recipe.xaml
    /// </summary>
    public partial class UC_Recipe : UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Recipe> _list = new List<Analityc_Recipe>();
        public UC_Recipe()
        {
            InitializeComponent();
            LV_Recipe_.ItemsSource = _context.Analityc_Recipe.OrderBy(A => A.Analityc_Recipe_id).ToList();
            Update_Recipe();
        }

        public void Update_Recipe()
        {
            _list = _context.Analityc_Recipe.ToList();
            LV_Recipe_.ItemsSource = _list;

        }

        private void New_Recipe_Click(object sender, RoutedEventArgs e)
        {
            New_Recipe new_Recipe = new New_Recipe(_context, this);
            new_Recipe.ShowDialog();
        }

        private void Edit_del_Recipe_Click(object sender, RoutedEventArgs e)
        {
            Edit_Del_Recipe edit_Del_Recipe = new Edit_Del_Recipe(_context, sender, this);
            edit_Del_Recipe.ShowDialog();
        }
    }
}
