using DiasFestivos.Aplicacion;
using DiasFestivos.Core.Interfaces.Repositorios;
using DiasFestivos.Core.Interfaces.Servicios;
using DiasFestivos.Infraestructura.Persistencia.Context;
using DiasFestivos.Infraestructura.Repositorio;
using Microsoft.EntityFrameworkCore;

namespace DiasFestivos.InyeccionDependencias
{
    public static class InyeccionDependencias
    {
        public static IServiceCollection AgregarDependencias(this IServiceCollection servicios, IConfiguration configuration)
        {
            servicios.AddDbContext<DiasFestivoContext>(opciones =>
            {
                opciones.UseSqlServer(configuration.GetConnectionString("DBConexion"));
            });

            servicios.AddTransient<IFestivoRepositorio, FestivoRepositorio>();
            servicios.AddTransient<ITipoRepositorio, TipoRepositorio>();

            servicios.AddTransient<IFestivoServicio, FestivoServicio>();
            servicios.AddTransient<ITipoServicio, TipoServicio>();
            return servicios;
        }
    }
}
