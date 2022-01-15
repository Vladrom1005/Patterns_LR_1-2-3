using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns__LR_1_
{
    //================================================== Тема ==================================================
    //========================= Таблица =========================
    //=== Интерфейс таблицы ===
    public interface iListView
    {
        string coloListView();
    }
    // Таблица обычная
    class CommonListView : iListView
    {
        public string coloListView()
        {
            return "#FFFFFFFF";
        }
    }
    // Таблица лето
    class SummerListView : iListView
    {
        public string coloListView()
        {
            return "#FFFFFFBA";
        }
    }
    // Таблица осень
    class AuthumListView : iListView
    {
        public string coloListView()
        {
            return "#FFFFF1DE";
        }
    }
    // Таблица зима
    class WinterListView : iListView
    {
        public string coloListView()
        {
            return "#FFDEF1FF";
        }
    }
    // Таблица весна
    class SpringListView : iListView
    {
        public string coloListView()
        {
            return "#FFF1FFDE";
        }
    }

    //========================= Кнопка =========================
    //=== Интерфейс кнопки ===
    public interface iButton
    {
        string colorButton();
    }
    // Кнопка обычная
    class CommonButton : iButton
    {
        public string colorButton()
        {
            return "#FFDDDDDD";
        }
    }
    // Кнопка лето
    class SummerButton : iButton
    {
        public string colorButton()
        {
            return "#FFFFFFAE";
        }
    }
    // Кнопка осень
    class AuthumButton : iButton
    {
        public string colorButton()
        {
            return "#FFFFE4DC";
        }
    }
    // Кнопка зима
    class WinterButton : iButton
    {
        public string colorButton()
        {
            return "#FFDCE4FF";
        }
    }
    // Кнопка весна
    class SpringButton : iButton
    {
        public string colorButton()
        {
            return "#FFE4FFDC";
        }
    }

    //========================= Окно =========================
    //=== Интерфейс окна ===
    public interface iWindow
    {
        string colorWindow();
    }
    // Окно обычное
    class CommonWindow: iWindow
    {
        public string colorWindow()
        {
            return "#FFFFFFFF";
        }
    }
    // Окно лето
    class SummerWindow : iWindow
    {
        public string colorWindow()
        {
            return "#FFFFFFDC";
        }
    }
    // Окно осень
    class AuthumWindow : iWindow
    {
        public string colorWindow()
        {
            return "#FFFFF6EA";
        }
    }
    // Окно зима
    class WinterWindow : iWindow
    {
        public string colorWindow()
        {
            return "#FFEAF6FF";
        }
    }
    // Окно весна
    class SpringWindow : iWindow
    {
        public string colorWindow()
        {
            return "#FFF6FFEA";
        }
    }

    //================================================== Фабрики ==================================================
    //=== Интерфейс фабрики ===
    public interface iThemeFactory
    {
        iListView createListView(); // Создание таблицы 
        iButton createButton();   // Создание кнопки
        iWindow createWindow(); // Создание окна
    }
    // Фабрика Обычная
    public class CommonThemeFactory : iThemeFactory
    {
        // Создание таблицы обычной
        public iListView createListView()
        {
            return new CommonListView();
        }
        // Создание кнопки обычной
        public iButton createButton()
        {
            return new CommonButton();
        }
        // Создание окна обычного
        public iWindow createWindow()
        {
            return new CommonWindow();
        }
    }
    // Фабрика лето
    public class SummerThemeFactory : iThemeFactory
    {
        // Создание теблицы лето
        public iListView createListView()
        {
            return new SummerListView();
        }
        // Создание кнопки лето
        public iButton createButton()
        {
            return new SummerButton();
        }
        // Создание окна лето
        public iWindow createWindow()
        {
            return new SummerWindow();
        }
    }
    // Фарбика осень
    public class AuthumThemeFactory : iThemeFactory
    {
        // Создание таблицы осень
        public iListView createListView()
        {
            return new AuthumListView();
        }
        // Создание кнопки осень
        public iButton createButton()
        {
            return new AuthumButton();
        }
        // Создание окна осень
        public iWindow createWindow()
        {
            return new AuthumWindow();
        }
    }
    // Фарбика зима
    public class WinterThemeFactory : iThemeFactory
    {
        // Создание таблицы зима
        public iListView createListView()
        {
            return new WinterListView();
        }
        // Создание кнопки зима
        public iButton createButton()
        {
            return new WinterButton();
        }
        // Создание окна зима
        public iWindow createWindow()
        {
            return new WinterWindow();
        }
    }
    // Фарбика весна
    public class SpringThemeFactory : iThemeFactory
    {
        // Создание таблицы весна
        public iListView createListView()
        {
            return new SpringListView();
        }
        // Создание кнопки весна
        public iButton createButton()
        {
            return new SpringButton();
        }
        // Создание окна весна
        public iWindow createWindow()
        {
            return new SpringWindow();
        }
    }

    //================================================== Тема приложения ==================================================
    public class AppTheme
    {
        private iListView _listview; // Таблица
        private iButton _button;   // Кнопка
        private iWindow _window; // Окно

        public AppTheme(iThemeFactory factory)
        {
            _listview = factory.createListView();
            _button = factory.createButton();
            _window = factory.createWindow();
        }

        public string[] SetTheme()
        {
            string[] gottenTheme = new string[3];
            gottenTheme[0] = _listview.coloListView();
            gottenTheme[1] = _button.colorButton();
            gottenTheme[2] = _window.colorWindow();
            return gottenTheme;
        }
    }
}
