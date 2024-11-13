using DiasFestivos.Dominio.Entidades;

namespace DiasFestivos.Core.Interfaces.Servicios
{
    public interface ITipoServicio
    {
        Task<IEnumerable<TBTipo>> ObtenerTodos();
    }
}
