using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

[Table("VocInfo")]
public partial class VocInfo
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Title { get; set; } = null!;

    [Unicode(false)]
    public string Content { get; set; } = null!;

    public int? Status { get; set; }

    [Column("ReplyYN")]
    public bool? ReplyYn { get; set; }

    [Column("CreateDT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; }

    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [InverseProperty("VocInfo")]
    public virtual ICollection<AlarmInfo> AlarmInfos { get; set; } = new List<AlarmInfo>();

    [InverseProperty("VocInfo")]
    public virtual ICollection<VocInfoComment> VocInfoComments { get; set; } = new List<VocInfoComment>();
}
