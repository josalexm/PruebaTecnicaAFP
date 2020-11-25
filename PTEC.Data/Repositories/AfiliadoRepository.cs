using Microsoft.EntityFrameworkCore;
using PTEC.Core.Models;
using PTEC.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Afiliado> GetAfiliadoByIdAsync(Guid id)
        {
            return await _db.Afiliado.Include(x => x.Telefonos).SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Afiliado> GetAfiliadoByIdNumeroDocumento(string numeroDocumento)
        {
            return await _db.Afiliado.AsNoTracking().Include(x => x.Telefonos).SingleOrDefaultAsync(x => x.NumeroDocumento == numeroDocumento);
        }

        public async Task SaveChangesAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
