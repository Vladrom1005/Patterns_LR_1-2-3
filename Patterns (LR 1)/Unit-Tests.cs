using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns__LR_1_
{
    class Unit_Tests
    {
        public List<UnitReport> TestAbstractFactory()
        {
            List<UnitReport> reports = new List<UnitReport>();

            AppTheme furSet;
            string[] gottenTheme;
            string test_passed = null;
            string[] expectation = new string[3];

            // Тема "Обычная"
            furSet = new AppTheme(new CommonThemeFactory());
            expectation[0] = "#FFFFFFFF";
            expectation[1] = "#FFDDDDDD";
            expectation[2] = "#FFFFFFFF";
            gottenTheme = furSet.SetTheme();
            for (int i = 0; i <= 2; i++)
            {
                if (expectation[i] == gottenTheme[i])
                    test_passed = "Да";
                else
                {
                    test_passed = "Нет";
                    break;
                }
            }
            reports.Add(new UnitReport("AppTheme.CommonThemeFactory.SetTheme()", expectation.ToString(), gottenTheme.ToString(), test_passed));

            // Тема "Лето"
            furSet = new AppTheme(new SummerThemeFactory());
            expectation[0] = "#FFFFFFBA";
            expectation[1] = "#FFFFFFAE";
            expectation[2] = "#FFFFFFDC";
            gottenTheme = furSet.SetTheme();
            for (int i = 0; i <= 2; i++)
            {
                if (expectation[i] == gottenTheme[i])
                    test_passed = "Да";
                else
                {
                    test_passed = "Нет";
                    break;
                }
            }
            reports.Add(new UnitReport("AppTheme.SummerThemeFactory.SetTheme()", expectation.ToString(), gottenTheme.ToString(), test_passed));

            // Тема "Осень"
            furSet = new AppTheme(new AuthumThemeFactory());
            expectation[0] = "#FFFFF1DE";
            expectation[1] = "#FFFFE4DC";
            expectation[2] = "#FFFFF6EA";
            gottenTheme = furSet.SetTheme();
            for (int i = 0; i <= 2; i++)
            {
                if (expectation[i] == gottenTheme[i])
                    test_passed = "Да";
                else
                {
                    test_passed = "Нет";
                    break;
                }
            }
            reports.Add(new UnitReport("AppTheme.AuthumThemeFactory.SetTheme()", expectation.ToString(), gottenTheme.ToString(), test_passed));
            
            // Тема "Зима"
            furSet = new AppTheme(new WinterThemeFactory());
            expectation[0] = "#FFDEF1FF";
            expectation[1] = "#FFDCE4FF";
            expectation[2] = "#FFEAF6FF";
            gottenTheme = furSet.SetTheme();
            for (int i = 0; i <= 2; i++)
            {
                if (expectation[i] == gottenTheme[i])
                    test_passed = "Да";
                else
                {
                    test_passed = "Нет";
                    break;
                }
            }
            reports.Add(new UnitReport("AppTheme.WinterThemeFactory.SetTheme()", expectation.ToString(), gottenTheme.ToString(), test_passed));
            
            // Тема "Весна"
            furSet = new AppTheme(new SpringThemeFactory());
            expectation[0] = "#FFF1FFDE";
            expectation[1] = "#FFE4FFDC";
            expectation[2] = "#FFF6FFEA";
            gottenTheme = furSet.SetTheme();
            for (int i = 0; i <= 2; i++)
            {
                if (expectation[i] == gottenTheme[i])
                    test_passed = "Да";
                else
                {
                    test_passed = "Нет";
                    break;
                }
            }
            reports.Add(new UnitReport("AppTheme.SpringThemeFactory.SetTheme()", expectation.ToString(), gottenTheme.ToString(), test_passed));

            return reports;
        }

        public List<UnitReport> TestState()
        {
            List<UnitReport> reports = new List<UnitReport>();
            iState currentStatus = new StatusOnline();
            string test_passed = null;
            string[] exp_authors = new string[4] { "М'Айк Лжец", "Анон", "Анон", "Армстронг" };
            string[] exp_messages = new string[4] 
              { "М'Айк не помнит своего детства. Возможно, его и не было.",
                "Ну и как там в Египте?",
                "Кто не работает, то ест. Учись, студент.",
                "Nanomachines, son!" };
            
            // Онлайн
            string[] result_Online_getMessage = currentStatus.getMessage();
            for (int i = 0; i <= 3; i++)
            {
                if (result_Online_getMessage[0] == exp_authors[i] && result_Online_getMessage[1] == exp_messages[i])
                {
                    test_passed = "Да";
                    break;
                }
                else
                    test_passed = "Нет";
            }
            reports.Add(new UnitReport("StatusOnline.getMessage()", "Автор + Сообщение", result_Online_getMessage.ToString(), test_passed));

            bool result_Online_getNotification = currentStatus.getNotification();
            if (result_Online_getNotification)
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusOnline.getNotification()", "True", result_Online_getNotification.ToString(), test_passed));

            iState result_Online_SwitchStatus = currentStatus.SwitchStatus();
            if (result_Online_SwitchStatus is StatusNotDistrub)
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusOnline.SwitchStatus()", "Статус \"Не беспокоить\"", result_Online_SwitchStatus.ToString(), test_passed));

            string[] exp_statusOnline = new string[2] { "В сети", "#FF009600" };
            string[] result_Online_getStatus = currentStatus.getStatus();
            if (result_Online_getStatus[0] == exp_statusOnline[0] && result_Online_getStatus[1] == exp_statusOnline[1])
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusOnline.getStatus()", exp_statusOnline.ToString(), result_Online_getStatus.ToString(), test_passed));

            currentStatus = currentStatus.SwitchStatus();

            // Не беспокоить
            string[] result_NotDistrub_getMessage = currentStatus.getMessage();
            for (int i = 0; i <= 3; i++)
            {
                if (result_NotDistrub_getMessage[0] == exp_authors[i] && result_NotDistrub_getMessage[1] == exp_messages[i])
                {
                    test_passed = "Да";
                    break;
                }
                else
                    test_passed = "Нет";
            }
            reports.Add(new UnitReport("StatusNotDistrub.getMessage()", "Автор + Сообщение", result_NotDistrub_getMessage.ToString(), test_passed));

            bool result_NotDistrub_getNotification = currentStatus.getNotification();
            if (!result_NotDistrub_getNotification)
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusNotDistrub.getNotification()", "False", result_NotDistrub_getNotification.ToString(), test_passed));

            iState result_NotDistrub_SwitchStatus = currentStatus.SwitchStatus();
            if (result_NotDistrub_SwitchStatus is StatusOffline)
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusNotDistrub.SwitchStatus()", "Статус \"Не в сети\"", result_NotDistrub_SwitchStatus.ToString(), test_passed));

            string[] exp_statusNotDistrub = new string[2] { "Не беспокоить", "#FF960000" };
            string[] result_NotDistrub_getStatus = currentStatus.getStatus();
            if (result_NotDistrub_getStatus[0] == exp_statusNotDistrub[0] && result_NotDistrub_getStatus[1] == exp_statusNotDistrub[1])
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusNotDistrub.getStatus()", exp_statusNotDistrub.ToString(), result_NotDistrub_getStatus.ToString(), test_passed));

            currentStatus = currentStatus.SwitchStatus();

            // Оффлайн
            string[] result_Offline_getMessage = currentStatus.getMessage();
            if (result_Offline_getMessage == null)
                test_passed = "Да";
            else
                test_passed = "Нет";
            if (result_Offline_getMessage == null)
                reports.Add(new UnitReport("StatusOffline.getMessage()", "Null", null, test_passed));
            else
                reports.Add(new UnitReport("StatusOffline.getMessage()", "Null", result_Offline_getMessage.ToString(), test_passed));

            bool result_Offline_getNotification = currentStatus.getNotification();
            if (!result_Offline_getNotification)
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusOffline.getNotification()", "False", result_Offline_getNotification.ToString(), test_passed));

            iState result_Offline_SwitchStatus = currentStatus.SwitchStatus();
            if (result_Offline_SwitchStatus is StatusOnline)
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusOffline.SwitchStatus()", "Статус \"В сети\"", result_Offline_SwitchStatus.ToString(), test_passed));

            string[] exp_statusOffline = new string[2] { "Не в сети", "#FF969696" };
            string[] result_Offline_getStatus = currentStatus.getStatus();
            if (result_Offline_getStatus[0] == exp_statusOffline[0] && result_Offline_getStatus[1] == exp_statusOffline[1])
                test_passed = "Да";
            else
                test_passed = "Нет";
            reports.Add(new UnitReport("StatusOffline.getStatus()", exp_statusOffline.ToString(), result_Offline_getStatus.ToString(), test_passed));

            return reports;
        }
    }

    public class UnitReport
    {
        public UnitReport(string method, string get_expectation, string get_actually, string test_passed)
        {
            this.method = method;
            this.get_expectation = get_expectation;
            this.get_actually = get_actually;
            this.test_passed = test_passed;
        }
        public string method { get; set; }
        public string get_expectation { get; set; }
        public string get_actually { get; set; }
        public string test_passed { get; set; }
    }
}
