using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectMonitor.Models
{
    public partial class ResultSlip
    {
		public ResultSlip()
		{
			PcrProcess = new HashSet<PcrProcess>();
		}
		public int Id { get; set; }
		public string Name { get; set; }
		public string Link { get; set; }

		public ICollection<PcrProcess> PcrProcess { get; set; }
	}
}
