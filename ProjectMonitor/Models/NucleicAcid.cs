using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
	public partial class NucleicAcid
	{
		public NucleicAcid()
		{
			PcrProcess = new HashSet<PcrProcess>();
		}
		public int Id { get; set; }
		public string Kod { get; set; }
		public int Hacim { get; set; }
		public string Sonuc { get; set; }

		public ICollection<PcrProcess> PcrProcess { get; set; }
	}
}
