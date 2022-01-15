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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Patterns__LR_1_
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {        
        public MainWindow()
        {
            InitializeComponent();
            notificationCount = 0;
            currentStatus = new StatusOnline();
        }

        //========================= Абстрактная фабрика =========================
        // Кнопка "Изменить тему"
        private void Btn_switchTheme_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem cbItem = cb_style.SelectedItem as ComboBoxItem;

            AppTheme furSet = null;
            if (cbItem.Tag.ToString() == "Common")
                furSet = new AppTheme(new CommonThemeFactory());
            if (cbItem.Tag.ToString() == "Summer")
                furSet = new AppTheme(new SummerThemeFactory());
            if (cbItem.Tag.ToString() == "Authim")
                furSet = new AppTheme(new AuthumThemeFactory());
            if (cbItem.Tag.ToString() == "Winter")
                furSet = new AppTheme(new WinterThemeFactory());
            if (cbItem.Tag.ToString() == "Spring")
                furSet = new AppTheme(new SpringThemeFactory());

            string[] gottenTheme = furSet.SetTheme();

            lv_messages.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[0]);

            btn_switchTheme.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_switchStatus.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_clearMessages.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_createMessage.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_clearMessages.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_clearNotifications.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_test_abstract.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);
            btn_test_state.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[1]);

            win_main.Background = (Brush)new BrushConverter().ConvertFromString(gottenTheme[2]);
        }
        //========================= Состояние =========================
        int notificationCount;  // Количество уведомлений
        iState currentStatus; // Текущее состояние

        // Кнопка "Сменить статус"
        private void Btn_switchStatus_Click(object sender, RoutedEventArgs e)
        {
            currentStatus = currentStatus.SwitchStatus();
            string[] status = currentStatus.getStatus();
            lab_status.Content = status[0];
            lab_status.Foreground = (Brush) new BrushConverter().ConvertFromString(status[1]);
        }
        // Кнопка "Получить сообщение"
        private void Btn_publc_Click(object sender, RoutedEventArgs e)
        {
            string[] msg = currentStatus.getMessage();
            if (msg == null)
                return;
            lv_messages.Items.Add(new oneMsg(msg[0], msg[1]));
            if (currentStatus.getNotification())
                notificationCount++;
            lab_notifications.Content = "Новых сообщений: " + notificationCount;
        }
        // Кнопка "Удалить сообщения"
        private void Btn_clearMessages_Click(object sender, RoutedEventArgs e)
        {
            lv_messages.Items.Clear();
        }
        // Кнопка "Сбросить счётчик уведомлений"
        private void Btn_clearNotifications_Click(object sender, RoutedEventArgs e)
        {
            notificationCount = 0;
            lab_notifications.Content = "Новых сообщений: " + notificationCount;
        }
        // Тест "абстрактной фабрики"
        private void Btn_test_abstract_Click(object sender, RoutedEventArgs e)
        {
            Unit_Tests tests = new Unit_Tests();
            TestReport winReport = new TestReport();
            winReport.reports = tests.TestAbstractFactory();
            winReport.UpdateReport();
            winReport.ShowDialog();

        }
        // Тест "состояния"
        private void Btn_test_state_Click(object sender, RoutedEventArgs e)
        {
            Unit_Tests tests = new Unit_Tests();
            TestReport winReport = new TestReport();
            winReport.reports = tests.TestState();
            winReport.UpdateReport();
            winReport.ShowDialog();

        }
    }

    public class oneMsg
    {
        public oneMsg(string author, string msg)
        {
            this.author = author;
            this.msg = msg;
        }
        public string author { get; set; }
        public string msg { get; set; }
    }
}
