using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kompas6API5;
using Kompas6API3D5COM;
using Kompas6API2D5COM;

namespace Shaft
{
    /// <summary>
    /// Класс построитель спецификации
    /// </summary>
    class SpecificationCreator : SpecificationGeneral
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="kompas"></param>
        /// <param name="data"></param>
         public SpecificationCreator(KompasObject kompas, DataOfSpecification.InformationAboutSpecification data):
            base(kompas, data)
       {
           
       }

        /// <summary>
        /// Метод создания спецификации
        /// </summary>
        /// <param name="_kompas"></param>
        public void GetSpecification(KompasObject _kompas)
        {
            base.CreateSpecification();
            base.CreateStamp();
        }
    }
}
