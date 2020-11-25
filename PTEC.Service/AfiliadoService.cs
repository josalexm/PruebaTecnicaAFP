using PTEC.Core.Models;
using PTEC.Core.Repositories;
using PTEC.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTEC.Service
{
    public class AfiliadoService : IAfiliadoService
    {
        private readonly IAfiliadoRepository _afiliadoRepository;

        public AfiliadoService(IAfiliadoRepository afiliadoRepository)
        {
            _afiliadoRepository = afiliadoRepository;
        }

        public async Task<Afiliado> AgregarAfiliadoAsync(Afiliado afiliado)
        {
            Afiliado afiliadoExistente = await _afiliadoRepository.GetAfiliadoByIdNumeroDocumentoAsync(afiliado.NumeroDocumento);
            if (afiliadoExistente != null)
                throw new ArgumentException("El número de documento ingresado ya existe");

            await _afiliadoRepository.AddAfiliadoAsync(afiliado);
            await _afiliadoRepository.SaveChangesAsync();

            return afiliado;
        }

        public async Task EditarAfiliadoAsync(Afiliado afiliado)
        {
            Afiliado afiliadoBd = await _afiliadoRepository.GetAfiliadoByIdAsync(afiliado.Id);
            afiliadoBd.Nombre = afiliado.Nombre;
            afiliadoBd.Apellido = afiliado.Apellido;
            afiliado.Telefonos = afiliado.Telefonos;

            await _afiliadoRepository.SaveChangesAsync();
        }

        public async Task EliminarAfiliadoAsync(Guid id)
        {
            Afiliado afiliadoBd = await _afiliadoRepository.GetAfiliadoByIdAsync(id);
            _afiliadoRepository.EliminarAfiliado(afiliadoBd);
            await _afiliadoRepository.SaveChangesAsync();
        }

        public async Task<Afiliado> GetAfiliadoByIdAsyc(Guid id)
        {
            return await _afiliadoRepository.GetAfiliadoByIdAsync(id);
        }

        public async Task<List<Afiliado>> GetListaAfiliadosAsync(string numeroDocumento)
        {
            bool sinNumeroDoc = string.IsNullOrEmpty(numeroDocumento);

            Expression<Func<Afiliado, bool>> where = x => (sinNumeroDoc || x.NumeroDocumento.Contains(numeroDocumento));
            List<Afiliado> listado = await _afiliadoRepository.GetListadoAfiliadosAsync(where);
            return listado;
        }
    }
}
