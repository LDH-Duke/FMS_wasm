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

    [Column("CREATE_USER")]
    [StringLength(15)]
    [Unicode(false)]
    public string? CreateUser { get; set; }

    [Column("UPDATE_USER")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UpdateUser { get; set; }

    [Column("DELETE_USER")]
    [StringLength(15)]
    [Unicode(false)]
    public string? DeleteUser { get; set; }

    [Column("CREATE_DT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; }

    [Column("UPDATE_DT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [Column("DELETE_DT", TypeName = "datetime")]
    public DateTime? DeleteDt { get; set; }

    [InverseProperty("Meterialinfo")]
    public virtual ICollection<TotalInventory> TotalInventories { get; set; } = new List<TotalInventory>();
}
