using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class EmployeeRoles
    {
		public EmployeeRoles()
		{
			Employees = new HashSet<Employees>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public int RoleLevel { get; set; }
		public bool CanAssignTask { get; set; }

		public ICollection<Employees> Employees { get; set; }
	}
}
