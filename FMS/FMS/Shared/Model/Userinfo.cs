using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("USERINFO")]
public partial class Userinfo
{
    [Column("ID")]
    public int Id { get; set; }

    [Key]
    [Column("USERID")]
    [StringLength(15)]
    [Unicode(false)]
    public string Userid { get; set; } = null!;

    [Column("PASSWORD")]
    [StringLength(30)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    [Column("ADMIN_YN")]
    public bool? AdminYn { get; set; }

    [Column("ALARM_YN")]
    public bool? AlarmYn { get; set; }

    [Column("PERM_PLACE")]
    public int? PermPlace { get; set; }

    [Column("PERM_DEVICE")]
    public int? PermDevice { get; set; }

    [Column("PERM_MATERIAL")]
    public int? PermMaterial { get; set; }

    [Column("PERM_ENERGY")]
    public int? PermEnergy { get; set; }

    [Column("PERM_ADM")]
    public int? PermAdm { get; set; }

    [Column("PERM_COMP")]
    public int? PermComp { get; set; }

    [Column("PERM_CONST")]
    public int? PermConst { get; set; }

    [Column("PERM_CLAIM")]
    public int? PermClaim { get; set; }

    [Column("PERM_SYS")]
    public int? PermSys { get; set; }

    [Column("PERM_IMPLOYEE")]
    public int? PermImployee { get; set; }

    [Column("PERM_LAWCK")]
    public int? PermLawck { get; set; }

    [Column("PERM_LAWEDU")]
    public int? PermLawedu { get; set; }

    [Column("STATUS")]
    public bool? Status { get; set; }

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

    [Column("PLACEINFO_CODE")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PlaceinfoCode { get; set; }

    [InverseProperty("UserinfoUser")]
    public virtual ICollection<Alarminfo> Alarminfos { get; set; } = new List<Alarminfo>();

    [ForeignKey("PlaceinfoCode")]
    [InverseProperty("Userinfos")]
    public virtual Placeinfo? PlaceinfoCodeNavigation { get; set; }

    [InverseProperty("UserinfoUser")]
    public virtual ICollection<VocinfoComment> VocinfoComments { get; set; } = new List<VocinfoComment>();
}
