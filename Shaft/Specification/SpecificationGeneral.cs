using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kompas6API5;
using Kompas6API3D5COM;
using Kompas6Constants3D;
using Kompas6Constants;
using Kompas6API2D5COM;
using KompasAPI7;
using System.Windows.Forms;

namespace Shaft
{
    /// <summary>
    /// Класс, включающий методы создания штампа и спецификации в целом
    /// </summary>
    class SpecificationGeneral
    {
        #region Variables
        /// <summary>
        /// Объект документа Компас 3D
        /// </summary>
        protected ksDocument3D _doc3D;
        
        /// <summary>
        /// Объект Компас 3D
        /// </summary>
        protected KompasObject _kompas;

        /// <summary>
        /// Объект документа спецификации Компас 3D
        /// </summary>
        ksSpcDocument _document;

        /// <summary>
        /// Объект параметров документа Компас 3D
        /// </summary>
        ksDocumentParam _documParam;

        /// <summary>
        /// Параметры документа
        /// </summary>
        protected string _docParam;
        
        /// <summary>
        /// Название документа
        /// </summary>
        protected string _docName;

        /// <summary>
        /// Параметры детали
        /// </summary>
        protected string _detParam;

        /// <summary>
        /// Название детали
        /// </summary>
        protected string _detName;

        /// <summary>
        /// Инициалы разработчика
        /// </summary>
        protected string _developName;

        /// <summary>
        /// Имя проверяющего
        /// </summary>
        protected string _masterName;

        /// <summary>
        /// Дата создания
        /// </summary>
        protected string _dateOfCreate;

        /// <summary>
        /// Дата проверки
        /// </summary>
        protected string _dateOfControl;
       
        /// <summary>
        /// Формат спецификации
        /// </summary>    
        const int SpcClmFormat = 1;
        const int SpcClmMark = 4;
        const int SpcClmName = 5;
        const int SpcClmCount = 6;
        #endregion

        #region Constructor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="kompas"></param>
        /// <param name="specData"></param>
        public SpecificationGeneral(KompasObject kompas, DataOfSpecification.InformationAboutSpecification specData)
        {
            this._docParam = specData.DocParam;
            this._docName = specData.DocName;
            this._detParam = specData.DetParam;
            this._detName = specData.DetName;
            this._developName = specData.DevelopName;
            this._masterName = specData.MasterName;
            this._dateOfCreate = specData.DateOfCreate ;
            this._dateOfControl = specData.DateOfControl;
            this._kompas = kompas; 
        }
        #endregion

        #region Methods
        /// <summary>
        /// Создание спецификации
        /// </summary>
         public void CreateSpecification()
        {
            _doc3D = (ksDocument3D)_kompas.Document3D();
            _doc3D = (ksDocument3D)_kompas.ActiveDocument3D();
            _documParam = (ksDocumentParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
            _documParam.Init();
            _documParam.type = 4;
            _documParam.regime = 0;
            var sheet = (ksSheetPar)_documParam.GetLayoutParam();
            sheet.Init();
            var str = _kompas.ksSystemPath(0) + "/graphic.lyt";
            sheet.layoutName = str;
            _document = (ksSpcDocument)_kompas.SpcDocument();
            _document.ksCreateDocument(_docParam);
            _kompas.Visible = true;
        }

        /// <summary>
        /// Создание и заполнение надписей на спецификации
        /// </summary>
        public void CreateStamp()
        {
            try
            {
                var docParam = (ksDocumentParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
                docParam.Init();
                docParam.type = 4; // тип документа. 4 - деталь
                docParam.regime = 0; //режим редактирования 
                var sheetPar = (ksSheetPar)(docParam.GetLayoutParam()); // стандартный вид оформления
                sheetPar.Init();
                string str = _kompas.ksSystemPath(0) + "/GRAPHIC.LYT";
                sheetPar.layoutName = str;
                var spcDocument = (ksSpcDocument)(_kompas.SpcDocument());
                spcDocument.ksCreateDocument(docParam);
                var spec = (ksSpecification)spcDocument.GetSpecification();
                spec.ksSpcObjectCreate(str, 1, 5, 0, 0, 0);
                spec.ksSetSpcObjectColumnText(SpcClmName, 1, 0, _docParam);
                spec.ksSetSpcObjectColumnText(SpcClmMark, 1, 0, _docName);
                spec.ksSetSpcObjectColumnText(SpcClmFormat, 1, 0, "A4");
                spec.ksSetSpcObjectColumnText(SpcClmCount, 1, 0, "1");
                spec.ksSpcCount(0, "1");
                spec.ksSpcObjectEnd();
                spec.ksSpcObjectCreate(str, 1, 20, 0, 0, 1);
                spec.ksSetSpcObjectColumnText(SpcClmName, 1, 0, _detParam);
                spec.ksSetSpcObjectColumnText(SpcClmMark, 1, 0, _detName);
                spec.ksSetSpcObjectColumnText(SpcClmFormat, 1, 0, "A4");
                spec.ksSetSpcObjectColumnText(SpcClmCount, 1, 0, "1");
                spec.ksSpcCount(0, "1");
                spec.ksSpcObjectEnd();
                _kompas.Visible = true;

                var stamp = (ksStamp)spcDocument.GetStamp();
                ksTextItemParam textItemParam = (ksTextItemParam)_kompas.GetParamStruct((short)StructType2DEnum.ko_TextItemParam);
                stamp.ksOpenStamp();
                stamp.ksColumnNumber(1);
                textItemParam.s = "Чертеж";
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(2);
                textItemParam.s = "Ведомый Вал";
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(3);
                textItemParam.s = "Металл";
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(7);
                textItemParam.s = "1";
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(110);
                textItemParam.s = _developName;
                stamp.ksSetTextLineAlign(0);
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(111);
                stamp.ksSetTextLineAlign(0);
                textItemParam.s = _masterName;
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(130);
                textItemParam.s = _dateOfCreate;
                stamp.ksTextLine(textItemParam);
                stamp.ksColumnNumber(131);
                textItemParam.s = _dateOfControl;
                stamp.ksTextLine(textItemParam);
                stamp.ksCloseStamp();
                _kompas.Visible = true;
            }

            catch
            {
                MessageBox.Show("Ошибка в спецификации", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}

