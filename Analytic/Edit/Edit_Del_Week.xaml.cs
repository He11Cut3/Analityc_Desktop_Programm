using Analytic.User_Control;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для Edit_Del_Week.xaml
    /// </summary>
    public partial class Edit_Del_Week : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Plan_Week uC_Plan_Week;
        private Analityc_Plan_Week _Plan_Week;

        public Edit_Del_Week(Analytic_dbEntities1 analytic_DbEntities1, object o, UC_Plan_Week uC_Plan)
        {
            InitializeComponent();
            _context = analytic_DbEntities1;
            _Plan_Week = (o as Button).DataContext as Analityc_Plan_Week;
            uC_Plan_Week = uC_Plan;
            WWeek_Nomenclature.Text = _Plan_Week.Analityc_Plan_Week_Nomenclature;
            WWeek_Note.Text = _Plan_Week.Analityc_Plan_Week_Note;
            WWeek_Volume.Text = _Plan_Week.Analityc_Plan_Week_Volume;
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

        private void Week_Check_Click(object sender, RoutedEventArgs e)
        {
            _Plan_Week.Analityc_Plan_Week_Status = "Задача выполнена ✓";
            _context.SaveChanges();
            uC_Plan_Week.Update_and_Check_Week();
            this.Close();
        }

        private void Plan_Week_Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _Plan_Week.Analityc_Plan_Week_Nomenclature = WWeek_Nomenclature.Text;
                _Plan_Week.Analityc_Plan_Week_Note = WWeek_Note.Text;
                _Plan_Week.Analityc_Plan_Week_Volume = WWeek_Volume.Text;
                _context.SaveChanges();
                uC_Plan_Week.Update_and_Check_Week();
                this.Close();
            }
        }

        private void Week_Del_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Plan_Week.Remove(_Plan_Week);
                _context.SaveChanges();
                uC_Plan_Week.Update_and_Check_Week();
                this.Close();
            }
        }
    }
}
