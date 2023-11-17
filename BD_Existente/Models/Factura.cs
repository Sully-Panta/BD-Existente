using System;
using System.Collections.Generic;

namespace BD_Existente.Models;

public partial class Factura
{
    public int Id { get; set; }

    public DateTime? Fecha { get; set; }

    public string? NombreEmpresa { get; set; }

    public int? Cliente { get; set; }

    public double? Total { get; set; }

    public virtual Cliente? ClienteNavigation { get; set; }

    public virtual ICollection<DetalleFactura> DetalleFacturas { get; } = new List<DetalleFactura>();
}
