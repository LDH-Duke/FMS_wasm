using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FMS.Shared.Models;

/// <summary>
/// 사용자 테이블
/// </summary>
[Table("UserInfo")]
public partial class UserInfo
{
    /// <summary>
    /// 자동 증가값
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// 사용자 ID
    /// </summary>
    [Key]
    [StringLength(15)]
    [Unicode(false)]
    [Required(ErrorMessage = "아이디를 입력해주세요")]
    public string UserId { get; set; } = null!;

    /// <summary>
    /// 비밀번호
    /// </summary>
    [StringLength(30)]
    [Unicode(false)]
    [Required(ErrorMessage = "비밃런호를 입력해주세요")]
    public string Password { get; set; } = null!;

    /// <summary>
    /// 관리자 여부 
    /// </summary>
    public bool? IsAdmin { get; set; } = false;

    /// <summary>
    /// 건물정보
    /// </summary>
    [Column("Perm_Place")]
    public bool? PermPlace { get; set; } = false;

    /// <summary>
    /// 장비관리
    /// </summary>
    [Column("Perm_Device")]
    public bool? PermDevice { get; set; } = false;

    /// <summary>
    /// 자재관리
    /// </summary>
    [Column("Perm_Material")]
    public bool? PermMaterial { get; set; } = false;

    /// <summary>
    /// 에너지 관리
    /// </summary>
    [Column("Perm_Energy")]
    public bool? PermEnergy { get; set; } = false;

    /// <summary>
    /// 행정관리
    /// </summary>
    [Column("Perm_Adm")]
    public bool? PermAdm { get; set; } = false;

    /// <summary>
    /// 업체관리
    /// </summary>
    [Column("Perm_Comp")]
    public bool? PermComp { get; set; } = false;

    /// <summary>
    /// rhdtkrhksfl
    /// </summary>
    [Column("Perm_Const")]
    public bool? PermConst { get; set; } = false;

    /// <summary>
    /// 민원관리
    /// </summary>
    [Column("Perm_Claim")]
    public bool? PermClaim { get; set; } = false;

    /// <summary>
    /// 시스템 연동
    /// </summary>
    [Column("Perm_Sys")]
    public bool? PermSys { get; set; } = false;

    /// <summary>
    /// 입퇴직관리
    /// </summary>
    [Column("Perm_Imployee")]
    public bool? PermImployee { get; set; } = false;

    /// <summary>
    /// 법정점검
    /// </summary>
    [Column("Perm_lawck")]
    public bool? PermLawck { get; set; } = false;

    /// <summary>
    /// 법정교육
    /// </summary>
    [Column("Perm_lawedu")]
    public bool? PermLawedu { get; set; } = false;

    /// <summary>
    /// 생성일자
    /// </summary>
    [Column("CreateDT", TypeName = "datetime")]
    public DateTime? CreateDt { get; set; } = DateTime.Now;

    /// <summary>
    /// 수정 일자
    /// </summary>
    [Column("UpdateDT", TypeName = "datetime")]
    public DateTime? UpdateDt { get; set; }

    [Column("PlaceInfo_Code")]
    [StringLength(25)]
    [Unicode(false)]
    public string? PlaceInfoCode { get; set; }

    [ForeignKey("PlaceInfoCode")]
    [InverseProperty("UserInfos")]
    public virtual PlaceInfo? PlaceInfoCodeNavigation { get; set; }
}
