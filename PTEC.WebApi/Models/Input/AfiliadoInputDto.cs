using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PTEC.WebApi.Models.Input
{
    public class AfiliadoInputDto
    {
        /// <summary>
        /// Nombre del afiliado
        /// </summary>
        [Required(ErrorMessage = "El nombre es requerido")]
        [MaxLength(200, ErrorMessage = "El nombre no puede exceder de 200 caracteres")]
        public string Nombre { get; set; }

        /// <summary>
        /// Apellido del afiliado
        /// </summary>
        [Required(ErrorMessage = "El apellido es requerido")]
        [MaxLength(200, ErrorMessage = "El apellido no puede exceder de 200 caracteres")]
        public string Apellido { get; set; }

        /// <summary>
        /// Numero de identificadion del afiliado
        /// </summary>
        [Required(ErrorMessage = "El numero de documento es requerido")]
        [MaxLength(200, ErrorMessage = "El numero de documento no puede exceder de 50 caracteres")]
        public string NumeroDocumento { get; set; }

        /// <summary>
        /// Lista de telefonos
        /// </summary>
        public List<string> Telefonos { get; set; }
    }
}
