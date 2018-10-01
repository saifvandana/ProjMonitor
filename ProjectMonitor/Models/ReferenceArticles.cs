using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class ReferenceArticles
    {
		public ReferenceArticles()
		{
			ProjectResearchPlan = new HashSet<ProjectResearchPlan>();
		}
		public int Id { get; set; }
		public string ReferansMakaleler { get; set; }

		public ICollection<ProjectResearchPlan> ProjectResearchPlan { get; set; }
	}
}
