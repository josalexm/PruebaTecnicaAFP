using System;
using System.Collections.Generic;
using System.Text;

namespace PTEC.Core.Models
{
    public class Telefono
    {
        /// <summary>
        /// Identificador del telefono
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Numero de telefono
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Identificado del afiliado al que pertenece el telefono
        /// </summary>
        public Guid IdAfiliado { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Afiliado Afiliado { get; set; }
    }
}
