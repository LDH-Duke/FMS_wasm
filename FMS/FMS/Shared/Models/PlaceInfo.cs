using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

/// <summary>
/// 사업장 테이블
/// </summary>
[Table("PlaceInfo")]
public partial class PlaceInfo
{
    /// <summary>
    /// 자동 증가값
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 사업장 코드
    /// </summary>
    [Key]
    [StringLength(25)]
    [Unicode(false)]
    [Required(ErrorMessage = "사업장코드를 입력해주세요.")]
    public string Code { get; set; } = null!;

    /// <summary>
    /// 사업장 명
    /// </summary>
    [StringLength(255)]
    [Unicode(false)]
    [Required(ErrorMessage = "사업장명을 입력해주세요")]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 비고
    /// </summary>
    [StringLength(20)]
    [Unicode(false)]
    public string? Note { get; set; }

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

    [InverseProperty("PlaceInfoCodeNavigation")]
    public virtual ICollection<PlantInfo> PlantInfos { get; set; } = new List<PlantInfo>();

    [InverseProperty("PlaceInfoCodeNavigation")]
    public virtual ICollection<UserInfo> UserInfos { get; set; } = new List<UserInfo>();
}
