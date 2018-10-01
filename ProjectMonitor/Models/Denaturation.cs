using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
	public partial class Denaturation
	{
		public Denaturation()
		{
			PcrProcess = new HashSet<PcrProcess>();
		}
		public int Id { get; set; }
		public int Temperature { get; set; }
		public int Duration { get; set; }
		public string Cycles { get; set; }

		public ICollection<PcrProcess> PcrProcess { get; set; }
	}
}
