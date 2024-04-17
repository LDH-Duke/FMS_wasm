using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

/// <summary>
/// 층 테이블
/// </summary>
[Table("FloorInfo")]
public partial class FloorInfo
{
    /// <summary>
    /// 자동 증가값
    /// </summary>
    [Key]
    public int Id { get; set; }

    /// <summary>
    /// 층 명칭
    /// </summary>
    [StringLength(10)]
    [Unicode(false)]
    [Required(ErrorMessage = "층 명칭을 입력해주세요")]
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
    /// [외래키] 건물 테이블 - 건물코드
    /// </summary>
    [Column("PlantInfo_Code")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PlantInfoCode { get; set; }

    [InverseProperty("FloorInfo")]
    public virtual ICollection<LocationInfo> LocationInfos { get; set; } = new List<LocationInfo>();

    [ForeignKey("PlantInfoCode")]
    [InverseProperty("FloorInfos")]
    public virtual PlantInfo? PlantInfoCodeNavigation { get; set; }
}
