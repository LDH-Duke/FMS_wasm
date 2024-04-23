using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("SUBITEM")]
public partial class Subitem
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("COLUMNNAME")]
    [StringLength(25)]
    [Unicode(false)]
    public string Columnname { get; set; } = null!;

    [Column("UNIT")]
    [StringLength(10)]
    [Unicode(false)]
    public string Unit { get; set; } = null!;

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

    [Column("BUILDINGINFO_CODE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? BuildinginfoCode { get; set; }

    [Column("FACILITYINFO_ID")]
    public int? FacilityinfoId { get; set; }

    [ForeignKey("BuildinginfoCode")]
    [InverseProperty("Subitems")]
    public virtual Buildinginfo? BuildinginfoCodeNavigation { get; set; }

    [ForeignKey("FacilityinfoId")]
    [InverseProperty("Subitems")]
    public virtual Facilityinfo? Facilityinfo { get; set; }
}
