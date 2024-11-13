using DiasFestivos.Core.Interfaces.Repositorios;
using DiasFestivos.Dominio.Entidades;
using DiasFestivos.Infraestructura.Persistencia.Context;
using DTOs;
using Microsoft.EntityFrameworkCore;
using System;

namespace DiasFestivos.Infraestructura.Repositorio
{
    public class FestivoRepositorio : IFestivoRepositorio
    {
        private readonly DiasFestivoContext context;
        public FestivoRepositorio(DiasFestivoContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<TBFestivos>> ObtenerTodos()
        {
            return await context.festivos.ToArrayAsync();
        }

        public async Task<TBFestivos> Obtener(int Id)
        {
            return await context.festivos.FindAsync(Id);
        }

        public async Task<IEnumerable<DTOsFestivos>> ObtenerPorYear(int Year)
        {
            var festivos = await context.festivos.Where(f => f.IdTipo == 1 || f.IdTipo == 2 || f.IdTipo == 3 || f.IdTipo == 4)
                           .OrderBy(f => f.Id)
                           .ToListAsync();

            DateTime domingoDePascua = ObtenerDomingoDePascua(Year);

            var dtosFestivos = festivos.Select(f => new DTOsFestivos
            {
                Nombre = f.Nombre,
                Fecha = f.IdTipo switch
                {
                    1 => $"{Year}/{f.Mes}/{f.Dia}", 
                    2 => SiguienteLunes(new DateTime(Year, f.Mes, f.Dia)).ToString("yyyy/MM/dd"),
                    3 => domingoDePascua.AddDays(f.DiasPascua).ToString("yyyy/MM/dd"),
                    4 => SiguienteLunes(domingoDePascua.AddDays(f.DiasPascua)).ToString("yyyy/MM/dd"),
                    _ => string.Empty
                }
            }).ToList();

            return dtosFestivos;
        }
        

        private DateTime ObtenerDomingoDePascua(int year)
        {
            int a = year % 19;
            int b = year % 4;
            int c = year % 7;
            int d = (19 * a + 24) % 30;
            int e = (2 * b + 4 * c + 6 * d + 5) % 7;

            int dia = d + e + 22; 
            int mes = 3;

            if (dia > 31)
            {
                dia -= 31; 
                mes = 4;
            }

            return new DateTime(year, mes, dia);
        }

        public static DateTime SiguienteLunes(DateTime Fecha)
        {
            if (Fecha.DayOfWeek == DayOfWeek.Monday) { return Fecha; }

            int diasParaAgregar = (int)DayOfWeek.Monday - (int)Fecha.DayOfWeek;
            if (diasParaAgregar <= 0) { diasParaAgregar += 7; }

            return Fecha.AddDays(diasParaAgregar);
        }
    }
}


