using DiasFestivos.Core.Interfaces.Repositorios;
using DiasFestivos.Core.Interfaces.Servicios;
using DiasFestivos.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiasFestivos.Aplicacion
{
    public class TipoServicio : ITipoServicio
    {
        private readonly ITipoRepositorio repositorio;

        public TipoServicio(ITipoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public Task<IEnumerable<TBTipo>> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }
    }
}
