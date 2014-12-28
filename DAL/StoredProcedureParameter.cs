using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/**
 * Autor: Roger Quiros
 * Stored Procedure Parameter
 * Permite mantener de una forma concreta los nombres y valores para los parametros de los procedimientos almacenados
 */
namespace DAL
{
    public class SPP
    {
        /**
         * Propiedades
         */
        public String Name { get; set; }
        public Object Value { get; set; }

        /**
         * Constructor del Store Procedure Parameter
         */
        public SPP(String name, Object value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}
