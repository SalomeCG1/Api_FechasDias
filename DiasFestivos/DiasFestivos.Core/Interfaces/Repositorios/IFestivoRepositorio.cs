using DiasFestivos.Dominio.Entidades;
using DTOs;

namespace DiasFestivos.Core.Interfaces.Repositorios
{
    public interface IFestivoRepositorio
    {
        Task<IEnumerable<TBFestivos>> ObtenerTodos();
        Task<TBFestivos> Obtener(int Id);
        Task<IEnumerable<DTOsFestivos>> ObtenerPorYear(int Year);
    }
}
