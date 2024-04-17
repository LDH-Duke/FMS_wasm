using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

/// <summary>
/// 공간 테이블
/// </summary>
[Table("LocationInfo")]
public partial class LocationInfo
{
    /// <summary>
    /// 자동 증가값
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 공간 명칭
    /// </summary>
    [StringLength(35)]
    [Unicode(false)]
    [Required(ErrorMessage = "공간 명칭을 입력해주세요.")]
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
    /// [외래키] 층 테이블 - 자동증가값
    /// </summary>
    [Column("FloorInfo_Id")]
    public int? FloorInfoId { get; set; }

    [InverseProperty("LocationInfo")]
    public virtual ICollection<DeviceInfo> DeviceInfos { get; set; } = new List<DeviceInfo>();

    [ForeignKey("FloorInfoId")]
    [InverseProperty("LocationInfos")]
    public virtual FloorInfo? FloorInfo { get; set; }
}
