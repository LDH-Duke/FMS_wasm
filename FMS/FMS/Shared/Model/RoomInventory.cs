using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("ROOM_INVENTORY")]
public partial class RoomInventory
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("ROM_MATERIAL_NUM")]
    public int RomMaterialNum { get; set; }

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

    [Column("ROOMINFO_ID")]
    public int? RoominfoId { get; set; }

    [Column("BUILDINGINFO_CODE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? BuildinginfoCode { get; set; }

    [ForeignKey("BuildinginfoCode")]
    [InverseProperty("RoomInventories")]
    public virtual Buildinginfo? BuildinginfoCodeNavigation { get; set; }

    [ForeignKey("RoominfoId")]
    [InverseProperty("RoomInventories")]
    public virtual Roominfo? Roominfo { get; set; }
}
