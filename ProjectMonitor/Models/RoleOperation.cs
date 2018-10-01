using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public class RoleOperation
    {
		public int RoleId { get; set; }
		public Role Role { get; set; }

		public int OperationId { get; set; }
		public Operation Operation { get; set; }
	}
}
