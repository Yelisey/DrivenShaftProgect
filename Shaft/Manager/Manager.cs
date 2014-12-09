using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kompas6API5;
using Kompas6API3D5COM;
using Kompas6Constants3D;
using System.Windows.Forms;
using System.Diagnostics;
using NUnit.Framework;


namespace Shaft
{
    /// <summary>
    /// Класс управляющий построением, инициализацией и открытием
    /// </summary>
    class Manager
    {
        /// <summary>
        /// Объект Компас 3D
        /// </summary>
        protected KompasObject _kompas;
        
        /// <summary>
        /// Объект класса MainShaft (построение вала)
        /// </summary>
        private ShaftCreator _drivenShaft;
       
        /// <summary>
        /// Объект для построения спецификации
        /// </summary>
        private SpecificationGeneral _spec;
 
        /// <summary>
        /// Создание спецификации
        /// </summary>
        /// <param name="drivenShaftSample"></param>
        /// <param name="typeOfThread"></param>
        public void InitSceneForSpecification(DataContainerShaft.InformationAboutShaft drivenShaftSample, 
            DataOfSpecification.InformationAboutSpecification InformationForSpecification)
        {
            try
            {
                if (_kompas != null)
                {

                    _spec = new SpecificationGeneral(_kompas, InformationForSpecification);
                    _spec.CreateSpecification();
                    _spec.CreateStamp();
                }
                else
                {
                    MessageBox.Show("Не запущен Компас 3D");
                }
            }
            catch
            {
                MessageBox.Show("Ошибка, перезапустите плагин!");
            }
        }

