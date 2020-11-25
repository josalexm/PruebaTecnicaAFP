using PTEC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTEC.Core.Repositories
{
    public interface IAfiliadoRepository
    {
        /// <summary>
        /// Extrae la informacion completa de un afiliado mediante su identificador
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Afiliado> GetAfiliadoByIdAsync(Guid id);

        /// <summary>
        /// Extrae la informacion completa de un afiliado mediante su numero de documento
        /// </summary>
        /// <param name="numeroDocumento"></param>
        /// <returns></returns>
        Task<Afiliado> GetAfiliadoByIdNumeroDocumento(string numeroDocumento);

        /// <summary>
        /// Agrega un nuevo registro a la base de datos
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        Task AddAfiliadoAsync(Afiliado afiliado);

        /// <summary>
        /// Hace efectivos los cambios realizados en la base de datos
        /// </summary>
        /// <returns></returns>
        Task SaveChangesAsync();
    }
}
