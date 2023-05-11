using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Analytic.Edit;

//Analytic_dbEntities

namespace Analytic.Edit
{
    public partial class UC_User : System.Windows.Controls.UserControl
    {
        Analytic_dbEntities1 _context = new Analytic_dbEntities1();
        List<Analityc_Stock> _list = new List<Analityc_Stock>();
        private Analityc_Stock _stock;

        public UC_User()
        {
            InitializeComponent();
            LV_User_.ItemsSource = _context.Analityc_Stock.OrderBy(A => A.Analityc_Stock_id).ToList();
            this._list = _context.Analityc_Stock.ToList();
            _stock = DataContext as Analityc_Stock;
            Update_and_Check_Stock();
        }

        public void Update_and_Check_Stock()
        {
            string time_now = DateTime.Now.ToString("dd.MM.yyyy");
            var recordsToUpdate = _context.Analityc_Stock.Where(x => x.Analityc_Stock_Date == time_now).ToList();

            foreach (Analityc_Stock status in recordsToUpdate)
            {
                status.Analityc_Stock_Status = "На произодстве. \nКомплектующие подходят для работы. ";
                _context.SaveChanges();
            }
            _list = _context.Analityc_Stock.ToList();
            LV_User_.ItemsSource = _list;
        }
        // Добавление
        private void New_Siryu_Click(object sender, RoutedEventArgs e)
        {
            New_Edit_Del_Stock new_Edit_Del_Stock = new New_Edit_Del_Stock(_context, this);
            new_Edit_Del_Stock.ShowDialog();
        }

        //Изменить/удалить // Изменить
        private void Edit_del_Click(object sender, RoutedEventArgs e)
        {
            Edit edit = new Edit(_context, sender, this);
            edit.ShowDialog();
        }
    }
}
