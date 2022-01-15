using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns__LR_1_
{
    //=== Интерфейс состояния ===
    public interface iState
    {
        string[] getMessage();  // Получить сообшение
        bool getNotification();  // Получить уведомление
        iState SwitchStatus();  // Смена статуса
        string[] getStatus();  // Обновить статус в окне
    }

    // Состояние: В сети
    public class StatusOnline : iState
    {
        
        public string[] getMessage()
        {
            return msgGenClass.createMessage();
        }

        public bool getNotification()
        {
            return true;
        }

        public iState SwitchStatus()
        {
            return new StatusNotDistrub();
        }

        public string[] getStatus()
        {
            string[] status = new string[2];
            status[0] = "В сети";
            status[1] = "#FF009600";
            return status;
        }
    }
    // Состояние: Не беспокоить
    public class StatusNotDistrub : iState
    {
        public string[] getMessage()
        {
            return msgGenClass.createMessage();
        }

        public bool getNotification()
        {
            return false;
        }

        public iState SwitchStatus()
        {

            return new StatusOffline();   
        }

        public string[] getStatus()
        {
            string[] status = new string[2];
            status[0] = "Не беспокоить";
            status[1] = "#FF960000";
            return status;
        }
    }
    // Состояние: Не в сети
    public class StatusOffline : iState
    {
        public string[] getMessage()
        {
            return null;
        }

        public bool getNotification()
        {
            return false;
        }

        public iState SwitchStatus()
        {
            return new StatusOnline();
        }

        public string[] getStatus()
        {
            string[] status = new string[2];
            status[0] = "Не в сети";
            status[1] = "#FF969696";
            return status;
        }
    }


    //===== Генератор сообщений =====
    public static class msgGenClass
    {
        static Random rnd = new Random();
        public static string[] createMessage()
        {
            string[] message = new string[2];
            message[0] = "Анон";
            switch (rnd.Next(4))
            {
                case 0:
                    message[0] = "М'Айк Лжец";
                    message[1] = "М'Айк не помнит своего детства. Возможно, его и не было.";
                    break;
                case 1:
                    message[1] = "Ну и как там в Египте?";
                    break;
                case 2:
                    message[1] = "Кто не работает, то ест. Учись, студент.";
                    break;
                case 3:
                    message[0] = "Армстронг";
                    message[1] = "Nanomachines, son!";
                    break;
            }
            return message;
        }
    }
}
