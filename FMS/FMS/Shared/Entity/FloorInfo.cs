using System;
using System.Collections.Generic;

namespace FMS.Shared.Entity;

public class FloorInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateDt { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? PlantInfoCode { get; set; }

    public virtual ICollection<LocationInfo> LocationInfos { get; set; } = new List<LocationInfo>();

    public virtual PlantInfo? PlantInfoCodeNavigation { get; set; }
}
