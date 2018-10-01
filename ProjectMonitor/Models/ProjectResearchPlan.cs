using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class ProjectResearchPlan
    {
		public ProjectResearchPlan()
		{
			Projects = new HashSet<Projects>();
		}

		public int Id { get; set; }
		public int ReferenceArticlesId { get; set; }
		public int ProjectStepsId { get; set; }
		public int StepsResearchId { get; set; }
		public int WorkItemsId { get; set; }

		public ReferenceArticles ReferenceArticles { get; set; }
		public ProjectSteps ProjectSteps { get; set; }
		public StepsResearch StepsResearch { get; set; }
		public WorkItems WorkItems { get; set; }

		public ICollection<Projects> Projects { get; set; }
	}
}
