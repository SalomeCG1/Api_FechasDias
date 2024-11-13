using DiasFestivos.Dominio.Entidades;
using DTOs;

namespace DiasFestivos.Core.Interfaces.Servicios
{
    public interface IFestivoServicio
    {
        Task<IEnumerable<TBFestivos>> ObtenerTodos();
        Task<TBFestivos> Obtener(int Id);
        Task<IEnumerable<DTOsFestivos>> ObtenerPorYear(int Year);
    }
}
