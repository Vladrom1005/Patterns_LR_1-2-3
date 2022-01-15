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

namespace Patterns__LR_1_
{
    /// <summary>
    /// Логика взаимодействия для TestReport.xaml
    /// </summary>
    public partial class TestReport : Window
    {
        public List<UnitReport> reports;

        public TestReport()
        {
            InitializeComponent();
        }

        public void UpdateReport()
        {
            lv_report.ItemsSource = reports;
        }

        private void Btn_close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        /*
        private void Btn_test_Click(object sender, RoutedEventArgs e)
        {
            reports = new List<UnitReport>();
            reports.Add(new UnitReport("Метод 1", "Ожидание 1", "Результат 1"));
            reports.Add(new UnitReport("Метод 2", "Ожидание 2", "Результат 2"));
            reports.Add(new UnitReport("Метод 3", "Ожидание 3", "Результат 3"));
            reports.Add(new UnitReport("Метод 4", "Ожидание 4", "Результат 4"));
            reports.Add(new UnitReport("Метод 5", "Ожидание 5", "Результат 5"));
            reports.Add(new UnitReport("Метод 6", "Ожидание 6", "Результат 6"));
            reports.Add(new UnitReport("Метод 7", "Ожидание 7", "Результат 7"));
            reports.Add(new UnitReport("Метод 8", "Ожидание 8", "Результат 8"));
            UpdateReport();
        }

        private void Btn_test_2_Click(object sender, RoutedEventArgs e)
        {
            reports = new List<UnitReport>();
            reports.Add(new UnitReport("Метод 8", "Ожидание 8", "Результат 8"));
            reports.Add(new UnitReport("Метод 7", "Ожидание 7", "Результат 7"));
            reports.Add(new UnitReport("Метод 6", "Ожидание 6", "Результат 6"));
            reports.Add(new UnitReport("Метод 5", "Ожидание 5", "Результат 5"));
            reports.Add(new UnitReport("Метод 4", "Ожидание 4", "Результат 4"));
            reports.Add(new UnitReport("Метод 3", "Ожидание 3", "Результат 3"));
            reports.Add(new UnitReport("Метод 2", "Ожидание 2", "Результат 2"));
            reports.Add(new UnitReport("Метод 1", "Ожидание 1", "Результат 1"));
            UpdateReport();
        }
        */
    }
}
