using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectMonitor.Models
{
    public class User
    {
        public long Id { get; set; }

        [Required]
        [StringLength(11)]
        [Display(Name = "TC Kimlik No")]
        public string IdentityNumber { get; set; }

        public string PasswordHashed { get; set; }
        public string PasswordHashedSalt { get; set; }
        
        [Required]
        [StringLength(50)]
        [Display(Name = "Ad")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Soyad")]
        public string LastName { get; set; }
        
        [Display(Name = "Ad Soyad")]
        [StringLength(50)]
        public string FullName
        {
            get => Name + " " + LastName;
            set
            {
                if (value == null) throw new ArgumentNullException(nameof(value));
            }
        }

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
        
        public virtual Role Role { get; set; }
    }
}
