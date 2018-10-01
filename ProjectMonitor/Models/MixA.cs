using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class MixA
    {
		public MixA()
		{
			PcrProcess = new HashSet<PcrProcess>();
		}
		public int Id { get; set; }
		public string Kod { get; set; }
		public int Hacim { get; set; }

		public ICollection<PcrProcess> PcrProcess { get; set; }
	}
}
