using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

[Table("VocInfo_Comment")]
public partial class VocInfoComment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Content { get; set; }

    public int? Status { get; set; }

    [Column("CreateDT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; }

    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [Column("VocInfo_ID")]
    public int? VocInfoId { get; set; }

    [Column("UserInfo_UserId")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UserInfoUserId { get; set; }

    [ForeignKey("UserInfoUserId")]
    [InverseProperty("VocInfoComments")]
    public virtual UserInfo? UserInfoUser { get; set; }

    [ForeignKey("VocInfoId")]
    [InverseProperty("VocInfoComments")]
    public virtual VocInfo? VocInfo { get; set; }
}
