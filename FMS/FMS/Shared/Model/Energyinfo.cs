using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("ENERGYINFO")]
public partial class Energyinfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CATEGORY")]
    [StringLength(10)]
    [Unicode(false)]
    public string Category { get; set; } = null!;

    [Column("TYPE")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Type { get; set; }

    [Column("METER_GB")]
    [StringLength(10)]
    [Unicode(false)]
    public string? MeterGb { get; set; }

    [Column("METER_DT", TypeName = "datetime")]
    public DateTime? MeterDt { get; set; }

    [Column("METER_VALUE")]
    public double? MeterValue { get; set; }

    [Column("DEL_YN")]
    public bool? DelYn { get; set; }

    [Column("CREATE_UESRID")]
    [StringLength(15)]
    [Unicode(false)]
    public string? CreateUesrid { get; set; }

    [Column("UPDATE_ID")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UpdateId { get; set; }

    [Column("CREATE_DT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; }

    [Column("UPDATE_DT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [Column("DELETE_DT", TypeName = "datetime")]
    public DateTime? DeleteDt { get; set; }
}
