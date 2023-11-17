﻿using System;
using System.Collections.Generic;

namespace BD_Existente.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Cedula { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public byte[]? Direccion { get; set; }

    public int? Edad { get; set; }

    public virtual ICollection<Factura> Facturas { get; } = new List<Factura>();
}
