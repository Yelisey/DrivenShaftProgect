using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kompas6API5;
using Kompas6API3D5COM;
using Kompas6Constants3D;
using Kompas6Constants;
using System.Windows.Forms;


namespace Shaft
{
    public partial class Specification: Form
    {
        /// <summary>
        /// Объявление объекта класса Manager
        /// </summary>
        Manager manager = new Manager();

        /// <summary>
        /// Объект структуры InformationAboutShaft
        /// </summary>
        public DataContainerShaft.InformationAboutShaft DrivenShaftSample;

        /// <summary>
        /// Объекта структуры InformationAboutSpecification
        /// </summary>
        public DataOfSpecification.InformationAboutSpecification DataForSpecification;

        /// <summary>
        /// Конструктор
        /// </summary>
        public Specification()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Далее обработчики ввода параметра документа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDocParam_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxDocParam.Text);
            DataForSpecification.DocParam = value;
        }

        /// <summary>
        /// Далее обработчики ввода названия документа
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDocName_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxDocName.Text);
            DataForSpecification.DocName = value;
        }

        /// <summary>
        /// Далее обработчики ввода параметра детали
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDetParam_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxDetParam.Text);
            DataForSpecification.DetParam = value;
        }

        /// <summary>
        /// Далее обработчики ввода названия детали
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDetName_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxDetName.Text);
            DataForSpecification.DetName = value;
        }

        /// <summary>
        /// Далее обработчики ввода инициалов разработчика
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxDevelopName_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxDevelopName.Text);
            DataForSpecification.DevelopName = value;
        }

        /// <summary>
        /// Далее обработчики ввода инициалов проверяющего
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void textBoxMasterName_TextChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(textBoxMasterName.Text);
            DataForSpecification.MasterName = value;
        }

        /// <summary>
        /// Далее обработчики ввода даты создания
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeCreateDate_ValueChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(dateTimeCreateDate.Text);
            DataForSpecification.DateOfCreate= value;
        }

        /// <summary>
        /// Далее обработчики ввода даты проверки
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dateTimeControlDate_ValueChanged(object sender, EventArgs e)
        {
            string value = Convert.ToString(dateTimeControlDate.Text);
            DataForSpecification.DateOfControl = value;
        }

        /// <summary>
        /// Построение спецификации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Specification.ActiveForm.Close();
            manager.OpenKompas3D();
            manager.InitSceneForSpecification(DrivenShaftSample,DataForSpecification);
         }
       }
    }



