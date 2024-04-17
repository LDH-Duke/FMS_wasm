using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Shared.Entity;

public class UserInfo
{
    public int Id { get; set; }
    [Required(ErrorMessage = "아이디를 입력해주세요")]
    public string UserId { get; set; } = null!;

    [Required(ErrorMessage = "비밀번호를 입력해주세요")]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "이름를 입력해주세요")]
    public string Name { get; set; }

    [Required(ErrorMessage = "이메일를 입력해주세요")]
    public string Email { get; set; }

    [Required(ErrorMessage = "전화번호를 입력해주세요")]
    public string Phone { get; set; }

    public bool? IsAdmin { get; set; }

    public bool? PermPlace { get; set; }

    public bool? PermDevice { get; set; }

    public bool? PermMaterial { get; set; }

    public bool? PermEnergy { get; set; }

    public bool? PermAdm { get; set; }

    public bool? PermComp { get; set; }

    public bool? PermConst { get; set; }

    public bool? PermClaim { get; set; }

    public bool? PermSys { get; set; }

    public bool? PermImployee { get; set; }

    public bool? PermLawck { get; set; }

    public bool? PermLawedu { get; set; }

    public DateTime? CreateDt { get; set; }

    public DateTime? UpdateDt { get; set; }

    public string? PlaceInfoCode { get; set; }

    public virtual PlaceInfo? PlaceInfoCodeNavigation { get; set; }
}
