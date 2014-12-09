using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace Shaft
{
    /// <summary>
    /// Класс, отвечающий за ведомый вал с 8 отверстиями
    /// </summary>
    class DrivenShaftFor8Hole : ShaftCreator
    {
        // <summary>
        /// Конструктор
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="kompas"></param>
        /// <param name="drivenShaftSample"></param>
        public DrivenShaftFor8Hole(ksDocument3D document3D, KompasObject kompas, DataContainerShaft.InformationAboutShaft drivenShaftSample) :
            base(document3D, kompas, drivenShaftSample)
        {
        }

        /// <summary>
        /// Метод для выреза отверстий
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="entitySketch2"></param>
         protected override void CutHoles(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
         {
            var slotCoords = MathLogic.GetCoordForSlots(_outsideDiameter, _widthHole, _heightHole, 90, 8);
            var mediumAngles = MathLogic.GetMediumAnglesByRadian(8);
            var radius = 40;
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit(); 
            sketchEdit.ksCircle(_outsideDiameter / 4 + 25, 0, radius, 1);
            sketchEdit.ksCircle(-_outsideDiameter / 4 - 25, 0, radius, 1);
            sketchEdit.ksCircle(0, _outsideDiameter / 4 + 25, radius, 1);
            sketchEdit.ksCircle(0, - _outsideDiameter / 4 - 25, radius, 1);
            sketchEdit.ksCircle(_outsideDiameter / 5 + 10, - _outsideDiameter / 5 - 10, radius, 1);
            sketchEdit.ksCircle(_outsideDiameter /5 + 10, _outsideDiameter /5 + 10, radius, 1);
            sketchEdit.ksCircle(-_outsideDiameter / 5 - 10, -_outsideDiameter / 5 - 10, radius, 1);
            sketchEdit.ksCircle(-_outsideDiameter / 5 - 10, _outsideDiameter / 5 + 10, radius, 1);
            sketchDefinition.EndEdit();
            base.CutObject(entitySketch2); 
        }

         /// <summary>
         /// Вспомогательная процедура для расстановки резцов
         /// </summary>
         /// <param name="sketchDefinition"></param>
         /// <param name="entitySketch2"></param>
         protected override void Holes(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
         {
             int i = 1;
             var slotCoords = MathLogic.GetCoordForSlots(_outsideDiameter, _widthHole, _heightHole, 90, 4);
             var mediumAngles = MathLogic.GetMediumAnglesByRadian(6);
             var radius = _outsideDiameter / 2;
             for (double phi = 0; phi < 2 * Math.PI; phi += 2 * Math.PI / _countOfPoints)
             {
                 double x = radius * Math.Cos(phi);
                 double y = radius * Math.Sin(phi);
                 CreateCircleHole(x, y, _radiusOfPoints, _depthOfPoints, "XOY", "ThroughAll");
                 if (i < _countOfPoints)
                 {
                     i++;
                 }
                 else break;
             }
         }

         /// <summary>
         /// Метод выдавливания шестерни
         /// </summary>
         /// <param name="sketchDefinition"></param>
         /// <param name="entitySketch2"></param>
        protected override void PressShaft(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
        {
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
            sketchEdit.ksCircle(0, 0, _outsideDiameter/4 - 40, 1);
            sketchDefinition.EndEdit();
            base.CutPressObject(entitySketch2);

        }

        /// <summary>
        /// Первая часть вала 
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="entitySketch2"></param>
        protected override void PressSecondShaft(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
        {
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit(); 
            sketchEdit.ksCircle(0, 0, _outsideDiameter/2 - 20, 1);
            sketchDefinition.EndEdit();
            base.CutForSecondShaft(entitySketch2);

        }

        /// <summary>
        /// Вторая часть вала 
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="entitySketch2"></param>
        protected override void PressSecondShaft2(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
        {
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit(); 
            sketchEdit.ksCircle(0, 0, (_outsideDiameter / 6 - 25), 1);
            sketchDefinition.EndEdit();
            base.CutPressPart1(entitySketch2);

        }

        /// <summary>
        /// Третья часть вала 
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="entitySketch2"></param>
        protected override void PressSecondShaft3(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
        {
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit(); 
            sketchEdit.ksCircle(0, 0, (_outsideDiameter / 6 - 26), 1);
            sketchDefinition.EndEdit();
            base.CutPressPart2(entitySketch2);

        }

        /// <summary>
        /// Четвертая часть вала 
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="entitySketch2"></param>
        protected override void PressSecondShaft4(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
        {
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit(); 
            sketchEdit.ksCircle(0, 0, (_outsideDiameter / 6 - 27), 1);
            sketchDefinition.EndEdit();
            base.CutPressPart3(entitySketch2);

        }

        /// <summary>
        /// Пятая часть вала 
        /// </summary>
        /// <param name="sketchDefinition"></param>
        /// <param name="entitySketch2"></param>
        protected override void PressSecondShaft5(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
        {
            var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit(); 
            sketchEdit.ksCircle(0, 0, (_outsideDiameter / 6 - 28), 1);
            sketchDefinition.EndEdit();
            base.CutPressPart4(entitySketch2);

        }

      /// <summary>
      /// Построение вала
      /// </summary>
       override public void CreateShaft()
       {
          base.CreateBase();
          base.PressBase();
          base.CutByPress();
          base.CutBase();
          base.CreateSlots();
          base.CutForBaseShaft();
          base.CreateShaft();
          base.ShaftCutPress();
          base.ShaftCutPress1();
          base.ShaftCutPress2();
          base.ShaftCutPress3();
          base.ShaftCutPress4();
          base.createFask(true, 2, "XOY");
          base.createFask(true, 2, "XOZ");
          base.createFask(true, 2, "YOZ");
          base.HolesCreate();        
       }
    }
}

