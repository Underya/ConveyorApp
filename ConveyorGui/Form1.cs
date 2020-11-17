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
        public Form1()
        {
            InitializeComponent();
            
        }

        /// <summary>
        /// Заполнение панели с элементами конвейера
        /// </summary>
        /// <param name="arr"></param>
        void FillingPanel(int[] arr)
        {
            //Удаление всех элементов
            ConveyorPanel.Controls.Clear();
            //Добавление новых
            foreach(int Product in arr)
            {
                Panel product = new Panel();
                product.Height = ConveyorPanel.Height - 2;
                product.Width = 90;
                //В зависимоти от типа - выбор цвета
                if(Product == 1)
                    product.BackColor = Color.Green;
                if (Product == 2)
                    product.BackColor = Color.Yellow;

                ConveyorPanel.Controls.Add(product);
            }
        }

    }
}
