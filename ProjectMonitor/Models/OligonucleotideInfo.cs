using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class OligonucleotideInfo
    {
		public OligonucleotideInfo()
		{
			Projects = new HashSet<Projects>();
		}
		public int Id { get; set; }
		public int OligoNucleotideId { get; set; }
		public int OligoNucleotideMixBId { get; set; }

		public OligoNucleotide OligoNucleotide { get; set; }
		public OligoNucleotideMixB OligoNucleotideMixB { get; set; }
		public ICollection<Projects> Projects { get; set; }
	}
}
