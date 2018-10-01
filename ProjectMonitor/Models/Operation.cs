using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectMonitor.Models
{
    public class Operation
    {
		
        public int Id { get; set; }

        [Display(Name = "Modül Adı")]
        public string Controller { get; set; }

        [Display(Name = "Eylem Adı")]
        public string Action { get; set; }

        [Display(Name = "Açıklama")]
		public string Name { get; set; }

        [Display(Name = "Aktif mi")]
        public bool IsActive { get; set; }

        public virtual ICollection<MenuItem> MenuItems { get; set; }
		public List<RoleOperation> RoleOperations { get; set; }
	}
}
