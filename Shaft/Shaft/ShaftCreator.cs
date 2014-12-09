using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants3D;

namespace Shaft
{
    /// <summary>
    /// Класс содержащий методы построения Ведомого Вала 
    /// </summary>
    public class ShaftCreator
    {
        #region Variables

        /// <summary>
        /// Высота шестерни
        /// </summary>
        protected double _heigthOfGear;

        /// <summary>
        /// Ширина шестерни
        /// </summary>
        protected double _widthOfGear;

        /// <summary>
        /// Объект документа Компас 3D
        /// </summary>
        protected ksDocument3D _doc3D;

        /// <summary>
        /// Объект Компас 3D
        /// </summary>
        protected KompasObject _kompas;

        /// <summary>
        /// Объект эскиза Компас 3D
        /// </summary>
        protected ksEntity _baseSketch;

        /// <summary>
        /// 
        /// </summary>
        protected ksPart _part;

        /// <summary>
        /// Объект части сборки Компас 3D
        /// </summary>
        protected double _countOfPoints;

        /// <summary>
        /// Радиус резцов
        /// </summary>
        protected double _radiusOfPoints;

        /// <summary>
        /// Высота отверстий
        /// </summary>
        protected double _heightHole;

        /// <summary>
        /// Ширина отверстий
        /// </summary>
        protected double _widthHole;

        /// <summary>
        /// Внешний диаметр
        /// </summary>
        protected double _outsideDiameter;

        /// <summary>
        /// Базовый диаметр
        /// </summary>
        protected double _baseDiameter;
        
        /// <summary>
        /// Высота вала
        /// </summary>
        protected double _heigthOfShaft;

        /// <summary>
        /// Высота вспомогательного вала
        /// </summary>
        protected double _heigtOfSecondShaft;

        /// <summary>
        /// Глубина резцов
        /// </summary>
        protected double _depthOfPoints;
        
        #endregion 

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="document3D"></param>
        /// <param name="kompas"></param>
        /// <param name="drivenShaftSample"></param>
        public ShaftCreator(ksDocument3D document3D, KompasObject kompas, DataContainerShaft.InformationAboutShaft drivenShaftSample)
        {
            this._outsideDiameter = drivenShaftSample.OutsideDiameter;
            this._heigthOfGear = drivenShaftSample.HeightOfGear;
            this._countOfPoints = drivenShaftSample.CountOfPoints;
            this._radiusOfPoints = drivenShaftSample.RadiusOfPoints;
            this._doc3D = document3D;
            this._baseDiameter = drivenShaftSample.BaseDiameter;
            this._kompas = kompas;
            this._widthHole = drivenShaftSample.WidthHole;
            this._heigthOfShaft = drivenShaftSample.HeightOfShaft;
            this._heigtOfSecondShaft = drivenShaftSample.HeightOfSecondShaft;
        }
       
   
       public ShaftCreator()
       {
           // TODO: Complete member initialization
       }
        #endregion 

       #region Base Operation
       /// <summary>
        /// Создание основания вала
        /// </summary>
       protected void CreateBase()
       {
           var radius = _outsideDiameter / 2;
           _part = (ksPart)_doc3D.GetPart((short)Part_Type.pTop_Part);
           ksSketchDefinition definitionSketch = null;
           if (_part != null)
           {
               _baseSketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
               if (_baseSketch != null)
               {
                   definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition(); 
                   if (definitionSketch != null)
                   {
                       var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                       definitionSketch.SetPlane(planeXOY); 
                       _baseSketch.Create();
                       var sketchEdit = (ksDocument2D)definitionSketch.BeginEdit();
                       sketchEdit.ksCircle(0, 0, radius, 1);
                       definitionSketch.EndEdit();

                   }
               }
           }
       }
        
