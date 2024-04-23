using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("ALARMINFO")]
public partial class Alarminfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("STATUS")]
    public int? Status { get; set; }

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

    [Column("USERINFO_USERID")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UserinfoUserid { get; set; }

    [Column("VOCINFO_ID")]
    public int? VocinfoId { get; set; }

    [Column("SOCKETROOMINFO_ID")]
    public int? SocketroominfoId { get; set; }

    [ForeignKey("SocketroominfoId")]
    [InverseProperty("Alarminfos")]
    public virtual Socketroominfo? Socketroominfo { get; set; }

    [ForeignKey("UserinfoUserid")]
    [InverseProperty("Alarminfos")]
    public virtual Userinfo? UserinfoUser { get; set; }

    [ForeignKey("VocinfoId")]
    [InverseProperty("Alarminfos")]
    public virtual Vocinfo? Vocinfo { get; set; }
}
