using PTEC.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PTEC.Core.Services
{
    public interface IAfiliadoService
    {
        /// <summary>
        /// Extrae una lista de afiliados segun los parametros estipulados
        /// </summary>
        /// <param name="numeroDocumento"></param>
        /// <returns></returns>
        Task<List<Afiliado>> GetListaAfiliadosAsync(string numeroDocumento);

        /// <summary>
        /// Agrega un nuevo registro a la base de datos
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        Task<Afiliado> AgregarAfiliadoAsync(Afiliado afiliado);

        /// <summary>
        /// Edita un registro existente de la base de datos
        /// </summary>
        /// <param name="afiliado"></param>
        /// <returns></returns>
        Task EditarAfiliadoAsync(Afiliado afiliado);

        /// <summary>
        /// Elimina un afiliado de la base de datos
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task EliminarAfiliadoAsync(Guid id);
    }
}
