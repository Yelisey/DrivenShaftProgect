using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Shaft
{
    partial class Shaft : Form
    {
        /// <summary>
        /// Объект класса Manager
        /// </summary>
        Manager manager = new Manager();

        /// <summary>
        /// Объект класса Specification
        /// </summary>
        Specification spec = new Specification();

        /// <summary>
        /// Объект класса DataContainerShaft
        /// </summary>
        public DataContainerShaft.InformationAboutShaft DrivenShaftSample;

        /// <summary>
        /// Первый набор параметров
        /// </summary>
        double[] ArrayOfFirstParameters = new double[] { 300, 200, 10, 55, 50, 10, 170, 4 };

        /// <summary>
        /// Второй набор параметров
        /// </summary>
        double[] ArrayOfSecondParameters = new double[] { 200, 200, 10, 48, 40, 8, 170, 4 };

        /// <summary>
        /// Третий набор параметров
        /// </summary>
        double[] ArrayOfThirdParameters = new double[] { 400, 300, 12, 60, 60, 12, 370, 4 };

        Dictionary<double, double[]> parameters = new Dictionary<double, double[]>();

        /// <summary>
        /// Конструктор
        /// </summary>
        public Shaft()
        {
            InitializeComponent();
        }

        private void Init()
        {
            parameters.Add(300, new double[] { 300, 200, 10, 55, 50, 10, 170, 4 });
            parameters.Add(200, new double[] { 200, 200, 10, 48, 40, 8, 170, 4 });
            parameters.Add(400, new double[] { 400, 300, 12, 60, 60, 12, 370, 4 });
        }

        /// <summary>
        /// Метод добавление величин параметров
        /// </summary>
        public void InputValueOfParameters(double []  Array)
        {
            for (int i = 1; i <= 8; i++)
            {
                this.Controls["textBox" + (i + 1).ToString()].Text = Convert.ToString(Array[i - 1]);
            }
        }

        /// <summary>
        /// внешний диаметр и задание параметров
        /// </summary>
        private void textBoxOutsideDiametr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox1.Text);
                DrivenShaftSample.OutsideDiameter = value;
                InputValueOfParameters(parameters[value]);
            }

            catch
            {
                ResetValue();
            }
       }
    
        /// <summary>
        /// базовый диаметр
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxBaseDiametr_TextChanged(object sender, EventArgs e)
        {
            textBox2.BackColor = Color.White;

            try
            {
                double value = Convert.ToDouble(textBox2.Text);
                DrivenShaftSample.BaseDiameter = value;

                if (value == 200 || value == 300 || value ==  400)
                {
                    textBox2.BackColor = Color.White;
                }
                else 
                {
                    textBox2.BackColor = Color.Red;
                }
            }

            catch
            {
                textBox2.Clear();
            }
        }

        /// <summary>
        /// Высота шестерни
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxHeightGear_TextChanged(object sender, EventArgs e)
        {
            textBox3.BackColor = Color.White;
            try
            {
                double value = Convert.ToDouble(textBox3.Text);
                DrivenShaftSample.HeightOfGear = value;
                if (value == 200 || value == 300)
                {
                    textBox3.BackColor = Color.White;
                }
                else 
                {
                    textBox3.BackColor = Color.Red;
                }
            }

            catch
            {
                textBox3.Clear();
            }
        }

        /// <summary>
        /// Количество резцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCountPoints_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox5.Text);
                DrivenShaftSample.CountOfPoints = value;

                if (value == 48 || value == 60 || value == 55)
                {
                    textBox5.BackColor = Color.White;
                }
                else
                {
                    textBox5.BackColor = Color.Red;
                }
            }

            catch
            {
                textBox5.Clear();
            }
        }

        /// <summary>
        /// Радиус резцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxRadiusPoints_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox4.Text);
                DrivenShaftSample.RadiusOfPoints = value;
                if (value == 8 || value == 10 || value == 12)
                {
                    textBox4.BackColor = Color.White;
                }
                else
                {
                    textBox4.BackColor = Color.Red;
                }
            }
            catch
            {
                textBox4.Clear();
            }
        }

        /// <summary>
        /// Ширина отверстий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxHoleDiametr_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox6.Text);
                DrivenShaftSample.WidthHole = value;
              
                if (value == 45 || value == 50 || value == 35 
                    || value == 48 || value == 58 
                    || value == 40 || value == 60)
                {
                    textBox6.BackColor = Color.White;
                }
                else
                {
                    textBox6.BackColor = Color.Red;
                }
            }

            catch
            {
             
            }
        }

        /// <summary>
        /// Глубина резцов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDepthHole_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox7.Text);
                DrivenShaftSample.DepthOfPoints = value;

                textBox7.BackColor = (value == 8 || value == 10 || value == 12)
                    ? Color.White 
                    : Color.Red;                
            }
            catch
            {
                textBox7.Clear();
            }
        }  

        /// <summary>
        /// Высота вала
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxHeightShaft_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double value = Convert.ToDouble(textBox8.Text);
                DrivenShaftSample.HeightOfShaft = value;

                if ((value == 170 && textBox3.Text == "200") 
                    || (value == 370 && textBox3.Text == "300"))
                {
                    textBox8.BackColor = Color.White;
                }
                else
                {
                    textBox8.BackColor = Color.Red;
                }

            }
            catch
            {
                textBox8.Clear();
            }
        }

        /// <summary>
        /// Количество отверстий
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxCountHole_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int value = Convert.ToInt32(textBox9.Text);

                if ((value == 8)||(value == 4))
                {
                    textBox9.BackColor = Color.White;
                }

                else
                {
                    textBox9.BackColor = Color.Red;
                }
               
                DrivenShaftSample.CountOfHole = value;
            }
                
            catch
            {
                textBox9.Clear();
            }
        }

        /// <summary>
        /// Вызов окна задания спецификации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Specification spec = new Specification();
            spec.Show();
        }

        /// <summary>
        /// Построение модели без создания спецификации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void безСпецификацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                manager.InitSceneForCreateShaft(DrivenShaftSample);
            }

            catch
            {
                MessageBox.Show("Ошибка в создании спецификации!");
            }
            
        }

        /// <summary>
        /// Вызов справки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        /// <summary>
        /// Обработчик ввода нечисловых данных на каждый textbox
        /// </summary>
        private bool _nonNumberEntered;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text) && e.KeyChar == ',')
                return;
            if (_nonNumberEntered)
            {
                e.Handled = true;
            }
        }
        ///
        #region .

        /// <summary>
        /// Перезагрузка величин
        /// </summary>
        public void ResetValue()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
        }
        #endregion///
        /// <summary>
        /// Обработчик ввода нечисловых данных на каждый textbox
        /// </summary>
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            _nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        _nonNumberEntered = true;
                    }
                }
            }
            if (ModifierKeys == Keys.Shift)
            {
                _nonNumberEntered = true;
            }
        }
    }
}