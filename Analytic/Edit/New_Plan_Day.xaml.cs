using Analytic.User_Control;
using System;
using System.Windows;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для New_Plan_Day.xaml
    /// </summary>
    public partial class New_Plan_Day : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Plan _uc;

        public New_Plan_Day(Analytic_dbEntities1 analytic_DbEntities1, UC_Plan uC_Plan)
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

        private void Day_Click(object sender, RoutedEventArgs e)
        {
            string time_now = DateTime.Now.AddDays(1).ToString("dd.MM.yyyy");
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Plan_Day.Add(new Analityc_Plan_Day()
                {
                    Analityc_Plan_Day_Nomenclature = DDay_Nomenclature.Text,
                    Analityc_Plan_Day_Date = time_now,
                    Analityc_Plan_Day_Volume = DDay_Volume.Text,
                    Analityc_Plan_Day_Note = DDay_Note.Text,
                    Analityc_Plan_Day_Status = "Не выполнено",
                });
                _context.SaveChanges();
                _uc.Update_and_Check();
                
                this.Close();
            }
        }
    }
}
