using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

/// <summary>
/// 건물 테이블
/// </summary>
[Table("PlantInfo")]
public partial class PlantInfo
{
    /// <summary>
    /// 자동 증가값
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 건물 코드
    /// </summary>
    [Key]
    [StringLength(25)]
    [Unicode(false)]
    [Required(ErrorMessage = "건물코드를 입력해주세요")]
    public string Code { get; set; } = null!;

    /// <summary>
    /// 건물명
    /// </summary>
    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "건물명을 입력해주세요")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 건물 주소
    /// </summary>
    [StringLength(255)]
    [Unicode(false)]
    public string? Address { get; set; }

    /// <summary>
    /// 연 면적
    /// </summary>
    public double? GrossFloorArea { get; set; }

    /// <summary>
    /// 대지면적
    /// </summary>
    public double? LandArea { get; set; }

    /// <summary>
    /// 건축면적
    /// </summary>
    public double? BuildingArea { get; set; }

    /// <summary>
    /// 생성일자
    /// </summary>
    [Column("CreateDT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; } = DateTime.Now;

    /// <summary>
    /// 수정일자
    /// </summary>
    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    /// <summary>
    /// [외래키] 사업장테이블 - 사업장코드
    /// </summary>
    [Column("PlaceInfo_Code")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PlaceInfoCode { get; set; }

    [InverseProperty("PlantInfoCodeNavigation")]
    public virtual ICollection<FloorInfo> FloorInfos { get; set; } = new List<FloorInfo>();

    [ForeignKey("PlaceInfoCode")]
    [InverseProperty("PlantInfos")]
    public virtual PlaceInfo? PlaceInfoCodeNavigation { get; set; }
}
