using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProjectMonitor.Models;

namespace ProjectMonitor.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "TC Kimlik No")]
        public string IdentityNumber { get; set; }

        [DataType(DataType.Password)]
        [Required]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "E-Posta")]
        public string Email { get; set; }

        [Display(Name = "Rol")]
        public short RoleId { get; set; }

        [Display(Name = "Aktif mi")]
        public bool IsActive { get; set; }

        [StringLength(30)]
        [Display(Name = "Cep Telefonu")]
        public string Phone { get; set; }

        [Display(Name = "Rol")]
		public virtual Role Role { get; set; }
		public object Users { get; internal set; }
	}
}
