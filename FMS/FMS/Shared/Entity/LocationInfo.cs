using System;
using System.Collections.Generic;

namespace FMS.Shared.Entity;

public partial class LocationInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateDt { get; set; }

    public DateTime? UpdateDt { get; set; }

    public int? FloorInfoId { get; set; }

    public virtual FloorInfo? FloorInfo { get; set; }
}
