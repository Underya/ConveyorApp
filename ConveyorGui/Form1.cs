using NetApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConveyorGui
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Объект для общения с сервером
        /// </summary>
        ConveyorApi api = null;

        public Form1()
        {
            InitializeComponent();
            //Создание API для общения с сервером
            SendSocket sendSocket = new SendSocket("127.0.0.1", 8001);
            api = new ConveyorApi(sendSocket);
            TryConnect();
        }

        /// <summary>
        /// Таймер для попытки подключения
        /// </summary>
        Timer timer = null;

        /// <summary>
        /// Запуск таймера для поключения
        /// </summary>
        void TryConnect()
        {
            //Попытка подключения
            try
            {
                api.GetState();
            }
            catch
            {
                //Если не вышло, запускается метод для подключения
                timer = new Timer();
                timer.Interval = milliSecond;
                timer.Tick += TimerTick;
                timer.Start();
                //Пользователю выводиться сообщение
                MessageBox.Show($"Не удалось подклюиться к серверу. Осталось попыток: {MaxCountConnect}");
                ShowError($"Не удалось подклюиться к серверу. Осталось попыток: {MaxCountConnect}");
                return;
            }

            //Если получилось - то просто запускается нормальная работа приложения
            StartWork();
        }

        /// <summary>
        /// Внутри функции происходит попытка подключения к серверу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerTick(object sender, EventArgs e)
        {
            //Уменьшение количества попыток подключения
            MaxCountConnect--;
            //Если попытка закончились
            if(MaxCountConnect <= 0)
            {
                MessageBox.Show("Не удалось подключиться к серверу. Запустите сервер, и попробуйте снова");
                Close();
                return;
            }

            //Попытка подключения
            try
            {
                ////Пересоздаётся объект для нового сокета
                //api = null;
                //SendSocket sendSocket = new SendSocket("127.0.0.1", 8001);
                //api = new ConveyorApi(sendSocket);
                api.GetState();
            }
            catch
            {
                //Если вылтело исключение - то продолжать подключаться дальше
                ShowError($"Не удалось подклюиться к серверу. Осталось попыток: {MaxCountConnect}");
                return;
            }

            //Если удалось подключиться
            //Удалить таймер
            timer.Stop();
            //Убрать ошибку
            HideError();
            //Запустить работу
            StartWork();
        }

        /// <summary>
        /// Максимальное количество попыток подключения
        /// </summary>
        int MaxCountConnect = 9;

        /// <summary>
        /// Время, через котороое будут повторятся попытка подключения
        /// </summary>
        int milliSecond = 10*1000;

        /// <summary>
        /// Запуск работы приложения
        /// </summary>
        void StartWork()
        {
            RefreshPanel();
            //Включить кнопки
            AddButton.Enabled = true;
            PushButton.Enabled = true;
        }

        /// <summary>
        /// Заполнение панели с элементами конвейера
        /// </summary>
        void RefreshPanel()
        {
            int[] state = null;
            try
            {
                state = api.GetState();
            }
            catch
            {
                ShowError("Не удалось получить состояние сервера!");
                return;
            }
            //Скрытие ошибок
            HideError();
            //Удаление всех элементов
            ConveyorPanel.Controls.Clear();
            //Добавление новых
            for(int i = state.Length - 1; i >= 0; i--) {
                int Type = state[i];
                Panel product = new Panel();
                product.Height = ConveyorPanel.Height - 2;
                product.Width = 85;
                //В зависимоти от типа - выбор цвета
                if(Type == 1)
                    product.BackColor = Color.Green;
                if (Type == 2)
                    product.BackColor = Color.Yellow;

                ConveyorPanel.Controls.Add(product);
            }
        }

        /// <summary>
        /// Добавление нового продутка
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddButton_Click(object sender, EventArgs e)
        {
            try
            {
                //Если выбранны годный продукт
                if (GoodRadio.Checked)
                    api.AddGoodProduct();
                //Если выбран дефективный продукт
                if (DefectiveButton.Checked)
                    api.AddDefectiveProduct();
            } catch(Exception err)
            {
                ShowError(err.Message);
                return;
            }
            //Обновление конвейера
            RefreshPanel();
        }

        /// <summary>
        /// Удаления элемента из очереди
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PushButton_Click(object sender, EventArgs e)
        {
            try
            {
                api.PushProduct();
            } catch(Exception err)
            {
                ShowError(err.Message);
                return;
            }
            //Обновление конвейера
            RefreshPanel();
        }

        /// <summary>
        /// Вывод сообщения об ошибке
        /// </summary>
        /// <param name="error_text">Текст ошибки</param>
        void ShowError(string error_text)
        {
            ErrorText.Text = error_text;
            ErrorText.Visible = true;
            ErrorHandler.Visible = true;
        }

        /// <summary>
        /// Скрытие текста с ошибкой в интерфейсе
        /// </summary>
        void HideError()
        {
            ErrorHandler.Visible = false;
            ErrorText.Visible = false;
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
