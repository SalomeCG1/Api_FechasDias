using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiasFestivos.Dominio.Entidades
{
    [Table("Tipo")]
    public class TBTipo
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Tipo")]
        public string Tipo { get; set; }
    }
}
