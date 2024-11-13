using DiasFestivos.Core.Interfaces.Repositorios;
using DiasFestivos.Core.Interfaces.Servicios;
using DiasFestivos.Dominio.Entidades;
using DTOs;

namespace DiasFestivos.Aplicacion
{
    public class FestivoServicio : IFestivoServicio
    {
        private readonly IFestivoRepositorio repositorio;

        public FestivoServicio(IFestivoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<TBFestivos> Obtener(int Id)
        {
            return await repositorio.Obtener(Id);
        }

        public async Task<IEnumerable<DTOsFestivos>> ObtenerPorYear(int Year)
        {   
            return await repositorio.ObtenerPorYear(Year);
        }

        public Task<IEnumerable<TBFestivos>> ObtenerTodos()
        {
            return repositorio.ObtenerTodos();
        }
    }
}
