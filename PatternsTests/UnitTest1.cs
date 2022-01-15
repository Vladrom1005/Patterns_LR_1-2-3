using NUnit.Framework;
using Patterns__LR_1_;

namespace Tests
{
    // Абстрактная фабрика
    [TestFixture]
    public class AbstractFactory
    {
        AppTheme furSet;
        string[] expectation;

        [Test]
        public void SetCommonTheme()
        {
            furSet = new AppTheme(new CommonThemeFactory());
            expectation = new string[3] { "#FFFFFFFF", "#FFDDDDDD", "#FFFFFFFF" };
            Assert.AreEqual(expectation, furSet.SetTheme());
        }

        [Test]
        public void SetSummerTheme()
        {
            furSet = new AppTheme(new SummerThemeFactory());
            expectation = new string[3] { "#FFFFFFBA", "#FFFFFFAE", "#FFFFFFDC" };
            Assert.AreEqual(expectation, furSet.SetTheme());
        }

        [Test]
        public void SetAuthumTheme()
        {
            furSet = new AppTheme(new AuthumThemeFactory());
            expectation = new string[3] { "#FFFFF1DE", "#FFFFE4DC", "#FFFFF6EA" };
            Assert.AreEqual(expectation, furSet.SetTheme());
        }

        [Test]
        public void SetWinterTheme()
        {
            furSet = new AppTheme(new WinterThemeFactory());
            expectation = new string[3] { "#FFDEF1FF", "#FFDCE4FF", "#FFEAF6FF" };
            Assert.AreEqual(expectation, furSet.SetTheme());
        }

        [Test]
        public void SetSpringTheme()
        {
            furSet = new AppTheme(new SpringThemeFactory());
            expectation = new string[3] { "#FFF1FFDE", "#FFE4FFDC", "#FFF6FFEA" };
            Assert.AreEqual(expectation, furSet.SetTheme());
        }
    }

    // Состиояние "В сети"
    [TestFixture]
    public class StateOnline
    {
        iState currentStatus;
        string[] exp_authors;
        string[] exp_messages;

        [SetUp]
        public void Setup()
        {
            currentStatus = new StatusOnline();
            exp_authors = new string[4] { "М'Айк Лжец", "Анон", "Анон", "Армстронг" };
            exp_messages = new string[4]
              { "М'Айк не помнит своего детства. Возможно, его и не было.",
                "Ну и как там в Египте?",
                "Кто не работает, то ест. Учись, студент.",
                "Nanomachines, son!" };
        }

        [Test]
        public void GetMessage()
        {
            string[] message = currentStatus.getMessage();
            Assert.True(System.Array.Exists(exp_authors, elem => elem.Contains(message[0])) && System.Array.Exists(exp_messages, elem => elem.Contains(message[1])));
            //Assert.Contains(message[0], exp_authors);
            //Assert.Contains(message[1], exp_messages);
        }

        [Test]
        public void GetNotification()
        {
            Assert.True(currentStatus.getNotification());
        }

        [Test]
        public void SwitchStatus()
        {
            Assert.True(currentStatus.SwitchStatus() is StatusNotDistrub);
        }

        [Test]
        public void GetStatus()
        {
            string[] exp_status = new string[2] { "В сети", "#FF009600" };
            Assert.AreEqual(exp_status, currentStatus.getStatus());
        }
    }

    // Состиояние "Не беспокоить"
    [TestFixture]
    public class NotDistrub
    {
        iState currentStatus;
        string[] exp_authors;
        string[] exp_messages;

        [SetUp]
        public void Setup()
        {
            currentStatus = new StatusNotDistrub();
            exp_authors = new string[4] { "М'Айк Лжец", "Анон", "Анон", "Армстронг" };
            exp_messages = new string[4]
              { "М'Айк не помнит своего детства. Возможно, его и не было.",
                "Ну и как там в Египте?",
                "Кто не работает, то ест. Учись, студент.",
                "Nanomachines, son!" };
        }

        [Test]
        public void GetMessage()
        {
            string[] message = currentStatus.getMessage();
            Assert.True(System.Array.Exists(exp_authors, elem => elem.Contains(message[0])) && System.Array.Exists(exp_messages, elem => elem.Contains(message[1])));
            //Assert.Contains(message[0], exp_authors);
            //Assert.Contains(message[1], exp_messages);
        }

        [Test]
        public void GetNotification()
        {
            Assert.False(currentStatus.getNotification());
        }

        [Test]
        public void SwitchStatus()
        {
            Assert.True(currentStatus.SwitchStatus() is StatusOffline);
        }

        [Test]
        public void GetStatus()
        {
            string[] exp_status = new string[2] { "Не беспокоить", "#FF960000" };
            Assert.AreEqual(exp_status, currentStatus.getStatus());
        }
    }
    
    // Состиояние "Не в сети"
    [TestFixture]
    public class Offline
    {
        iState currentStatus;
        string[] exp_authors;
        string[] exp_messages;

        [SetUp]
        public void Setup()
        {
            currentStatus = new StatusOffline();
            exp_authors = new string[4] { "М'Айк Лжец", "Анон", "Анон", "Армстронг" };
            exp_messages = new string[4]
              { "М'Айк не помнит своего детства. Возможно, его и не было.",
                "Ну и как там в Египте?",
                "Кто не работает, то ест. Учись, студент.",
                "Nanomachines, son!" };
        }

        [Test]
        public void GetMessage()
        {
            Assert.Null(currentStatus.getMessage());
            //Assert.Contains(message[0], exp_authors);
            //Assert.Contains(message[1], exp_messages);
        }

        [Test]
        public void GetNotification()
        {
            Assert.False(currentStatus.getNotification());
        }

        [Test]
        public void SwitchStatus()
        {
            Assert.True(currentStatus.SwitchStatus() is StatusOnline);
        }

        [Test]
        public void GetStatus()
        {
            string[] exp_status = new string[2] { "Не в сети", "#FF969696" };
            Assert.AreEqual(exp_status, currentStatus.getStatus());
        }
    }
}