        /// <summary>
        /// Построение детали
        /// </summary>
        /// <param name="drivenShaftSample"></param>
        /// <param name="typeOfThread"></param>
        public void InitSceneForCreateShaft(DataContainerShaft.InformationAboutShaft drivenShaftSample)
        {
            //Для нагрузочного теста
            //Stopwatch sWatch = new Stopwatch();
            //sWatch.Start();
            //for (int i = 0; i < 30; i++)
            //{
           if (drivenShaftSample.CountOfHole == 4)
                {

                    if ((drivenShaftSample.OutsideDiameter > 500) || (drivenShaftSample.OutsideDiameter < 370) || (drivenShaftSample.OutsideDiameter == ' '))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах внешнего диаметра!");
                    }

                    else if ((drivenShaftSample.BaseDiameter > 400) || (drivenShaftSample.BaseDiameter < 100))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах базового диаметра!");
                    }
                    else if ((drivenShaftSample.HeightOfGear > 300) || (drivenShaftSample.HeightOfGear < 100))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах высоты шестерни!");
                    }
                    else if ((drivenShaftSample.RadiusOfPoints > 12) || (drivenShaftSample.RadiusOfPoints < 3))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах радиуса резцов!");
                    }
                    else if ((drivenShaftSample.CountOfPoints > 60) || (drivenShaftSample.CountOfPoints < 20))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах количества резцов!");
                    }
                    else if ((drivenShaftSample.WidthHole > 65) || (drivenShaftSample.WidthHole < 10))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах ширины отверстий!");
                    }
                    else if ((drivenShaftSample.DepthOfPoints > 12) || (drivenShaftSample.DepthOfPoints < 1))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах глубины резцов!");
                    }
                    else if ((drivenShaftSample.HeightOfShaft > 400) || (drivenShaftSample.HeightOfShaft < 100))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах высоты вала!");
                    }
                    else if (drivenShaftSample.CountOfHole != 4)
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах количества отверстий!");
                    }

                    else
                    {
                        OpenKompas3D();
                        var doc3D = (ksDocument3D)_kompas.Document3D();
                        doc3D.Create(false, false);
                        doc3D = (ksDocument3D)_kompas.ActiveDocument3D();
                        _drivenShaft = new DrivenShaftFor4Hole(doc3D, _kompas, drivenShaftSample);
                        _drivenShaft.CreateShaft();
                    }


                }
                else if (drivenShaftSample.CountOfHole == 8)
                {
                    if ((drivenShaftSample.OutsideDiameter > 500) || (drivenShaftSample.OutsideDiameter < 370))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах внешнего диаметра!");
                    }
                    else if ((drivenShaftSample.BaseDiameter > 400) || (drivenShaftSample.BaseDiameter < 100))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах базового диаметра!");
                    }
                    else if ((drivenShaftSample.HeightOfGear > 300) || (drivenShaftSample.HeightOfGear < 100))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах высоты шестерни!");
                    }
                    else if ((drivenShaftSample.RadiusOfPoints > 12) || (drivenShaftSample.RadiusOfPoints < 3))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах радиуса резцов!");
                    }
                    else if ((drivenShaftSample.CountOfPoints > 60) || (drivenShaftSample.CountOfPoints < 20))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах количества резцов!");
                    }
                    else if ((drivenShaftSample.WidthHole > 65) || (drivenShaftSample.WidthHole < 10))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах ширины отверстий!");
                    }
                    else if ((drivenShaftSample.DepthOfPoints > 12) || (drivenShaftSample.DepthOfPoints < 1))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах глубины резцов!");
                    }
                    else if ((drivenShaftSample.HeightOfShaft > 400) || (drivenShaftSample.HeightOfShaft < 100))
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах высоты вала!");
                    }

                    else if (drivenShaftSample.CountOfHole != 8)
                    {
                        throw new System.ArgumentOutOfRangeException("Ошибка в параметрах количества отверстий!");
                    }
                }
                else
                {
                    var doc3D = (ksDocument3D)_kompas.Document3D();
                    doc3D.Create(false, false);
                    doc3D = (ksDocument3D)_kompas.ActiveDocument3D();
                    _drivenShaft = new DrivenShaftFor8Hole(doc3D, _kompas, drivenShaftSample);
                    _drivenShaft.CreateShaft();

                }
            }
    

           
               
            //}
           // sWatch.Stop();
        //MessageBox.Show("Время выполнения операций", sWatch.ElapsedMilliseconds.ToString());

        #region Test
        [TestFixture]
        public class Validate
        {
            public Validate()
            {

            }

            [Test]
            public void TestOutsideDiametr()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(4004343, 200, 200, 35, 45, 34, 4, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestBaseDiametr()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200343, 200, 35, 45, 34, 4, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }


            [Test]
            public void TestHeightOfGear()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 2003434, 35, 45, 34, 4, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestRadiusWidthHole()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 3534343, 45, 34, 4, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestCountOfPoints()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 4534343, 34, 4, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestRadiusOfPoints()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 343434, 4, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestCountOfHole()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 434343, 300, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }


            [Test]
            public void TestHeightOfShaft()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 30034343, 200, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestHeightOfSecondShaft()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 300, 20034343, 4);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

            [Test]
            public void TestDepthOfPoints()
            {
                Manager manager = new Manager();
                DataContainerShaft.InformationAboutShaft drivenShaftSample =
                   new DataContainerShaft.InformationAboutShaft(400, 200, 200, 35, 45, 34, 4, 300, 200, 4434343);
                Assert.That(() => manager.InitSceneForCreateShaft(drivenShaftSample), Throws.InnerException);
            }

        #endregion

        }

        /// <summary>
        /// Открытие Компас 3D
        /// </summary>
        public void OpenKompas3D()
        {
            try
            {
                if (_kompas == null)
                {
                    Type type = Type.GetTypeFromProgID("KOMPAS.Application.5");
                    _kompas = (KompasObject)Activator.CreateInstance(type);
                }

                if (_kompas != null)
                {
                    _kompas.Visible = true;
                    _kompas.ActivateControllerAPI();
                }
            }
            catch
            {
                MessageBox.Show("Ошибка! Компас-3D не открывается!");
            }
        }
    }
}

