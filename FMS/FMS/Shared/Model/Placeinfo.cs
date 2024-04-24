using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("PLACEINFO")]
public partial class Placeinfo
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("CODE")]
    [StringLength(25)]
    [Unicode(false)]
    public string Code { get; set; } = null!;

    [Column("CONTRACTNUM")]
    [StringLength(45)]
    [Unicode(false)]
    public string Contractnum { get; set; } = null!;

    [Column("NAME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("NOTE")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Note { get; set; }

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

    [InverseProperty("PlaceinfoCodeNavigation")]
    public virtual ICollection<Buildinginfo> Buildinginfos { get; set; } = new List<Buildinginfo>();

    [InverseProperty("PlaceinfoCodeNavigation")]
    public virtual ICollection<Userinfo> Userinfos { get; set; } = new List<Userinfo>();
}
