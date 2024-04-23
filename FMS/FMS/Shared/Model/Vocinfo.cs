using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("VOCINFO")]
public partial class Vocinfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("TITLE")]
    [StringLength(30)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Column("CONTENT")]
    [Unicode(false)]
    public string Content { get; set; } = null!;

    [Column("STATUS")]
    public int? Status { get; set; }

    [Column("REPLY_YN")]
    public bool? ReplyYn { get; set; }

    [Column("PHONENUMBER")]
    [StringLength(20)]
    [Unicode(false)]
    public string? Phonenumber { get; set; }

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

    [InverseProperty("Vocinfo")]
    public virtual ICollection<Alarminfo> Alarminfos { get; set; } = new List<Alarminfo>();

    [InverseProperty("Vocinfo")]
    public virtual ICollection<VocinfoComment> VocinfoComments { get; set; } = new List<VocinfoComment>();
}
