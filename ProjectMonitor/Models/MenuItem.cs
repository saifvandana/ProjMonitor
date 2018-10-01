using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectMonitor.Models
{
    public class MenuItem
    {
        public short Id { get; set; }
        [Display(Name = "Menü Adı")]
        public string Name { get; set; }
        [Display(Name = "Üst Menüsü (varsa)")]
        public short? ParentId { get; set; }
        [Display(Name = "Eylem Adı")]
        public short OperationId { get; set; }
        [Display(Name = "Sıra Numarası")]
        public short OrderNumber { get; set; }
        [Display(Name = "Menü İkon/Resim")]
        public string Icon { get; set; }
        [Display(Name = "Durumu (Aktif/Pasif)")]
        public bool IsActive { get; set; }

        public virtual ICollection<MenuItem> MenuChildrenItems { get; set; }

        public virtual MenuItem ChildItem { get; set; }
        public virtual Operation Operation { get; set; }

    }
}
