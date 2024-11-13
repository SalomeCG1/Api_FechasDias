using DiasFestivos.Core.Interfaces.Repositorios;
using DiasFestivos.Dominio.Entidades;
using DiasFestivos.Infraestructura.Persistencia.Context;
using Microsoft.EntityFrameworkCore;

namespace DiasFestivos.Infraestructura.Repositorio
{
    public class TipoRepositorio : ITipoRepositorio
    {
        private readonly DiasFestivoContext context;
        public TipoRepositorio(DiasFestivoContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TBTipo>> ObtenerTodos()
        {
            return await context.tipos.ToArrayAsync();
        }
    }
}
