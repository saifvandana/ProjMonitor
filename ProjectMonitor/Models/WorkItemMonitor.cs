using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
	public partial class WorkItemMonitor
	{
		public WorkItemMonitor()
		{
			Projects = new HashSet<Projects>();
		}
		public int Id { get; set; }
		public int WorkItemTypeId { get; set; }
		public int WorkItemUsed { get; set; }
		public int WorkItemDelivered { get; set; }
		public int WorkItemRemaining { get; set; }

		public WorkItemType WorkItemType { get; set; }
		

		public ICollection<Projects> Projects { get; set; }
	}
}
