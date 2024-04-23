using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("MATERIALINFO_INVENTORY")]
public partial class MaterialinfoInventory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("INCOMING_NUM")]
    public int IncomingNum { get; set; }

    [Column("OUTGOING")]
    public int Outgoing { get; set; }

    [Column("PRICE")]
    public int Price { get; set; }

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

    [Column("METERIALINFO_ID")]
    public int? MeterialinfoId { get; set; }

    [ForeignKey("MeterialinfoId")]
    [InverseProperty("MaterialinfoInventories")]
    public virtual Materialinfo? Meterialinfo { get; set; }
}
