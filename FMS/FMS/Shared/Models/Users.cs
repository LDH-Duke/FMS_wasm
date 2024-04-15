using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Shared.Models
{
    public class Users : BaseEmtity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "아이디를 입력해주세요")]
        public string? Account { get; set; }

        [Required(ErrorMessage = "비밀번호를 입력해주세요")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "이름을 입력해주세요")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "이메일을 입력해주세요")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "전화번호를 입력해주세요")]
        public string? PhoneNumber { get; set; }
    }
}
