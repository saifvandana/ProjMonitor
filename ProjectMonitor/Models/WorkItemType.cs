using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class WorkItemType
    {
		public WorkItemType()
		{
			WorkItemMonitor = new HashSet<WorkItemMonitor>();
		}
		public int Id { get; set; }
		public DateTime AlimTarihi { get; set; }
		public string AlinanKisi { get; set; }
		public string TeslimAlan { get; set; }
		public string Marka { get; set; }
		public int TeslimAlinanAdet { get; set; }
		public int WorkItemsId { get; set; }

		public WorkItems WorkItems { get; set; }

		public ICollection<WorkItemMonitor> WorkItemMonitor { get; set; }
	}
}
