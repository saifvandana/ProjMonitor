using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
	public partial class OligoNucleotideMixB
	{
		public OligoNucleotideMixB()
		{
			OligonucleotideInfo = new HashSet<OligonucleotideInfo>();
		}

		public int Id { get; set; }
		public string MixBCode { get; set; }
		public string Aciklama { get; set; }
		public DateTime HazirlamaTarihi { get; set; }

		public ICollection<OligonucleotideInfo> OligonucleotideInfo { get; set; }
	}
}
