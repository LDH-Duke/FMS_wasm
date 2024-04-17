using System;
using System.Collections.Generic;

namespace FMS.Shared.Entity;

public partial class PlaceInfo
{
    public int Id { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Note { get; set; }

    public DateTime? CreateDt { get; set; }

    public DateTime? UpdateDt { get; set; }

    public virtual PlantInfo? PlantInfoCodeNavigation { get; set; }

    public virtual ICollection<PlantInfo> PlantInfoPlaceInfoCodeNavigations { get; set; } = new List<PlantInfo>();
}
