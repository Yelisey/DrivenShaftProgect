using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shaft
{
    /// <summary>
    /// Класс, содержащий данные, о спецификации
    /// </summary>
    public class DataOfSpecification
    {
        public struct InformationAboutSpecification
        {
            /// <summary>
            /// Параметры документа
            /// </summary>
            public string DocParam;

            /// <summary>
            /// Название документа
            /// </summary>
            public string DocName;

            /// <summary>
            /// Параметры детали
            /// </summary>
            public string DetParam;

            /// <summary>
            /// Название детали
            /// </summary>
            public string DetName;

            /// <summary>
            /// Инициалы разработчика
            /// </summary>
            public string DevelopName;

            /// <summary>
            /// Имя проверяющего
            /// </summary>
            public string MasterName;

            /// <summary>
            /// Дата создания
            /// </summary>
            public string DateOfCreate;

            /// <summary>
            /// Формат спецификации
            /// </summary>  
            public string DateOfControl;

            /// <summary>
            /// Конструктор
            /// </summary>
            /// <param name="kompas"></param>
            /// <param name="specData"></param>
            public InformationAboutSpecification(string docParam, string docName, string detParam, string detName,
            string developName, string masterName, string dateOfCreate, string dateOfControl)
            {
                this.DocParam = docParam;
                this.DocName = docName;
                this.DetParam = detParam;
                this.DetName = detName;
                this.DevelopName = developName;
                this.MasterName = masterName;
                this.DateOfCreate = dateOfCreate;
                this.DateOfControl = dateOfControl;
            }
        }
    }
}
