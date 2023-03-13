using Analytic.User_Control;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для Edit_Del_Month.xaml
    /// </summary>
    public partial class Edit_Del_Month : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Plan_Month uC_Plan_Monthh;
        private Analityc_Plan_Month _Plan_Month;

        public Edit_Del_Month(Analytic_dbEntities1 analytic_DbEntities1, object o, UC_Plan_Month uC_Plan_Month)
        {
            InitializeComponent();
            _context = analytic_DbEntities1;
            _Plan_Month = (o as Button).DataContext as Analityc_Plan_Month;
            uC_Plan_Monthh = uC_Plan_Month;
            MMonth_Nomenclature.Text = _Plan_Month.Analityc_Plan_Month_Nomenclature;
            MMonth_Note.Text = _Plan_Month.Analityc_Plan_Month_Note;
            MMonth_Volume.Text = _Plan_Month.Analityc_Plan_Month_Volume;
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


        private void Plan_Month_Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _Plan_Month.Analityc_Plan_Month_Nomenclature = MMonth_Nomenclature.Text;
                _Plan_Month.Analityc_Plan_Month_Note = MMonth_Note.Text;
                _Plan_Month.Analityc_Plan_Month_Volume = MMonth_Volume.Text;
                _context.SaveChanges();
                uC_Plan_Monthh.Update_and_Check_Month();
                this.Close();
            }
        }

        private void Month_Check_Click(object sender, RoutedEventArgs e)
        {
            _Plan_Month.Analityc_Plan_Month_Status = "Задача выполнена ✓";
            _context.SaveChanges();
            uC_Plan_Monthh.Update_and_Check_Month();
            this.Close();
        }

        private void Month_Del_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Plan_Month.Remove(_Plan_Month);
                _context.SaveChanges();
                uC_Plan_Monthh.Update_and_Check_Month();
                this.Close();
            }
        }
    }
}
