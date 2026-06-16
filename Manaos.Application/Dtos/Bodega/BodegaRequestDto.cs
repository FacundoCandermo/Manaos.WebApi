using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Manaos.Application.Dtos.Bodega
{
    public class BodegaRequestDto
    {
        public int Id { get; set; }
        [StringLength(100)]
        [DefaultValue("Bodega Central")]
        public string Nombre { get; set; }
        [StringLength(200)]
        [DefaultValue("Av. Mitre 1200, Lobos")]
        public string? Direccion { get; set; }
    }
}