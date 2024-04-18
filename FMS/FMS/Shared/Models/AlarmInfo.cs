using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

[Table("AlarmInfo")]
public partial class AlarmInfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    public int? Status { get; set; }

    [Column("CreateDT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; }

    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [Column("UserInfo_UserId")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UserInfoUserId { get; set; }

    [Column("VocInfo_ID")]
    public int? VocInfoId { get; set; }

    [ForeignKey("UserInfoUserId")]
    [InverseProperty("AlarmInfos")]
    public virtual UserInfo? UserInfoUser { get; set; }

    [ForeignKey("VocInfoId")]
    [InverseProperty("AlarmInfos")]
    public virtual VocInfo? VocInfo { get; set; }
}