       /// <summary>
       /// Создание круговых отверстий
       /// </summary>
       /// <param name="x1"></param>
       /// <param name="y1"></param>
       /// <param name="rad"></param>
       /// <param name="depth"></param>
       /// <param name="plane"></param>
       /// <param name="defType"></param>
       protected void CreateCircleHole(double x1, double y1, double rad, double depth, string plane, string defType)
       {

           rad = 10;
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           {
               // Создаем новый эскиз
               ksEntity entitySketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
               if (entitySketch != null)
               {
                   // интерфейс свойств эскиза
                   ksSketchDefinition sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                   if (sketchDef != null)
                   {
                       // получим интерфейс базовой плоскости
                       ksEntity basePlane;
                       if (plane == "XOY")
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                       }
                       else
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                       }
                       sketchDef.SetPlane(basePlane);	// установим плоскость базовой для эскиза
                       entitySketch.Create();			// создадим эскиз1

                       // интерфейс редактора эскиза
                       ksDocument2D sketchEdit = (ksDocument2D)sketchDef.BeginEdit();

                       //круглое отверстие
                       sketchEdit.ksCircle(x1, y1, rad, 1);
                       sketchDef.EndEdit();	// завершение редактирования эскиза
                       // вырежим выдавливанием

                       ksEntity entityCutExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);

                       if (entityCutExtr != null)
                       {
                           ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();

                           if (cutExtrDef != null)
                           {
                               cutExtrDef.cut = true;
                               cutExtrDef.directionType = (short)Direction_Type.dtReverse;

                               if (defType == "ThroughAll")
                               {
                                   cutExtrDef.SetSideParam(false, (short)End_Type.etThroughAll, depth);
                               }
                               else if (defType == "Blind")
                               {
                                   cutExtrDef.SetSideParam(false, (short)End_Type.etBlind, depth);
                               }

                               cutExtrDef.SetSketch(entitySketch);
                               entityCutExtr.Create();	// создадим операцию вырезание выдавливанием
                               // CreateChamfer ( "XOZ" );
                               sketchDef.EndEdit(); // завершение редактирования эскиза
                           }
                       }
                   }
               }
           }
       }

        /// <summary>
        /// Выдавливание отверстия в основании вала
        /// </summary>
       protected void CutByPress()
       {
           var radius = 50;
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true;
                   planeOffsetDefinition.offset = _heigthOfGear;
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   var sketchEdit = (ksDocument2D)sketchDefinition.BeginEdit();
                   sketchEdit.ksCircle(0, 0, radius, 1);
                   sketchDefinition.EndEdit();
                   this.CutObject(entitySketch2);

               }
           }
       }
       #region Virtual methods


       protected virtual void CutHoles(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
       {

       }

       protected virtual void Holes(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
       {

       }

       protected virtual void PressShaft(ksSketchDefinition sketchDefinition, ksEntity entitySketch2)
       {

       }

       protected virtual void PressSecondShaft(ksSketchDefinition sketchDefinition, ksEntity entitySketch3)
       {

       }

       protected virtual void PressSecondShaft2(ksSketchDefinition sketchDefinition, ksEntity entitySketch4)
       {

       }

       protected virtual void PressSecondShaft3(ksSketchDefinition sketchDefinition, ksEntity entitySketch5)
       {

       }

       protected virtual void PressSecondShaft4(ksSketchDefinition sketchDefinition, ksEntity entitySketch6)
       {

       }

       protected virtual void PressSecondShaft5(ksSketchDefinition sketchDefinition, ksEntity entitySketch7)
       {

       }

       virtual public void CreateShaft()
       {

       }

       #endregion

       /// <summary>
       /// Выдавливание основания в сторону роста детали
       /// </summary>
       protected void PressBase()
       {
           var entityExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
           var sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
           var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();
           if (entityExtr != null)
           {
               var extrusionDef = (ksBaseExtrusionDefinition)entityExtr.GetDefinition(); 

               if (extrusionDef != null)
               {
                   extrusionDef.SetSideParam(true, (short)End_Type.etBlind, _heigthOfGear);
                   extrusionDef.SetSketch(_baseSketch);	
                   entityExtr.Create();				

                   entityExtr.Update();               
               }
           }

           definitionSketch.EndEdit();    
           sketch.Update();               
       }

       /// <summary>
       /// Выдавливание основания вырезанием
       /// </summary>
       protected void CutBase()
       {
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);

           if (_part != null)
           {
               // Создаем новый эскиз
               var sketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
               var definitionSketch = (ksSketchDefinition)_baseSketch.GetDefinition();

               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

               //Получаем интерфейс объекта "смещенная плоскость"
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();

                   // интерфейс свойств эскиза

               if (definitionSketch != null)
                   {
                       // получим интерфейс базовой плоскости
                       ksEntity basePlane;
                       if (planeOffsetDefinition != null)
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                       }
                       else
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                       }
                       definitionSketch.SetPlane(basePlane);	// установим плоскость базовой для эскиза
                       sketch.Create();			// создадим эскиз1

                       // интерфейс редактора эскиза
                       ksDocument2D sketchEdit = (ksDocument2D)definitionSketch.BeginEdit();

                       //круглое отверстие
                       sketchEdit.ksCircle(0, 0, _outsideDiameter / 2, 1);
                       definitionSketch.EndEdit();	// завершение редактирования эскиза
                       // вырежим выдавливанием
                      
                   
                   ksEntity entityCutExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
                       if (entityCutExtr != null)
                       {
                           ksCutExtrusionDefinition cutExtrDef = (ksCutExtrusionDefinition)entityCutExtr.GetDefinition();
                           if (cutExtrDef != null)
                           {
                               cutExtrDef.SetSketch(sketch);	// установим эскиз операции
                               cutExtrDef.directionType = (short)Direction_Type.dtBoth;//обратное направление
                               cutExtrDef.SetSideParam(true, (short)End_Type.etBlind, _heigthOfGear);
                               entityCutExtr.Create();	// создадим операцию вырезание выдавливанием
                               definitionSketch.EndEdit(); // завершение редактирования эскиза
                           }
                       }
               }
           }
       }

       /// <summary>
       /// Создание отверстий
       /// </summary>
       protected void CreateSlots()
       {
           var radius = _outsideDiameter / 2;
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);


           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true; 
                   planeOffsetDefinition.offset = _heigthOfGear; 
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   CutHoles(sketchDefinition, entitySketch2);
               }
           }
       }

       /// <summary>
       /// Создание резцов
       /// </summary>
       protected void HolesCreate()
       {
           var radius = _outsideDiameter / 2;
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);


           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true;
                   planeOffsetDefinition.offset = _heigthOfGear;
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   Holes(sketchDefinition, entitySketch2);
               }
           }
       }


       /// <summary>
       /// Вырезать объект
       /// </summary>
       /// <param name="entitySketch">Ссылка на эскиз объекта</param>
       protected void CutObject(ksEntity entitySketch)
       {
           var entityCutExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
           var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
           cutExtrusionDefinition.cut = true;
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heigthOfGear);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityCutExtrusion.Create();
       }

        /// <summary>
        /// Создание фаски
        /// </summary>
        /// <param name="tangent"></param>
        /// <param name="radius"></param>
        /// <param name="Plane"></param>
       public void createFask(bool tangent, double radius, string Plane)
       {
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           var part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);

           if (part != null)
           {
               ksEntity entitySketch = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
               ksEntity fillet = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_fillet);

               if (entitySketch != null)
               {
                   ksSketchDefinition sketchDef = (ksSketchDefinition)entitySketch.GetDefinition();
                   if (sketchDef != null)
                   {
                       ksEntity basePlane;
                       if (Plane == "XOY")
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
                       }
                       else if (Plane == "XOZ")
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOZ);
                       }
                       else
                       {
                           basePlane = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeYOZ);
                       }
                       sketchDef.SetPlane(basePlane);	// установим плоскость базовой для эскиза
                       entitySketch.Create();			


                       ksEntity entityExtr = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
                       if (entityExtr != null)
                       {
                           // интерфейс свойств базовой операции выдавливания
                           FilletDefinition ks = (FilletDefinition)fillet.GetDefinition();
                           // интерфейс базовой операции выдавливания
                           if (ks != null)
                           {

                               ks.radius = radius;
                               ks.tangent = tangent;
                               
                               ksEntityCollection EntityColectionPart = (ksEntityCollection)_part.EntityCollection((short)Obj3dType.o3d_edge);
                               ksEntityCollection EntityCollectionFillet = (ksEntityCollection)ks.array();
                               EntityCollectionFillet.Clear();
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(0));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(1));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(2));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(3));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(4));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(5));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(6));
                               EntityCollectionFillet.Add(EntityColectionPart.GetByIndex(7));
                               fillet.Create();
                               sketchDef.EndEdit(); 
                           }
                       }
                   }
               }
           }
       }

       /// <summary>
       /// Вырез объекта
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void CutPressObject(ksEntity entitySketch)
       {
           var entityBaseExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
           var cutExtrusionDefinition = (ksBaseExtrusionDefinition)entityBaseExtrusion.GetDefinition();
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heigthOfShaft);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityBaseExtrusion.Create();
       }


       /// <summary>
       /// Создание основания вала
       /// </summary>
       protected void ShaftCutPress()
       {
          
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true; //Прямое направление смещения 
                   planeOffsetDefinition.offset = 0; //Величина смещения
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   PressShaft(sketchDefinition, entitySketch2);
               }
           }
       }

       /// <summary>
       /// Вырезание под основание вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void CutForSecondShaft(ksEntity entitySketch)
       {
           var entityCutExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_cutExtrusion);
           var cutExtrusionDefinition = (ksCutExtrusionDefinition)entityCutExtrusion.GetDefinition();
           cutExtrusionDefinition.cut = true;
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtBoth;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, 50);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityCutExtrusion.Create();
       }

       /// <summary>
       /// Выдавливание под основание (основная операция)
       /// </summary>
       protected void CutForBaseShaft()
       {

           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true; 
                   planeOffsetDefinition.offset = _heigthOfGear;
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();

                   var entitySketch3 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch3.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch3.Create();
                   PressSecondShaft(sketchDefinition, entitySketch3);
               }
           }
       }

        /// <summary>
        /// Первая часть вала
        /// </summary>
        /// <param name="entitySketch"></param>
       protected void CutPressPart1(ksEntity entitySketch)
       {
           var entityBaseExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
           var cutExtrusionDefinition = (ksBaseExtrusionDefinition)entityBaseExtrusion.GetDefinition();
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heigthOfShaft/24);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityBaseExtrusion.Create();
       }

       /// <summary>
       /// Вырез под первую часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void ShaftCutPress1()
       {
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true;  
                   planeOffsetDefinition.offset = _heigthOfShaft;
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   PressSecondShaft2(sketchDefinition, entitySketch2);
               }
           }
       }

       /// <summary>
       /// Вторая часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void CutPressPart2(ksEntity entitySketch)
       {
           var entityBaseExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
           var cutExtrusionDefinition = (ksBaseExtrusionDefinition)entityBaseExtrusion.GetDefinition();
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heigthOfShaft / 8);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityBaseExtrusion.Create();
       }

       /// <summary>
       /// Вырез под вторую часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void ShaftCutPress2()
       {
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true; 
                   planeOffsetDefinition.offset = _heigthOfShaft; 
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   PressSecondShaft3(sketchDefinition, entitySketch2);
               }
           }
       }

       /// <summary>
       /// Третья часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void CutPressPart3(ksEntity entitySketch)
       {
           var entityBaseExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
           var cutExtrusionDefinition = (ksBaseExtrusionDefinition)entityBaseExtrusion.GetDefinition();
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heigthOfShaft/5);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityBaseExtrusion.Create();
       }

       /// <summary>
       /// Вырез под третью часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void ShaftCutPress3()
       {

           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);


           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);

               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true;
                   planeOffsetDefinition.offset = _heigthOfShaft;
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();

                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   PressSecondShaft4(sketchDefinition, entitySketch2);
               }
           }
       }

       /// <summary>
       /// Четвертая часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void CutPressPart4(ksEntity entitySketch)
       {
           var entityBaseExtrusion = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_baseExtrusion);
           var cutExtrusionDefinition = (ksBaseExtrusionDefinition)entityBaseExtrusion.GetDefinition();
           cutExtrusionDefinition.directionType = (short)Direction_Type.dtNormal;
           cutExtrusionDefinition.SetSideParam(true, (short)End_Type.etBlind, _heigthOfShaft / 2);
           cutExtrusionDefinition.SetSketch(entitySketch);
           entityBaseExtrusion.Create();
       }

       /// <summary>
       /// Вырез под четвертую часть вала
       /// </summary>
       /// <param name="entitySketch"></param>
       protected void ShaftCutPress4()
       {
           var doc = (ksDocument3D)_kompas.ActiveDocument3D();
           _part = (ksPart)doc.GetPart((short)Part_Type.pTop_Part);
           if (_part != null)
           {
               var planeXOY = (ksEntity)_part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
               var entityOffsetPlane = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_planeOffset);
               var planeOffsetDefinition = (ksPlaneOffsetDefinition)entityOffsetPlane.GetDefinition();
               if (planeOffsetDefinition != null)
               {
                   planeOffsetDefinition.direction = true; 
                   planeOffsetDefinition.offset = _heigthOfShaft; 
                   planeOffsetDefinition.SetPlane(planeXOY);
                   entityOffsetPlane.Create();
                   var entitySketch2 = (ksEntity)_part.NewEntity((short)Obj3dType.o3d_sketch);
                   var sketchDefinition = (ksSketchDefinition)entitySketch2.GetDefinition();
                   sketchDefinition.SetPlane(entityOffsetPlane);
                   entitySketch2.Create();
                   PressSecondShaft5(sketchDefinition, entitySketch2);
               }
           }
       }

       #endregion    
    }
}
