using Microsoft.EntityFrameworkCore;
using PTEC.Core.Models;
using PTEC.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PTEC.Data.Repositories
{
    public class AfiliadoRepository : IAfiliadoRepository
    {
        PTecnicaContext _db;

        public AfiliadoRepository(PTecnicaContext db)
        {
            _db = db;
        }

        public async Task AddAfiliadoAsync(Afiliado afiliado)
        {
            await _db.AddAsync(afiliado);
        }

        public void EliminarAfiliado(Afiliado afiliado)
        {
            _db.RemoveRange(afiliado.Telefonos);
            _db.Afiliado.Remove(afiliado);
        }

        public async Task<Afiliado> GetAfiliadoByIdAsync(Guid id)
        {
            return await _db.Afiliado.Include(x => x.Telefonos).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Afiliado> GetAfiliadoByIdNumeroDocumentoAsync(string numeroDocumento)
        {
            return await _db.Afiliado.AsNoTracking().Include(x => x.Telefonos).SingleOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento);
        }

        public async Task<List<Afiliado>> GetListadoAfiliadosAsync(Expression<Func<Afiliado, bool>> where)
        {
            List<Afiliado> listado = await _db.Afiliado.Where(where).Include(x => x.Telefonos).ToListAsync();
            return listado;
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
