using Analytic.Edit;
using Analytic.User_Control;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace Analytic
{
    /// <summary>
    /// Логика взаимодействия для Main.xaml
    /// </summary>
    public partial class Main : Window
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Stock> _material = new List<Analityc_Stock>();
        public Main()
        {
            InitializeComponent();
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseEventArgs e)
        {
            DragMove();
        }
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
       

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_Plan_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();


            UC_User uC_User = new UC_User();
            LV_User_Grid.Children.Add(uC_User);
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();

            UC_Order uC_Order = new UC_Order();
            LV_Order.Children.Add(uC_Order);

        }

        private void RadioButton_Checked_3(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Order.Children.Clear();

            UC_Product uC_Product = new UC_Product();
            LV_Product.Children.Add(uC_Product);
        }

        private void RadioButton_Checked_4(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;

            LV_User_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();

            UC_Plan uC_Plan = new UC_Plan();
            LV_Plan_Grid.Children.Add(uC_Plan);
        }

        private void RadioButton_Checked_5(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;

            LV_User_Grid.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Order.Children.Clear();
            LV_Product.Children.Clear();


            UC_Plan_Week uC_Plan_Week = new UC_Plan_Week();
            LV_Plan_Week_Grid.Children.Add(uC_Plan_Week);
        }

        private void RadioButton_Checked_6(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Visible;
            Week.Visibility = Visibility.Visible;
            Month.Visibility = Visibility.Visible;

            LV_User_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Product.Children.Clear();

            UC_Plan_Month uC_Plan_Month = new UC_Plan_Month();
            LV_Plan_Month_Grid.Children.Add(uC_Plan_Month);
        }

        private void RadioButton_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Recipe.Children.Clear();
            LV_Order.Children.Clear();
            LV_Product.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();
        }

        private void RadioButton_Checked_7(object sender, RoutedEventArgs e)
        {
            Day.Visibility = Visibility.Collapsed;
            Week.Visibility = Visibility.Collapsed;
            Month.Visibility = Visibility.Collapsed;

            LV_User_Grid.Children.Clear();
            LV_Plan_Grid.Children.Clear();
            LV_Plan_Week_Grid.Children.Clear();
            LV_Order.Children.Clear();
            LV_Product.Children.Clear();
            LV_Plan_Month_Grid.Children.Clear();

            UC_Recipe uC_Recipe = new UC_Recipe();
            LV_Recipe.Children.Add(uC_Recipe);
        }

        private void Report_Checked(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите создать отчёт?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                Day_Ex();
                Week_Ex();
                Month_Ex();
            }
        }
        public void Day_Ex()
        {

            List<Analityc_Plan_Day> day = _context.Analityc_Plan_Day.ToList();


            // Определяем наименования столбцов
            string[] columnNames = new string[] { "Номенклатура (День)", "Выполнить до(День)", "Статус выполнения(День)", "Обьем(День)", "Примечание(День)" };
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Добавляем лист
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("День");

                // Записываем наименования столбцов
                for (int i = 0; i < columnNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Записываем данные
                for (int i = 0; i < day.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = day[i].Analityc_Plan_Day_Nomenclature;
                    worksheet.Cells[i + 2, 2].Value = day[i].Analityc_Plan_Day_Volume;
                    worksheet.Cells[i + 2, 3].Value = day[i].Analityc_Plan_Day_Note;
                    worksheet.Cells[i + 2, 4].Value = day[i].Analityc_Plan_Day_Date;
                    worksheet.Cells[i + 2, 5].Value = day[i].Analityc_Plan_Day_Status;
                }

                // Сохраняем файл
                File.WriteAllBytes("День.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "День.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
        public void Week_Ex()
        {
            List<Analityc_Plan_Week> week = _context.Analityc_Plan_Week.ToList();
            // Определяем наименования столбцов
            string[] columnNames = new string[] { "Номенклатура(Неделя)", "Выполнить до(Неделя)", "Статус выполнения(Неделя)", "Обьем(Неделя)", "Примечание(Неделя)" };
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Добавляем лист
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Неделя");

                // Записываем наименования столбцов
                for (int i = 0; i < columnNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Записываем данные
                for (int i = 0; i < week.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = week[i].Analityc_Plan_Week_Nomenclature;
                    worksheet.Cells[i + 2, 2].Value = week[i].Analityc_Plan_Week_Volume;
                    worksheet.Cells[i + 2, 3].Value = week[i].Analityc_Plan_Week_Note;
                    worksheet.Cells[i + 2, 4].Value = week[i].Analityc_Plan_Week_Date;
                    worksheet.Cells[i + 2, 5].Value = week[i].Analityc_Plan_Week_Status;
                }

                // Сохраняем файл
                File.WriteAllBytes("Неделя.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Неделя.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
        public void Month_Ex()
        {
            List<Analityc_Plan_Month> month = _context.Analityc_Plan_Month.ToList();
            // Определяем наименования столбцов
            string[] columnNames = new string[] { "Номенклатура(Месяц)", "Выполнить до(Месяц)", "Статус выполнения(Месяц)", "Обьем(Месяц)", "Примечание(Месяц)" };
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            // Создаем новый файл Excel
            using (ExcelPackage package = new ExcelPackage())
            {
                // Добавляем лист
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Месяц");

                // Записываем наименования столбцов
                for (int i = 0; i < columnNames.Length; i++)
                {
                    worksheet.Cells[1, i + 1].Value = columnNames[i];
                }

                // Записываем данные
                for (int i = 0; i < month.Count; i++)
                {
                    worksheet.Cells[i + 2, 1].Value = month[i].Analityc_Plan_Month_Nomenclature;
                    worksheet.Cells[i + 2, 2].Value = month[i].Analityc_Plan_Month_Volume;
                    worksheet.Cells[i + 2, 3].Value = month[i].Analityc_Plan_Month_Note;
                    worksheet.Cells[i + 2, 4].Value = month[i].Analityc_Plan_Month_Date;
                    worksheet.Cells[i + 2, 5].Value = month[i].Analityc_Plan_Month_Status;
                }

                // Сохраняем файл
                File.WriteAllBytes("Месяц.xlsx", package.GetAsByteArray());
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = System.IO.Path.Combine(desktopPath, "Месяц.xlsx");
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
        }
    }
}
