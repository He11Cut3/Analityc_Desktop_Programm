using Analytic.User_Control;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для New_Plan_Week.xaml
    /// </summary>
    public partial class New_Plan_Week : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Plan_Week _uc;

        public New_Plan_Week(Analytic_dbEntities1 analytic_DbEntities1, UC_Plan_Week uC_Plan)
        {
            InitializeComponent();
            this._context = analytic_DbEntities1;
            this._uc = uC_Plan;
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

        private void Week_Click(object sender, RoutedEventArgs e)
        {
            string time_now = DateTime.Now.AddDays(7).ToString("dd.MM.yyyy");
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Plan_Week.Add(new Analityc_Plan_Week()
                {
                    Analityc_Plan_Week_Nomenclature = WWeek_Nomenclature.Text,
                    Analityc_Plan_Week_Date = time_now,
                    Analityc_Plan_Week_Volume = WWeek_Volume.Text,
                    Analityc_Plan_Week_Note = WWeek_Note.Text,
                    Analityc_Plan_Week_Status = "Не выполнено",
                });
                _context.SaveChanges();
                _uc.Update_and_Check_Week();

                this.Close();
            }
        }
    }
}
