using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class Results
    {
		public Results()
		{
			Projects = new HashSet<Projects>();
		}
		public int Id { get; set; }
		public int SampleExtractionId { get; set; }
		public string NanogramDegeri { get; set; }
		public string TeslimAlan { get; set; }
		public bool TespitDegeri1 { get; set; }
		public bool TespitDegeri2 { get; set; }
		public bool TespitDegeri3 { get; set; }
		public bool TespitDegeri4 { get; set; }
		public bool TespitDegeri5 { get; set; }
		public bool TespitDegeri6 { get; set; }
		public bool TespitDegeri7 { get; set; }
		public bool TespitDegeri8 { get; set; }
		public bool TespitDegeri9 { get; set; }
		public string GorselLinki { get; set; } 
		public bool Onay { get; set; }

		public SampleExtraction Sample { get; set; }

		public ICollection<Projects> Projects { get; set; }
	}
}
