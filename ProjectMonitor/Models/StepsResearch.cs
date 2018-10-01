using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class StepsResearch
    {
		public StepsResearch()
		{
			ProjectResearchPlan = new HashSet<ProjectResearchPlan>();
		}
		public int Id { get; set; }
		public string Metodlar { get; set; }
		public string Referans { get; set; }

		public ICollection<ProjectResearchPlan> ProjectResearchPlan { get; set; }
	}
}
