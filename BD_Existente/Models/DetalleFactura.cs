using System;
using System.Collections.Generic;

namespace BD_Existente.Models;

public partial class DetalleFactura
{
    public int Id { get; set; }

    public string? NombreArticulo { get; set; }

    public int? Cantidad { get; set; }

    public double? PrecioUnitario { get; set; }

    public double? PrecioTotal { get; set; }

    public int? Factura { get; set; }

    public virtual Factura? FacturaNavigation { get; set; }
}
