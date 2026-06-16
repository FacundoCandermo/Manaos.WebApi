using Manaos.Enums;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.SolicitudReposicion
{
    public class SolicitudReposicionRequestDto
    {
        public int Id { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha { get; set; }
        public EstadoSolicitudReposicion Estado { get; set; }
        [StringLength(500)]
        public string? Observaciones { get; set; }
    }
}
