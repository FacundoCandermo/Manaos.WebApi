using Manaos.Application;
using Manaos.Application.Dtos.Reposicion;
using Manaos.Entities;
using Manaos.Enums;

namespace Manaos.Services.Reposicion
{
    public interface IReposicionService
    {
        IList<FaltanteReposicionResponseDto>? ObtenerFaltantes();
    }

    public class ReposicionService : IReposicionService
    {
        private readonly IApplication<StockBodega> _stockBodega;
        private readonly IApplication<Bodega> _bodega;
        private readonly IApplication<SolicitudReposicion> _solicitudReposicion;
        private readonly IApplication<DetalleSolicitudReposicion> _detalleSolicitudReposicion;

        public ReposicionService(
            IApplication<StockBodega> stockBodega
            , IApplication<Bodega> bodega
            , IApplication<SolicitudReposicion> solicitudReposicion
            , IApplication<DetalleSolicitudReposicion> detalleSolicitudReposicion)
        {
            _stockBodega = stockBodega;
            _bodega = bodega;
            _solicitudReposicion = solicitudReposicion;
            _detalleSolicitudReposicion = detalleSolicitudReposicion;
        }

        public IList<FaltanteReposicionResponseDto>? ObtenerFaltantes()
        {
            var bodegaPrincipal = _bodega.GetAll().FirstOrDefault(b => b.EsPrincipal);
            if (bodegaPrincipal is null)
            {
                return null;
            }

            var idsSolicitudesActivas = _solicitudReposicion.GetAll()
                .Where(s => s.Estado == EstadoSolicitudReposicion.Pendiente || s.Estado == EstadoSolicitudReposicion.Aprobada)
                .Select(s => s.Id)
                .ToList();

            var detallesActivos = _detalleSolicitudReposicion.GetAll()
                .Where(d => idsSolicitudesActivas.Contains(d.IdSolicitudReposicion))
                .ToList();

            var faltantes = new List<FaltanteReposicionResponseDto>();
            foreach (var stock in _stockBodega.GetAll().Where(s => s.IdBodega == bodegaPrincipal.Id))
            {
                if (stock.Cantidad >= stock.StockMinimo)
                {
                    continue;
                }

                var cantidadPendiente = detallesActivos
                    .Where(d => d.IdProducto == stock.IdProducto)
                    .Sum(d => d.Cantidad);

                var cantidadSugerida = stock.StockMaximo - stock.Cantidad - cantidadPendiente;
                if (cantidadSugerida <= 0)
                {
                    continue;
                }

                faltantes.Add(new FaltanteReposicionResponseDto
                {
                    IdProducto = stock.IdProducto,
                    NombreProducto = stock.Producto.Nombre,
                    IdBodega = stock.IdBodega,
                    NombreBodega = bodegaPrincipal.Nombre,
                    Cantidad = stock.Cantidad,
                    StockMinimo = stock.StockMinimo,
                    StockMaximo = stock.StockMaximo,
                    CantidadPendiente = cantidadPendiente,
                    CantidadSugerida = cantidadSugerida
                });
            }

            return faltantes;
        }
    }
}
