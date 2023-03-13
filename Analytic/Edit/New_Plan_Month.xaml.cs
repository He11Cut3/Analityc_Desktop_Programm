using Analytic.User_Control;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для New_Plan_Month.xaml
    /// </summary>
    public partial class New_Plan_Month : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Plan_Month _uc;

        public New_Plan_Month(Analytic_dbEntities1 analytic_DbEntities1, UC_Plan_Month uC_Plan_Month)
        {
            InitializeComponent();
            this._context = analytic_DbEntities1;
            this._uc = uC_Plan_Month;
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

        private void Month_Click(object sender, RoutedEventArgs e)
        {
            string time_now = DateTime.Now.AddDays(31).ToString("dd.MM.yyyy");
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Plan_Month.Add(new Analityc_Plan_Month()
                {
                    Analityc_Plan_Month_Nomenclature = MMonth_Nomenclature.Text,
                    Analityc_Plan_Month_Date = time_now,
                    Analityc_Plan_Month_Volume = MMonth_Volume.Text,
                    Analityc_Plan_Month_Note = MMonth_Note.Text,
                    Analityc_Plan_Month_Status = "Не выполнено",
                });
                _context.SaveChanges();
                _uc.Update_and_Check_Month();

                this.Close();
            }
        }
    }
}
