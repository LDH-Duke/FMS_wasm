using System;
using System.Collections.Generic;

namespace FMS.Shared.Entity;

public partial class PlantInfo
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Address { get; set; }

    public double? GrossFloorArea { get; set; }

    public double? LandArea { get; set; }

    public double? BuildingArea { get; set; }

    public DateTime? CreateDt { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? PlaceInfoCode { get; set; }

    public virtual PlaceInfo CodeNavigation { get; set; } = null!;

    public virtual ICollection<FloorInfo> FloorInfos { get; set; } = new List<FloorInfo>();

    public virtual PlaceInfo? PlaceInfoCodeNavigation { get; set; }
}
