using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaft
{
    public static class MathLogic
    {
            /// <summary>
            /// Функция для построения круга
            /// </summary>
            /// <param name="xCoord"></param>
            /// <param name="yCoord"></param>
            /// <param name="radius"></param>
            /// <returns></returns>
            private static double CirculeFunction(double xCoord, double yCoord, double radius)
            {
                double zCoord;
                zCoord = Math.Pow(xCoord, 2) + Math.Pow(yCoord, 2) - Math.Pow(radius, 2);
                return zCoord;
            }

            /// <summary>
            /// Получение координат линий
            /// </summary>
            /// <param name="radius"></param>
            /// <param name="coord1"></param>
            /// <param name="flag"></param>
            /// <returns></returns>
            private static double GetCoordIntersectLineByCircule(double radius, double coord1, bool flag)
            {
                double coord2;
                coord2 = Math.Abs(Math.Pow((Math.Pow(radius, 2) - Math.Pow(coord1, 2)), 0.5));
                if (flag)
                {
                    return coord2;
                }
                else
                {
                    return -coord2;
                }
            }
            /// <summary>
            /// Умножение матриц
            /// </summary>
            /// <param name="matrixA"></param>
            /// <param name="matrixB"></param>
            /// <returns></returns>
            private static List<List<double>> MultiplyMatrix(List<List<double>> matrixA, List<List<double>> matrixB)
            {
                var matrixC = new List<List<double>>();
                for (int i = 0; i < 4; i++)
                {
                    var matrix = new List<double>();
                    for (int j = 0; j < 2; j++)
                    {
                        matrix.Add(0);
                    }
                    matrixC.Add(matrix);
                }
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {

                        double sum = 0;
                        for (int k = 0; k < 2; k++)
                        {
                            sum += matrixA[i][k] * matrixB[k][j];

                        }

                        matrixC[i][j] = sum;
                    }
                }
                return matrixC;
            }
            /// <summary>
            /// Матрица значений
            /// </summary>
            /// <param name="angle"></param>
            /// <returns></returns>
            private static List<List<double>> GetRotateMatrix(double angle)
            {
                var angleByRadian = angle * 3.1416 / 180;

                var rotateMatrix = new List<List<double>>();
                var coord1 = new List<double>();
                var coord2 = new List<double>();
                coord1.Add(Math.Cos(angleByRadian));
                coord1.Add(Math.Sin(angleByRadian));
                coord2.Add(-Math.Sin(angleByRadian));
                coord2.Add(Math.Cos(angleByRadian));
                rotateMatrix.Add(coord1);
                rotateMatrix.Add(coord2);

                return rotateMatrix;
            }

            /// <summary>
            /// Получение угла
            /// </summary>
            /// <param name="countOfAngle"></param>
            /// <returns></returns>
            public static List<double> GetMediumAnglesByRadian(int countOfAngle)
            {
                var rotateAngle = 360 / countOfAngle;
                var mediumAngles = new List<double>();
                var angle = 0;
                for (int i = 0; i < countOfAngle; i++)
                {
                    mediumAngles.Add(angle * 3.1416 / 120);
                    angle += rotateAngle;
                }


                return mediumAngles;
            }

            /// <summary>
            /// Получение базовых координат
            /// </summary>
            /// <param name="_widthOfGear"></param>
            /// <param name="slotWeight"></param>
            /// <param name="slotHeight"></param>
            /// <returns></returns>
            private static List<List<double>> GetBaseSlotCoords(double _widthOfGear, double slotWeight, double slotHeight)
            {
                double radius = (_widthOfGear / 2);
                var baseSlotDotCoords = new List<List<double>>();
                var coord1 = new List<double>();
                var coord2 = new List<double>();
                var coord3 = new List<double>();
                var coord4 = new List<double>();
                coord1.Add(radius - slotHeight);
                coord1.Add(slotWeight / 2);
                coord2.Add(radius - slotHeight);
                coord2.Add(-slotWeight / 2);
                coord3.Add(GetCoordIntersectLineByCircule(radius, (slotWeight / 2), true));
                coord3.Add(slotWeight / 2);
                coord4.Add(GetCoordIntersectLineByCircule(radius, (slotWeight / 2), true));
                coord4.Add(-slotWeight / 2);
                baseSlotDotCoords.Add(coord1);
                baseSlotDotCoords.Add(coord2);
                baseSlotDotCoords.Add(coord3);
                baseSlotDotCoords.Add(coord4);

                return baseSlotDotCoords;
            }
            
            /// <summary>
            /// Получение матрицы координат
            /// </summary>
            /// <param name="matrix"></param>
            /// <returns></returns>
            private static List<List<double>> GetTranspositionMatrix(List<List<double>> matrix)
            {
                double temp = 0;
                for (int i = 0; i < 2; i++)
                {
                    for (int j = 0; j < 2; j++)
                    {
                        temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                    }
                }
                return matrix;
            }

            /// <summary>
            /// Список координат
            /// </summary>
            /// <returns></returns>
            public static List<List<double>> GetCoordForSlots(double _widthOfGear, double slotWidth, double slotHeght, double angle, int countOfSlot)
            {
                var baseAngle = angle;
                var coordDots = new List<List<double>>();
                var baseDots = GetBaseSlotCoords(_widthOfGear, slotWidth, slotHeght);
                coordDots.Add(baseDots[0]);
                coordDots.Add(baseDots[1]);
                for (int i = 1; i < countOfSlot; i++)
                {
                    var rotateMatrix = GetRotateMatrix(angle);
                    var dots = MultiplyMatrix(baseDots, rotateMatrix);
                    angle += baseAngle;
                    coordDots.Add(dots[0]);
                    coordDots.Add(dots[1]);
                    coordDots.Add(dots[2]);
                    coordDots.Add(dots[3]);
                }

                return coordDots;
            }
        }
    }


