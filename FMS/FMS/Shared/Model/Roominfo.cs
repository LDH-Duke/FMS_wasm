using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("ROOMINFO")]
public partial class Roominfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("NAME")]
    [StringLength(35)]
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

    [Column("FLOORINFO_ID")]
    public int? FloorinfoId { get; set; }

    [InverseProperty("Roominfo")]
    public virtual ICollection<Facilityinfo> Facilityinfos { get; set; } = new List<Facilityinfo>();

    [ForeignKey("FloorinfoId")]
    [InverseProperty("Roominfos")]
    public virtual Floorinfo? Floorinfo { get; set; }

    [InverseProperty("Roominfo")]
    public virtual ICollection<Materialinfo> Materialinfos { get; set; } = new List<Materialinfo>();
}
