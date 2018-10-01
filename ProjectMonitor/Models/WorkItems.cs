using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
	public partial class WorkItems
	{
		public WorkItems()
		{
			ProjectResearchPlan = new HashSet<ProjectResearchPlan>();
			WorkItemType = new HashSet<WorkItemType>();
			//WorkItemUsed = new HashSet<WorkItemUsed>();
			//WorkItemDelivered = new HashSet<WorkItemDelivered>();
			//WorkItemRemaining = new HashSet<WorkItemRemaining>();
		}
		public int Id { get; set; }
		public string ItemName { get; set; }
		public string Birimi { get; set; }
		public int Adedi { get; set; }
			
		public ICollection<ProjectResearchPlan> ProjectResearchPlan { get; set; }
		public ICollection<WorkItemType> WorkItemType { get; set; }
		//public ICollection<WorkItemUsed> WorkItemUsed { get; set; }
		//public ICollection<WorkItemDelivered> WorkItemDelivered { get; set; }
		//public ICollection<WorkItemRemaining> WorkItemRemaining { get; set; }
	}
}
