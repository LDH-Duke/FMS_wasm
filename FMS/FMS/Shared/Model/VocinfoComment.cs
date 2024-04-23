using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("VOCINFO_COMMENT")]
public partial class VocinfoComment
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("CONTENT")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Content { get; set; }

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

    [Column("VOCINFO_ID")]
    public int? VocinfoId { get; set; }

    [Column("USERINFO_USERID")]
    [StringLength(15)]
    [Unicode(false)]
    public string? UserinfoUserid { get; set; }

    [ForeignKey("UserinfoUserid")]
    [InverseProperty("VocinfoComments")]
    public virtual Userinfo? UserinfoUser { get; set; }

    [ForeignKey("VocinfoId")]
    [InverseProperty("VocinfoComments")]
    public virtual Vocinfo? Vocinfo { get; set; }
}
