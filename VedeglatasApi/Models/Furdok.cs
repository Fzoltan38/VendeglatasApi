using System;
using System.Collections.Generic;

namespace VedeglatasApi.Models;

public partial class Furdok
{
    public int Id { get; set; }

    public string? Nev { get; set; }

    public string? Cim { get; set; }

    public string? Irnyitoszam { get; set; }

    public DateTime? Regtime { get; set; } = DateTime.Now;

    public int? Varosid { get; set; }

    public virtual Varosok? Varos { get; set; }
}
