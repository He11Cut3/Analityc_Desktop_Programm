using Analytic.User_Control;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Analytic.Edit
{
    /// <summary>
    /// Логика взаимодействия для Edit_Del_Recipe.xaml
    /// </summary>
    public partial class Edit_Del_Recipe : Window
    {
        private Analytic_dbEntities1 _context;
        private UC_Recipe _Main;
        private Analityc_Recipe _Recipe;
        private Analityc_Finished_Products _Product;
        private Edit_Del_Product _edit;
        Analytic_dbEntities1 context = new Analytic_dbEntities1();
        public Edit_Del_Recipe(Analytic_dbEntities1 analytic_DbEntities1, object o, UC_Recipe uC_Recipe)
        {
            InitializeComponent();
            _context = analytic_DbEntities1;
            _Recipe = (o as Button).DataContext as Analityc_Recipe;
            _Main = uC_Recipe;
            Name.Text = _Recipe.Analityc_Recipe_Name;
            One.Text = _Recipe.Analityc_Recipe_Ingredients_One;
            Two.Text = _Recipe.Analityc_Recipe_Ingredients_Two;
            Three.Text = _Recipe.Analityc_Recipe_Ingredients_Three;
            Four.Text = _Recipe.Analityc_Recipe_Ingredients_Four;
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
            if ((MessageBox.Show("Вы уверены, что хотите приготовить рецепт?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                int F1, F2, F3, F4, F5, F6;
                int Sum_Sugar, Sum_Water, Sum_Treacle, Sum_Flavoring;
                //Сахар
                var Sugar = _context.Analityc_Stock.Where(x => x.Analityc_Stock_Name == "Сироп(Сахар)").ToList();
                T1.Text = "";

                foreach (Analityc_Stock status_Sugar1 in Sugar)
                {
                    T1.Text = status_Sugar1.Analityc_Stock_Weight;
                }

                F1 = Convert.ToInt32(T1.Text);
                F2 = Convert.ToInt32(One.Text);
                Sum_Sugar = F1 - F2;

                foreach (Analityc_Stock status_Sugar2 in Sugar)
                {
                    status_Sugar2.Analityc_Stock_Weight = Sum_Sugar.ToString();
                }

                //Вода
                var Water = _context.Analityc_Stock.Where(x => x.Analityc_Stock_Name == "Сироп(Вода)").ToList();
                T1.Text = "";


                foreach (Analityc_Stock status_Water1 in Water)
                {
                    T1.Text = status_Water1.Analityc_Stock_Weight;
                }

                F3 = Convert.ToInt32(T1.Text);
                F4 = Convert.ToInt32(Two.Text);
                Sum_Water = F3 - F4;

                foreach (Analityc_Stock status_Water2 in Water)
                {
                    status_Water2.Analityc_Stock_Weight = Sum_Water.ToString();
                }

                //Патока
                var Treacle = _context.Analityc_Stock.Where(x => x.Analityc_Stock_Name == "Сироп(Патока)").ToList();
                T1.Text = "";

                foreach (Analityc_Stock status_Treacle1 in Treacle)
                {
                    T1.Text = status_Treacle1.Analityc_Stock_Weight;
                }

                F4 = Convert.ToInt32(T1.Text);
                F5 = Convert.ToInt32(Three.Text);
                Sum_Treacle = F4 - F5;

                foreach (Analityc_Stock status_Treacle2 in Treacle)
                {
                    status_Treacle2.Analityc_Stock_Weight = Sum_Treacle.ToString();
                }

                //Ароматизатор
                var Flavoring = _context.Analityc_Stock.Where(x => x.Analityc_Stock_Name == "Сироп(Ароматизатор)").ToList();
                T1.Text = "";

                foreach (Analityc_Stock status_Flavoring1 in Flavoring)
                {
                    T1.Text = status_Flavoring1.Analityc_Stock_Weight;
                }

                F5 = Convert.ToInt32(T1.Text);
                F6 = Convert.ToInt32(Four.Text);
                Sum_Flavoring = F5 - F6;

                foreach (Analityc_Stock status_Flavoring2 in Flavoring)
                {
                    status_Flavoring2.Analityc_Stock_Weight = Sum_Flavoring.ToString();
                }

                string time_now = DateTime.Now.AddDays(2).ToString("dd.MM.yyyy");

                _context.Analityc_Finished_Products.Add(new Analityc_Finished_Products()
                {
                    Analityc_Finished_Products_Name = "Сироп",
                    Analityc_Finished_Products_Date = time_now,
                    Analityc_Finished_Products_Weight = "5000",
                    Analityc_Finished_Products_Number_Boxes = "В ожидании",
                    Analityc_Finished_Products_Description = "",
                    Analityc_Finished_Products_Status = "2-х дневный карантин",
                });

                this.Close();
                _context.SaveChanges();
            }
        }

        private void Recipe_Edit_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите изменить информацию?", "Изменение", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _Recipe.Analityc_Recipe_Name = Name.Text;
                _Recipe.Analityc_Recipe_Ingredients_One = One.Text;
                _Recipe.Analityc_Recipe_Ingredients_Two = Two.Text;
                _Recipe.Analityc_Recipe_Ingredients_Three = Three.Text;
                _Recipe.Analityc_Recipe_Ingredients_Four = Four.Text;
                _context.SaveChanges();
                _Main.Update_Recipe();
                this.Close();
            }
        }

        private void Recipe_Del_Click(object sender, RoutedEventArgs e)
        {
            if ((MessageBox.Show("Вы уверены, что хотите удалить информацию?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning)) == MessageBoxResult.Yes)
            {
                _context.Analityc_Recipe.Remove(_Recipe);
                _context.SaveChanges();
                _Main.Update_Recipe();
                this.Close();
            }
        }
    }
}
