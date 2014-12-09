using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaft
{
    /// <summary>
    /// Класс содержащий данные о детали
    /// </summary>
    public class DataContainerShaft
    {
        /// <summary>
        /// Структура содержащая параметры детали ведомый вал
        /// </summary>
        public struct InformationAboutShaft
        {
            /// <summary>
            /// Высота шестерни
            /// </summary>
            public double HeightOfGear;

            /// <summary>
            /// Высота вала
            /// </summary>
            public double HeightOfShaft;

            /// <summary>
            /// Высота дополнительного вала
            /// </summary>
            public double HeightOfSecondShaft;

            /// <summary>
            /// Количество резцов
            /// </summary>
            public double CountOfPoints;

            /// <summary>
            /// Радиус резцов
            /// </summary>
            public double RadiusOfPoints;

            /// <summary>
            /// Внешний диаметр
            /// </summary>
            public double OutsideDiameter;

            /// <summary>
            /// Базовый диаметр
            /// </summary>
            public double BaseDiameter;

            /// <summary>
            /// Ширина отверстий
            /// </summary>
            public double WidthHole;

            /// <summary>
            /// Количество отверстий
            /// </summary>
            public int    CountOfHole;

            /// <summary>
            /// Глубина резцов отверстий
            /// </summary>
            public double DepthOfPoints;

            /// <summary>
            /// Конструктор инициализирующий параметры детали ведомый вал
            /// </summary>
            /// <param name="outsideDiameter"></param>
            /// <param name="baseDiameter"></param>
            /// <param name="heigthOfGear"></param>
            /// <param name="widthHole"></param>
            /// <param name="countOfPoints"></param>
            /// <param name="radiusOfPoints"></param>
            /// <param name="countOfHole"></param>
            /// <param name="heigthOfShaft"></param>
            /// <param name="heigthOfSecondShaft"></param>
            /// <param name="depthOfPoints"></param>
            public InformationAboutShaft(double outsideDiameter, double baseDiameter, double heigthOfGear,
                double widthHole, double countOfPoints, double radiusOfPoints, int countOfHole, double heigthOfShaft, double heigthOfSecondShaft, double depthOfPoints)
            {
                this.OutsideDiameter = outsideDiameter;
                this.BaseDiameter = baseDiameter;
                this.HeightOfGear = heigthOfGear;
                this.CountOfPoints = countOfPoints;
                this.RadiusOfPoints = radiusOfPoints;
                this.WidthHole = widthHole;
                this.CountOfHole = countOfHole;
                this.HeightOfShaft = heigthOfShaft;
                this.HeightOfSecondShaft = heigthOfSecondShaft;
                this.DepthOfPoints = depthOfPoints;
            }
        }
    }
}























/*
public void addToDictionary()
            {
                Dictionary<string, string> firstParameters =
                    new Dictionary<string, string>();
                firstParameters.Add("outsideDiameter", "400");
                firstParameters.Add("baseDiameter", "300");
                firstParameters.Add("heigthOfGear", "200");
            }
*/