using Analytic.User_Control;
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
using System.Windows.Shapes;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для New_Recipe.xaml
    /// </summary>
    public partial class New_Recipe : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Recipe _uc;
        public New_Recipe(Analytic_dbEntities1 analytic_DbEntities1, UC_Recipe uC_Recipe)
        {
            InitializeComponent();
            this._context = analytic_DbEntities1;
            this._uc = uC_Recipe;
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

        private void Recipe_Click(object sender, RoutedEventArgs e)
        {
            string time_now = DateTime.Now.AddDays(31).ToString("dd.MM.yyyy");
            if ((MessageBox.Show("Вы уверены, что хотите добавить информацию?", "Добавление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Recipe.Add(new Analityc_Recipe()
                {
                    Analityc_Recipe_Name = Name.Text,
                    Analityc_Recipe_Ingredients_One = One.Text,
                    Analityc_Recipe_Ingredients_Two = Two.Text,
                    Analityc_Recipe_Ingredients_Three = Three.Text,
                    Analityc_Recipe_Ingredients_Four = Four.Text,
                });
                _context.SaveChanges();
                _uc.Update_Recipe();

                this.Close();
            }
        }
    }
}
