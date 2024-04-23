using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("FACILITYINFO")]
public partial class Facilityinfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("CATEGORY")]
    [StringLength(10)]
    [Unicode(false)]
    public string Category { get; set; } = null!;

    [Column("TYPE")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Type { get; set; }

    [Column("STANDARD_CAPACITY")]
    public double? StandardCapacity { get; set; }

    [Column("STANDARD_UNIT")]
    [StringLength(10)]
    [Unicode(false)]
    public string? StandardUnit { get; set; }

    [Column("FACILITY_CREATEDT", TypeName = "datetime")]
    public DateTime? FacilityCreatedt { get; set; }

    [Column("LIFESPAN")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Lifespan { get; set; }

    [Column("FACILITY_UPDATEDT", TypeName = "datetime")]
    public DateTime? FacilityUpdatedt { get; set; }

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

    [Column("ROOMINFO_ID")]
    public int? RoominfoId { get; set; }

    [ForeignKey("RoominfoId")]
    [InverseProperty("Facilityinfos")]
    public virtual Roominfo? Roominfo { get; set; }

    [InverseProperty("Facilityinfo")]
    public virtual ICollection<Subitem> Subitems { get; set; } = new List<Subitem>();
}
