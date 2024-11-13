using DiasFestivos.Dominio.Entidades;

namespace DiasFestivos.Core.Interfaces.Repositorios
{
    public interface ITipoRepositorio
    {
        Task<IEnumerable<TBTipo>> ObtenerTodos();
    }
}
