using System;
using System.Collections.Generic;

namespace FMS.Shared.Entity;

public class DeviceInfo
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateTime? CreateDt { get; set; }

    public DateTime? UpdateDt { get; set; }

    public int? LocationInfoId { get; set; }

    public virtual LocationInfo? LocationInfo { get; set; }
}
