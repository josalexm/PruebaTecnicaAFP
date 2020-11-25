using System;
using System.Collections.Generic;
using System.Text;

namespace PTEC.Core.Models
{
    public class Afiliado
    {
        /// <summary>
        /// Identificador del afiliado
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nombre del afiliado
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del afiliado
        /// </summary>
        public string Apellido { get; set; }

        /// <summary>
        /// Numero de identificadion del afiliado
        /// </summary>
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Fecha de ingreso del registro
        /// </summary>
        public DateTimeOffset FechaIngreso { get; set; }

        /// <summary>
        /// Lista de telefonos pertenecientes al afiliado
        /// </summary>
        public List<Telefono> Telefonos { get; set; }
    }
}
