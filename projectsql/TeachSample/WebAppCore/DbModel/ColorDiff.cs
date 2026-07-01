using System;
using System.Collections.Generic;

namespace WebAppCore.DbModel;

public partial class ColorDiff
{
    public uint Id { get; set; }

    public string? Name { get; set; }

    public double? Brightness { get; set; }

    public double? RedGreen { get; set; }

    public double? YellowBlue { get; set; }

    public string? Image { get; set; }
}
