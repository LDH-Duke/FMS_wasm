using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("MATERIALINFO")]
public partial class Materialinfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CATEGORY")]
    [StringLength(10)]
    [Unicode(false)]
    public string Category { get; set; } = null!;

    [Column("TYPE")]
    [StringLength(30)]
    [Unicode(false)]
    public string Type { get; set; } = null!;

    [Column("NAME")]
    [StringLength(100)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("UNIT")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Unit { get; set; }

    [Column("STANDARD")]
    [StringLength(10)]
    [Unicode(false)]
    public string? Standard { get; set; }

    [Column("MANUFACTURING_COMP")]
    [StringLength(25)]
    [Unicode(false)]
    public string? ManufacturingComp { get; set; }

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

    [InverseProperty("Meterialinfo")]
    public virtual ICollection<MaterialinfoInventory> MaterialinfoInventories { get; set; } = new List<MaterialinfoInventory>();

    [ForeignKey("RoominfoId")]
    [InverseProperty("Materialinfos")]
    public virtual Roominfo? Roominfo { get; set; }
}
