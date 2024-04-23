using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("FLOORINFO")]
public partial class Floorinfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    [StringLength(10)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

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

    [ForeignKey("BuildinginfoCode")]
    [InverseProperty("Floorinfos")]
    public virtual Buildinginfo? BuildinginfoCodeNavigation { get; set; }

    [InverseProperty("Floorinfo")]
    public virtual ICollection<Roominfo> Roominfos { get; set; } = new List<Roominfo>();
}
