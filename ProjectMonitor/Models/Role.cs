using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectMonitor.Models
{
    public class Role
    {
		public Role()
		{
			Users = new HashSet<User>();
		}
		
        public int Id { get; set; }

        [Display(Name = "Rol Adı")]
        public string Name { get; set; }

        [Display(Name = "Listede Göster")]
        public bool ShowInList { get; set; }

        public virtual ICollection<User> Users { get; set; }
	    public List<RoleOperation> RoleOperations { get; set; }

		public static implicit operator Role(SelectList v)
		{
			throw new NotImplementedException();
		}
	}
}
