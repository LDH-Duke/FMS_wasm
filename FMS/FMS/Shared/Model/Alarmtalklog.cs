using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Model;

[Table("ALARMTALKLOG")]
public partial class Alarmtalklog
{
    [Key]
    [Column("ID")]
    public int Id { get; set; }

    [Column("RESULT")]
    [StringLength(100)]
    [Unicode(false)]
    public string Result { get; set; } = null!;

    [Column("RECEIVE_PHONENUMBER")]
    [StringLength(20)]
    [Unicode(false)]
    public string? ReceivePhonenumber { get; set; }

    [Column("SENDER_PHONENUMBER")]
    [StringLength(20)]
    [Unicode(false)]
    public string? SenderPhonenumber { get; set; }

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
}
