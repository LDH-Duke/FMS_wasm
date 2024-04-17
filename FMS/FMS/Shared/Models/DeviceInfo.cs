using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Shared.Models;

/// <summary>
/// 장비 테이블
/// </summary>
[Table("DeviceInfo")]
public partial class DeviceInfo
{
    /// <summary>
    /// 자동 증가값
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 장비 명칭
    /// </summary>
    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "장비명칭을 입력해주세요")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 생성 일자
    /// </summary>
    [Column("CreateDT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; } = DateTime.Now;

    /// <summary>
    /// 수정 일자
    /// </summary>
    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    /// <summary>
    /// [외래키] 공간 테이블 - 자동증가값
    /// </summary>
    [Column("LocationInfo_Id")]
    public int? LocationInfoId { get; set; }

    [ForeignKey("LocationInfoId")]
    [InverseProperty("DeviceInfos")]
    public virtual LocationInfo? LocationInfo { get; set; }
}
