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

        ConveyorApi api = null;

        public Form1()
        {
            InitializeComponent();
            //Создание API для общения с сервером
            SendSocket sendSocket = new SendSocket("127.0.0.1", 8001);
            api = new ConveyorApi(sendSocket);
            //Пока - тест
            StartWork();
        }

        /// <summary>
        /// Запуск работы приложения
        /// </summary>
        void StartWork()
        {
            RefreshPanel();
        }

        /// <summary>
        /// Заполнение панели с элементами конвейера
        /// </summary>
        void RefreshPanel()
        {
            int[] state = api.GetState();
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
            //Если выбранны годный продукт
            if (GoodRadio.Checked)
                api.AddGoodProduct();
            //Если выбран дефективный продукт
            if (DefectiveButton.Checked)
                api.AddDefectiveProduct();

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
            api.PushProduct();
            //Обновление конвейера
            RefreshPanel();
        }
    }
}
