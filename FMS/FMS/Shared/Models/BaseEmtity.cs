using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS.Shared.Models
{
    public class BaseEmtity
    {
        public DateTime? CreateAt { get; set; }
        public string? CreateUser { get; set; }
        public DateTime? UpdateAt { get; set; }
        public string UpdateUser { get; set; } = string.Empty;
        public bool IsDeleted { get; set; }
        public string? DeleteUser { get; set; }
    }
}
